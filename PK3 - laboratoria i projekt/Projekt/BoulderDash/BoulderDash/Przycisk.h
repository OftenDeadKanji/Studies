#pragma once

using namespace std;
class Przycisk
{
private:
	string wyrazenie;
	int x1 = 0; int  y1 = 0; int x2 = 0; int y2 = 0; //wspó³rzêdne rysowania
	int wlk = 70; //wielkoœæ czcionki - domyœlnie tak jak jest w #define
	bool czyInterakt = 1;
	bool czyRamka = 1;
	ALLEGRO_COLOR kolorCzcionki = al_map_rgb(185, 122, 87);
	ALLEGRO_COLOR kolorPodswietlenia = al_map_rgb(250, 250, 250);
	ALLEGRO_COLOR kolorTla = al_map_rgb(150, 150, 150);
	ALLEGRO_FONT* czcionka;
public:
	//konstruktory
	Przycisk();
	Przycisk(string, bool);
	Przycisk(string, bool, int, int, int);
	Przycisk(const Przycisk &);
	//destruktor
	~Przycisk();

	Przycisk& operator= (const Przycisk&);

	void podajWymWyraz(int*,int*);
	void rysuj();
	bool czyKlik();
	void zmianWyraz(string);
	void zmienInterakt(bool);

	void zmienKolorCz(ALLEGRO_COLOR);
	void zmienKolorPd(ALLEGRO_COLOR);
	void zmienKolorTl(ALLEGRO_COLOR);
	void zmienWlkCz(int);

	ALLEGRO_FONT* podajCzcionke();
	//metody operuj¹ce na wspó³.
	int podajX1();
	int podajY1();
	int podajX2();
	int podajY2();

	void zmienX(int);
	void zmienY(int);
};