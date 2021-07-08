#include <stdio.h>
#include <Windows.h>
#include "Szachownica.h"
#include "Rysowanie.h"
#include "Program.h"
#include "Inicjalizacja.h"
#include <time.h>
#include <string.h>

int main()
{
	ALLEGRO_DISPLAY* display = NULL;
	if (!al_init()) {
		al_show_native_message_box(display, "Szachy", "Blad", "Allegro nie chce init...", NULL, ALLEGRO_MESSAGEBOX_ERROR);
	}

	DWORD dwWidth = GetSystemMetrics(SM_CXSCREEN);
	DWORD dwHeight = GetSystemMetrics(SM_CYSCREEN);

	const float szer = dwWidth, wys = dwHeight;
	const float wspProp = szer / 1920.0, wymPole = wspProp * 123, wymSzach = wspProp * 983;
	int tabWym[8][8][2]; // szachownica jest 8x8, ka¿de pole zaczyna siê dwiema wspó³rzêdnymi (0 - x; 1 - y)

	initTabWym(tabWym, szer, wys, wymPole);

	const int fps = 30;
	ALLEGRO_COLOR zolty = al_map_rgb(250, 232, 107);

	al_set_new_display_flags(ALLEGRO_FULLSCREEN);
	display = al_create_display(szer, wys);
	al_clear_to_color(al_map_rgb(100, 130, 170));
	al_set_window_title(display, "Szachy");

	al_init_font_addon();
	al_init_ttf_addon();
	al_init_image_addon();
	al_init_acodec_addon();
	al_init_primitives_addon();

	ALLEGRO_BITMAP* szachow = al_load_bitmap("obrazy/Szachownica.png");
	ALLEGRO_BITMAP* piCz = al_load_bitmap("obrazy/pionek_czarny.png");
	ALLEGRO_BITMAP* piBi = al_load_bitmap("obrazy/pionek_bialy.png");
	ALLEGRO_BITMAP* wiCz = al_load_bitmap("obrazy/wieza_czarna.png");
	ALLEGRO_BITMAP* wiBi = al_load_bitmap("obrazy/wieza_biala.png");
	ALLEGRO_BITMAP* koCz = al_load_bitmap("obrazy/konik_czarny.png");
	ALLEGRO_BITMAP* koBi = al_load_bitmap("obrazy/konik_bialy.png");
	ALLEGRO_BITMAP* goCz = al_load_bitmap("obrazy/goniec_czarny.png");
	ALLEGRO_BITMAP* goBi = al_load_bitmap("obrazy/goniec_bialy.png");
	ALLEGRO_BITMAP* kaCz = al_load_bitmap("obrazy/krolowa_czarna.png");
	ALLEGRO_BITMAP* kaBi = al_load_bitmap("obrazy/krolowa_biala.png");
	ALLEGRO_BITMAP* krCz = al_load_bitmap("obrazy/krol_czarny.png");
	ALLEGRO_BITMAP* krBi = al_load_bitmap("obrazy/krol_bialy.png");

	ALLEGRO_BITMAP* tabObrazy[12] = { piCz, piBi, wiCz, wiBi, koCz, koBi, goCz, goBi, kaCz, kaBi, krCz, krBi };

	ALLEGRO_BITMAP* szachBObr = al_load_bitmap("obrazy/szachbObr.png");
	ALLEGRO_BITMAP* szachCObr = al_load_bitmap("obrazy/szachcObr.png");
	ALLEGRO_BITMAP* matObr = al_load_bitmap("obrazy/matObr.png");
	ALLEGRO_BITMAP* szachB = al_load_bitmap("obrazy/szachb.png");
	ALLEGRO_BITMAP* szachC = al_load_bitmap("obrazy/szachc.png");
	ALLEGRO_BITMAP* szachObr = al_load_bitmap("obrazy/szachObr.png");
	ALLEGRO_BITMAP* mat = al_load_bitmap("obrazy/mat.png");
	ALLEGRO_BITMAP* matC = al_load_bitmap("obrazy/matC.png");
	ALLEGRO_BITMAP* matCObr = al_load_bitmap("obrazy/matCObr.png");

	ALLEGRO_FONT* czcionkaMala = al_load_font("czcionka/orbitron.ttf", wspProp * 24, NULL);
	ALLEGRO_FONT* czcionkaDuza = al_load_font("czcionka/orbitron.ttf", wspProp * 50, NULL);

	al_install_audio();
	al_install_mouse();
	al_install_keyboard();

	ALLEGRO_EVENT_QUEUE* kolejka = al_create_event_queue();
	ALLEGRO_TIMER* czas = al_create_timer(1.0 / fps);

	al_reserve_samples(2);
	ALLEGRO_SAMPLE* muzyka = al_load_sample("muzyka/2.wav");
	ALLEGRO_SAMPLE* alarm = al_load_sample("muzyka/4.wav");

	ALLEGRO_EVENT zdarzenie;
	al_register_event_source(kolejka, al_get_keyboard_event_source());
	al_register_event_source(kolejka, al_get_timer_event_source(czas));
	al_register_event_source(kolejka, al_get_display_event_source(display));
	al_register_event_source(kolejka, al_get_mouse_event_source());

	struct pionek* Szachownica[8][8];
	initSzachWym(Szachownica, szer, wys, wymPole);

	al_start_timer(czas);

	int a, WspX, WspY;
	int gotowe = 0, rys, wyj, odNowa = 1; 
	int licznik, zmiana, Gracz, ruch, rysObr;
	float xKw, yKw;				    //wsp. rysowanego obramowania pola
	int stoper, stoper1, stoper2, nowyCzas, sekunda = 0, minuty = 0;
	int czasS[2];
	int tabWsp[2][2], zbite[2];
	int zbK, zbT;					//kolor i typ zbitej figury
	char czas1[20] = "";
	char czas2[20] = "";
	int czySzachB, czySzachC, czyMatB, czyMatC;
	int WspAtak[2][2];				// 00, 01 - atakowany król, 10, 11 - figura atakuj¹ca
	int xPi;						
	int czyRuch[3][2];				//czy wie¿e albo król chocia¿ raz ju¿ siê ruszyli - do sprawdzenia podczas roszady
	int ukryte[2][8];				

	al_play_sample(muzyka, 1.0, 0, 1.0, ALLEGRO_PLAYMODE_LOOP, 0);

	while (odNowa == 1) { //ustawiane s¹ pocz¹tkowe wartoœci niektórych zmiennych
		initSzachownica(Szachownica, tabObrazy); //szachownica jest "resetowana"
		gotowe = 0, rys = 1, wyj = 0, xPi = -1;
		licznik = zmiana = Gracz = ruch = rysObr = 0;
		stoper1 = stoper2 = minuty = sekunda = 0;
		czasS[0] = czasS[1] = stoper1;
		nowyCzas = clock() / CLOCKS_PER_SEC;
		czySzachB = czySzachC = czyMatB = czyMatC = 0;
		strcpy(czas1, "0:00");
		strcpy(czas2, "0:00");

		for (int a1 = 0; a1 < 3; a1++)
			for (int b = 0; b < 2; b++)
				czyRuch[a1][b] = 0;

		while (!gotowe) {
			zaznaczAtakowane(Szachownica, 0, 0); //zaznaczane s¹ pola atakowane przez figury
			al_wait_for_event(kolejka, &zdarzenie);
			switch (zdarzenie.type) {
			case(ALLEGRO_EVENT_KEY_DOWN):
				if (zdarzenie.keyboard.keycode == ALLEGRO_KEY_ESCAPE) {
					wyj = al_show_native_message_box(display, "Szachy", "Wyjscie z programu", "Czy na pewno chcesz zakonczyc program?", NULL, ALLEGRO_MESSAGEBOX_YES_NO);
					if (wyj == 1) {
						gotowe = 1;
						odNowa = 2;
						break;
					}
				}
				break;
			case(ALLEGRO_EVENT_DISPLAY_CLOSE):
				gotowe = 1;
				odNowa = 2;
				break;
			case(ALLEGRO_EVENT_MOUSE_BUTTON_DOWN):
				if ((zdarzenie.mouse.button & 1) && (zdarzenie.mouse.x >= 0.93*szer && zdarzenie.mouse.y >= 0.969*wys))
					wyj = al_show_native_message_box(display, "Szachy", "Wyjscie z programu", "Czy na pewno chcesz zakonczyc program?", NULL, ALLEGRO_MESSAGEBOX_YES_NO);
				if (wyj == 1) {
					gotowe = 1;
					odNowa = 2;
					break;
				}
				if ((zdarzenie.mouse.button & 1) && (zdarzenie.mouse.x >= 0.25*szer && zdarzenie.mouse.x <= (0.25*szer + wymSzach) && zdarzenie.mouse.y >= 0.04*wys && zdarzenie.mouse.y <= (0.04*wys + wymSzach))) {
					a = ktorePole(zdarzenie.mouse.x, zdarzenie.mouse.y, szer, wys, wymPole); //u¿ytkownik klin¹³ na planszê
					WspX = a / 10;
					WspY = a % 10;

					if (Gracz == 0 && licznik == 0) { //pierwsze klikniêcie Gracza 1
						if (Szachownica[WspX][WspY]->kolor != 0) //Gracz 1 klika nie na swoj¹ figurê
							continue;
					}
					else if (Gracz == 1 && licznik == 0) { //pierwsze klikniêcie Gracza 2
						if (Szachownica[WspX][WspY]->kolor != 1) //Gracz 2 klika nie na swoj¹ figurê
							continue;
					}
					if (licznik == 1) { //Po drugim klikniêciu
						if (tabWsp[0][0] == WspX && tabWsp[1][0] == WspY) {
							rysObr--;
							licznik--;
							continue;
						}
						tabWsp[0][1] = WspX;
						tabWsp[1][1] = WspY;

						//teraz sprawdzana jest poprawnoœæ zamierzonego ruchu
						ruch = czyPoprawny(tabWsp[0][0], tabWsp[0][1], tabWsp[1][0], tabWsp[1][1], Szachownica, Gracz, czyRuch);
						if (ruch) {
							//jeœli jest poprawny, figura jest przemieszczana
							zamienZawartoscPola(tabWsp[0][0], tabWsp[0][1], tabWsp[1][0], tabWsp[1][1], Szachownica, zbite);
						}
							//xPi - wspó³rzêdna x pionka, który dociera na koniec szachownicy
						xPi = zamienPionek(Szachownica, kaBi, kaCz); //zamiana pionek->królowa, gdy znajduje siê na koñcu planszy
						zaznaczAtakowane(Szachownica, 0, 0);

						if (sprSzach(Szachownica, Gracz)) { //czy przypadkiem po wykonaniu ruchu w³asny król nie jest szachowny
							if (ruch) {
								zbK = zbite[0]; //zapamiêtywany jest kolor zbitej figury
								zbT = zbite[1]; //oraz jej typ
								zamienZawartoscPola(tabWsp[0][1], tabWsp[0][0], tabWsp[1][1], tabWsp[1][0], Szachownica, zbite);
								zbite[0] = zbK; //powy¿sza funkcja przywraca figurê na swoje miejsce, lecz nie przywraca zbitej
								zbite[1] = zbT; //dziêki zbK oraz zbT wiemy co zosta³o (nies³usznie) zbite
								przywrFig(Szachownica, zbite, tabWsp[0][1], tabWsp[1][1], tabObrazy); //zbita figura jest przywracana
							}
							if (xPi != -1) //jeœli promocja pionka nie by³a mo¿liwa, przywraca mu siê w³aœciwy typ
								zamienNaPionek(Szachownica, xPi, Gracz, piBi, piCz);
							xPi = -1;
							ruch = 0;
						}
						else
							if (Gracz)
								czySzachC = 0;
							else
								czySzachB = 0;

						//w³asny król nie jest szachowany, sprawdzane jest czy jeden gracz szachuje drugiego
						if (Gracz) { 
							if (sprSzach(Szachownica, 0)) {
								al_play_sample(alarm, 0.2, 0, 1.0, ALLEGRO_PLAYMODE_ONCE, 0);
								czySzachB = 1;
								ktoAtakuje(Szachownica, 0, WspAtak);
								if (sprOtocz(Szachownica, 0)) //sprawdzane czy król jest matowany
									if (!wylaczKryjace(Szachownica, WspAtak, 0, ukryte)) { //oraz czy nie da siê "uratowaæ" króla
										czyMatB = 1;
									}
							}
						}
						else
							if (sprSzach(Szachownica, 1)) {
								al_play_sample(alarm, 0.2, 0, 1.0, ALLEGRO_PLAYMODE_ONCE, 0);
								czySzachC = 1;
								ktoAtakuje(Szachownica, 1, WspAtak);
								if (sprOtocz(Szachownica, 1))
									if (!wylaczKryjace(Szachownica, WspAtak, 1, ukryte))
										czyMatC = 1;
							}
						rysObr--;
						if (!ruch) {
							licznik--;
							continue;
						}
						rys = 1;
						zmiana++;
						poczRuch(Szachownica, czyRuch); //sprawdzane póŸniej przy roszadzie
					}
					if (Szachownica[WspX][WspY]->kolor != -1 && licznik == 0) { //Gracz klikn¹³ na w³asn¹ figurê
						tabWsp[0][0] = WspX;
						tabWsp[1][0] = WspY;
						xKw = tabWym[WspX][WspY][0];
						yKw = tabWym[WspX][WspY][1];
						rysObr++;
						licznik++;
					} 
					//przemieszczono figurê, zosta³ wykonany poprawny ruch
					if (zmiana) {
						zmiana--;
						licznik--;
						if (Gracz == 0)
							Gracz++;
						else
							Gracz--;
					}
				}
				break;
			case(ALLEGRO_EVENT_TIMER):
				rys = 1; //timer umo¿liwia wyœwitlanie czasu na bie¿¹co
				break;
			}
			if (rys) { //tutaj wywo³ywane s¹ funckjê:
				stoperF(czasS, &czas1, &czas2, nowyCzas, &sekunda, Gracz); //odmierzaj¹ce czas
				rysujTekst(czcionkaMala, czcionkaDuza, zolty, czas1, czas2, szer, wys); //oraz rysuj¹ce ró¿ne elementy na ekranie
				rysujPola(Szachownica, szachow, zolty, wspProp, szer, wys, rysObr, xKw, yKw, wymPole);
				rysujSzach(czySzachB, czySzachC, szer, wys, wspProp, szachB, szachC, szachBObr, szachCObr);
				rysujMat(czyMatB, czyMatC, szer, wys, wspProp, mat, matObr, matC, matCObr);
				al_flip_display();
				al_clear_to_color(al_map_rgb(100, 130, 170));
				rys = 0;
			}
			if (czyMatB || czyMatC) { //koniec gry
				al_rest(0.25);
				odNowa = al_show_native_message_box(display, "Szachy", "SZACH-MAT", "Czy chcesz zagrac jeszcze raz?", NULL, ALLEGRO_MESSAGEBOX_YES_NO);
				gotowe = 1;
			}
		}
	}

	for (int i = 0; i < 8; i++)
		for (int j = 0; j < 8; j++)
			free(Szachownica[i][j]);

	al_destroy_bitmap(szachow);

	al_destroy_bitmap(piBi);
	al_destroy_bitmap(piCz);
	al_destroy_bitmap(wiBi);
	al_destroy_bitmap(wiCz);
	al_destroy_bitmap(goBi);
	al_destroy_bitmap(goCz);
	al_destroy_bitmap(koBi);
	al_destroy_bitmap(koCz);
	al_destroy_bitmap(kaBi);
	al_destroy_bitmap(kaCz);
	al_destroy_bitmap(krBi);
	al_destroy_bitmap(krCz);

	al_destroy_bitmap(szachBObr);
	al_destroy_bitmap(szachCObr);
	al_destroy_bitmap(szachC);
	al_destroy_bitmap(szachB);
	al_destroy_bitmap(matObr);
	al_destroy_bitmap(matCObr);
	al_destroy_bitmap(matC);
	al_destroy_bitmap(mat);

	al_destroy_sample(muzyka);
	al_destroy_sample(alarm);
	al_destroy_timer(czas);

	al_destroy_event_queue(kolejka);

	al_destroy_font(czcionkaMala);
	al_destroy_font(czcionkaDuza);

	al_destroy_display(display);

	al_uninstall_keyboard();
	al_uninstall_mouse();
	al_uninstall_audio();
	return 0;
}

