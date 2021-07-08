#include "pch.h"

Diament::Diament(char kol)
{
	if (kol == 'b') //niebieski
		obraz = al_load_bitmap("Obrazy/diamentNiebieski.png");
	else //kolor == 'l'
		obraz = al_load_bitmap("Obrazy/diamentZielony.png");
	kolor = kol;
	zebrDiam = al_load_sample("muzyka/diament.wav");
}

Diament::Diament(char kol, int wspX, int wspY)
{
	if (kol == 'b') //niebieski
		obraz = al_load_bitmap("Obrazy/diamentNiebieski.png");
	else //kolor == 'l'
		obraz = al_load_bitmap("Obrazy/diamentZielony.png");
	kolor = kol;
	x = wspX;
	y = wspY;
	zebrDiam = al_load_sample("muzyka/diament.wav");
}

Diament::Diament(Diament& ob) : Obiekt(ob), kolor(ob.kolor)
{
	zebrDiam = al_load_sample("muzyka/diament.wav");
}

Diament::~Diament()
{
	al_destroy_bitmap(obraz);
	al_destroy_sample(zebrDiam);
}

void Diament::odtworzDzwiek()
{
	al_play_sample(zebrDiam, 1.0, 0.0, 1.0, ALLEGRO_PLAYMODE_ONCE, NULL);
}

char Diament::podajZapis()
{
	return kolor;
}

bool Diament::czyWejsc()
{
	return true;
}

bool Diament::czyZniszczyc()
{
	return true;
}

thread Diament::spadanieWatek(Obiekt* tab[][20], mutex tabMutex[][20])
{
	return thread([=] { spadanie(tab, tabMutex); });
}

void Diament::spadanie(Obiekt* tab[][20], mutex tabMutex[][20])
{
	Obiekt* chwil;
	while((tab[x][y]->podajZapis() == 'b' || tab[x][y]->podajZapis() == 'l') && (!koniec)) {
		if (y + 1 <= 19 && tab[x][y + 1]->podajZapis() == '0' && tabMutex[x][y + 1].try_lock()) {
			chwil = tab[x][y + 1];
			chwil->zmienY(y);
			tab[x][y + 1] = tab[x][y];
			tab[x][y] = chwil;
			tabMutex[x][y + 1].unlock();
			if (y + 2 <= 19 && tab[x][y + 2]->podajZapis() == 'r')
				tab[x][y + 2]->smierc();
			y++;
		}
		/*else if (wspY + 1 <= 19 && (tab[wspX][wspY + 1]->podajZapis() == 's' || tab[wspX][wspY + 1]->podajZapis() == 'b' || tab[wspX][wspY + 1]->podajZapis() == 'l'))
			if (wspX + 1 <= 19 && wspY + 1 <= 19 && tab[wspX + 1][wspY]->podajZapis() == '0' && tab[wspX + 1][wspY + 1]->podajZapis() == '0' && tabMutex[wspX+1][wspY].try_lock()) {
				tab[wspX + 1][wspY] = tab[wspX][wspY];
				tab[wspX][wspY] = szablony[0];
				tabMutex[wspX + 1][wspY].unlock();
			}
			else if (wspX - 1 >= 0 && wspY + 1 <= 19 && tab[wspX - 1][wspY]->podajZapis() == '0' && tab[wspX - 1][wspY + 1]->podajZapis() == '0' && tabMutex[wspX-1][wspY].try_lock()) {
				tab[wspX - 1][wspY] = tab[wspX][wspY];
				tab[wspX][wspY] = szablony[0];
				tabMutex[wspX - 1][wspY].unlock();
			}*/
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

