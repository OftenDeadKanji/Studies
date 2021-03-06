#include "common.h"
#include "renderwidget.h"
#include "vertexttypes.h"

typedef Vertex_Pos VertexType;
const float g_ClearColor[] = {100.f/255.f, 149.f/255.f, 237.f/255.f, 1.f};

#pragma region ctors, dtor

RenderWidget::RenderWidget(float width, float height, HWND winId) :
	m_pDevice(0), m_pDebugger(0), m_pContext(0), m_pSwapChain(0), m_pRenderTargetView(0),	
	m_pRastState(0), m_pVertexShader_Pos(0), m_pPixelShader_Pos(0), m_pInputLayout(0), m_pVertexBuffer(0), m_pIndexBuffer(0),
	m_NumOfIndices(0), m_NumOfVertices(0), m_UseIndexBuffer(true), m_CameraDataDirty(false)
{
	dxInitialize(width, height, winId, true);
	m_PerfCounter.start();
}

RenderWidget::~RenderWidget()
{
	//dx clean-up:
	//1. pipeline may keep references to some objects that have been bound to it - make sure they are released
	m_pContext->ClearState();
	
	//2. release the objects used by the application
	dxReleaseCOMRefs();
	SAFE_RELEASE(m_pSwapChain);
	SAFE_RELEASE(m_pContext);
	SAFE_RELEASE(m_pDevice);

	if(m_pDebugger)
	{
		m_pDebugger->ReportLiveDeviceObjects(D3D11_RLDO_DETAIL);		//D3D11_RLDO_DETAIL//D3D11_RLDO_SUMMARY
		SAFE_RELEASE(m_pDebugger);
	}
}

#pragma endregion

#pragma region dx

void RenderWidget::dxInitialize(float width, float height, HWND winId, bool debug)
{
	HRESULT hr; 
	DXGI_SWAP_CHAIN_DESC swapChainDesc;
	
	swapChainDesc = DXGI_SWAP_CHAIN_DESC();		//reset the struct

	swapChainDesc.BufferCount = 1;
	swapChainDesc.BufferDesc.Width = width;
	swapChainDesc.BufferDesc.Height = height;
	swapChainDesc.BufferDesc.Format = DXGI_FORMAT_R8G8B8A8_UNORM;
	swapChainDesc.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
	swapChainDesc.SampleDesc.Count = 1;
	swapChainDesc.SampleDesc.Quality = 0;
	swapChainDesc.SwapEffect = DXGI_SWAP_EFFECT_DISCARD;
	swapChainDesc.Windowed = true;
	swapChainDesc.OutputWindow = winId;
	swapChainDesc.BufferDesc.RefreshRate.Numerator = 0;
	swapChainDesc.BufferDesc.RefreshRate.Denominator = 1;
	UINT flags = debug ? D3D11_CREATE_DEVICE_DEBUG : 0;	

	//only D3D 9.1 features are used in this lab -> no need to target "better" video cards
	D3D_FEATURE_LEVEL featureLevels[] = { D3D_FEATURE_LEVEL_9_1 };

	//http://msdn.microsoft.com/en-us/library/windows/desktop/ff476083%28v=vs.85%29.aspx
	//pAdapter: pass NULL to use the default adapter, which is the first adapter enumerated by IDXGIFactory1::EnumAdapters.
	//pFeatureLevels: A pointer to an array of D3D_FEATURE_LEVELs, which determine the order of feature levels to attempt to create. If NULL => 11.0-10.1-10.0-9.3-9.2-9.1
	hr = D3D11CreateDeviceAndSwapChain(nullptr, D3D_DRIVER_TYPE_HARDWARE, nullptr, flags, featureLevels, 1, D3D11_SDK_VERSION, &swapChainDesc, &m_pSwapChain, &m_pDevice, nullptr, &m_pContext);
	assert(!FAILED(hr));


	if(debug)
	{
		//ID3D11Debug interface is used for various debugging ops and is retrieved using the COM query interface techniques.
		//It also causes complete error/warning msgs to be output at runtime and enables memory leak detection as well.
		//D3D11_CREATE_DEVICE_DEBUG device creation flag must be set to enable access to the debug interface.
		hr = m_pDevice->QueryInterface(__uuidof(ID3D11Debug), (void **)&m_pDebugger);
		assert(!FAILED(hr));
	}

	dxReset(width, height);
}

