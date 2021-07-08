#pragma once
#include "Program.h"

void initTabWym(int tabWym[8][8][2], int szer, int wys, int wymPole);
void initSzachWym(struct pionek* Szachownica[8][8], int szer, int wys, int wymPole);
void initSzachownica(struct pionek* Szachownica[8][8], ALLEGRO_BITMAP* tab[12]);