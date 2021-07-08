#include "pch.h"

Dynamit::Dynamit()
{
	dynamit0 = al_load_bitmap("Obrazy/dynamit.png");
	obraz = dynamit0;
}

Dynamit::Dynamit(int wspX, int wspY)
{
	dynamit0 = al_load_bitmap("Obrazy/dynamit.png");
	obraz = dynamit0;
	x = wspX;
	y = wspY;
}

Dynamit::Dynamit(Dynamit& ob) : Obiekt(ob)
{}

Dynamit::~Dynamit()
{
	al_destroy_bitmap(dynamit0);
}

char Dynamit::podajZapis()
{
	return 't';
}

bool Dynamit::czyWejsc()
{
	return true;
}

bool Dynamit::czyZniszczyc()
{
	return true;
}
