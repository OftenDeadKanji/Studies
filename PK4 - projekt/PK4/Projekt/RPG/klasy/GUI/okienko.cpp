#include "../../pch.h"

#pragma region Konstruktory i destruktor
Okienko::Okienko(Gracz* gracz, const std::map <int, std::vector<std::string>> & spis, trybOkienka tryb) : gracz(gracz), spis(spis), tryb(tryb)
{}

Okienko::Okienko(Gracz * gracz, Handlarz * han, const std::map<int, std::vector<std::string>>& spis, trybOkienka tryb) : gracz(gracz), han(han), spis(spis), tryb(tryb)
{}

Okienko::Okienko(float x, float y, Gracz* gracz, const std::map <int, std::vector<std::string>> & spis, trybOkienka tryb) : x(x), y(y), gracz(gracz), spis(spis), tryb(tryb)
{}

Okienko::~Okienko()
{
	usunPrzyciski();
	usunTeksty();
}
#pragma endregion

void Okienko::dodajPrzycisk(const std::string & napis)
{
	przyciski.push_back(new Przycisk(napis, 0.1 * x, 0.1 * y, WLK_CZCIONKI * WSP_WLK));
}

void Okienko::usunPrzyciski()
{
	for (auto iter = przyciski.begin(); iter != przyciski.end(); iter++)
		delete (*iter);
	przyciski.clear();
}

void Okienko::dodajTekst(const std::string & napis)
{
	teksty.push_back(new Tekst(napis, 0.1*x, 0.1*y, 20 * WSP_WLK, 0.8*x));
}

void Okienko::usunTeksty()
{
	for (auto iter = teksty.begin(); iter != teksty.end(); iter++)
		delete (*iter);
	teksty.clear();
}

void Okienko::ustawWspolrzedne()
{
	usunPrzyciski();
	usunTeksty();

	switch (tryb) {
	case OKIENKO_MENU: {
		//dodajPrzycisk("ZAPISZ");
		dodajPrzycisk("EKWIPUNEK");
		dodajPrzycisk("WROC DO GRY");
		dodajPrzycisk("WYJDZ Z GRY");

		int licznik = 0;

		for (auto iter = przyciski.begin(); iter != przyciski.end(); iter++) {
			(*iter)->zmienX(this->x + 50 * WSP_SZER);
			(*iter)->zmienY(this->y + 50 * WSP_WYS + licznik++ * 1.5 * wielkosc * WSP_WLK);
		}
		break;
	}
	case OKIENKO_EKWIPUNEK: {
		dodajPrzycisk("WYJDZ");

		int lbwierszy = ceil((float)gracz->podajLiczbePrzedmiotow() / 5.0);

		przyciski.at(0)->zmienX(x + 0.35 * szerOkna);
		przyciski.at(0)->zmienY(y + 0.8 * wysOkna);
	}
							break;
	case OKIENKO_HANDEL: {
		dodajPrzycisk("WYJDZ");

		int lbwierszy = ceil((float)gracz->podajLiczbePrzedmiotow() / 5.0);

		przyciski.at(0)->zmienX(x + 0.35 * szerOkna);
		przyciski.at(0)->zmienY(y + 0.8 * wysOkna);
	}
						 break;

	}

}

void Okienko::zmienTryb(trybOkienka tryb)
{
	this->tryb = tryb;
	ustawWspolrzedne();
}

int Okienko::ktoryPrzycisk()
{
	int ktory = 0;
	for (auto iter = przyciski.begin(); iter != przyciski.end(); iter++) {
		if ((*iter)->czyKlik())
			return ktory;
		else
			ktory++;
	}
	return -1;
}

int Okienko::podajWielkosc()
{
	return wielkosc;
}

