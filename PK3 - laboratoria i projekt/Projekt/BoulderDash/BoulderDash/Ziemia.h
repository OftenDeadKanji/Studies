#pragma once
#include "Main.h"

class Ziemia: public Obiekt
{
private:
	ALLEGRO_SAMPLE* kopanie;
public:
	Ziemia();
	Ziemia(int, int);
	Ziemia(Ziemia&);
	~Ziemia();

	void odtworzDzwiek();
	char podajZapis();
	bool czyWejsc();
	bool czyZniszczyc();
};