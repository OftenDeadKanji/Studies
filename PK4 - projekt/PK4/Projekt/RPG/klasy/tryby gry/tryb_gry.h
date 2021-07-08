#pragma once
class Tryb_Gry
{
protected:
	Okno okno;
	ALLEGRO_EVENT_QUEUE* kolejka;
	ALLEGRO_EVENT zdarzenie;
	ALLEGRO_MOUSE_STATE stanMyszy;

	std::map <int, std::vector<std::string>> spis;
public:
	Tryb_Gry();
	Tryb_Gry(ALLEGRO_DISPLAY*);
	~Tryb_Gry();

	virtual void uruchom() = 0;
	virtual void rysuj() = 0;
	void wczytajSpis();
};