bool Okienko::obsluz()
{
	ALLEGRO_EVENT_QUEUE* kolejka = al_create_event_queue();
	ALLEGRO_EVENT zdarzenie;
	ALLEGRO_MOUSE_STATE stanMyszy;

	al_register_event_source(kolejka, al_get_mouse_event_source());

	bool warunekOk = true, warunek = true;

	ustawWspolrzedne();

	float czasRozp = 0, odstepCzasu = 0;

	while (warunekOk) {
		if (czasRozp == 0)
			czasRozp = clock() / static_cast<float>(CLOCKS_PER_SEC);
		odstepCzasu = clock() / static_cast<float>(CLOCKS_PER_SEC) - czasRozp;
		al_get_next_event(kolejka, &zdarzenie);
		switch (zdarzenie.type) {
			
		case ALLEGRO_EVENT_MOUSE_BUTTON_DOWN:
			al_get_mouse_state(&stanMyszy);
			if (odstepCzasu >= 0.1) {
				czasRozp = 0;
				if (tryb == OKIENKO_EKWIPUNEK &&
					stanMyszy.x >= this->x + 50 * WSP_SZER && stanMyszy.y >= this->y + 50 * WSP_WYS &&
					stanMyszy.x <= this->x + 50 * WSP_SZER * 6 && stanMyszy.y <= this->y + 50 * WSP_WYS * 6) {

					int nrKolumny = (stanMyszy.x - this->x) / (50 * WSP_SZER);
					int nrWiersza = (stanMyszy.y - this->y) / (50 * WSP_WYS);
					Przedmiot* przedmiot = gracz->podajPrzedmiot(nrKolumny*nrWiersza - 1);
					gracz->zalozPrzedmiot(przedmiot);
				}
				else if (tryb == OKIENKO_HANDEL &&
					stanMyszy.x >= this->x + 50 * WSP_SZER && stanMyszy.y >= this->y + 50 * WSP_WYS &&
					stanMyszy.x <= this->x + 50 * WSP_SZER * 4 && stanMyszy.y <= this->y + 50 * WSP_WYS * 6) {

					if (gracz->podajLiczbePrzedmiotow() > 0) {
						int nrKolumny = (stanMyszy.x - this->x) / (50 * WSP_SZER);
						int nrWiersza = (stanMyszy.y - this->y) / (50 * WSP_WYS);

						if (nrKolumny + 3 * (nrWiersza - 1) <= gracz->podajLiczbePrzedmiotow()) {
							Przedmiot* przedmiot = gracz->podajPrzedmiot(nrKolumny - 1 + 3 * (nrWiersza - 1));
							if (han->podajZloto() >= (float)przedmiot->podajWartosc() * 0.9) {
								han->zmienZloto(han->podajZloto() - (float)przedmiot->podajWartosc() * 0.9);
								gracz->zmienZloto(gracz->podajZloto() + (float)przedmiot->podajWartosc() * 0.9);

								gracz->zdejmijPrzedmiot(nrKolumny - 1 + 3 * (nrWiersza - 1));
								han->dodajPrzedmiot(przedmiot);
								gracz->usunPrzedmiot(przedmiot);
							}
						}
					}
				}
				else if (tryb == OKIENKO_HANDEL &&
					stanMyszy.x >= this->x + 50 * WSP_SZER * 4 && stanMyszy.y >= this->y + 50 * WSP_WYS &&
					stanMyszy.x <= this->x + 50 * WSP_SZER * 8 && stanMyszy.y <= this->y + 50 * WSP_WYS * 6) {

					if (han->podajLiczbePrzedmiotow() > 0) {
						int nrKolumny = (stanMyszy.x - this->x) / (50 * WSP_SZER) - 4;
						int nrWiersza = (stanMyszy.y - this->y) / (50 * WSP_WYS);

						if (nrKolumny + 3 * (nrWiersza - 1) <= han->podajLiczbePrzedmiotow()) {
							Przedmiot* przedmiot = han->podajPrzedmiot(nrKolumny - 1 + 3 * (nrWiersza - 1));
							if (gracz->podajZloto() >= (float)przedmiot->podajWartosc() * 0.9) {
								han->zmienZloto(han->podajZloto() + (float)przedmiot->podajWartosc() * 0.9);
								gracz->zmienZloto(gracz->podajZloto() - (float)przedmiot->podajWartosc() * 0.9);

								gracz->dodajPrzedmiot(przedmiot);
								han->usunPrzedmiot(przedmiot);
							}
						}
					}
				}

				int ktory = ktoryPrzycisk();
				switch (ktory) {
				case 0:
					if (tryb == OKIENKO_EKWIPUNEK) {
						zmienTryb(OKIENKO_MENU);
						al_flush_event_queue(kolejka);
					}
					else if (tryb == OKIENKO_MENU) {
						zmienTryb(OKIENKO_EKWIPUNEK);
						al_flush_event_queue(kolejka);
					}
					else if (tryb == OKIENKO_HANDEL)
						warunekOk = false;
					break;
				case 1:
					warunekOk = false;
					break;
				case 2:
					warunekOk = warunek = false;
					break;
				}
			}
			break;
			al_flush_event_queue(kolejka);
		}
		rysuj();
	}

	al_destroy_event_queue(kolejka);
	return warunek;
}

