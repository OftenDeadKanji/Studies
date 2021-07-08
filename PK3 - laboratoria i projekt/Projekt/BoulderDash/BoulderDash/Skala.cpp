#include "pch.h"

Skala::Skala()
{
	obraz = al_load_bitmap("Obrazy/skala.png");
	uderzenie = al_load_sample("muzyka/skala.wav");
}

Skala::Skala(int wspX, int wspY)
{
	obraz = al_load_bitmap("Obrazy/skala.png");
	uderzenie = al_load_sample("muzyka/skala.wav");
	x = wspX;
	y = wspY;
}

Skala::Skala(Skala& ob) : Obiekt(ob)
{
	uderzenie = al_load_sample("muzyka/skala.wav");
}

Skala::~Skala()
{
	al_destroy_bitmap(obraz);
	al_destroy_sample(uderzenie);
}

char Skala::podajZapis()
{
	return 's';
}

bool Skala::czyWejsc()
{
	return true;
}

bool Skala::czyZniszczyc()
{
	return true;
}

void Skala::odtworzDzwiek()
{
	if (al_get_sample_length(uderzenie) > 0)
		al_play_sample(uderzenie, 1.0, 0, 1.0, ALLEGRO_PLAYMODE_ONCE, NULL);
}

thread Skala::spadanieWatek(Obiekt* tab[][20], mutex tabMutex[][20])
{
	return thread([=] { spadanie(tab, tabMutex); });
}

void Skala::spadanie(Obiekt* tab[][20], mutex tabMutex[][20])
{
	Obiekt* chwil;
	while(tab[x][y]->podajZapis() == 's' && (!koniec)) {
		if (y + 1 <= 19 && tab[x][y + 1]->podajZapis() == '0' && tabMutex[x][y + 1].try_lock()) {
			chwil = tab[x][y + 1];
			chwil->zmienY(y);
			tab[x][y + 1] = tab[x][y];
			tab[x][y] = chwil;
			tabMutex[x][y + 1].unlock();
			if (y + 2 <= 19 && tab[x][y + 2]->podajZapis() == 'r')
				tab[x][y + 2]->smierc();
			if ((y + 2 <= 19 && tab[x][y + 2]->podajZapis() != '0') || y + 2 == 19)
				odtworzDzwiek();
			y++;
		}
		else if (y + 1 <= 19 && (tab[x][y + 1]->podajZapis() == 's' || tab[x][y + 1]->podajZapis() == 'b' || tab[x][y + 1]->podajZapis() == 'l')) //czy znajdujemy siê na skale
			if (x + 1 <= 19 && tab[x + 1][y]->podajZapis() == '0' && tab[x + 1][y + 1]->podajZapis() == '0' && tabMutex[x + 1][y].try_lock()) {
				chwil = tab[x + 1][y];
				chwil->zmienX(x);
				tab[x + 1][y] = tab[x][y];
				tab[x][y] = chwil;
				tabMutex[x + 1][y].unlock();
				x++;
			}
			else if (x - 1 >= 0 && tab[x - 1][y]->podajZapis() == '0' && tab[x - 1][y + 1]->podajZapis() == '0' && tabMutex[x - 1][y].try_lock()) {
				chwil = tab[x - 1][y];
				chwil->zmienX(x);
				tab[x - 1][y] = tab[x][y];
				tab[x][y] = chwil;
				tabMutex[x - 1][y].unlock();
				x--;
			}
		al_rest(0.3);
	}
}