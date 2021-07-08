#include "../../pch.h"

Tekst::Tekst()
{}

Tekst::Tekst(std::string tekst) : tekst(tekst)
{
	czcionka = al_load_font(YRSAM_SCIEZKA, wlkCzcionki, NULL);
	dopasujDoSzer();
}

Tekst::Tekst(std::string tekst, int x, int y) : tekst(tekst), x(x), y(y)
{
	czcionka = al_load_font(YRSAM_SCIEZKA, wlkCzcionki, NULL);
	dopasujDoSzer();
}

Tekst::Tekst(std::string tekst, int x, int y, int wlk) : tekst(tekst), x(x), y(y), wlkCzcionki(wlk)
{
	czcionka = al_load_font(YRSAM_SCIEZKA, wlkCzcionki, NULL);
	dopasujDoSzer();
}

Tekst::Tekst(int tekst, int x, int y, int wlk) : tekstI(tekst), x(x), y(y), wlkCzcionki(wlk)
{
	czcionka = al_load_font(YRSAM_SCIEZKA, wlkCzcionki, NULL);
	dopasujDoSzer();
	tryb = false;
}

Tekst::Tekst(std::string tekst, int x, int y, float szer) : tekst(tekst), x(x), y(y), maxSzer(szer)
{
	czcionka = al_load_font(YRSAM_SCIEZKA, wlkCzcionki, NULL);
	dopasujDoSzer();
}

Tekst::Tekst(std::string tekst, int x, int y, int wlk, float szer) : tekst(tekst), x(x), y(y), wlkCzcionki(wlk), maxSzer(szer)
{
	czcionka = al_load_font(YRSAM_SCIEZKA, wlkCzcionki, NULL);
	dopasujDoSzer();
}

void Tekst::zmienTekst(std::string tekst)
{
	this->tekst = tekst;
	dopasujDoSzer();
}

void Tekst::zmienTekst(int tekst)
{
	this->tekstI = tekst;
}

void Tekst::zmienX(int x)
{
	this->x = x;
}

void Tekst::zmienY(int y)
{
	this->y = y;
}

int Tekst::pobWlkCzcionki()
{
	return wlkCzcionki;
}

void Tekst::zmienMaxSzer(float szer)
{
	this->maxSzer = szer;
}

void Tekst::zmienWielkosc(int wielkosc)
{
	this->wlkCzcionki = wielkosc;
	al_destroy_font(czcionka);
	czcionka = al_load_font(YRSAM_SCIEZKA, wlkCzcionki, NULL);
}

void Tekst::zmienKolor(ALLEGRO_COLOR kolor)
{
	this->kolor = kolor;
}

void Tekst::podajWymiary(int & szer, int & wys)
{
	int x1 = 0, y1 = 0, x2 = 0, y2 = 0, maxSzer = 0, indeks = 0;
	szer = wys = 0;
	for (auto iter = wiersze.begin(); iter != wiersze.end(); iter++) {
		al_get_text_dimensions(czcionka, iter->c_str(), &x1, &y1, &x2, &y2);
		if (maxSzer < x2 + x1)
			maxSzer = x2 + x1;
		wys += y2 + y1;
	}
	szer = maxSzer;
}

void Tekst::dopasujDoSzer()
{
	int x = 0, y = 0, szer = 0, wys = 0;
	wiersze.clear();
	wiersze.push_back(tekst);
	if (maxSzer)
		for (auto iterW = wiersze.begin(); iterW != wiersze.end(); iterW++) {
			//pobranie wymiarów tekstu
			al_get_text_dimensions(czcionka, iterW->c_str(), &x, &y, &szer, &wys);

			while (szer > maxSzer) {
				int pozycja = iterW->length();
				for (auto iterS = iterW->end() - 1; (*iterS) != ' '; iterS--)
					pozycja--;

				std::string slowo;
				slowo = iterW->substr(pozycja);

				if (iterW->empty()) {
					(*iterW) = slowo;
					maxSzer = szer;
				}
				else if (iterW == wiersze.end() - 1)
					wiersze.push_back(slowo);
				else {
					std::string aktWiersz = *(iterW + 1);
					slowo += aktWiersz;
					*(iterW + 1) = slowo;
				}
				al_get_text_dimensions(czcionka, iterW->c_str(), &x, &y, &szer, &wys);
			}
		}
}

void Tekst::rysuj()
{
	int indeks = 0;
	for (auto iter = wiersze.begin(); iter != wiersze.end(); iter++)
		if (tryb)
			al_draw_text(czcionka, kolor, x, y + indeks * wlkCzcionki * WSP_WLK, NULL, iter->c_str());
		else
			al_draw_textf(czcionka, kolor, x, y + indeks * wlkCzcionki * WSP_WLK, NULL, "%d", tekstI);
}


Tekst::~Tekst()
{
	if (czcionka)
		al_destroy_font(czcionka);
}
