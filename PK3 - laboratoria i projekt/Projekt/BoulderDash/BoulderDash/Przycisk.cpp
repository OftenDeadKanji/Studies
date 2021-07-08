#include "pch.h"

Przycisk::Przycisk()
{
	czcionka = al_load_font("Czcionki/YrsaM.ttf", wlk, NULL);
}

Przycisk::Przycisk(string wyraz, bool czy)
{
	wyrazenie = wyraz;
	czcionka = al_load_font("Czcionki/YrsaM.ttf", wlk, NULL);
	czyInterakt = czyRamka = czy;
	if (!czy)
		kolorPodswietlenia = kolorCzcionki;
	int szer, wys;
	podajWymWyraz(&szer, &wys);
	x2 = szer;
	y2 = wys;
}

Przycisk::Przycisk(string wyraz, bool czy, int wspX, int wspY, int wielk)
{
	wyrazenie = wyraz;
	wlk = wielk;
	czcionka = al_load_font("Czcionki/YrsaM.ttf", wlk, NULL);
	czyInterakt = czyRamka = czy;
	if (!czy)
		kolorPodswietlenia = kolorCzcionki;
	x1 = wspX;
	y1 = wspY;
	int szer, wys;
	podajWymWyraz(&szer, &wys);
	x2 = x1 + szer;
	y2 = y1 + wys;
}

Przycisk::Przycisk(const Przycisk &przycisk) :	wyrazenie(przycisk.wyrazenie),
												x1(przycisk.x1), x2(przycisk.x2), y1(przycisk.y1), y2(przycisk.y2), wlk(przycisk.wlk), 
												czyInterakt(przycisk.czyInterakt), czyRamka(przycisk.czyRamka),
												kolorCzcionki(przycisk.kolorCzcionki), kolorPodswietlenia(przycisk.kolorPodswietlenia),
												kolorTla(przycisk.kolorTla)
{
	czcionka = al_load_font("Czcionki/YrsaM.ttf", wlk, NULL);
}

Przycisk::~Przycisk()
{
	al_destroy_font(czcionka);
}

Przycisk& Przycisk::operator= (const Przycisk& przyc)
{
	wyrazenie = przyc.wyrazenie;
	x1 = przyc.x1;	x2 = przyc.x2;	y1 = przyc.y1;	y2 = przyc.y2;
	wlk = przyc.wlk;
	czyInterakt = przyc.czyInterakt;
	czcionka = al_load_font("Czcionki/YrsaM.ttf", wlk, NULL);

	return *this;
}

void Przycisk::podajWymWyraz(int *szer, int *wys)
{
	int x, y, w, h;
	al_get_text_dimensions(czcionka, wyrazenie.c_str(), &x, &y, &w, &h);
	*szer = x + w;
	*wys = y + h;
}

void Przycisk::rysuj()
{
	if (czyInterakt)
		al_draw_rectangle(x1, y1, x2 + wlk * (2.0 / 7.0), y2 + wlk * (2.0 / 7.0), kolorCzcionki, 5);
	al_draw_text(czcionka, kolorCzcionki, x1 + 10, y1 + 10, NULL, wyrazenie.c_str());

	float xy[2];
	pozycjaMyszki(xy);
	if (xy[0] >= x1 && xy[0] <= (x2 + wlk*(2.0/7.0)) && xy[1] >= y1 && xy[1] <= (y2 + wlk * (2.0 / 7.0)))
	//if(czyKlik())
		al_draw_text(czcionka, kolorPodswietlenia, x1 + 10, y1 + 10, NULL, wyrazenie.c_str());
}

bool Przycisk::czyKlik()
{
	float xy[2];
	pozycjaMyszki(xy);

	if (xy[0] >= x1 && xy[0] <= (x2 + wlk * (2.0 / 7.0)) && xy[1] >= y1 && xy[1] <= (y2 + wlk * (2.0 / 7.0)))
		return 1;
	return 0;
}

void Przycisk::zmianWyraz(string wyraz)
{
	wyrazenie = wyraz;
}

void Przycisk::zmienInterakt(bool czy)
{
	czyInterakt = czy;
}

void Przycisk::zmienKolorCz(ALLEGRO_COLOR kolor)
{
	kolorCzcionki = kolor;
}

void Przycisk::zmienKolorPd(ALLEGRO_COLOR kolor)
{
	kolorPodswietlenia = kolor;
}

void Przycisk::zmienKolorTl(ALLEGRO_COLOR kolor)
{
	kolorTla = kolor;
}

void Przycisk::zmienWlkCz(int x)
{
	wlk = x;
	czcionka = al_load_ttf_font("Czcionki/YrsaM.ttf", wlk, NULL);
	int szer, wys;
	podajWymWyraz(&szer, &wys);
	x2 = x1 + szer;
	y2 = y1 + wys;
}

ALLEGRO_FONT* Przycisk::podajCzcionke()
{
	return czcionka;
}

int Przycisk::podajX1()
{
	return x1;
}

int Przycisk::podajY1()
{
	return y1;
}

int Przycisk::podajX2()
{
	return x2;
}

int Przycisk::podajY2()
{
	return y2;
}

void Przycisk::zmienX(int x)
{
	int chwil = x1;
	x1 = x;
	x2 = x - chwil;
}

void Przycisk::zmienY(int y)
{
	int chwil = y1;
	y1 = y;
	y2 = y - chwil;
}