#include "pch.h"


Drzwi::Drzwi(char czyOtw)
{
	if (czyOtw == 'o')
		obraz = al_load_bitmap("Obrazy/drzwiOtw.png");
	else
		obraz = al_load_bitmap("Obrazy/drzwiZmk.png");
	czyOtwarte = czyOtw;
	otwarcie = al_load_sample("muzyka/drzwi.wav");
}

Drzwi::Drzwi(char czyOtw, int wspX, int wspY)
{
	if (czyOtw == 'o')
		obraz = al_load_bitmap("Obrazy/drzwiOtw.png");
	else
		obraz = al_load_bitmap("Obrazy/drzwiZmk.png");
	czyOtwarte = czyOtw;
	x = wspX;
	y = wspY;
	otwarcie = al_load_sample("muzyka/drzwi.wav");
}

Drzwi::Drzwi(Drzwi& ob) : Obiekt(ob), czyOtwarte(ob.czyOtwarte)
{
	otwarcie = al_load_sample("muzyka/drzwi.wav");
}

Drzwi::~Drzwi()
{
	al_destroy_bitmap(obraz);
	al_destroy_sample(otwarcie);
}

void Drzwi::otworz()
{
	al_destroy_bitmap(obraz);
	obraz = al_load_bitmap("Obrazy/drzwiOtw.png");
	al_play_sample(otwarcie, 1.0, 0.0, 1.0, ALLEGRO_PLAYMODE_ONCE, 0);
	czyOtwarte = 'o';
}

char Drzwi::podajZapis()
{
	return czyOtwarte;
}

bool Drzwi::czyWejsc()
{
	if (czyOtwarte == 'o')
		return true;
	else
		return false;
}

bool Drzwi::czyZniszczyc()
{
	return false;
}