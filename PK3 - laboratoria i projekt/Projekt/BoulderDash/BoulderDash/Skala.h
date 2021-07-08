#pragma once

class Skala :
	public Obiekt
{
private:
	ALLEGRO_SAMPLE* uderzenie;
public:
	Skala();
	Skala(int, int);
	Skala(Skala&);
	~Skala();

	void odtworzDzwiek();
	char podajZapis();
	bool czyWejsc();
	bool czyZniszczyc();
	thread spadanieWatek(Obiekt* tab[][20], mutex tabMutex[][20]);
	void spadanie(Obiekt* tab[][20], mutex tabMutex[][20]);
};

