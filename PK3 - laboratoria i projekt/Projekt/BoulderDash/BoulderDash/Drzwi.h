#pragma once
#include "Main.h"

class Drzwi : public Obiekt
{
private:
	char czyOtwarte; //'o' - otwarte, 'z' - zamkniete
	ALLEGRO_SAMPLE* otwarcie;
public:
	Drzwi(char);
	Drzwi(char, int, int);
	Drzwi(Drzwi&);
	~Drzwi();

	void otworz();
	char podajZapis();
	bool czyWejsc();
	bool czyZniszczyc();
};