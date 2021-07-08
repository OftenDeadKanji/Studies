#include "rysowanie.h"

void rysujTekst(ALLEGRO_FONT* czcionkaMala, ALLEGRO_FONT* czcionkaDuza, ALLEGRO_COLOR zolty, char* czas1, char* czas2, int szer, int wys)
{
	al_draw_text(czcionkaMala, zolty, 0.93*szer, 0.01*wys, ALLEGRO_ALIGN_LEFT, "Szachy"); 
	al_draw_text(czcionkaMala, zolty, 0.93*szer, 0.969*wys, NULL, "Wyjscie");
	al_draw_text(czcionkaDuza, zolty, 0.17*szer, 0.9*wys, NULL, czas1);
	al_draw_text(czcionkaDuza, zolty, 0.77*szer, 0.05*wys, NULL, czas2);
}

void rysujPola(struct pionek* Szachownica[8][8], ALLEGRO_BITMAP* szachow, ALLEGRO_COLOR zolty, const float Wsp, int szer, int wys, int rysObr, float xKw, float yKw, int wymPole) 
{
	al_draw_scaled_bitmap(szachow, 0, 0, 983, 983, 0.25*szer, 0.04*wys, Wsp * 983, Wsp * 983, NULL); //rysowanie szachownicy
	for (int i = 0; i < 8; ++i) {
		for (int j = 0; j < 8; ++j) {
			if (Szachownica[i][j]->kolor != -1) { //jeœli pole nie jest puste, rysowana jest odpowiednia figura
				al_draw_scaled_bitmap(Szachownica[i][j]->obraz, 0, 0, 123, 123, Szachownica[i][j]->x, Szachownica[i][j]->y, Wsp * 123, Wsp * 123, NULL);
			}
		}
	}
	if (rysObr) //po pierwszym klikniêciu, rysowane jest obramowanie wokó³ pola
		al_draw_rectangle(xKw, yKw, xKw + wymPole, yKw + wymPole, zolty, 10);
}

void rysujSzach(int czySzach1, int czySzach2, int szer, int wys, float Wsp, ALLEGRO_BITMAP* szachB, ALLEGRO_BITMAP* szachC, ALLEGRO_BITMAP* szachBObr, ALLEGRO_BITMAP* szachCObr) {
	//gdy jeden z królów jest szachowany, pojaiwa siê odpowiedni napis
	if (czySzach1) {
		al_draw_scaled_bitmap(szachB, 0, 0, 400, 350, 0.01*szer, 0.3*wys, Wsp * 400, Wsp * 350, NULL);
		al_draw_scaled_bitmap(szachBObr, 0, 0, 400, 350, 0.01*szer, 0.3*wys, Wsp * 400, Wsp * 350, NULL);
	}
	if (czySzach2) {
		al_draw_scaled_bitmap(szachC, 0, 0, 400, 350, 0.78*szer, 0.3*wys, Wsp * 400, Wsp * 350, NULL);
		al_draw_scaled_bitmap(szachCObr, 0, 0, 400, 350, 0.78*szer, 0.3*wys, Wsp * 400, Wsp * 350, NULL);
	}
}

void rysujMat(int czyMat1, int czyMat2, int szer, int wys, float Wsp, ALLEGRO_BITMAP* mat, ALLEGRO_BITMAP* matObr, ALLEGRO_BITMAP* matC, ALLEGRO_BITMAP* matCObr) {
	//gdy jeden z królów jest matowany, pojaiwa siê odpowiedni napis
	if (czyMat1) {
		al_draw_scaled_bitmap(mat, 0, 0, 400, 350, 0.01*szer, 0.45*wys, Wsp * 400, Wsp * 350, NULL);
		al_draw_scaled_bitmap(matObr, 0, 0, 400, 350, 0.01*szer, 0.45*wys, Wsp * 400, Wsp * 350, NULL);
	}
	if (czyMat2) {
		al_draw_scaled_bitmap(matC, 0, 0, 400, 350, 0.8*szer, 0.4*wys, Wsp * 400, Wsp * 350, NULL);
		al_draw_scaled_bitmap(matCObr, 0, 0, 400, 350, 0.8*szer, 0.4*wys, Wsp * 400, Wsp * 350, NULL);
	}
}