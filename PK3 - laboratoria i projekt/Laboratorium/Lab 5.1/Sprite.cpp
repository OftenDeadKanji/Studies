#include "stdafx.h"
#include "Sprite.h"


Sprite::Sprite()
{
	x = static_cast <float> (5 + rand() % 70);
	y = static_cast <float> (5 + rand() % 15);
}

Sprite::Sprite(const Sprite &animal)
{
	x = animal.x;
	dx = animal.dx;
	y = animal.y;
	dy = animal.dy;
}

Sprite::Sprite(Sprite &&animal)
{
	x = animal.x;
	dx = animal.dx;
	y = animal.y;
	dy = animal.dy;
}

Sprite::~Sprite()
{
}