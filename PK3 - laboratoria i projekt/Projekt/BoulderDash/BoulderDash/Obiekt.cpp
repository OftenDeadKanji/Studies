#include "pch.h"

Obiekt::Obiekt()
{}

Obiekt::Obiekt(Obiekt& ob) : x(ob.x), y(ob.y)
{
	this->obraz = al_clone_bitmap(ob.pobObraz());
}

Obiekt::~Obiekt()
{}

int Obiekt::pobX()
{
	return x;
}

int Obiekt::pobY()
{
	return y;
}

void Obiekt::zmienX(int wspX)
{
	x = wspX;
}

void Obiekt::zmienY(int wspY)
{
	y = wspY;
}

void Obiekt::zmienObraz(int)
{}

ALLEGRO_BITMAP* Obiekt::pobObraz()
{
	return obraz;
}

void Obiekt::rysuj()
{
	al_draw_bitmap(obraz, x*wymObiekt, y*wymObiekt, NULL);
}

void Obiekt::zmienTryb(bool tryb)
{
	koniec = tryb;
}

int Obiekt::czyKoniec()
{
	return koniec;
}

void Obiekt::spadanie(Obiekt* tab[20][20], mutex tabMutex[20][20])
{}

void Obiekt::odtworzDzwiek()
{}

void Obiekt::smierc()
{}

bool Obiekt::podajStan()
{
	return false;
}