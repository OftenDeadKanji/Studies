struct VSInput
{
	float3 position : POSITION0;
};

struct VSOutput
{
	float4 clipPos : SV_POSITION;
};

VSOutput VSMain(in VSInput input)
{
	VSOutput output;

	output.clipPos = float4(input.position.xyz, 1.0);

	return output;
}

typedef VSOutput PSInput;

float4 PSMain(PSInput input) : SV_TARGET						//note: no parameters -> we could pass VSOutput but SV_Position is not used so params can be dropped
{
	return float4(0.4, 0.4, 0.4, 1.0);
}
