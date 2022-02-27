#ifndef VERTEXTYPES_H
#define VERTEXTYPES_H

#include "common.h"

struct Vertex_Pos
{
	Vertex_Pos(float parx, float pary, float parz) : x(parx), y(pary), z(parz) {}
	float x, y, z;
};

struct Vertex_PosCol : public Vertex_Pos
{
	Vertex_PosCol(float parx, float pary, float parz, float parr, float parg, float parb, float para = 1.f)
		: Vertex_Pos(parx, pary, parz), r(parr), g(parg), b(parb), a(para) {}
	float r, g, b, a;
};

//struct Vertex_PosNorm
//{
//	Vertex_PosNorm(float parx, float pary, float parz, float parnx, float parny, float parnz)
//		: x(parx), y(pary), z(parz), nx(parnx), ny(parny), nz(parnz) {}
//	float x, y, z, nx, ny, nz;
//};

struct Vertex_PosNorm : public Vertex_Pos
{
	Vertex_PosNorm(float parx, float pary, float parz, float parnx, float parny, float parnz)
		: Vertex_Pos(parx, pary, parz), nx(parnx), ny(parny), nz(parnz) {}
	float nx, ny, nz;
};

struct Vertex_PosNormUV : public Vertex_PosNorm
{
	Vertex_PosNormUV(float parx, float pary, float parz, float parnx, float parny, float parnz, float paru, float parv)
		: Vertex_PosNorm(parx, pary, parz, parnx, parny, parnz), u(paru), v(parv) {}
	float u, v;
};

#endif