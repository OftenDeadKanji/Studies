#pragma once
#include <allegro5/allegro.h>
#include <allegro5/allegro_font.h>
#include <allegro5/allegro_ttf.h>
#include <allegro5/allegro_image.h>
#include <allegro5/allegro_primitives.h>
#include "Program.h"

void rysujTekst(ALLEGRO_FONT* czcionkaMala, ALLEGRO_FONT* czcionkaDuza, ALLEGRO_COLOR zolty, char* czas1, char* czas2, int szer, int wys);
void rysujPola(struct pionek* Szachownica[8][8], ALLEGRO_BITMAP* szachow, ALLEGRO_COLOR zolty, float Wsp, int szer, int wys, int rysObr, float x, float y, int wymPole);
void rysujSzach(int czySzach1, int czySzach2, int szer, int wys, float Wsp, ALLEGRO_BITMAP* szachB, ALLEGRO_BITMAP* szachC, ALLEGRO_BITMAP* szachBObr, ALLEGRO_BITMAP* szachCObr);
void rysujMat(int czyMat1, int czyMat2, int szer, int wys, float Wsp, ALLEGRO_BITMAP* mat, ALLEGRO_BITMAP* matObr, ALLEGRO_BITMAP* matC, ALLEGRO_BITMAP* matCObr);