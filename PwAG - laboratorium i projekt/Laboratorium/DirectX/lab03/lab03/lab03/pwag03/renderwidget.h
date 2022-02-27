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

	void setQuadPositionX(float x) { m_ObjPosX = x; m_ObjPosDataDirty = true; }
	void setQuadPositionY(float y) { m_ObjPosY = y; m_ObjPosDataDirty = true; }
	void setQuadPositionZ(float z) { m_ObjPosZ = z; m_ObjPosDataDirty = true; }
	void dxRender();

protected:
	//virtual void resizeEvent();
	//virtual void paintEvent();
	//virtual void wheelEvent();
	//virtual void mousePressEvent();
	//virtual void mouseReleaseEvent();
	//virtual void mouseMoveEvent();
    
private:

	void updateFPS();

	//dx related stuff
	void dxInitialize(float width, float height, HWND winId, bool debug = false);
	
	void dxReset(float width, float height);
	void dxCreateResourcesAndStateObjectsAndShaders(float width, float height);
	void dxReleaseCOMRefs();

	void dxCreateRenderTargetViews();
	void dxSetupViewPorts(float width, float height);
	void dxCreateShaderObjects(ID3DBlob *&vsBlob, ID3DBlob *&psBlob);			//we need the vs blob to be used for layout init
	void dxCreateInputLayouts(ID3DBlob *vsBlob);
	void dxCreateVertexBuffers();
	void dxCreateIndexBuffers();
	void dxCreateRasterizerStates();
	void dxCreateConstantBuffers(ID3DBlob *vsBlob, ID3DBlob *psBlob);
	void dxSetupViewAndProjection(float width, float height);
	void dxCreateTextures();
	void dxCreateShaderResourceViews();
	void dxCreateSamplerStates();

	void dxConfigureInputAssemblerStage();
	void dxConfigureVertexShaderStage(bool sceneConstantsOutdated = true, bool objectConstantsOutdated = true);
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
	ID3D11Buffer *m_pConstantBuffer_scene, *m_pConstantBuffer_object;
	ID3D11Texture2D *m_pTexture;

	//resource views
	ID3D11RenderTargetView *m_pRenderTargetView;
	ID3D11ShaderResourceView *m_pTextureSRV;

	//ID3D11DeviceChild inheritants: "A device-child interface accesses data used by a device."
	//a. state objects for fixed-function stages (input layouts are sometimes included as state objects and sometimes referred to separately)
	ID3D11RasterizerState *m_pRastState;			//state object for RS
	ID3D11InputLayout * m_pInputLayout;				//input layout/state object for IA (but primitive topology must be set separately)
	ID3D11SamplerState *m_pSamplerState;			//shader texture sampler config object
	//b. compiled shaders for programmable stages
	ID3D11VertexShader *m_pVertexShader;			//compiled shader for VS
	ID3D11PixelShader *m_pPixelShader;				//compiled shader for PS

	//vp config
	D3D11_VIEWPORT m_ViewPort;

	//view, projection things
	DirectX::SimpleMath::Matrix m_ProjectionMatrix, m_ViewMatrix, m_ViewProjectionMatrix;
	DirectX::SimpleMath::Vector3 m_CameraPosition, m_CameraTarget, m_CameraUp;

	//mouse stuff
	float m_MouseWheelMult, m_MouseMoveMult;

	//misc
	std::vector<IUnknown *> m_vToBeReleased;
	bool m_CameraDataDirty, m_ObjPosDataDirty;
	unsigned int m_NumOfIndices, m_NumOfVertices;
	PerfCounter m_PerfCounter;
	float m_ObjPosX, m_ObjPosY, m_ObjPosZ;
	
};

#endif
