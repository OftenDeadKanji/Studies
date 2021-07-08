#pragma once

class Okienko {
protected:
	float szerOkna = 450 * WSP_SZER, wysOkna = 400 * WSP_WYS;

	float x = 0.5 * (SZER_OKNA * WSP_SZER - szerOkna); 
	float y = 0.5 * (WYS_OKNA * WSP_WYS - wysOkna);

	int wielkosc = WLK_CZCIONKI;
	std::vector <Przycisk*> przyciski;
	std::vector <Tekst*> teksty;
	trybOkienka tryb;
	std::map <int, std::vector<std::string>> spis;
	Gracz* gracz;
	Handlarz* han;
public:
	Okienko(Gracz* gracz, const std::map <int, std::vector<std::string>> &, trybOkienka);
	Okienko(Gracz* gracz, Handlarz* han, const std::map <int, std::vector<std::string>> &, trybOkienka);
	Okienko(float x, float y, Gracz* gracz, const std::map <int, std::vector<std::string>> &, trybOkienka);
	~Okienko();

	void dodajPrzycisk(const std::string &);
	void usunPrzyciski();
	void dodajTekst(const std::string &);
	void usunTeksty();

	void ustawWspolrzedne();
	void zmienTryb(trybOkienka);
	int ktoryPrzycisk();
	int podajWielkosc();

	bool obsluz();

	void rysuj();
};