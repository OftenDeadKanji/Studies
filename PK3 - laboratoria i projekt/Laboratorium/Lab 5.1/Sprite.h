#pragma once
#include "Console.h"
class Sprite
{
public:
	float x, y;
	float dx = 0.0f, dy = 0.0f;

	Sprite();
	Sprite(const Sprite &);
	Sprite(Sprite &&);
	~Sprite();
};

