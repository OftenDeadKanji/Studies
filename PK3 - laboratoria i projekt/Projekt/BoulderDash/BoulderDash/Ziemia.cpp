#include "pch.h"


#pragma region Konstruktory
Ziemia::Ziemia()
{
	obraz = al_load_bitmap("Obrazy/ziemia.png");
	kopanie = al_load_sample("muzyka/kopanie.wav");
}

Ziemia::Ziemia(Ziemia& ob) : Obiekt(ob)
{
	//obraz = al_clone_bitmap(ziemia.pobObraz());
	kopanie = al_load_sample("muzyka/kopanie.wav");
}

Ziemia::Ziemia(int wspX, int wspY)
{
	obraz = al_load_bitmap("Obrazy/ziemia.png");
	x = wspX;
	y = wspY;
	kopanie = al_load_sample("muzyka/kopanie.wav");
}

Ziemia::~Ziemia()
{
	al_destroy_bitmap(obraz);
	al_destroy_sample(kopanie);
}
#pragma endregion

void Ziemia::odtworzDzwiek()
{
	al_play_sample(kopanie, 1.0, 0, 1.0, ALLEGRO_PLAYMODE_ONCE, NULL);
}

char Ziemia::podajZapis()
{
	return 'g';
}

bool Ziemia::czyWejsc()
{
	return true;
}

bool Ziemia::czyZniszczyc()
{
	return true;
}