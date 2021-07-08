#pragma once

class Dynamit :
	public Obiekt
{
protected:
	ALLEGRO_BITMAP* dynamit0;
	ALLEGRO_BITMAP* dynamit1;
	ALLEGRO_BITMAP* dynamit2;
	ALLEGRO_BITMAP* dynamit3;
	ALLEGRO_BITMAP* eksplozja;
public:
	Dynamit();
	Dynamit(int, int);
	Dynamit(Dynamit&);
	~Dynamit();

	char podajZapis();
	virtual bool czyWejsc();
	bool czyZniszczyc();
};

