#include "pch.h"

using namespace experimental::filesystem;

void pozycjaMyszki(float xy[2])
{
	//funkcja odczytuje aktualny stan myszki i zapisuje w tablicy wspolrzedne kursora

	ALLEGRO_MOUSE_STATE stanMyszki;
	al_get_mouse_state(&stanMyszki);
	xy[0] = stanMyszki.x;
	xy[1] = stanMyszki.y;
}

void podajWsp(int* x, int* y)
{
	//funkcja korzysta z pozycjaMyszki() w celu podania wspolrzednych pola na planszy - nr wiersza i kolumny

	float xy[2];
	pozycjaMyszki(xy);
	*x = (int)xy[0] / wymObiekt;
	*y = (int)xy[1] / wymObiekt;

}

int sprPrzycisk(Przycisk* tab[], int rozmiar)
{
	//funkcja sprawdza czy ktorys z przyciskow nie zostal nacisniety przez uzytkownika i zwraca jego umowny numer
	for (int i = 0; i < rozmiar; i++)
		if (tab[i]->czyKlik())
			return i;
	return -1;
}

void sprawdzPoziom(Obiekt* tab[][20], bool* czyDobrze)
{
	//funkcja sprawdza czy poziom stworzony w edytorze jest poprawny
	//do tego wymagane jest ustawienia dokladnie jednego pola z graczem i jednego pola z drzwiami

	int lbGraczy = 0;
	int lbDrzwi = 0;

	for (int i = 0; i < 20; i++)
		for (int j = 0; j < 20; j++) {
			switch (tab[i][j]->podajZapis()) {
			case 'r': //gracz
				lbGraczy++;
				break;
			case 'z': //drzwi [zamkniête]
				lbDrzwi++;
				break;
			}
			if (lbDrzwi > 1 || lbGraczy > 1) {
				*czyDobrze = false;
				return;
			}
		}
	if (lbGraczy == 1 && lbDrzwi == 1)
		*czyDobrze = true;
	else
		*czyDobrze = false;

}

void zapiszPoziom(Obiekt* tab[][20])
{
	//funkcja zapisuje poziom stworzony w edytorze do pliku
	//kazda klasa ma unikalny zapis w postaci pojedynczego znaku, ktory wlasnie bedzie wpisywany do pliku

	fstream plik;
	string nazwa;
	ostringstream konwersja;

	for (int i = 1; i < MAXPOZ; i++) {
		konwersja.str("");
		konwersja << i;
		nazwa = "Poziomy/" + konwersja.str() + ".dat";
		plik.open(nazwa, ios::in);
		if (!plik.is_open())
			break;
		plik.close();
	}
	plik.open(nazwa, ios::out | ios::binary);
	for (int i = 0; i < 20; i++) {
		for (int j = 0; j < 20; j++)
			plik << tab[j][i]->podajZapis();
		plik << '\n';
	}
	plik.close();
}

size_t podajLbPlikow(path sciezka)
{
	//funkcja zwraca liczbe plikow w folderze

	return (size_t)distance(directory_iterator{ sciezka }, directory_iterator{});
}

