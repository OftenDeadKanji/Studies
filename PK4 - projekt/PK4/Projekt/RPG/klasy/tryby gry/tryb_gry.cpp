#include "../../pch.h"

Tryb_Gry::Tryb_Gry()
{}

Tryb_Gry::Tryb_Gry(ALLEGRO_DISPLAY * okno) : okno(okno)
{}

Tryb_Gry::~Tryb_Gry()
{}

void Tryb_Gry::wczytajSpis()
{
	spis.clear();
	std::ifstream plik;
	std::string dane;
	int id;
	plik.open("Spis/ID.txt", std::ios::in);
	if (!plik.is_open())
		throw Wyjatek("Nie mozna otworzyc pliku Spis/ID.txt");
	while (!plik.eof()) {
		getline(plik, dane);
		if (dane == "")
			break;
		id = atoi(dane.c_str());
		while (dane != "---") {
			getline(plik, dane);
			if (dane == "---")
				break;
			spis[id].push_back(dane);
		}
	}

	plik.close();
}
