#include "pch.h"

Puste::Puste()
{
	obraz = al_load_bitmap("Obrazy/Puste.png");
}

Puste::Puste(int wspX, int wspY)
{
	obraz = al_load_bitmap("Obrazy/Puste.png");
	x = wspX;
	y = wspY;
}

Puste::Puste(Puste& ob) : Obiekt(ob)
{}

Puste::~Puste()
{
	al_destroy_bitmap(obraz);
}


char Puste::podajZapis()
{
	return '0';
}

bool Puste::czyWejsc()
{
	return true;
}

bool Puste::czyZniszczyc()
{
	return true;
}