void RenderWidget::dxCreateResourcesAndStateObjectsAndShaders()
{
	//create resources	
	dxCreateVertexBuffers();
	dxCreateIndexBuffers();

	//create resource views
	dxCreateRenderTargetViews();	

	//create shaders, input layouts and state objects
	ID3DBlob *vsBlob = 0, *psBlob = 0;
	dxCreateShaderObjects(vsBlob, psBlob);
	dxCreateInputLayouts(vsBlob);				//note: uses vsBlob to verify if input layout is consistent with vertex shader code
	dxCreateRasterizerStates();
	SAFE_RELEASE(vsBlob);
	SAFE_RELEASE(psBlob);

	//store COM objects for which the app holds references (convenience)
	m_vToBeReleased.push_back(m_pVertexBuffer);
	m_vToBeReleased.push_back(m_pIndexBuffer);
	m_vToBeReleased.push_back(m_pRenderTargetView);
	m_vToBeReleased.push_back(m_pVertexShader_Pos);
	m_vToBeReleased.push_back(m_pPixelShader_Pos);
	m_vToBeReleased.push_back(m_pInputLayout);	
	m_vToBeReleased.push_back(m_pRastState);	
}

void RenderWidget::dxRender()
{
	updateFPS();
	
	dxConfigureInputAssemblerStage();
	dxConfigureVertexShaderStage();
	dxConfigureRasterizerStage();
	dxConfigurePixelShaderStage();
	dxConfigureOutputMergerStage();
	
	//clear the RT	
	m_pContext->ClearRenderTargetView(m_pRenderTargetView, g_ClearColor);

	if(m_NumOfVertices)
	{
		//draw the geometry
		if(m_UseIndexBuffer && m_NumOfIndices)
			m_pContext->DrawIndexed(m_NumOfIndices, 0, 0);
		else		
			m_pContext->Draw(m_NumOfVertices, 0);
	}

	//all the rendering in the current frame has been completed => ..
	//.. => RT contents can be presented in the client area of the render window
	m_pSwapChain->Present(0, 0);
}

void RenderWidget::dxReset(float width, float height)
{
	dxReleaseCOMRefs();
	
	//http://msdn.microsoft.com/en-us/library/windows/desktop/bb174577%28v=vs.85%29.aspx
	//set this value to DXGI_FORMAT_UNKNOWN to preserve the existing format of the back buffer
	//this "preserve trick" works the same for BufferCount, Width and Height is we set them to zeros
	//howevere, PIX does not tolerate the "preserve trick" so we explicitly set the parameters
	m_pSwapChain->ResizeBuffers(1, width, height, DXGI_FORMAT_R8G8B8A8_UNORM, 0);
	
	dxSetupViewPorts(width, height);
	dxCreateResourcesAndStateObjectsAndShaders();
}

void RenderWidget::dxReleaseCOMRefs()
{
	//release all the COM objects for which the app held references
	for(std::vector<IUnknown *>::iterator it = m_vToBeReleased.begin(); it != m_vToBeReleased.end(); it++)
		SAFE_RELEASE(*it);

	m_vToBeReleased.clear();
}

void RenderWidget::dxSetupViewPorts(float width, float height)
{
	//configure the viewport
	m_ViewPort = D3D11_VIEWPORT();		//reset the struct
	m_ViewPort.MinDepth = 0.0f;
	m_ViewPort.MaxDepth = 1.0f;
	m_ViewPort.TopLeftX = 0;
	m_ViewPort.TopLeftY = 0;
	m_ViewPort.Width = width;
	m_ViewPort.Height = height;
}

void RenderWidget::dxCreateRenderTargetViews()
{
	HRESULT hr;

	//http://msdn.microsoft.com/en-us/library/windows/desktop/bb174570%28v=vs.85%29.aspx
	//if the swap chain's swap effect is DXGI_SWAP_EFFECT_DISCARD, this method can only access the first buffer; for this situation, set the index to zero.
	ID3D11Texture2D *pSwapChainBuffer = 0;
	hr = m_pSwapChain->GetBuffer(0, __uuidof(ID3D11Texture2D), (void **)&pSwapChainBuffer);			//temporarily grab the swapchain buffer ptr to create an RTV
	assert(!FAILED(hr));

	hr = m_pDevice->CreateRenderTargetView(pSwapChainBuffer, nullptr, &m_pRenderTargetView);			//RTV created -> swapchain buffer ptr/address no longer needed by the app -> release
	assert(!FAILED(hr));
	SAFE_RELEASE(pSwapChainBuffer);		
}

