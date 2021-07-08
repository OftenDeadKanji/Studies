#pragma once
class Tekst
{
protected:
	std::string tekst;
	int tekstI;
	std::vector <std::string> wiersze;
	float maxSzer = 0;
	ALLEGRO_FONT* czcionka;
	int wlkCzcionki = WLK_CZCIONKI;
	int x, y;
	ALLEGRO_COLOR kolor = al_map_rgb(CZARNY);
	//true - string, false - int
	bool tryb = true;
public:
	Tekst();
	Tekst(std::string);
	Tekst(std::string, int, int);
	Tekst(std::string, int, int, int);
	Tekst(std::string, int, int, float);
	Tekst(int, int, int, int);
	Tekst(std::string, int, int, int, float);

	void zmienTekst(std::string);
	void zmienTekst(int);
	void zmienMaxSzer(float);
	void zmienWielkosc(int);
	void zmienKolor(ALLEGRO_COLOR);
	void zmienX(int);
	void zmienY(int);

	int pobWlkCzcionki();

	void podajWymiary(int & szer, int & wys);
	void dopasujDoSzer();

	void rysuj();

	~Tekst();
};

