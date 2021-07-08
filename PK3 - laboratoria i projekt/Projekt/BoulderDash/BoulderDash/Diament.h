#pragma once

class Diament :
	public Obiekt
{
private:
	char kolor;
	ALLEGRO_SAMPLE* zebrDiam;
public:
	Diament(char);
	Diament(char, int, int);
	Diament(Diament&);
	~Diament();

	void odtworzDzwiek();
	char podajZapis();
	bool czyWejsc();
	bool czyZniszczyc();
	thread spadanieWatek(Obiekt* tab[][20], mutex tabMutex[][20]);
	void spadanie(Obiekt* tab[][20],mutex tabMutex[][20]);
};