void RenderWidget::dxCreateShaderObjects(ID3DBlob *&vsBlob, ID3DBlob *&psBlob)
{
	HRESULT hr;

	//http://msdn.microsoft.com/en-us/library/windows/desktop/jj215820%28v=vs.85%29.aspx
	//about specifying shader targets for the compiler

	//compile vertex shader
	vsBlob = nullptr;
	ShaderCompiler::Compile("../pwag01/pos.fx", "VSMain", "vs_4_0_level_9_1", &vsBlob);			//simple VS_2.0-like shader

	//create vertex shader object
	hr = m_pDevice->CreateVertexShader(vsBlob->GetBufferPointer(), vsBlob->GetBufferSize(), nullptr, &m_pVertexShader_Pos);
	assert(!FAILED(hr));

	//compile pixel shader
	psBlob = nullptr;
	ShaderCompiler::Compile("../pwag01/pos.fx", "PSMain", "ps_4_0_level_9_1", &psBlob);			//simple PS_2.0-like shader	

	//create pixel shader object
	hr = m_pDevice->CreatePixelShader(psBlob->GetBufferPointer(), psBlob->GetBufferSize(), nullptr, &m_pPixelShader_Pos);
	assert(!FAILED(hr));	
}

void RenderWidget::dxCreateInputLayouts(ID3DBlob *vsBlob)
{
	HRESULT hr;

	//define input layout for the vertex buffer
	std::vector<D3D11_INPUT_ELEMENT_DESC> vertexBufferElements;
	D3D11_INPUT_ELEMENT_DESC posElement = {"POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 0, D3D11_INPUT_PER_VERTEX_DATA, 0};
	vertexBufferElements.push_back(posElement);

	//create the vertex buffer layout
	hr = m_pDevice->CreateInputLayout(&vertexBufferElements[0], vertexBufferElements.size(), vsBlob->GetBufferPointer(), vsBlob->GetBufferSize(), &m_pInputLayout);
	assert(!FAILED(hr));
}

void RenderWidget::dxCreateVertexBuffers()
{
	HRESULT hr;
	D3D11_BUFFER_DESC buffDesc;				//struct used to describe/config the vertex and index buffers	
	D3D11_SUBRESOURCE_DATA buffInitData;	//struct used to initialize the vertex and index buffers	

	//init the vertices
	std::vector<VertexType> vertices;	
	//clip space rectangle (actually it is NDC already, since w is assumed to be 1.0 -> see VS)
	//...
	vertices.push_back(VertexType(-0.5f, -0.5f, 0.5f));
	vertices.push_back(VertexType(0.5f, -0.5f, 0.5f));
	vertices.push_back(VertexType(-0.5f, 0.5f, 0.5f));

	//vertices.push_back(VertexType(0.5f, -0.5f, 0.5f));
	//vertices.push_back(VertexType(-0.5f, 0.5f, 0.5f));
	vertices.push_back(VertexType(0.5f, 0.5f, 0.5f));

	m_NumOfVertices = vertices.size();

	if(m_NumOfVertices)
	{
		//define the vertex buffer config
		buffDesc = D3D11_BUFFER_DESC();			//reset the struct
		buffDesc.ByteWidth = vertices.size() * sizeof(VertexType);
		buffDesc.BindFlags = D3D11_BIND_VERTEX_BUFFER;
		buffDesc.Usage = D3D11_USAGE_DEFAULT;
		buffDesc.CPUAccessFlags = 0;

		//set the init vertex data pointer
		buffInitData = D3D11_SUBRESOURCE_DATA();		//reset the struct	
		buffInitData.pSysMem = &vertices[0];

		//create the vertex buffer
		hr = m_pDevice->CreateBuffer(&buffDesc, &buffInitData, &m_pVertexBuffer);
		assert(!FAILED(hr));
	}
}

void RenderWidget::dxCreateIndexBuffers()
{
	HRESULT hr;
	D3D11_BUFFER_DESC buffDesc;				//struct used to describe/config the vertex and index buffers	
	D3D11_SUBRESOURCE_DATA buffInitData;	//struct used to initialize the vertex and index buffers	

	//init the indices
	std::vector<WORD> indices;
	//...
	indices.push_back(0);
	indices.push_back(1);
	indices.push_back(2);
	indices.push_back(1);
	indices.push_back(3);
	indices.push_back(2);

	m_NumOfIndices = indices.size();

	if(m_NumOfIndices)
	{
		//define the index buffer config
		buffDesc = D3D11_BUFFER_DESC();			//reset the struct
		buffDesc.ByteWidth = indices.size() * sizeof(WORD);
		buffDesc.BindFlags = D3D11_BIND_INDEX_BUFFER;
		buffDesc.Usage = D3D11_USAGE_DEFAULT;
		buffDesc.CPUAccessFlags = 0;

		//set the init index data pointer
		buffInitData = D3D11_SUBRESOURCE_DATA();		//reset the struct	
		buffInitData.pSysMem = &indices[0];

		//create the index buffer
		hr = m_pDevice->CreateBuffer(&buffDesc, &buffInitData, &m_pIndexBuffer);
		assert(!FAILED(hr));
	}
}

void RenderWidget::dxCreateRasterizerStates()
{
	HRESULT hr;
	D3D11_RASTERIZER_DESC rastDesc;			//struct used to initialize the rasterizer state

	//define the rasterizer state object config
	rastDesc = D3D11_RASTERIZER_DESC();		//reset struct
	
	rastDesc.AntialiasedLineEnable = false;
	rastDesc.CullMode = D3D11_CULL_BACK;		//use D3D11_CULL_BACK/FRONT to actually do any "backface" culling
	rastDesc.DepthBias = 0;
	rastDesc.DepthBiasClamp = 0.0f;
	rastDesc.DepthClipEnable = true;
	rastDesc.FillMode = D3D11_FILL_SOLID;
	//rastDesc.FillMode = D3D11_FILL_WIREFRAME;
	rastDesc.FrontCounterClockwise = true;
	rastDesc.MultisampleEnable = false;
	rastDesc.ScissorEnable = false;
	rastDesc.SlopeScaledDepthBias = 0.0f;

	//create the rasterizer state object
	hr = m_pDevice->CreateRasterizerState(&rastDesc, &m_pRastState);
	assert(!FAILED(hr));
}

void RenderWidget::dxConfigureInputAssemblerStage()
{
	//config the Input Assembler stage
	UINT stride = sizeof(VertexType);
	UINT offset = 0;
	m_pContext->IASetVertexBuffers(0, 1, &m_pVertexBuffer, &stride, &offset);
	m_pContext->IASetIndexBuffer(m_pIndexBuffer, DXGI_FORMAT_R16_UINT, 0);
	m_pContext->IASetInputLayout(m_pInputLayout);
	m_pContext->IASetPrimitiveTopology(D3D11_PRIMITIVE_TOPOLOGY_TRIANGLELIST);	
}

void RenderWidget::dxConfigureVertexShaderStage()
{
	//config the Vertex Shader stage
	m_pContext->VSSetShader(m_pVertexShader_Pos, nullptr, 0);

	//in more complex apps shader resources, samplers and const buffers would be set here
	//m_pContext->VSSetShaderResources(...)
	//m_pContext->VSSetSamplers(...)
	//m_pContext->VSSetConstantBuffers(...)
}

void RenderWidget::dxConfigureRasterizerStage()
{	
	//config the Rasterizer stage
	m_pContext->RSSetState(m_pRastState);
	m_pContext->RSSetViewports(1, &m_ViewPort);
}

void RenderWidget::dxConfigurePixelShaderStage()
{
	//config the Pixel Shader stage
	m_pContext->PSSetShader(m_pPixelShader_Pos, nullptr, 0);

	//in more complex apps shader resources, samplers and const buffers would be set here
	//m_pContext->PSSetShaderResources(...)
	//m_pContext->PSSetSamplers(...)
	//m_pContext->PSSetConstantBuffers(...)
}

void RenderWidget::dxConfigureOutputMergerStage()
{
	//config the Output Merger stage
	//http://msdn.microsoft.com/en-us/library/windows/desktop/ff476464%28v=vs.85%29.aspx
	//no depth-stencil target (view) is bound => no depth-stencil state either
	m_pContext->OMSetRenderTargets(1, &m_pRenderTargetView, 0);

	//in more complex apps depth-stencil state and blend state objects would be set here
	//m_pContext->OMSetDepthStencilState(...)
	//m_pContext->OMSetBlendState(...)
}

#pragma endregion

#pragma region aux

void RenderWidget::updateFPS()
{
	double elapsed = m_PerfCounter.stop();
	m_PerfCounter.start();

	static double msSinceLastFPSUpdate = 0.0, lastFrameDuration = 0.0;
	msSinceLastFPSUpdate += elapsed;

	if(elapsed != lastFrameDuration && elapsed != 0.0 && msSinceLastFPSUpdate >= 500.0)
	{
		lastFrameDuration = elapsed;
		msSinceLastFPSUpdate = 0.0;
	}
}

#pragma endregion
