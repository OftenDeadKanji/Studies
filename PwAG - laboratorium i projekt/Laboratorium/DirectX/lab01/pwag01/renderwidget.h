#ifndef RENDERWIDGET_H
#define RENDERWIDGET_H

#include "common.h"
#include "perfcounter.h"
#include "shadercompiler.h"


class RenderWidget
{
    
public:
	explicit RenderWidget(float width, float height, HWND winId);
    virtual ~RenderWidget();

	void setUseIndexBuffer(bool useIB) { m_UseIndexBuffer = useIB; }
	bool getUseIndexBuffer() { return m_UseIndexBuffer; }
	void dxRender();
private:

	void updateFPS();

	//dx related stuff
	void dxInitialize(float width, float height, HWND winId, bool debug = false);
	
	void dxReset(float width, float height);
	void dxCreateResourcesAndStateObjectsAndShaders();	
	void dxReleaseCOMRefs();

	void dxCreateRenderTargetViews();
	void dxSetupViewPorts(float width, float height);
	void dxCreateShaderObjects(ID3DBlob *&vsBlob, ID3DBlob *&psBlob);			//we need the vs blob to be used for layout init
	void dxCreateInputLayouts(ID3DBlob *vsBlob);
	void dxCreateVertexBuffers();
	void dxCreateIndexBuffers();
	void dxCreateRasterizerStates();

	void dxConfigureInputAssemblerStage();
	void dxConfigureVertexShaderStage();
	void dxConfigureRasterizerStage();
	void dxConfigurePixelShaderStage();
	void dxConfigureOutputMergerStage();

	//device, context, debugger
	ID3D11Device *m_pDevice;
	ID3D11Debug *m_pDebugger;
	ID3D11DeviceContext *m_pContext;

	//resources	
	IDXGISwapChain *m_pSwapChain;	
	ID3D11Buffer *m_pVertexBuffer;
	ID3D11Buffer *m_pIndexBuffer;

	//resource views
	ID3D11RenderTargetView *m_pRenderTargetView;	

	//ID3D11DeviceChild inheritants: "A device-child interface accesses data used by a device."
	//a. state objects for fixed-function stages (input layouts are sometimes included as state objects and sometimes referred to separately)
	ID3D11RasterizerState *m_pRastState;			//state object for RS
	ID3D11InputLayout * m_pInputLayout;				//input layout/state object for IA (but primitive topology must be set separately)
	//b. compiled shaders for programmable stages
	ID3D11VertexShader *m_pVertexShader_Pos;			//compiled shader for VS
	ID3D11PixelShader *m_pPixelShader_Pos;				//compiled shader for PS

	//vp config
	D3D11_VIEWPORT m_ViewPort;

	//misc
	std::vector<IUnknown *> m_vToBeReleased;
	bool m_CameraDataDirty, m_UseIndexBuffer;
	unsigned int m_NumOfIndices, m_NumOfVertices;
	PerfCounter m_PerfCounter;
	
};

#endif
