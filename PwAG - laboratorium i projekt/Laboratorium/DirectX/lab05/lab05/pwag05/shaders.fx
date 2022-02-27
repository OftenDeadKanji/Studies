struct VSInput
{
	float3 position : POSITION;
	float4 color : COLOR;
};

struct VSOutput
{
	float4 position : SV_POSITION;
	float4 color : COLOR;
};

cbuffer cb_scene
{
	matrix viewProjectionMatrix;
};

cbuffer cb_object
{
	matrix worldMatrix;
};

cbuffer cb_division
{
	int division;
};

///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////
VSOutput VSMain(in VSInput input)
{
	VSOutput output;

	output.position = float4(input.position, 1.0f);
	output.color = input.color;
	
	return output;
}
///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////

typedef VSOutput HSInput;
typedef VSOutput HSOutput;

struct COutput
{
	float edges[3] : SV_TessFactor;
	float inside : SV_InsideTessFactor;
};

COutput PatchConstantFunction(InputPatch<HSInput, 3> inputPatch, uint patchId : SV_PrimitiveID)
{
	COutput output;

	output.edges[0] = division;
	output.edges[1] = division;
	output.edges[2] = division;

	output.inside = division;

	return output;
}

[domain("tri")]
[partitioning("integer")]
[outputtopology("triangle_cw")]
[outputcontrolpoints(3)]
[patchconstantfunc("PatchConstantFunction")]
HSOutput HSMain(InputPatch<HSInput, 3> patch, uint pointId : SV_OutputControlPointID, uint patchId : SV_PrimitiveID)
{
	HSOutput output;
	output.position = patch[pointId].position;
	output.color = patch[pointId].color;

	return output;
}
///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////

struct PSInput
{
	float4 position : SV_POSITION;
	float4 color : COLOR;
};

static const float PI = 3.1415926535897932384626433832795f;

[domain("tri")]
PSInput DSMain(COutput input, float3 uvwCoord : SV_DomainLocation, const OutputPatch<HSOutput, 3> patch)
{
	float3 vertexPosition;
	PSInput output;
	
	vertexPosition = uvwCoord.x * patch[0].position + uvwCoord.y * patch[1].position + uvwCoord.z * patch[2].position;

	vertexPosition.z = 0.5 * cos(vertexPosition.x * PI) * 0.5 * cos(vertexPosition.y  * PI);

	output.position = mul(float4(vertexPosition, 1.0), worldMatrix);
	output.position = mul(viewProjectionMatrix, output.position);

	output.color = uvwCoord.x * patch[0].color + uvwCoord.y * patch[1].color + uvwCoord.z * patch[2].color;
	return output;
}

///////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////

float4 PSMain(PSInput input) : SV_TARGET
{
	return input.color;
}
///////////////////////////////////////////////////////////////////////////////////////////////