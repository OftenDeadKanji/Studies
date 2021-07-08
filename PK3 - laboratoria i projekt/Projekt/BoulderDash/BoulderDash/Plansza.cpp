#include "pch.h"

Plansza::Plansza()
{}

Plansza::~Plansza()
{
	usun();
}

void Plansza::dodajPuste(Puste& ob)
{
	Puste* nowy = new Puste(ob);
	tabPuste[lbPuste++] = nowy;
}

void Plansza::dodajZiemia(Ziemia& ob)
{
	Ziemia* nowy = new Ziemia(ob);
	tabZiemia[lbZiemia++] = nowy;
}

void Plansza::dodajSkala(Skala& ob)
{
	Skala* nowy = new Skala(ob);
	tabSkala[lbSkala++] = nowy;
}

void Plansza::dodajSciana(Sciana& ob)
{
	Sciana* nowy = new Sciana(ob);
	tabSciana[lbSciana++] = nowy;
}

void Plansza::dodajDrzwi(Drzwi& ob)
{
	Drzwi* nowy = new Drzwi(ob);
	tabDrzwi[lbDrzwi++] = nowy;
}

void Plansza::dodajGracz(Gracz& ob)
{
	Gracz* nowy = new Gracz(ob);
	tabGracz[lbGracz++] = nowy;
}

void Plansza::dodajDiament(Diament& ob)
{
	Diament* nowy = new Diament(ob);
	tabDiament[lbDiament++] = nowy;
}

void Plansza::dodajDynamit(Dynamit& ob)
{
	Dynamit* nowy = new Dynamit(ob);
	tabDynamit[lbDynamit++] = nowy;
}

void Plansza::dodajAktDynamit(AktDynamit& ob)
{
	AktDynamit* nowy = new AktDynamit(ob);
	tabAktDynamit[lbAktDynamit++] = nowy;
}

void Plansza::wczytajPoziom(int nrPoz)
{
	//funkcja na podstawie zawartosci pliku wczytuje dany poziom
	Ziemia ziemia;
	Drzwi drzwiOtw('o');
	Drzwi drzwiZmk('z');
	Sciana nieprzSc('n');
	Sciana przSc('p');
	Puste puste;
	Skala skala;
	Gracz gracz;
	Diament dmtZl('l');
	Diament dmtNb('b');
	Dynamit dynamit;
	AktDynamit aktDynamit;

	ostringstream konwersja;
	konwersja << nrPoz;
	ifstream plik;
	plik.open("Poziomy/" + konwersja.str() + ".dat", ios::binary | ios::in);
	string obiekty;
	for (int i = 0; i < 20; i++) {
		getline(plik, obiekty);
		for (int j = 0; j < 20; j++)
			switch (obiekty[j]) {
			case '0':
				puste.zmienX(j);
				puste.zmienY(i);
				dodajPuste(puste);
				Poziom[j][i] = tabPuste[lbPuste - 1];
				break;
			case 'g':
				ziemia.zmienX(j);
				ziemia.zmienY(i);
				dodajZiemia(ziemia);
				Poziom[j][i] = tabZiemia[lbZiemia - 1];
				break;
			case 's':
				skala.zmienX(j);
				skala.zmienY(i);
				dodajSkala(skala);
				Poziom[j][i] = tabSkala[lbSkala - 1];
				break;
			case 'p':
				przSc.zmienX(j);
				przSc.zmienY(i);
				dodajSciana(przSc);
				Poziom[j][i] = tabSciana[lbSciana - 1];
				break;
			case 'n':
				nieprzSc.zmienX(j);
				nieprzSc.zmienY(i);
				dodajSciana(nieprzSc);
				Poziom[j][i] = tabSciana[lbSciana - 1];
				break;
			case 'o':
				drzwiOtw.zmienX(j);
				drzwiOtw.zmienY(i);
				dodajDrzwi(drzwiOtw);
				Poziom[j][i] = tabDrzwi[lbDrzwi - 1];
				break;
			case 'z':
				drzwiZmk.zmienX(j);
				drzwiZmk.zmienY(i);
				dodajDrzwi(drzwiZmk);
				Poziom[j][i] = tabDrzwi[lbDrzwi - 1];
				break;
			case 'r':
				gracz.zmienX(j);
				gracz.zmienY(i);
				dodajGracz(gracz);
				Poziom[j][i] = tabGracz[lbGracz - 1];
				break;
			case 'b':
				dmtNb.zmienX(j);
				dmtNb.zmienY(i);
				dodajDiament(dmtNb);
				Poziom[j][i] = tabDiament[lbDiament - 1];
				break;
			case 'l':
				dmtZl.zmienX(j);
				dmtZl.zmienY(i);
				dodajDiament(dmtZl);
				Poziom[j][i] = tabDiament[lbDiament - 1];
				break;
			case 't':
				dynamit.zmienX(j);
				dynamit.zmienY(i);
				dodajDynamit(dynamit);
				Poziom[j][i] = tabDynamit[lbDynamit - 1];
				break;
			}
	}
	plik.close();
}

