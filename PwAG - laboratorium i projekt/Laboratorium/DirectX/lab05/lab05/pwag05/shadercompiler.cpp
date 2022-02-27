#include "common.h"
#include "shadercompiler.h"


void ShaderCompiler::Compile(const std::string &filename, const std::string &entry, const std::string &sm, ID3DBlob **blob)
{
	HRESULT hr;
	DWORD flags = D3DCOMPILE_ENABLE_STRICTNESS | D3DCOMPILE_DEBUG;
	ID3DBlob *errBlob;
	
	std::ifstream stream(filename.c_str());
	if(!stream)
	{
		OutputDebugString(L"Shader file not found\n");
		stream.close();

		assert(0 && "Shader file not found");
	}

	std::string source(std::istreambuf_iterator<char>(stream), (std::istreambuf_iterator<char>()));
	stream.close();

	hr = D3DCompile(source.c_str(), source.size(), filename.c_str(), NULL, NULL, entry.c_str(), sm.c_str(), flags, 0, blob, &errBlob);

	if(FAILED(hr))
	{
		if(errBlob != NULL)
		{
			OutputDebugStringA((char *)errBlob->GetBufferPointer());
			errBlob->Release();
			errBlob = NULL;
		}

		assert(0 && "Shader compilation failed");
	}

	SAFE_RELEASE(errBlob);
}