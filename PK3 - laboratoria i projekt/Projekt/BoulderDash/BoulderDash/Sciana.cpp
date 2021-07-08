#include "pch.h"


Sciana::Sciana(char rodz)
{
	if (rodz == 'p')
		obraz = al_load_bitmap("Obrazy/przekraczalnaSciana.png");
	else
		obraz = al_load_bitmap("Obrazy/nieprzekraczalnaSciana.png");
	rodzaj = rodz;
}

Sciana::Sciana(char rodz, int wspX, int wspY)
{
	if (rodz == 'p')
		obraz = al_load_bitmap("Obrazy/przekraczalnaSciana.png");
	else
		obraz = al_load_bitmap("Obrazy/nieprzekraczalnaSciana.png");
	rodzaj = rodz;
	x = wspX;
	y = wspY;
}

Sciana::Sciana(Sciana& ob) : Obiekt(ob), rodzaj(ob.rodzaj)
{}

Sciana::~Sciana()
{
	al_destroy_bitmap(obraz);
}


char Sciana::podajZapis()
{
	return rodzaj;
}

bool Sciana::czyWejsc()
{
	return false;
}

bool Sciana::czyZniszczyc()
{
	if (rodzaj == 'p')
		return true;
	else
		return false;
}