void stoperF(int czasS[2], char** czas1, char** czas2, int nowyCzas, int* sekunda, int Gracz)
{
	int stoper = (clock() - nowyCzas) / 1000; //czas w sekundach
	char sek1[20] = "";
	char sek2[20] = "";
	char min1[20] = "";
	char min2[20] = "";
	if (stoper > 0)
		if (stoper - *sekunda == 1) {
			if (Gracz) {
				czasS[1]++;
				sprintf(min2, "%d", czasS[1] / 60);
				sprintf(sek2, "%d", czasS[1] % 60);
				strcat(min2, ":");
				int sekundy2 = czasS[1] % 60;
				if (sekundy2 < 10)
					strcat(min2, "0");
				strcat(min2, sek2);
				strcpy(czas2, min2); //ostateczny zapis czasu gracza 2
			}
			else {
				czasS[0]++;
				sprintf(min1, "%d", czasS[0] / 60);
				sprintf(sek1, "%d", czasS[0] % 60);
				strcat(min1, ":");
				int sekundy1 = czasS[0] % 60;
				if (sekundy1 < 10)
					strcat(min1, "0");
				strcat(min1, sek1);
				strcpy(czas1, min1); //ostateczny zapis czasu gracza 1
			}
			*sekunda = stoper;
		}
		else if (stoper - *sekunda > 1)
			*sekunda = stoper;
}

int zamienPionek(struct pionek* Szachownica[8][8], ALLEGRO_BITMAP* kaBi, ALLEGRO_BITMAP* kaCz)
{ // zamiana pionka na królow¹ <-- promocja
	for (int i = 0; i < 8; i++) {
		if (Szachownica[i][0]->typ == pi) {
			Szachownica[i][0]->typ = ka;
			Szachownica[i][0]->obraz = kaBi;
			return i;
		}
		if (Szachownica[i][7]->typ == pi) {
			Szachownica[i][7]->typ = ka;
			Szachownica[i][7]->obraz = kaCz;
			return i;
		}
	}
	return -1;
}

void zamienNaPionek(struct pionek* Szachownica[8][8], int xPi, int kolor, ALLEGRO_BITMAP* piBi, ALLEGRO_BITMAP* piCz)
{ //gdy promocja siê "nie powiod³a" - zamiana spowrotem na pionka
	if (kolor == 0) {
		Szachownica[xPi][1]->typ = pi;
		Szachownica[xPi][1]->obraz = piBi;
		return;
	}
	if (kolor == 1) {
		Szachownica[xPi][6]->typ = pi;
		Szachownica[xPi][6]->obraz = piCz;
	}
}