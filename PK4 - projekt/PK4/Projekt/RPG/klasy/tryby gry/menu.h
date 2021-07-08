#pragma once
class Menu: public Tryb_Gry
{
private:
	ALLEGRO_BITMAP* tlo;
public:
	Menu();
	~Menu();

	void uruchom();
	void rysuj();
};

