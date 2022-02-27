#ifndef SHADER_COMPILER_H
#define SHADER_COMPILER_H

#include "common.h"

class ShaderCompiler
{
public:
	virtual ~ShaderCompiler() {}

	static void Compile(const std::string &filename, const std::string &entry, const std::string &sm, ID3DBlob **blob);

protected:
	ShaderCompiler() {}
};

#endif