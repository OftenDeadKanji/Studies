#include "pch.h"

Gracz::Gracz()
{
	obraz = al_load_bitmap("Obrazy/Gracz.png");
}

Gracz::Gracz(int wspX, int wspY)
{
	obraz = al_load_bitmap("Obrazy/Gracz.png");
	x = wspX;
	y = wspY;
}

Gracz::Gracz(Gracz& ob) : Obiekt(ob), czyMartwy(ob.czyMartwy), posPkt(ob.posPkt)
{}

Gracz::~Gracz()
{
	al_destroy_bitmap(obraz);
}

char Gracz::podajZapis()
{
	return 'r';
}

bool Gracz::czyWejsc()
{
	return true;
}

bool Gracz::czyZniszczyc()
{
	return true;
}

void Gracz::smierc()
{
	czyMartwy = true;
	ALLEGRO_SAMPLE* smierc = al_load_sample("muzyka/smierc.wav");
	al_play_sample(smierc, 1.0, 0, 1.0, ALLEGRO_PLAYMODE_ONCE, 0);
	al_rest(1);
	al_destroy_sample(smierc);
}

bool Gracz::podajStan()
{
	return czyMartwy;
}

void Gracz::zmienPkt(int punkty)
{
	posPkt = punkty;
}

int Gracz::podajPkt()
{
	return posPkt;
}

int Gracz::podajLbDyn()
{
	return lbDyn;
}

void Gracz::zmniejszLbDyn()
{
	lbDyn--;
}

void Gracz::ruchDol(Plansza* pl, Obiekt* Poziom[][20], Puste* tabPuste[MAXOBIEKTOW], int lbPuste, Obiekt* ob, mutex tabMutex[][20])
{
	Puste puste(x, y);
	switch (ob->podajZapis()) {
	case 's':
		tabMutex[x][y + 1].unlock();
		break;
	case 'b':
		if (posPkt - 1 >= 0)
			posPkt -= 1;
		ob->odtworzDzwiek();
		if (Poziom[x][y]->podajZapis() != 't') {
			pl->dodajPuste(puste);
			Poziom[x][y] = tabPuste[lbPuste];
		}
		Poziom[x][++y] = this;
		tabMutex[x][y - 1].unlock();
		break;
	case 'l':
		for (int i = 0; i < 2; i++)
			if (posPkt - 1 >= 0)
				posPkt -= 1;
		ob->odtworzDzwiek(); 
		if (Poziom[x][y]->podajZapis() != 't') {
			pl->dodajPuste(puste);
			Poziom[x][y] = tabPuste[lbPuste];
		}
		Poziom[x][++y] = this;
		tabMutex[x][y - 1].unlock();
		break;
	case 't':
		lbDyn++;
		if (Poziom[x][y]->podajZapis() != 't') {
			pl->dodajPuste(puste);
			Poziom[x][y] = tabPuste[lbPuste];
		}
		Poziom[x][++y] = this;
		tabMutex[x][y - 1].unlock();
		break;
	case 'g':
		ob->odtworzDzwiek();
		if (Poziom[x][y]->podajZapis() != 't') {
			pl->dodajPuste(puste);
			Poziom[x][y] = tabPuste[lbPuste];
		}
		Poziom[x][++y] = this;
		tabMutex[x][y - 1].unlock();
		break;
	case '0':
		if (Poziom[x][y]->podajZapis() != 't') {
			ob->zmienY(ob->pobY() - 1);
			Poziom[x][y] = ob;
		}
		Poziom[x][++y] = this;
		tabMutex[x][y - 1].unlock();
		break;
	case 'o':
		if (Poziom[x][y]->podajZapis() != 't') {
			pl->dodajPuste(puste);
			Poziom[x][y] = tabPuste[lbPuste];
		}
		y++;
		break;
	}
}