void Menu()
{
	//funkcja odpowiedzialna za wyswietlanie menu

	#pragma region Allegro
	ALLEGRO_DISPLAY* okno = al_create_display(SZER, WYS);
	ALLEGRO_BITMAP* tlo = al_load_bitmap("Obrazy/tlo_1.png");
	ALLEGRO_EVENT_QUEUE* kolejka = al_create_event_queue();
	ALLEGRO_EVENT zdarzenie;
	al_register_event_source(kolejka, al_get_mouse_event_source());

	al_reserve_samples(MAXDZWIEKOW);
	ALLEGRO_SAMPLE* muzyka = al_load_sample("muzyka/menu.wav");
	al_play_sample(muzyka, 1.0, 0, 1.0, ALLEGRO_PLAYMODE_LOOP, NULL);
	#pragma endregion

	#pragma region Przyciski
	const int wspX0 = 10;
	const int wspY0 = 100;
	Przycisk rozp("Rozpocznij gre", true, wspX0, wspY0, wlkCzcionki);
	Przycisk edyt("Edytor poziomow", true, wspX0, wspY0 * 2, wlkCzcionki);
	Przycisk autor("Autorzy", true, wspX0, wspY0 * 3, wlkCzcionki);
	Przycisk wyj("Wyjdz", true, wspX0, wspY0 * 4, wlkCzcionki);

	const int rozmiar = 4;
	Przycisk* tab[4] = { &rozp, &edyt, &autor, &wyj };
	#pragma endregion

	bool wyjscie = 0;
	int ktory;

	while (!wyjscie) {
		al_clear_to_color(al_map_rgb(SZARY));
		al_draw_bitmap(tlo, 0, 0, NULL);
		rysujPrzyciski(tab, rozmiar);
		al_flip_display();

		#pragma region Obs³uga zdarzeñ
		al_wait_for_event(kolejka, &zdarzenie);
		if (zdarzenie.type == ALLEGRO_EVENT_MOUSE_BUTTON_DOWN) {
			ktory = sprPrzycisk(tab, rozmiar);
			switch (ktory) {
			case 0:
				rysujPrzejscie('z');
				Gra();
				rysujPrzejscie('o');
				break;
			case 1:
				rysujPrzejscie('z');
				Edytor(okno);
				rysujPrzejscie('o');
				break;
			case 2:
				rysujPrzejscie('z');
				Autorzy();
				rysujPrzejscie('o');
				break;
			case 3:
				wyjscie = 1;
				break;
			}
		}
		al_flush_event_queue(kolejka);
		#pragma endregion
	}
		
	al_destroy_event_queue(kolejka);
	al_destroy_sample(muzyka);
	al_destroy_bitmap(tlo);
	al_destroy_display(okno);
}

void Gra()
{
	rysujPrzejscie('o');

	int lbPlikow = podajLbPlikow("Poziomy");

#pragma region Inicjalizacja obiektów, tablic wskaŸników na obiekty
	Plansza plansza;

	const int yWybor = 100;
	Przycisk Wybor("Poziom", false, wymPole, yWybor, wlkCzcionki - 30);

	Przycisk Poprz("<-", true, Wybor.podajX1(), Wybor.podajY2(), wlkCzcionki - 40);
	Poprz.zmienInterakt(false);

	Przycisk Nr("1", false, Poprz.podajX2() + 20, Poprz.podajY1(), wlkCzcionki - 40);

	Przycisk Nast("->", true, Nr.podajX2() + 20, Nr.podajY1(), wlkCzcionki - 40);
	Nast.zmienInterakt(false);

	Przycisk Graj("Graj", true, 0.0125*SZER, 0.85*WYS, wlkCzcionki);

	Przycisk Wyjdz("Wyjdz", true, 0.75*SZER, 0.85*WYS, wlkCzcionki);

	const int lbPrzyc = 6;
	Przycisk* tab[lbPrzyc] = { &Wybor , &Poprz, &Nast, &Nr, &Graj, &Wyjdz };

	Obiekt* Poziom[20][20];
#pragma endregion

	ALLEGRO_BITMAP* tlo = al_load_bitmap("Obrazy/tlo_2.png");
	ALLEGRO_EVENT_QUEUE* kolejka = al_create_event_queue();
	ALLEGRO_EVENT zdarzenie;
	al_register_event_source(kolejka, al_get_mouse_event_source());

	int wyjscie = 0;
	int nrPoz = 1;
	ostringstream konwersja;
	plansza.wczytajPoziom(nrPoz);
	while (!wyjscie) {
		al_clear_to_color(al_map_rgb(SZARY));
		al_draw_bitmap(tlo, 0, 0, 0);
		al_draw_line(0, wymPole, wymPole, wymPole, al_map_rgb(BRAZOWY), GRUBOSC);
		al_draw_line(wymPole, 0, wymPole, wymPole, al_map_rgb(BRAZOWY), GRUBOSC);
		rysujPrzyciski(tab, lbPrzyc);
		plansza.rysuj();

#pragma region Obs³uga zdarzeñ
		while (al_get_next_event(kolejka, &zdarzenie))
			switch (zdarzenie.type) {
			case(ALLEGRO_EVENT_MOUSE_BUTTON_DOWN):
				if (Wyjdz.czyKlik()) {
					wyjscie = 1;
					break;
				}
				if (Graj.czyKlik()) {
					rysujPrzejscie('z');
					plansza.graj(); // teraz cala gra to metoda klasy plansza
					plansza.usun();
					plansza.wczytajPoziom(nrPoz);
					rysujPrzejscie('o');
					break;
				}
				if (Nast.czyKlik())
					if (nrPoz < lbPlikow) {
						nrPoz++;
						plansza.usun();
						plansza.wczytajPoziom(nrPoz);
					}

				if (Poprz.czyKlik())
					if (nrPoz > 1) {
						nrPoz--;
						plansza.usun();
						plansza.wczytajPoziom(nrPoz);
					}

				konwersja.str("");
				konwersja << nrPoz;
				Nr.zmianWyraz(konwersja.str());
				break;
			}

		al_flip_display();
	}
#pragma endregion

	al_destroy_event_queue(kolejka);
	al_destroy_bitmap(tlo);

	rysujPrzejscie('z');
}

