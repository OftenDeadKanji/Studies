#pragma once
class Edytor : public Tryb_Gry
{
private:
	Poziom poziom;
	
	int przesuniecie = 0;
public:
	Edytor();
	Edytor(ALLEGRO_DISPLAY *);
	~Edytor();

	void uruchom();
	int ktoryObraz();
	void rysuj();
};

