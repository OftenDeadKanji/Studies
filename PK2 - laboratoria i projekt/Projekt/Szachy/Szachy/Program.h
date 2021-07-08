#pragma once
#include <allegro5/allegro.h>
#include <allegro5/allegro_native_dialog.h>
#include <allegro5/allegro_font.h>
#include <allegro5/allegro_ttf.h>
#include <allegro5/allegro_image.h>
#include <allegro5/allegro_audio.h>
#include <allegro5/allegro_acodec.h>
#include <allegro5/allegro_primitives.h>

enum typ { pi = 1, wi, ko, go, ka, kr };
struct pionek {
	int  typ, kolor, x, y;// atakB, atakC;
	int atak[2];
	ALLEGRO_BITMAP* obraz;
};

void stoperF(int czasS[2], char** czas1, char** czas2, int nowyCzas, int* sekunda, int Gracz);
int zamienPionek(struct pionek* Szachownica[8][8], ALLEGRO_BITMAP* kaBi, ALLEGRO_BITMAP* kaCz);
void zamienNaPionek(struct pionek* Szachownica[8][8], int xPi, int kolor, ALLEGRO_BITMAP* piBi, ALLEGRO_BITMAP* piCz);
