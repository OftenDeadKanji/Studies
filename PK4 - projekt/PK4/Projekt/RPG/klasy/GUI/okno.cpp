#include "../../pch.h"

Okno::Okno()
{}

Okno::Okno(ALLEGRO_DISPLAY * okno) : okno(okno)
{}

Okno::~Okno()
{
	for (int i = 0; i < przyciski.size(); i++)
		delete przyciski[i];
}

void Okno::stworz(int szer, int wys)
{
	okno = al_create_display(szer, wys);
	al_set_new_display_flags(ALLEGRO_WINDOWED);
}

void Okno::dodajPrzycisk(std::string napis, float x, float y, int wlk)
{
	Przycisk* nowy = new Przycisk(napis, x, y, wlk);
	przyciski.push_back(nowy);
}

void Okno::dodajPrzycisk(std::string napis, float x, float y, int wlk, bool czyInt, bool czyRmk)
{
	Przycisk* nowy = new Przycisk(napis, x, y, wlk, czyInt, czyRmk);
	przyciski.push_back(nowy);
}

void Okno::rysuj()
{
	for (int i = 0; i < przyciski.size(); i++)
		przyciski[i]->rysuj();
}

ALLEGRO_DISPLAY * Okno::pobOkno()
{
	return okno;
}

void Okno::zmienRozmiar(int szer, int wys)
{
	al_resize_display(okno, szer, wys);
	al_set_window_position(okno, (SZER_MONITORA - szer) * 0.5, (WYS_MONITORA - wys) * 0.5);
}

void Okno::zmienNapisPrzycisk(std::string napis, int ktory)
{
	przyciski[ktory]->zmienNapis(napis);
}

int Okno::ktoryPrzycisk()
{
	for (int i = 0; i < przyciski.size(); i++)
		if (przyciski[i]->czyKlik())
			return i;
	return -1;
}
