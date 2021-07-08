#include "pch.h"

void rysujBrame()
{
	ALLEGRO_BITMAP* brama = al_load_bitmap("Obrazy/Brama.png");
	al_draw_bitmap(brama, 0, 0, 0);
	al_destroy_bitmap(brama);
}

void rysujPrzejscie(char tryb)
{
	ALLEGRO_BITMAP* bramaP = al_load_bitmap("Obrazy/BramaP.png");
	ALLEGRO_BITMAP* bramaL = al_load_bitmap("Obrazy/BramaL.png");
	ALLEGRO_BITMAP* tlo = al_load_bitmap("Obrazy/tlo_2.png");
	const float lbKrokow = 416.0;
	const float szybkosc = 0.85;
	const int rozmiarObrazX = 512;
	const int rozmiarObrazY = 800;
	if (tryb == 'z') {
		for (int i = 0; i < lbKrokow; i++) {
			al_draw_bitmap(bramaP, SZER - i, 0, 0); //x: 0-416
			al_draw_bitmap_region(bramaL, rozmiarObrazX - i, 0, rozmiarObrazX, rozmiarObrazY, 0, 0, 0); // x: 0-416
			al_flip_display();
			al_rest(szybkosc / lbKrokow);
		}
		al_rest(0.5);
	}
	else {
		for (int i = lbKrokow; i > 0; i--) {
			al_draw_bitmap(tlo, 0, 0, 0);
			al_draw_bitmap(bramaP, SZER - i, 0, 0); //x: 0-416
			al_draw_bitmap_region(bramaL, rozmiarObrazX - i, 0, rozmiarObrazX, rozmiarObrazY, 0, 0, 0); // x: 0-416
			al_flip_display();
			al_rest(szybkosc / lbKrokow);
		}
	}
	al_destroy_bitmap(tlo);
	al_destroy_bitmap(bramaL);
	al_destroy_bitmap(bramaP);
}

void rysujEdytor(Obiekt* tabSzb[], Obiekt* tabEdt[][20])
{
	for (int i = 0; i < lbObiekt - 2; i++)
		al_draw_bitmap(tabSzb[i]->pobObraz(), tabSzb[i]->pobX(), tabSzb[i]->pobY(), 0);
	rysujPoziom(tabEdt);
}

void rysujPoziom(Obiekt* tabPoz[][20])
{
	for (int i = 0; i < 20; i++)
		for (int j = 0; j < 20; j++)
			al_draw_bitmap(tabPoz[i][j]->pobObraz(), i * 32, j * 32, 0);
}

void rysujPrzyciski(Przycisk* tab[], int rozmiar)
{
	for (int i = 0; i < rozmiar; i++)
		tab[i]->rysuj();
}

void rysujPomocnicze(Przycisk* pkt, ALLEGRO_FONT* czcionka)
{
	al_draw_text(czcionka, al_map_rgb(BRAZOWY), pkt->podajX1(), pkt->podajY1() - 50, 0, "Wymagane");
	al_draw_text(czcionka, al_map_rgb(BRAZOWY), pkt->podajX1(), pkt->podajY1() - 25, 0, "punkty:");
	al_draw_text(czcionka, al_map_rgb(BRAZOWY), pkt->podajX1(), pkt->podajY2() + 50, 0, "Sterowanie:");
	al_draw_text(czcionka, al_map_rgb(BRAZOWY), pkt->podajX1(), pkt->podajY2() + 125, 0, "Ruch -");
	al_draw_text(czcionka, al_map_rgb(BRAZOWY), pkt->podajX1() + 10, pkt->podajY2() + 150, 0, "strzalki");
	al_draw_text(czcionka, al_map_rgb(BRAZOWY), pkt->podajX1(), pkt->podajY2() + 200, 0, "Dynamit -");
	al_draw_text(czcionka, al_map_rgb(BRAZOWY), pkt->podajX1() + 10, pkt->podajY2() + 225, 0, "prawy Ctrl");
}