void Plansza::rysuj()
{
	for (int i = 0; i < 20; i++)
		for (int j = 0; j < 20; j++)
			Poziom[i][j]->rysuj();
}

void Plansza::usun()
{
	while (lbAktDynamit)
		delete tabAktDynamit[--lbAktDynamit];
	while (lbDiament)
		delete tabDiament[--lbDiament];
	while (lbDrzwi)
		delete tabDrzwi[--lbDrzwi];
	while (lbDynamit)
		delete tabDynamit[--lbDynamit];
	while (lbGracz)
		delete tabGracz[--lbGracz];
	while (lbPuste)
		delete tabPuste[--lbPuste];
	while (lbSciana)
		delete tabSciana[--lbSciana];
	while (lbSkala)
		delete tabSkala[--lbSkala];
	while (lbZiemia)
		delete tabZiemia[--lbZiemia];
}

void Plansza::zmienTrybDyn()
{
	for (int i = 0; i < lbAktDynamit; i++) {
		tabAktDynamit[i]->zmienObraz();
		if (tabAktDynamit[i]->podajTryb() == 4)
			tabAktDynamit[i]->wybuch(tabGracz[0]);
		else if (tabAktDynamit[i]->podajTryb() == 5) {
			//dodajhPuste
			int x = tabAktDynamit[i]->pobX();
			int y = tabAktDynamit[i]->pobY();
			Puste puste;
			if (x - 1 >= 0) {
				if (y - 1 >= 0 && Poziom[x - 1][y - 1]->czyZniszczyc()) {
					puste.zmienX(x - 1);
					puste.zmienY(y - 1);
					dodajPuste(puste);
					Poziom[x - 1][y - 1] = tabPuste[lbPuste - 1];
				}
				if (Poziom[x - 1][y]->czyZniszczyc()) {
					puste.zmienX(x - 1);
					puste.zmienY(y);
					dodajPuste(puste);
					Poziom[x - 1][y] = tabPuste[lbPuste - 1];
				}
				if (y + 1 <= 19 && Poziom[x - 1][y + 1]->czyZniszczyc()) {
					puste.zmienX(x - 1);
					puste.zmienY(y + 1);
					dodajPuste(puste);
					Poziom[x - 1][y + 1] = tabPuste[lbPuste - 1];
				}
			}
			if (y - 1 >= 0 && Poziom[x][y - 1]->czyZniszczyc()) {
				puste.zmienX(x);
				puste.zmienY(y - 1);
				dodajPuste(puste);
				Poziom[x][y - 1] = tabPuste[lbPuste - 1];
			}
			puste.zmienX(x);
			puste.zmienY(y);
			dodajPuste(puste);
			Poziom[x][y] = tabPuste[lbPuste - 1];
			if (y + 1 <= 19 && Poziom[x][y + 1]->czyZniszczyc()) {
				puste.zmienX(x);
				puste.zmienY(y + 1);
				dodajPuste(puste);
				Poziom[x][y + 1] = tabPuste[lbPuste - 1];
			}
			if (x + 1 <= 19) {
				if (y - 1 >= 0 && Poziom[x + 1][y - 1]->czyZniszczyc()) {
					puste.zmienX(x + 1);
					puste.zmienY(y - 1);
					dodajPuste(puste);
					Poziom[x + 1][y - 1] = tabPuste[lbPuste - 1];
				}
				if (Poziom[x + 1][y]->czyZniszczyc()) {
					puste.zmienX(x + 1);
					puste.zmienY(y);
					dodajPuste(puste);
					Poziom[x + 1][y] = tabPuste[lbPuste - 1];
				}
				if (y + 1 <= 19 && Poziom[x + 1][y + 1]->czyZniszczyc()) {
					puste.zmienX(x + 1);
					puste.zmienY(y + 1);
					dodajPuste(puste);
					Poziom[x + 1][y + 1] = tabPuste[lbPuste - 1];
				}
			}
		}
	}
}

