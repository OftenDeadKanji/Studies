#include "../../pch.h"

Przycisk::Przycisk()
{}

Przycisk::Przycisk(std::string napis, float x, float y, int wlk) : x1(x), y1(y)
{
	this->napis = new Tekst(napis, x1 + 10 * WSP_SZER, y1, wlk);
	int xK, yK;
	this->napis->podajWymiary(xK, yK);
	x2 = (xK + x1 + 10 * WSP_SZER) + 10 * WSP_SZER;
	y2 = (yK + y1) + 15 * WSP_WYS;
}

Przycisk::Przycisk(std::string napis, float x, float y, int wlk, bool czyIn, bool czyRmk): x1(x), y1(y), czyInteraktywne(czyIn), czyRamka(czyRmk)
{
	this->napis = new Tekst(napis, x + 10 * WSP_SZER, y, wlk);
	int xK, yK;
	this->napis->podajWymiary(xK, yK);
	x2 = (xK + x1 + 10 * WSP_SZER) + 10 * WSP_SZER;
	y2 = (yK + y1) + 15 * WSP_WYS;
}

Przycisk::~Przycisk()
{
	delete napis;
}

void Przycisk::zmienX(float x)
{
	this->x1 = x;
	napis->zmienX(x + 10 * WSP_SZER);
	int xK, yK;
	napis->podajWymiary(xK, yK);
	x2 = (xK + x1 + 10 * WSP_SZER) + 10 * WSP_SZER;
}

void Przycisk::zmienY(float y)
{
	this->y1 = y;
	napis->zmienY(y + 10 * WSP_WYS);
	int xK, yK;
	napis->podajWymiary(xK, yK);
	y2 = (yK + y1) + 15 * WSP_WYS;
}

void Przycisk::zmienCzyInterakt(bool stan)
{
	czyInteraktywne = stan;
}

void Przycisk::zmienCzyRamka(bool stan)
{
	czyRamka = stan;
}

void Przycisk::zmienNapis(std::string napis)
{
	this->napis->zmienTekst(napis);
}

void Przycisk::zmienWielkosc(int wielkosc)
{
	napis->zmienWielkosc(wielkosc);
}

void Przycisk::podajWymiary(int & szer, int & wys)
{
	szer = x2 - x1;
	wys = y2 - y1;
}

bool Przycisk::czyKlik()
{
	ALLEGRO_MOUSE_STATE stanMyszy;
	al_get_mouse_state(&stanMyszy);
	if (stanMyszy.x > x1 - 10 && stanMyszy.x < x2 + 10 && stanMyszy.y > y1 && stanMyszy.y < y2 + 15)
		return true;
	else
		return false;
}

void Przycisk::rysuj()
{
	ALLEGRO_MOUSE_STATE stanMyszy;
	al_get_mouse_state(&stanMyszy);

	if (czyInteraktywne && stanMyszy.x > x1 - 10 && stanMyszy.x < x2 + 10 && stanMyszy.y > y1 && stanMyszy.y < y2 + 15)
		napis->zmienKolor(al_map_rgb(SZARY));
	else
		napis->zmienKolor(al_map_rgb(CZARNY));

	napis->rysuj();

	if (czyRamka)
		al_draw_rectangle(x1, y1, x2, y2, al_map_rgb(CZARNY), 5);
}
