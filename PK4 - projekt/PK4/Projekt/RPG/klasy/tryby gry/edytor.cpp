#include "../../pch.h"

Edytor::Edytor()
{}

Edytor::Edytor(ALLEGRO_DISPLAY* okno) : Tryb_Gry(okno)
{}

Edytor::~Edytor()
{}

//funkcja zwraca liczbe plikow w folderze
size_t podajLbPlikow(std::filesystem::path sciezka)
{
	return (size_t)std::distance(std::filesystem::directory_iterator{ sciezka }, std::filesystem::directory_iterator{});
}

void Edytor::uruchom()
{
	okno.zmienRozmiar(SZER_OKNA * WSP_SZER, WYS_OKNA * WSP_WYS);

	kolejka = al_create_event_queue();
	al_register_event_source(kolejka, al_get_mouse_event_source());
	al_register_event_source(kolejka, al_get_display_event_source(okno.pobOkno()));

#pragma region Przyciski
	okno.dodajPrzycisk("Nowy poziom", SZER_GRANICA * WSP_SZER + 50 * WSP_SZER, 300 * WSP_WYS, 30 * WSP_WLK);
	okno.dodajPrzycisk("<", SZER_GRANICA* WSP_SZER + 50 * WSP_SZER, 400 * WSP_WYS, 30 * WSP_WLK);
	okno.dodajPrzycisk(">", SZER_GRANICA* WSP_SZER + 150 * WSP_SZER, 400 * WSP_WYS, 30 * WSP_WLK);
	okno.dodajPrzycisk("Wczytaj poziom", SZER_GRANICA* WSP_SZER + 50 * WSP_SZER, 500 * WSP_WYS, 30 * WSP_WLK);
	okno.dodajPrzycisk("Zapisz poziom", SZER_GRANICA* WSP_SZER + 50 * WSP_SZER, 600 * WSP_WYS, 30 * WSP_WLK);
	okno.dodajPrzycisk("Wyjdz", SZER_GRANICA* WSP_SZER + 50 * WSP_SZER, 800 * WSP_WYS, 30 * WSP_WLK);
	okno.dodajPrzycisk("1", SZER_GRANICA* WSP_SZER + 100 * WSP_SZER, 400 * WSP_WYS, 30 * WSP_WLK, false, false);
	okno.dodajPrzycisk("<-", SZER_GRANICA* WSP_SZER, 100 * WSP_WYS, 30 * WSP_WLK, true, false);
	okno.dodajPrzycisk("->", SZER_GRANICA* WSP_SZER + 250 * WSP_SZER, 100 * WSP_WYS, 30 * WSP_WLK, true, false);
#pragma endregion

	std::ostringstream konwersja;
	std::fstream plik;
	std::string dane;

	wczytajSpis();
	poziom.wczytajSpis();

	int nrObrazu;
	int nrPoziomu = 1;
	int warunek = 1;
	const int* wsk = nullptr;
	auto iter = spis.begin();
	//poziom.wczytajPoziomEdytor(nrPoziomu);
	while (warunek) {
		while (al_get_next_event(kolejka, &zdarzenie))
			switch (zdarzenie.type) {
			case ALLEGRO_EVENT_DISPLAY_CLOSE:
				warunek = false;
				break;
			case ALLEGRO_EVENT_MOUSE_BUTTON_DOWN:
				al_get_mouse_state(&stanMyszy);
				if (al_mouse_button_down(&stanMyszy, 2))
					poziom.usunElementPlanszy(stanMyszy.x / (100 * WSP_SZER), stanMyszy.y / (100 * WSP_WYS));
				if (al_mouse_button_down(&stanMyszy, 1)) {
					if (stanMyszy.x > SZER_GRANICA * WSP_SZER + 50 * WSP_SZER && stanMyszy.x < SZER_GRANICA* WSP_SZER + 250 * WSP_SZER &&
						stanMyszy.y > 50 * WSP_WYS && stanMyszy.y < 200 * WSP_WYS) {
						nrObrazu = ktoryObraz();
						for (int i = 0; i < przesuniecie + nrObrazu; i++)
							iter++;
						wsk = &(iter->first);
						iter = spis.begin();
					}
					else if (stanMyszy.x < SZER_GRANICA * WSP_SZER) {
						if (wsk != nullptr)
							poziom.dodajElementPlanszy(*wsk, stanMyszy.x / (100 * WSP_SZER), stanMyszy.y / (100 * WSP_WYS));
					}
					else
						switch (okno.ktoryPrzycisk()) {
						case 0: // nowy poziom
							konwersja << podajLbPlikow("Zapis/Poziomy/Edytor") + 1;
							//std::ofstream plik;
							plik.open("Zapis/Poziomy/Edytor/" + konwersja.str() + ".dat", std::ios::out | std::ios::binary);
							plik.close();
							konwersja.str("");
							break;
						case 1: // <
							if (nrPoziomu > 1) {
								nrPoziomu--;
								konwersja << nrPoziomu;
								okno.zmienNapisPrzycisk(konwersja.str(), 6);
								konwersja.str("");
								poziom.usunZawartosc();
								poziom.wczytajPoziomEdytor(nrPoziomu);
							}
							break;
						case 2: // >
							if (nrPoziomu < (int)podajLbPlikow("Zapis/Poziomy/Edytor")) {
								nrPoziomu++;
								konwersja << nrPoziomu;
								okno.zmienNapisPrzycisk(konwersja.str(), 6);
								konwersja.str("");
								poziom.usunZawartosc();
								poziom.wczytajPoziomEdytor(nrPoziomu);
							}
							break;
						case 3: // Wczytaj
							poziom.usunZawartosc();
							poziom.wczytajPoziomEdytor(nrPoziomu);
							break;
						case 4: // Zapisz
							poziom.zapiszPoziom();
							break;
						case 5: // Wyjdz
							warunek = 0;
							break;
						case 7: // <-
							if (przesuniecie == 1)
								przesuniecie -= 1;
							if (przesuniecie == 2)
								przesuniecie -= 2;
							if (przesuniecie >= 3)
								przesuniecie -= 3;
							break;
						case 8: // ->
							przesuniecie += 3;
						}
					break;
				}
			}
		rysuj();
	}
}

