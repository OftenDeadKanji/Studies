struct VSInput
{
	float3 position : POSITION0;
	float4 color : COLOR0;
};

struct VSOutput
{
	float4 clipPos : SV_POSITION;
	float4 color : COLOR;
};

cbuffer VSConstants
{
	float4x4 ViewProjMatrix; // float4x4 <=> matrix
};

cbuffer VSConstants1
{
	float4x4 worldMatrix; // float4x4 <=> matrix
};

VSOutput VSMain(in VSInput input)
{
	VSOutput output;

	output.clipPos = mul(mul(worldMatrix, ViewProjMatrix), float4(input.position.xyz, 1.0));

	output.color = input.color;
	return output;
}

typedef VSOutput PSInput;

float4 PSMain(PSInput input) : SV_TARGET //note: no parameters -> we could pass VSOutput but SV_Position is not used so params can be dropped
{
	return input.color;
}