void Edytor(ALLEGRO_DISPLAY* okno)
{
	rysujPrzejscie('o');

	#pragma region Allegro
	ALLEGRO_BITMAP* tlo = al_load_bitmap("Obrazy/tlo_2.png");
	ALLEGRO_EVENT_QUEUE* kolejka = al_create_event_queue();
	ALLEGRO_EVENT zdarzenie;
	ALLEGRO_TIMER* czas = al_create_timer(1.0 / 60);
	ALLEGRO_FONT* czcionkaD = al_load_font("Czcionki/YrsaM.ttf", 50, NULL);
	ALLEGRO_FONT* czcionkaM = al_load_font("Czcionki/YrsaM.ttf", 30, NULL);
	ALLEGRO_MOUSE_STATE stanMyszki;
	al_register_event_source(kolejka, al_get_mouse_event_source());
	al_register_event_source(kolejka, al_get_timer_event_source(czas));
	#pragma endregion

	#pragma region Tworzenie obiektów, tablic i ich inicjalizacja

	Ziemia ziemia(wymPole, 100);
	Drzwi drzwiZmk('z', wymPole + 32, 100);
	Sciana nieprzSc('n', wymPole + 64, 100);
	Sciana przSc('p', wymPole + 96, 100);
	Puste puste(wymPole + 128, 100);
	Skala skala(wymPole, 132);
	Gracz gracz(wymPole + 32, 132);
	Diament dmtZl('l', wymPole + 64, 132);
	Diament dmtNb('b', wymPole + 96, 132);
	Dynamit dynamit(wymPole + 128, 132);

	Obiekt* szablon = &puste;
	Obiekt* tabSzablon[lbObiekt - 2] = { &ziemia, &drzwiZmk, &nieprzSc, &przSc, &puste, &skala, &gracz, &dmtZl, &dmtNb, &dynamit };
	Obiekt* tabEdyt[20][20];


	for (int i = 0; i < 20; i++)
		for (int j = 0; j < 20; j++)
			tabEdyt[i][j] = &puste;

	Przycisk wyj("Wyjdz", true, 0.75*SZER, 0.85*WYS, wlkCzcionki);
	Przycisk szablony("Szablony", false, wymPole, 10, 40);
	Przycisk zapisz("Zapisz  ", true, wymPole + 20, 0.5*WYS, 40);

	Przycisk* przyciski[3] = { &wyj, &szablony, &zapisz };
	const int rozmiar = 3;
#pragma endregion

	bool czyDobrze = false;
	bool pokaz = false;
	float czasRozp = 0;
	float czasOdstepu = 0;
	float czasTrwania = 0;

	al_start_timer(czas);

	int Menu = 0;
	while (!Menu) {
		#pragma region Rysowanie
		al_clear_to_color(al_map_rgb(SZARY));
		al_draw_bitmap(tlo, 0, 0, 0);
		rysujPrzyciski(przyciski, rozmiar);
		rysujEdytor(tabSzablon, tabEdyt);
		al_draw_line(0, wymPole, wymPole, wymPole, al_map_rgb(BRAZOWY), GRUBOSC);
		al_draw_line(wymPole, 0, wymPole, wymPole, al_map_rgb(BRAZOWY), GRUBOSC);
		al_draw_text(czcionkaM, al_map_rgb(BRAZOWY), zapisz.podajX1(), zapisz.podajY2()+40, NULL, "Potrzeba");
		al_draw_text(czcionkaM, al_map_rgb(BRAZOWY), zapisz.podajX1() + 10, zapisz.podajY2() + 70, NULL, "1x Gracz");
		al_draw_text(czcionkaM, al_map_rgb(BRAZOWY), zapisz.podajX1() + 10, zapisz.podajY2() + 100, NULL, "1x Drzwi");

		if (pokaz) {
			const int wspX = 10;
			if (czyDobrze)
				al_draw_text(czcionkaD, al_map_rgb(BRAZOWY), wspX, wyj.podajY1(), 0, "Zapis udany!");
			else
				al_draw_text(czcionkaD, al_map_rgb(BRAZOWY), wspX, wyj.podajY1(), 0, "Nieprawidlowy poziom!");
			czasTrwania = clock() / static_cast<float>(CLOCKS_PER_SEC);
		}

		if ((czasTrwania - czasRozp) > 2)
			pokaz = false; // komunikat o blednym poziomie pojawia sie na 2 sekundy
		#pragma endregion

		al_flip_display();
		al_wait_for_event(kolejka, &zdarzenie);

		czasOdstepu = clock() / static_cast<float>(CLOCKS_PER_SEC);
		al_get_mouse_state(&stanMyszki);

	#pragma region Obs³uga zdarzeñ
		if (zdarzenie.type == ALLEGRO_EVENT_TIMER)
			if (al_mouse_button_down(&stanMyszki, 1)) {
				float xy[2];
				pozycjaMyszki(xy);
				//1. opcja - gracz klikn¹³ w pole do edycji
				if (xy[0] < wymPole && xy[1] < wymPole) {
					int x, y;
					podajWsp(&x, &y);
					tabEdyt[x][y] = szablon;
				}
				else {
					//spr. czy w przycisk Wyjdz
					if (wyj.czyKlik()) {
						break;
					}
					//spr. czy w przycisk Zapisz
					else if (zapisz.czyKlik() && ((czasOdstepu - czasRozp) > 2)) {
						sprawdzPoziom(tabEdyt, &czyDobrze);
						if (czyDobrze)
							zapiszPoziom(tabEdyt);
						pokaz = true;
						czasRozp = clock() / static_cast<float>(CLOCKS_PER_SEC);
						continue;
					}
					int x, y;
					for (int i = 0; i < lbObiekt - 2; i++) {
						x = xy[0] - tabSzablon[i]->pobX();
						y = xy[1] - tabSzablon[i]->pobY();

						if (x <= 32 && x >= 0 && y <= 32 && y >= 0) { //-----wybrany zosta³ jeden z szablonów
							szablon = tabSzablon[i];
						}
					}
				}
			}
#pragma endregion

	}
	al_destroy_font(czcionkaM);
	al_destroy_font(czcionkaD);
	al_destroy_timer(czas);
	al_destroy_event_queue(kolejka);
	al_destroy_bitmap(tlo);
	rysujPrzejscie('z');
}

