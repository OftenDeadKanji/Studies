#pragma once
class Okno
{
private:
	ALLEGRO_DISPLAY* okno;

	std::vector <Przycisk*> przyciski;
public:
	Okno();
	Okno(ALLEGRO_DISPLAY*);
	~Okno();

	void stworz(int, int);
	void dodajPrzycisk(std::string, float, float, int);
	void dodajPrzycisk(std::string, float, float, int, bool, bool);
	void rysuj();
	ALLEGRO_DISPLAY* pobOkno();
	void zmienRozmiar(int, int);
	void zmienNapisPrzycisk(std::string, int);

	//zwraca -1 gdy nie naciœniêto ¿adnego przycisku
	int ktoryPrzycisk();
};