void Gracz::ruchGora(Plansza* pl, Obiekt* Poziom[][20], Puste* tabPuste[MAXOBIEKTOW], int lbPuste, Obiekt* ob, mutex tabMutex[][20])
{
	Puste puste(x, y);
	switch (ob->podajZapis()) {
	case 's':
		tabMutex[x][y - 1].unlock();
		break;
	case 'b':
		if (posPkt - 1 >= 0)
			posPkt -= 1;
		ob->odtworzDzwiek();
		if (Poziom[x][y]->podajZapis() != 't') {
			pl->dodajPuste(puste);
			Poziom[x][y] = tabPuste[lbPuste];
		}
		Poziom[x][--y] = this;
		tabMutex[x][y + 1].unlock();
		break;
	case 'l':
		for (int i = 0; i < 2; i++)
			if (posPkt - 1 >= 0)
				posPkt -= 1;
		ob->odtworzDzwiek();
		if (Poziom[x][y]->podajZapis() != 't') {
			pl->dodajPuste(puste);
			Poziom[x][y] = tabPuste[lbPuste];
		}
		Poziom[x][--y] = this;
		tabMutex[x][y + 1].unlock();
		break;
	case 't':
		lbDyn++;
		if (Poziom[x][y]->podajZapis() != 't') {
			pl->dodajPuste(puste);
			Poziom[x][y] = tabPuste[lbPuste];
		}
		Poziom[x][--y] = this;
		tabMutex[x][y + 1].unlock();
		break;
	case 'g':
		ob->odtworzDzwiek();
		if (Poziom[x][y]->podajZapis() != 't') {
			pl->dodajPuste(puste);
			Poziom[x][y] = tabPuste[lbPuste];
		}
		Poziom[x][--y] = this;
		tabMutex[x][y + 1].unlock();
		break;
	case '0':
		if (Poziom[x][y]->podajZapis() != 't') {
			ob->zmienY(ob->pobY() + 1);
			Poziom[x][y] = ob;
		}
		Poziom[x][--y] = this;
		tabMutex[x][y + 1].unlock();
		break; 
	case 'o':
			if (Poziom[x][y]->podajZapis() != 't') {
				pl->dodajPuste(puste);
				Poziom[x][y] = tabPuste[lbPuste];
			}
			y--;
			break;
	}
}

void Gracz::ruchLewo(Plansza* pl, Obiekt* Poziom[][20], Puste* tabPuste[MAXOBIEKTOW], int lbPuste, Obiekt* ob, mutex tabMutex[][20])
{
	Puste puste(x, y);
	switch (ob->podajZapis()) {
	case 's':
		if (x - 2 > 0 && (Poziom[x - 2][y]->podajZapis() == '0')) {
			if (Poziom[x][y]->podajZapis() != 't') {
				Poziom[x - 2][y]->zmienX(Poziom[x - 2][y]->pobX() + 2);
				Poziom[x][y] = Poziom[x - 2][y];
			}
			ob->zmienX(ob->pobX() - 1);
			Poziom[x - 2][y] = ob;
			Poziom[--x][y] = this;
			tabMutex[x + 1][y].unlock();
		}
		else
			tabMutex[x - 1][y].unlock();
		break;
	case 'b':
		if (posPkt - 1 >= 0)
			posPkt -= 1;
		ob->odtworzDzwiek();
		if (Poziom[x][y]->podajZapis() != 't') {
			pl->dodajPuste(puste);
			Poziom[x][y] = tabPuste[lbPuste];
		}
		Poziom[--x][y] = this;
		tabMutex[x + 1][y].unlock();
		break;
	case 'l':
		for (int i = 0; i < 2; i++)
			if (posPkt - 1 >= 0)
				posPkt -= 1;
		ob->odtworzDzwiek();
		if (Poziom[x][y]->podajZapis() != 't') {
			pl->dodajPuste(puste);
			Poziom[x][y] = tabPuste[lbPuste];
		}
		Poziom[--x][y] = this;
		tabMutex[x + 1][y].unlock();
		break;
	case 't':
		lbDyn++;
		if (Poziom[x][y]->podajZapis() != 't') {
			pl->dodajPuste(puste);
			Poziom[x][y] = tabPuste[lbPuste];
		}
		Poziom[--x][y] = this;
		tabMutex[x + 1][y].unlock();
		break;
	case 'g':
		ob->odtworzDzwiek();
		if (Poziom[x][y]->podajZapis() != 't') {
			pl->dodajPuste(puste);
			Poziom[x][y] = tabPuste[lbPuste];
		}
		Poziom[--x][y] = this;
		tabMutex[x + 1][y].unlock();
		break;
	case '0':
		if (Poziom[x][y]->podajZapis() != 't') {
			ob->zmienX(ob->pobX() + 1);
			Poziom[x][y] = ob;
		}
		Poziom[--x][y] = this;
		tabMutex[x + 1][y].unlock();
		break;
	case 'o':
		if (Poziom[x][y]->podajZapis() != 't') {
			pl->dodajPuste(puste);
			Poziom[x][y] = tabPuste[lbPuste];
		}
		x--;
		break;
	}
}