void Autorzy()
{
	rysujPrzejscie('o');

	ALLEGRO_FONT* czcionka = al_load_ttf_font("Czcionki/YrsaM.ttf", wlkCzcionki, NULL);
	ALLEGRO_BITMAP* tlo = al_load_bitmap("Obrazy/tlo_3.png");
	ALLEGRO_EVENT_QUEUE* kolejka = al_create_event_queue();
	ALLEGRO_EVENT zdarzenie;
	al_register_event_source(kolejka, al_get_mouse_event_source());

	Przycisk wyjdz("Wyjdz", true, 0.75*SZER, 0.85*WYS, wlkCzcionki);
	
	float clockSec = static_cast<float>(CLOCKS_PER_SEC);
	float czasRozpFun = clock() / clockSec;
	const int czasTrwania = 10;
	float stoper;
	int Menu = 0;
	const int wspX = 10;
	while (!Menu)
	{
		stoper = (clock() / clockSec - czasRozpFun) / czasTrwania;
		float przesuwacz = stoper - static_cast<int>(stoper);

		al_clear_to_color(al_map_rgb(SZARY));
		al_draw_bitmap(tlo, 0, 0, 0);
		al_draw_text(czcionka, al_map_rgb(BRAZOWY), wspX, przesuwacz * WYS, NULL, "Mateusz a.k.a Kanji");
		wyjdz.rysuj();
		
		al_flip_display();

		while (al_get_next_event(kolejka, &zdarzenie))
			if (zdarzenie.type == ALLEGRO_EVENT_MOUSE_BUTTON_DOWN && wyjdz.czyKlik())
				Menu = 1;
	}

	al_destroy_event_queue(kolejka);
	al_destroy_bitmap(tlo);
	al_destroy_font(czcionka);
	rysujPrzejscie('z');
}