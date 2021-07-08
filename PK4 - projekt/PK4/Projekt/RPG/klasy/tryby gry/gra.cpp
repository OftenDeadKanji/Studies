#include "../../pch.h"
#include "gra.h"

Gra::Gra()
{}

Gra::Gra(ALLEGRO_DISPLAY* okno) : Tryb_Gry(okno)
{}

Gra::~Gra()
{}

void Gra::wczytaj()
{
	std::ifstream plik;
	plik.open("Zapis/stan.dat", std::ios::in | std::ios::binary);
	if (!plik.is_open())
		throw Wyjatek("Nie mozna otworzyc pliku Zapis/stan.dat");
	int nrPoz;
	plik >> nrPoz;
	poziom.wczytajPoziom(nrPoz);
}

void Gra::uruchom()
{
	//pierwsze wczytywanie poziomu
	try {
		wczytaj();
		//sprawdzanie czy gracz znajduje siê na planszy
		if (!(gracz = poziom.sprawdzGracz()))
			throw Wyjatek("Brak gracza na planszy.");
	}
	catch (Wyjatek wyj) {
		al_show_native_message_box(okno.pobOkno(), "Komunikat", "Uwaga:", wyj.what(), "OK", ALLEGRO_MESSAGEBOX_WARN);
		return;
	}

	tabPaski[0][0] = new Tekst("HP", x1HP, y1HP, 20 * WSP_WLK);
	tabPaski[0][1] = new Tekst("XP", x1XP, y1XP, 20 * WSP_WLK);

	tabPaski[1][0] = new Tekst("", x2HP, y1HP, 20 * WSP_WLK);
	tabPaski[1][1] = new Tekst("", x2XP, y1XP, 20 * WSP_WLK);

	tabTekst[0][0] = new Tekst("Poziom", x1Stat, y1Stat, 30 * WSP_WLK);
	tabTekst[0][1] = new Tekst("Atak", x1Stat, y1Stat + 40 * WSP_WYS, 30 * WSP_WLK);
	tabTekst[0][2] = new Tekst("Obrona", x1Stat, y1Stat + 80 * WSP_WYS, 30 * WSP_WLK);
	tabTekst[0][3] = new Tekst("Szyb. ataku", x1Stat, y1Stat + 120 * WSP_WYS, 30 * WSP_WLK);
	tabTekst[0][4] = new Tekst("Szyb. ruchu", x1Stat, y1Stat + 160 * WSP_WYS, 30 * WSP_WLK);

	tabTekst[1][0] = new Tekst(0, x2Stat, y1Stat, 30 * WSP_WLK);
	tabTekst[1][1] = new Tekst(0, x2Stat, y1Stat + 40 * WSP_WYS, 30 * WSP_WLK);
	tabTekst[1][2] = new Tekst(0, x2Stat, y1Stat + 80 * WSP_WYS, 30 * WSP_WLK);
	tabTekst[1][3] = new Tekst(0, x2Stat, y1Stat + 120 * WSP_WYS, 30 * WSP_WLK);
	tabTekst[1][4] = new Tekst(0, x2Stat, y1Stat + 160 * WSP_WYS, 30 * WSP_WLK);

	wczytajSpis();
	okno.zmienRozmiar(SZER_OKNA * WSP_SZER, WYS_OKNA * WSP_WYS);
	okno.dodajPrzycisk("MENU", SZER_GRANICA * WSP_SZER + 100 * WSP_SZER, 7.0 / 9.0 * WYS_OKNA * WSP_WYS, WLK_CZCIONKI * WSP_WLK);

	kolejka = al_create_event_queue();
	czas = al_create_timer(1.0 / FPS);

	al_register_event_source(kolejka, al_get_mouse_event_source());
	al_register_event_source(kolejka, al_get_keyboard_event_source());
	al_register_event_source(kolejka, al_get_display_event_source(okno.pobOkno()));
	al_register_event_source(kolejka, al_get_timer_event_source(czas));

	al_start_timer(czas);
	float czasRozp = 0;
	float odstepCzasu = 0;
	bool warunek = true;
	int licznik = 0;
	try {
		while (warunek) {
#pragma region Czas
			if (czasRozp == 0)
				czasRozp = clock() / static_cast<float>(CLOCKS_PER_SEC);
			odstepCzasu = clock() / static_cast<float>(CLOCKS_PER_SEC) - czasRozp;
#pragma endregion

#pragma region Obs³uga zdarzeñ
			al_get_next_event(kolejka, &zdarzenie);
			al_get_keyboard_state(&stanKlawiatury);
			switch (zdarzenie.type) {
			case ALLEGRO_EVENT_DISPLAY_CLOSE:
				warunek = false;
				break;
			case ALLEGRO_EVENT_MOUSE_BUTTON_DOWN:
				if (!okno.ktoryPrzycisk()) {
					Okienko okienko(gracz, spis, OKIENKO_MENU);
					warunek = okienko.obsluz();
				}
				break;
			case ALLEGRO_EVENT_KEY_DOWN:
				if (al_key_down(&stanKlawiatury, ALLEGRO_KEY_F)) //podniesienie przedmiotu
					poziom.podniesPrzedmiot();
				else if (al_key_down(&stanKlawiatury, ALLEGRO_KEY_E)) { //rozmowa, handel
					poziom.handluj();
				}
				else if (al_key_down(&stanKlawiatury, ALLEGRO_KEY_P)) {
					poziom.przejdz(gracz->podajX(), gracz->podajY());
					if (!(gracz = poziom.sprawdzGracz()))
						throw Wyjatek("Brak gracza na planszy");
					poziom.zapiszPoziom();
				}
				break;

			case ALLEGRO_EVENT_TIMER:
#pragma region Strza³ki
				if (al_key_down(&stanKlawiatury, ALLEGRO_KEY_UP)) {
					{
						gracz->dodajRozkaz(RUCH);
						gracz->zmienKierunekRuchu(GORA);
					}
				}
				else if (al_key_down(&stanKlawiatury, ALLEGRO_KEY_DOWN)) {
					{
						gracz->dodajRozkaz(RUCH);
						gracz->zmienKierunekRuchu(DOL);
					}
				}
				else if (al_key_down(&stanKlawiatury, ALLEGRO_KEY_LEFT)) {
					{
						gracz->dodajRozkaz(RUCH);
						gracz->zmienKierunekRuchu(LEWO);
					}
				}
				else if (al_key_down(&stanKlawiatury, ALLEGRO_KEY_RIGHT)) {
					{
						gracz->dodajRozkaz(RUCH);
						gracz->zmienKierunekRuchu(PRAWO);
					}
				}
				else if (al_key_down(&stanKlawiatury, ALLEGRO_KEY_Q))//zaatakowanie
					poziom.zaatakuj(*gracz);
#pragma endregion
				break;
			}
#pragma endregion
			if (odstepCzasu >= (1.0 / FPS)) {
				poziom.ustawEkwipunek();
				poziom.analizujRozkazy();
				poziom.umieranie(gracz);
				rysuj();
				czasRozp = 0;
			}
		}
	}
	catch (Wyjatek wyj) {
		al_show_native_message_box(okno.pobOkno(), "Komunikat", "Uwaga:", wyj.what(), "OK", ALLEGRO_MESSAGEBOX_WARN);
		al_destroy_timer(czas);
		al_destroy_event_queue(kolejka);

		for (int i = 0; i < 2; i++)
			for (int j = 0; j < 2; j++)
				delete tabPaski[i][j];

		for (int i = 0; i < 2; i++)
			for (int j = 0; j < 5; j++)
				delete tabTekst[i][j];
		return;
	}

	poziom.zapiszPoziom();
	al_destroy_timer(czas);
	al_destroy_event_queue(kolejka);

	for (int i = 0; i < 2; i++)
		for (int j = 0; j < 2; j++)
			delete tabPaski[i][j];

	for (int i = 0; i < 2; i++)
		for (int j = 0; j < 5; j++)
			delete tabTekst[i][j];

}


