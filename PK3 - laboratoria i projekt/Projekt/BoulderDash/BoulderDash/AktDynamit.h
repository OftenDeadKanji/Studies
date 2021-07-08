#pragma once

class AktDynamit :
	public Dynamit
{
private:
	int tryb = 1;
	ALLEGRO_SAMPLE* eksploz;
public:
	AktDynamit();
	AktDynamit(int wspX, int wspY);
	AktDynamit(AktDynamit&);
	~AktDynamit();

	bool czyWejsc();
	int podajTryb();
	void zmienObraz();
	void wybuch(Gracz*);
	void rysuj(Obiekt* tab[][20]);
};