void Gracz::ruchPrawo(Plansza* pl, Obiekt* Poziom[][20], Puste* tabPuste[MAXOBIEKTOW], int lbPuste, Obiekt* ob, mutex tabMutex[][20])
{
	Puste puste(x, y);
	switch (ob->podajZapis()) {
	case 's':
		if (x + 2 < 19 && (Poziom[x + 2][y]->podajZapis() == '0')) {
			if (Poziom[x][y]->podajZapis() != 't') {
				Poziom[x + 2][y]->zmienX(Poziom[x + 2][y]->pobX() - 2);
				Poziom[x][y] = Poziom[x + 2][y];
			}
			ob->zmienX(ob->pobX() + 1);
			Poziom[x + 2][y] = ob;
			Poziom[++x][y] = this;
			tabMutex[x - 1][y].unlock();
		}
		else
			tabMutex[x + 1][y].unlock();
		break;
	case 'b':
		if (posPkt - 1 >= 0)
			posPkt -= 1;
		ob->odtworzDzwiek();
		if (Poziom[x][y]->podajZapis() != 't') {
			pl->dodajPuste(puste);
			Poziom[x][y] = tabPuste[lbPuste];
		}
		Poziom[++x][y] = this;
		tabMutex[x - 1][y].unlock();
		break;
	case 'l':
		for (int i = 0; i < 2; i++)
			if (posPkt - 1 >= 0)
				posPkt -= 1;
		ob->odtworzDzwiek();
		if (Poziom[x][y]->podajZapis() != 't') {
			pl->dodajPuste(puste);
			Poziom[x][y] = tabPuste[lbPuste];
		}
		Poziom[++x][y] = this;
		tabMutex[x - 1][y].unlock();
		break;
	case 't':
		lbDyn++;
		if (Poziom[x][y]->podajZapis() != 't') {
			pl->dodajPuste(puste);
			Poziom[x][y] = tabPuste[lbPuste];
		}
		Poziom[++x][y] = this;
		tabMutex[x - 1][y].unlock();
		break;
	case 'g':
		ob->odtworzDzwiek();
		if (Poziom[x][y]->podajZapis() != 't') {
			pl->dodajPuste(puste);
			Poziom[x][y] = tabPuste[lbPuste];
		}
		Poziom[++x][y] = this;
		tabMutex[x - 1][y].unlock();
		break;
	case '0':
		if (Poziom[x][y]->podajZapis() != 't') {
			ob->zmienX(ob->pobX() - 1);
			Poziom[x][y] = ob;
		}
		Poziom[++x][y] = this;
		tabMutex[x - 1][y].unlock();
		break;
	case 'o':
		if (Poziom[x][y]->podajZapis() != 't') {
			pl->dodajPuste(puste);
			Poziom[x][y] = tabPuste[lbPuste];
		}
		x++;
		break;
	}
}