void Gra::rysujInfoGracz()
{
#pragma region Punkty ¿ycia i doœwiadczenia
	std::ostringstream pkt;
	std::ostringstream maxPkt;
	float x1, x2, y1, procent, szerPaska;

	x1 = SZER_GRANICA * WSP_SZER + 0.02 * SZER_OKNA * WSP_SZER;
	x2 = SZER_GRANICA * WSP_SZER + 0.14* SZER_OKNA * WSP_SZER;
	y1 = 0.1 * WYS_OKNA * WSP_WYS;

	pkt << gracz->podajPktZycia();
	maxPkt << gracz->podajMaxPktZycia();
	tabPaski[1][0]->zmienTekst(pkt.str() + "/" + maxPkt.str());

	procent = (float)gracz->podajPktZycia() / (float)gracz->podajMaxPktZycia();
	szerPaska = x2 + 0.04 * SZER_OKNA * WSP_SZER - x1;

	al_draw_rectangle(x1, y1 + tabPaski[0][0]->pobWlkCzcionki(), x2 + 0.04 * SZER_OKNA * WSP_SZER, y1 + 30 * WSP_WYS, al_map_rgb(CZARNY), 1);
	al_draw_filled_rectangle(1 + x1, 1 + y1 + tabPaski[0][0]->pobWlkCzcionki(), x1 + szerPaska * procent - 1, y1 + 30 * WSP_WYS - 1, al_map_rgb(CZERWONY));


	pkt.str("");
	maxPkt.str("");

	x1 = SZER_GRANICA * WSP_SZER + 0.02 * SZER_OKNA * WSP_SZER;
	x2 = SZER_GRANICA * WSP_SZER + 0.14* SZER_OKNA * WSP_SZER;
	y1 = 0.1 * WYS_OKNA * WSP_WYS + 50 * WSP_WYS;

	pkt << gracz->podajPktDosw();
	maxPkt << gracz->podajMaxPktDosw();
	tabPaski[1][1]->zmienTekst(pkt.str() + "/" + maxPkt.str());

	procent = (float)gracz->podajPktDosw() / (float)gracz->podajMaxPktDosw();
	szerPaska = x2 + 0.04 * SZER_OKNA * WSP_SZER - x1;

	al_draw_rectangle(x1, y1 + tabPaski[0][1]->pobWlkCzcionki(), x2 + 0.04 * SZER_OKNA * WSP_SZER, y1 + 30 * WSP_WYS, al_map_rgb(CZARNY), 1);
	al_draw_filled_rectangle(1 + x1, 1 + y1 + tabPaski[0][1]->pobWlkCzcionki(), x1 + szerPaska * procent - 1, y1 + 30 * WSP_WYS - 1, al_map_rgb(ZOLTY));

	for (int i = 0; i < 2; i++)
		for (int j = 0; j < 2; j++)
			tabPaski[i][j]->rysuj();
#pragma endregion

#pragma region Statystyki

	tabTekst[1][0]->zmienTekst(gracz->podajPoziom());
	tabTekst[1][1]->zmienTekst(gracz->podajWartAtaku());
	tabTekst[1][2]->zmienTekst(gracz->podajWartObrony());
	tabTekst[1][3]->zmienTekst(gracz->podajSzybkoscAtaku());
	tabTekst[1][4]->zmienTekst(gracz->podajSzybkoscRuchu());

	for (int i = 0; i < 2; i++)
		for (int j = 0; j < 5; j++) 
			tabTekst[i][j]->rysuj();
		
#pragma endregion
}

void Gra::rysuj()
{
	al_clear_to_color(al_map_rgb(BIALY));

	al_draw_line(SZER_GRANICA * WSP_SZER, 0, SZER_GRANICA * WSP_SZER, WYS_MONITORA, al_map_rgb(CZARNY), 5);
	rysujInfoGracz();
	okno.rysuj();
	poziom.rysujPoziom();

	al_flip_display();

}