void Plansza::obslugaSpadania2(Obiekt * tab[20][20], mutex tabMut[20][20], int x, int y)
{
	tab[x][y]->spadanie(tab, tabMutex);
}

void Plansza::graj()
{
	rysujPrzejscie('o');

#pragma region Obiekty
	/*Plansza plansza;

	Ziemia ziemia;
	Drzwi drzwiOtw('o');
	Drzwi drzwiZmk('z');
	Sciana nieprzSc('n');
	Sciana przSc('p');
	Puste puste;
	Skala skala;
	Gracz gracz;
	Diament dmtZl('l');
	Diament dmtNb('b');
	Dynamit dynamit;
	AktDynamit aktDynamit;

	Obiekt* szablony[lbObiekt] = { &puste, &ziemia, &skala, &przSc, &nieprzSc, &drzwiOtw, &drzwiZmk, &gracz, &dmtNb, &dmtZl, &dynamit, &aktDynamit };*/
	Przycisk zakoncz("Zakoncz", true, 0.3*SZER, 0.85*WYS, wlkCzcionki);
	Przycisk pkt("0", false, wymPole + 10, 0.125*WYS, wlkCzcionki - 20);
#pragma endregion

#pragma region Allegro
	ALLEGRO_EVENT_QUEUE* kolejka = al_create_event_queue();
	ALLEGRO_EVENT zdarzenie;
	const float FPS = 60.0;
	ALLEGRO_TIMER* czas = al_create_timer(1.0 / FPS);
	ALLEGRO_KEYBOARD_STATE stanKlaw;

	ALLEGRO_BITMAP* tlo = al_load_bitmap("Obrazy/tlo_2.png");
	ALLEGRO_SAMPLE* wygrana = al_load_sample("muzyka/wygrana.wav");
	ALLEGRO_FONT* czcionka = al_load_ttf_font("Czcionki/YrsaM.ttf", wlkCzcionki - 40, NULL);

	al_register_event_source(kolejka, al_get_mouse_event_source());
	al_register_event_source(kolejka, al_get_keyboard_event_source());
	al_register_event_source(kolejka, al_get_timer_event_source(czas));
#pragma endregion

#pragma region Analiza poziomu
	//int xGracz = tabGracz[0]->pobX();
	//int yGracz = tabGracz[0]->pobY();
	int xDrzwi = tabDrzwi[0]->pobX();
	int	yDrzwi = tabDrzwi[0]->pobY();
	int maxPkt = 0;
	mutex czyDzialac[20][20];
	int lbDyn = 0;
	int aktDyn[4][2] = { -1,-1,-1,-1,-1,-1,-1,-1 };
	int trybDyn[4] = { 1,1,1,1 };

	for (int i = 0; i < lbDiament; i++)
		if (tabDiament[i]->podajZapis() == 'b')
			maxPkt += 1;
		else
			maxPkt += 2;
	tabGracz[0]->zmienPkt(0.8*maxPkt);
	//analizujPoziom(Poziom, &xDrzwi, &yDrzwi, &xGracz, &yGracz, &maxPkt, czyDzialac);
#pragma endregion

#pragma region Elementy wielow¹tkowoœci
	//mutex tabMutex[20][20];
	//te mutexy odpowiedzialne sa za blokowanie przejsc spadajacych obiektow na dane pole
	//wazne, aby np. dwie skaly nie spadly w to samo miesca - jedna spada z gory, druga zeslizgiwuje sie
	tabMutex[tabGracz[0]->pobX()][tabGracz[0]->pobY()].lock();

	thread tabWatk[MAXOBIEKTOW];
	/*kazde pole na planszy na swoj wlasny watek - wymagane do spadania, gdyz w tej funkcji istanieje dokladnie
	po jednym obiekcie z danej klasy, ktory potem wyswietlany jest w roznych miejscach*/

	for (int i = 0; i < 20; i++)
		for (int j = 0; j < 20; j++)
			Poziom[i][j]->zmienTryb(false);
	/*Obiekt* Poziom2[20][20];
	mutex tabMutex2[20][20];*/
	for (int i = 0; i < lbSkala + lbDiament; i++) {
		if (i < lbSkala) {
			tabWatk[i] = tabSkala[i]->spadanieWatek(Poziom, tabMutex);
			//tabWatk[i] = thread(sk.spadanie, Poziom, tabMutex);
			//tabWatk[i] = thread(obslugaSpadania2, Poziom, tabMutex, tabSkala[i]->pobX(), tabSkala[i]->pobY());
		}
		else
			tabWatk[i] = tabDiament[i-lbSkala]->spadanieWatek(Poziom, tabMutex);
			//tabWatk[i - lbSkala] = thread(tabDiament[i - lbSkala]->spadanie);
	}

	/*for (int i = 0; i < 20; i++)
		for (int j = 0; j < 20; j++)
			tabWatk[i][j] = thread(obslugaSpadania, Poziom, tabMutex, i, j);*/

#pragma endregion

#pragma region Dodatkowe zmienne
	float odstepCzasu = 0;
	float czasRozp = 0;

	float czasOdswiez = 0;
	float czasRozpOdswiez = 0;

	float czasDynamit = 0;
	float czasRozpOdlicz = 0;

	ostringstream konwersja;
//	int posPkt = maxPkt * 0.8; //tyle trzeba zebrac punktow, aby przejsc poziom
	int wyjscie = 0;
	bool czyOtwarto = 0;
	bool czyEksploz = false;
#pragma endregion

#pragma region Rozgrywanie poziomu
	al_start_timer(czas);
	while (!wyjscie) {

#pragma region Rysowanie
		al_clear_to_color(al_map_rgb(SZARY));
		al_draw_bitmap(tlo, 0, 0, 0);
		al_draw_line(0, wymPole, wymPole, wymPole, al_map_rgb(BRAZOWY), GRUBOSC);
		al_draw_line(wymPole, 0, wymPole, wymPole, al_map_rgb(BRAZOWY), GRUBOSC);

		if (tabGracz[0]->podajPkt() == 0 && !czyOtwarto) {
			tabDrzwi[0]->otworz();
			czyOtwarto = 1;
		}

		konwersja.str("");
		konwersja << tabGracz[0]->podajPkt();
		pkt.zmianWyraz(konwersja.str());

		pkt.rysuj();
		zakoncz.rysuj();
		rysujPomocnicze(&pkt, czcionka);
		rysuj();
		for (int i = 0; i < lbAktDynamit; i++)
			tabAktDynamit[i]->rysuj(Poziom);
		al_flip_display();
#pragma endregion

#pragma region Odœwie¿anie

		if (czasRozp == 0)
			czasRozp = clock() / static_cast<float>(CLOCKS_PER_SEC);
		odstepCzasu = clock() / static_cast<float>(CLOCKS_PER_SEC) - czasRozp;

		if (czasRozpOdlicz == 0)
			czasRozpOdlicz = clock() / static_cast<float>(CLOCKS_PER_SEC);
		czasDynamit = clock() / static_cast<float>(CLOCKS_PER_SEC) - czasRozpOdlicz;

		if (czasDynamit > 0.5) {
			zmienTrybDyn();
			czasRozpOdlicz = 0;
		}
#pragma endregion

#pragma region Zwyciêstwo lub pora¿ka
		if (tabGracz[0]->podajPkt() == 0 && tabGracz[0]->pobX() == xDrzwi && tabGracz[0]->pobY() == yDrzwi) {
			al_draw_bitmap(tabDrzwi[0]->pobObraz(), tabGracz[0]->pobX() * wymObiekt, tabGracz[0]->pobY() * wymObiekt, NULL);
			al_play_sample(wygrana, 1.0, 0.0, 1.0, ALLEGRO_PLAYMODE_ONCE, NULL);
			al_rest(1.0);
			wyjscie = 1;
		}
		if (tabGracz[0]->podajStan()) {
			al_rest(1.0);
			wyjscie = 1;
		}
#pragma endregion

#pragma region Obs³uga zdarzeñ
		while (al_get_next_event(kolejka, &zdarzenie)) {
			switch (zdarzenie.type) {
			case(ALLEGRO_EVENT_MOUSE_BUTTON_DOWN):
				if (zakoncz.czyKlik())
					wyjscie = 1;
				break;
#pragma region Wciœniêty klawisz
			case(ALLEGRO_EVENT_TIMER):
				al_get_keyboard_state(&stanKlaw);
#pragma region Strza³ka w dó³
				if (al_key_down(&stanKlaw, ALLEGRO_KEY_DOWN)) {
					if (odstepCzasu < 0.3)
						break;
					czasRozp = 0;
					if (tabGracz[0]->pobY() < 19)
						if (Poziom[tabGracz[0]->pobX()][tabGracz[0]->pobY() + 1]->czyWejsc() && tabMutex[tabGracz[0]->pobX()][tabGracz[0]->pobY() + 1].try_lock())
							tabGracz[0]->ruchDol(this, Poziom, tabPuste, lbPuste, Poziom[tabGracz[0]->pobX()][tabGracz[0]->pobY() + 1], tabMutex);
							/*switch (Poziom[tabGracz[0]->pobX()][yGracz + 1]->podajZapis()) {
					case 's':
						tabMutex[tabGracz[0]->pobX()][yGracz + 1].unlock();
						break;
					case 'b':
						if (tabGracz[0]->podajPkt() - 1 >= 0)
							posPkt -= 1;
						Poziom[tabGracz[0]->pobX()][yGracz + 1]->odtworzDzwiek();
						Poziom[tabGracz[0]->pobX()][yGracz] = &puste;
						Poziom[tabGracz[0]->pobX()][++yGracz] = &gracz;
						tabMutex[tabGracz[0]->pobX()][yGracz - 1].unlock();
						break;
					case 'l':
						for (int i = 0; i < 2; i++)
							if (posPkt - 1 >= 0)
								posPkt -= 1;
						Poziom[tabGracz[0]->pobX()][yGracz + 1]->odtworzDzwiek();
						Poziom[tabGracz[0]->pobX()][yGracz] = &puste;
						Poziom[tabGracz[0]->pobX()][++yGracz] = &gracz;
						tabMutex[tabGracz[0]->pobX()][yGracz - 1].unlock();
						break;
					case 't':
						lbDyn++;
						Poziom[tabGracz[0]->pobX()][yGracz] = &puste;
						Poziom[tabGracz[0]->pobX()][++yGracz] = &gracz;
						tabMutex[tabGracz[0]->pobX()][yGracz - 1].unlock();
						break;
					case 'g':
						Poziom[tabGracz[0]->pobX()][yGracz + 1]->odtworzDzwiek();
						Poziom[tabGracz[0]->pobX()][yGracz] = &puste;
						Poziom[tabGracz[0]->pobX()][++yGracz] = &gracz;
						tabMutex[tabGracz[0]->pobX()][yGracz - 1].unlock();
						break;
					default:
						Poziom[tabGracz[0]->pobX()][yGracz] = &puste;
						Poziom[tabGracz[0]->pobX()][++yGracz] = &gracz;
						tabMutex[tabGracz[0]->pobX()][yGracz - 1].unlock();
						break;
					}*/
					break;
				}
#pragma endregion
#pragma region Strza³ka w górê
				if (al_key_down(&stanKlaw, ALLEGRO_KEY_UP)) {
					if (odstepCzasu < 0.3)
						break;
					czasRozp = 0;
					if (tabGracz[0]->pobY() > 0)
						if (Poziom[tabGracz[0]->pobX()][tabGracz[0]->pobY() - 1]->czyWejsc() && tabMutex[tabGracz[0]->pobX()][tabGracz[0]->pobY() - 1].try_lock())
							tabGracz[0]->ruchGora(this, Poziom, tabPuste, lbPuste, Poziom[tabGracz[0]->pobX()][tabGracz[0]->pobY() - 1], tabMutex);
							/*switch (Poziom[tabGracz[0]->pobX()][yGracz - 1]->podajZapis()) {
							case 's':
								tabMutex[tabGracz[0]->pobX()][yGracz - 1].unlock();
								break;
							case 'b':
								if (posPkt - 1 >= 0)
									posPkt -= 1;
								Poziom[tabGracz[0]->pobX()][yGracz - 1]->odtworzDzwiek();
								Poziom[tabGracz[0]->pobX()][yGracz] = &puste;
								Poziom[tabGracz[0]->pobX()][--yGracz] = &gracz;
								tabMutex[tabGracz[0]->pobX()][yGracz + 1].unlock();
								break;
							case 'l':
								for (int i = 0; i < 2; i++)
									if (posPkt - 1 >= 0)
										posPkt -= 1;
								Poziom[tabGracz[0]->pobX()][yGracz - 1]->odtworzDzwiek();
								Poziom[tabGracz[0]->pobX()][yGracz] = &puste;
								Poziom[tabGracz[0]->pobX()][--yGracz] = &gracz;
								tabMutex[tabGracz[0]->pobX()][yGracz + 1].unlock();
								break;
							case 't':
								lbDyn++;
								Poziom[tabGracz[0]->pobX()][yGracz] = &puste;
								Poziom[tabGracz[0]->pobX()][--yGracz] = &gracz;
								tabMutex[tabGracz[0]->pobX()][yGracz + 1].unlock();
								break;
							case 'g':
								Poziom[tabGracz[0]->pobX()][yGracz - 1]->odtworzDzwiek();
								Poziom[tabGracz[0]->pobX()][yGracz] = &puste;
								Poziom[tabGracz[0]->pobX()][--yGracz] = &gracz;
								tabMutex[tabGracz[0]->pobX()][yGracz + 1].unlock();
								break;
							default:
								Poziom[tabGracz[0]->pobX()][yGracz] = &puste;
								Poziom[tabGracz[0]->pobX()][--yGracz] = &gracz;
								tabMutex[tabGracz[0]->pobX()][yGracz + 1].unlock();
								break;
							}*/

					break;
				}
#pragma endregion
#pragma region Strza³ka w lewo
				if (al_key_down(&stanKlaw, ALLEGRO_KEY_LEFT)) {
					if (odstepCzasu < 0.3)
						break;
					czasRozp = 0;
					if (tabGracz[0]->pobX() > 0) {
						if (Poziom[tabGracz[0]->pobX() - 1][tabGracz[0]->pobY()]->czyWejsc() && tabMutex[tabGracz[0]->pobX() - 1][tabGracz[0]->pobY()].try_lock()) {
							tabGracz[0]->ruchLewo(this, Poziom, tabPuste, lbPuste, Poziom[tabGracz[0]->pobX() - 1][tabGracz[0]->pobY()], tabMutex);
							/*switch (Poziom[tabGracz[0]->pobX() - 1][yGracz]->podajZapis()) {
							case 's':
								if (tabGracz[0]->pobX() - 2 > 0 && (Poziom[tabGracz[0]->pobX() - 2][yGracz]->podajZapis() == '0')) {
									Poziom[tabGracz[0]->pobX() - 2][yGracz] = &skala;
									Poziom[tabGracz[0]->pobX()][yGracz] = &puste;
									Poziom[--tabGracz[0]->pobX()][yGracz] = &gracz;
									tabMutex[tabGracz[0]->pobX() + 1][yGracz].unlock();
								}
								else
									tabMutex[tabGracz[0]->pobX() - 1][yGracz].unlock();
								break;
							case 'b':
								if (posPkt - 1 >= 0)
									posPkt -= 1;
								Poziom[tabGracz[0]->pobX() - 1][yGracz]->odtworzDzwiek();
								Poziom[tabGracz[0]->pobX()][yGracz] = &puste;
								Poziom[--tabGracz[0]->pobX()][yGracz] = &gracz;
								tabMutex[tabGracz[0]->pobX() + 1][yGracz].unlock();
								break;
							case 'l':
								for (int i = 0; i < 2; i++)
									if (posPkt - 1 >= 0)
										posPkt -= 1;
								Poziom[tabGracz[0]->pobX() - 1][yGracz]->odtworzDzwiek();
								Poziom[tabGracz[0]->pobX()][yGracz] = &puste;
								Poziom[--tabGracz[0]->pobX()][yGracz] = &gracz;
								tabMutex[tabGracz[0]->pobX() + 1][yGracz].unlock();
								break;
							case 't':
								lbDyn++;
								Poziom[tabGracz[0]->pobX()][yGracz] = &puste;
								Poziom[--tabGracz[0]->pobX()][yGracz] = &gracz;
								tabMutex[tabGracz[0]->pobX() + 1][yGracz].unlock();
								break;
							case 'g':
								Poziom[tabGracz[0]->pobX() - 1][yGracz]->odtworzDzwiek();
								Poziom[tabGracz[0]->pobX()][yGracz] = &puste;
								Poziom[--tabGracz[0]->pobX()][yGracz] = &gracz;
								tabMutex[tabGracz[0]->pobX() + 1][yGracz].unlock();
								break;
							default:
								Poziom[tabGracz[0]->pobX()][yGracz] = &puste;
								Poziom[--tabGracz[0]->pobX()][yGracz] = &gracz;
								tabMutex[tabGracz[0]->pobX() + 1][yGracz].unlock();
								break;
							}
							*/
						}
					}
					break;
				}
#pragma endregion
#pragma region Strza³ka w prawo
				if (al_key_down(&stanKlaw, ALLEGRO_KEY_RIGHT)) {
					if (odstepCzasu < 0.3)
						break;
					czasRozp = 0;
					if (tabGracz[0]->pobX() < 19) {
						if (Poziom[tabGracz[0]->pobX() + 1][tabGracz[0]->pobY()]->czyWejsc() && tabMutex[tabGracz[0]->pobX() + 1][tabGracz[0]->pobY()].try_lock()) {
							tabGracz[0]->ruchPrawo(this, Poziom, tabPuste, lbPuste, Poziom[tabGracz[0]->pobX() + 1][tabGracz[0]->pobY()], tabMutex);
							/*switch (Poziom[xGracz + 1][yGracz]->podajZapis()) {
							case 's':
								if (xGracz + 2 < 19 && (Poziom[xGracz + 2][yGracz]->podajZapis() == '0')) {
									Poziom[xGracz + 2][yGracz] = &skala;
									Poziom[xGracz][yGracz] = &puste;
									Poziom[++xGracz][yGracz] = &gracz;
									tabMutex[xGracz - 1][yGracz].unlock();
								}
								else
									tabMutex[xGracz + 1][yGracz].unlock();
								break;
							case 'b':
								if (posPkt - 1 >= 0)
									posPkt -= 1;
								Poziom[xGracz + 1][yGracz]->odtworzDzwiek();
								Poziom[xGracz][yGracz] = &puste;
								Poziom[++xGracz][yGracz] = &gracz;
								tabMutex[xGracz - 1][yGracz].unlock();
								break;
							case 'l':
								for (int i = 0; i < 2; i++)
									if (posPkt - 1 >= 0)
										posPkt -= 1;
								Poziom[xGracz + 1][yGracz]->odtworzDzwiek();
								Poziom[xGracz][yGracz] = &puste;
								Poziom[++xGracz][yGracz] = &gracz;
								tabMutex[xGracz - 1][yGracz].unlock();
								break;
							case 't':
								lbDyn++;
								Poziom[xGracz][yGracz] = &puste;
								Poziom[++xGracz][yGracz] = &gracz;
								tabMutex[xGracz - 1][yGracz].unlock();
								break;
							case 'g':
								Poziom[xGracz + 1][yGracz]->odtworzDzwiek();
								Poziom[xGracz][yGracz] = &puste;
								Poziom[++xGracz][yGracz] = &gracz;
								tabMutex[xGracz - 1][yGracz].unlock();
								break;
							default:
								Poziom[xGracz][yGracz] = &puste;
								Poziom[++xGracz][yGracz] = &gracz;
								tabMutex[xGracz - 1][yGracz].unlock();
								break;
							}
							*/
						}
					}
					break;
				}
#pragma endregion
#pragma region Prawy CTRL
				if (al_key_down(&stanKlaw, ALLEGRO_KEY_RCTRL)) {
					if (odstepCzasu < 0.3)
						break;
					czasRozp = 0;
					if (tabGracz[0]->podajLbDyn() > 0 && Poziom[tabGracz[0]->pobX()][tabGracz[0]->pobY()]->podajZapis() != 't') {
						tabGracz[0]->zmniejszLbDyn();
						AktDynamit nowy(tabGracz[0]->pobX(), tabGracz[0]->pobY());
						dodajAktDynamit(nowy);
						Poziom[tabGracz[0]->pobX()][tabGracz[0]->pobY()] = tabAktDynamit[lbAktDynamit - 1];
						/*for (int i = 0; i < 4; i++)
							if (aktDyn[i][0] == -1) {
								aktDyn[i][0] = xGracz;
								aktDyn[i][1] = yGracz;
								Poziom[xGracz][yGracz] = &aktDynamit;
								break;
							}*/
					}
					break;
				}
#pragma endregion
#pragma endregion
			}
		}
#pragma endregion
	}
#pragma endregion

#pragma region Zakoñczenie funkcji
	for (int i = 0; i < 20; i++)
		for (int j = 0; j < 20; j++)
			Poziom[i][j]->zmienTryb(true);

	//odblokowywanie wszystkich Mutexów
	for (int i = 0; i < 20; i++)
		for (int j = 0; j < 20; j++) {
			tabMutex[i][j].try_lock();
			tabMutex[i][j].unlock();
			czyDzialac[i][j].try_lock();
			czyDzialac[i][j].unlock();
		}

	for (int i = 0; i < lbSkala + lbDiament; i++)
		tabWatk[i].detach();

	al_destroy_font(czcionka);
	al_destroy_sample(wygrana);
	al_destroy_bitmap(tlo);
	al_destroy_timer(czas);
	al_destroy_event_queue(kolejka);
#pragma endregion

	rysujPrzejscie('z');

}