#pragma once

class Gra :
	public Tryb_Gry
{
private:
	ALLEGRO_KEYBOARD_STATE stanKlawiatury;
	ALLEGRO_TIMER* czas;
	const float FPS = 60.0;
	Poziom poziom;
	Gracz* gracz;

	bool koniec = false;

	int x1HP = SZER_GRANICA * WSP_SZER + 0.02 * SZER_OKNA * WSP_SZER;
	int x2HP = SZER_GRANICA * WSP_SZER + 0.14* SZER_OKNA * WSP_SZER;
	int y1HP = 0.1 * WYS_OKNA * WSP_WYS;

	int x1XP = SZER_GRANICA * WSP_SZER + 0.02 * SZER_OKNA * WSP_SZER;
	int x2XP = SZER_GRANICA * WSP_SZER + 0.14* SZER_OKNA * WSP_SZER;
	int y1XP = 0.1 * WYS_OKNA * WSP_WYS + 50 * WSP_WYS;

	Tekst* tabPaski[2][2];

	int x1Stat = SZER_GRANICA * WSP_SZER + 0.02 * SZER_OKNA * WSP_SZER;
	int x2Stat = SZER_GRANICA * WSP_SZER + 0.14* SZER_OKNA * WSP_SZER;
	int y1Stat = 0.3 * WYS_OKNA * WSP_WYS;

	Tekst* tabTekst[2][5];

public:
	Gra();
	Gra(ALLEGRO_DISPLAY*);
	~Gra();

	void wczytaj();
	void uruchom();
	void rysujInfoGracz();
	void rysuj();
};