int Edytor::ktoryObraz()
{
	ALLEGRO_MOUSE_STATE stanMyszy;
	al_get_mouse_state(&stanMyszy);

	int i = (stanMyszy.x - (SZER_GRANICA * WSP_SZER + 50 * WSP_SZER)) / (50 * WSP_SZER); //ktora kolumna
	int j = (stanMyszy.y - 50 * WSP_WYS) / (50 * WSP_WYS); //ktory wiersz

	return 3 * i + j;
}

void Edytor::rysuj()
{
	al_clear_to_color(al_map_rgb(BIALY));
	al_draw_line(SZER_GRANICA * WSP_SZER, 0, SZER_GRANICA * WSP_SZER, WYS_MONITORA, al_map_rgb(CZARNY), 5);
	
	auto iter = spis.begin();
	for (int i = 0; i < przesuniecie; i++) {
		if (iter == spis.end()) {
			przesuniecie = i;
			break;
		}
		iter++;
	}

	for (int i = 0; i < 4; i++)
		for (int j = 0; j < 3; j++) {
			if (iter == spis.end())
				break;
			std::string sciezka = "Obrazy/" + iter->second[0];
			ALLEGRO_BITMAP* obraz = al_load_bitmap(sciezka.c_str());
			al_draw_scaled_bitmap(obraz, 0, 0, 100, 100, SZER_GRANICA * WSP_SZER + 50 * WSP_SZER * (i + 1), 50 * WSP_WYS * (j + 1), 50 * WSP_SZER, 50 * WSP_WYS, NULL);
			al_destroy_bitmap(obraz);

			iter++;
		}
	poziom.rysujPoziom();
	okno.rysuj();
	al_flip_display();
}