void Okienko::rysuj()
{
	al_draw_rectangle(x, y, x + szerOkna, y + wysOkna, al_map_rgb(CZARNY), 2);
	al_draw_filled_rectangle(x + 2, y + 2, x + szerOkna - 2, y + wysOkna, al_map_rgb(SZARY));

	for (auto iter = przyciski.begin(); iter != przyciski.end(); iter++)
		(*iter)->rysuj();
	for (auto iter = teksty.begin(); iter != teksty.end(); iter++)
		(*iter)->rysuj();

	if (tryb == OKIENKO_EKWIPUNEK) {
		for (int i = 0; i < gracz->podajLiczbePrzedmiotow(); i++) {
			int x = this->x + 50 * WSP_SZER * (i % 5 + 1);
			int y = this->y + 50 * WSP_WYS * (i / 5 + 1);
			al_draw_filled_rectangle(x, y, x + 50 * WSP_WLK, y + 50 * WSP_WLK, al_map_rgb(BIALY));
			al_draw_rectangle(x + 1, y + 1, x + 50 * WSP_WLK - 1, y + 50 * WSP_WLK - 1, al_map_rgb(CZARNY), 2);
			std::string sciezka = "Obrazy/" + spis.find(gracz->podajPrzedmiot(i)->podajID())->second[0];
			ALLEGRO_BITMAP* obraz = al_load_bitmap(sciezka.c_str());
			al_draw_scaled_bitmap(obraz, 0, 0, 100, 100, x, y, 50 * WSP_SZER, 50 * WSP_WYS, NULL);
			al_destroy_bitmap(obraz);
		}
	}
	else if (tryb == OKIENKO_HANDEL) {
		ALLEGRO_FONT* czcionka = al_load_font(YRSAM_SCIEZKA, 30 * WSP_WLK, NULL);

		//lista GRACZA
		al_draw_textf(czcionka, al_map_rgb(CZARNY), this->x + 50 * WSP_SZER, this->y + 10 * WSP_WYS, NULL, "%d", gracz->podajZloto());
		for (int i = 0; i < gracz->podajLiczbePrzedmiotow(); i++) {
			int x = this->x + 50 * WSP_SZER * (i % 3 + 1);
			int y = this->y + 50 * WSP_WYS * (i / 3 + 1);

			al_draw_filled_rectangle(x, y, x + 50 * WSP_WLK, y + 50 * WSP_WLK, al_map_rgb(BIALY));
			al_draw_rectangle(x + 1, y + 1, x + 50 * WSP_WLK - 1, y + 50 * WSP_WLK - 1, al_map_rgb(CZARNY), 2);

			std::string sciezka = "Obrazy/" + spis.find(gracz->podajPrzedmiot(i)->podajID())->second[0];
			ALLEGRO_BITMAP* obraz = al_load_bitmap(sciezka.c_str());

			al_draw_scaled_bitmap(obraz, 0, 0, 100, 100, x, y, 50, 50, NULL);
			al_destroy_bitmap(obraz);
		}

		//lista HANDLARZA
		al_draw_textf(czcionka, al_map_rgb(CZARNY), this->x + 250 * WSP_SZER, this->y + 10 * WSP_WYS, NULL, "%d", han->podajZloto());
		for (int i = 0; i < han->podajLiczbePrzedmiotow(); i++) {
			int x = this->x + 50 * WSP_SZER * (i % 3 + 1 + 4);
			int y = this->y + 50 * WSP_WYS * (i / 3 + 1);
			al_draw_filled_rectangle(x, y, x + 50 * WSP_WLK, y + 50 * WSP_WLK, al_map_rgb(BIALY));
			al_draw_rectangle(x + 1, y + 1, x + 50 * WSP_WLK - 1, y + 50 * WSP_WLK - 1, al_map_rgb(CZARNY), 2);
			std::string sciezka = "Obrazy/" + spis.find(han->podajPrzedmiot(i)->podajID())->second[0];
			ALLEGRO_BITMAP* obraz = al_load_bitmap(sciezka.c_str());
			al_draw_scaled_bitmap(obraz, 0, 0, 100, 100, x, y, 50, 50, NULL);
			al_destroy_bitmap(obraz);
		}
		al_destroy_font(czcionka);
	}

	al_flip_display();
}
