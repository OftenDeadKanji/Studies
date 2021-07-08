#pragma once
#include "Program.h"


int ktorePole(int, int, int, int, int);
void zaznaczAtakowane(struct pionek*[8][8], int, int);
int czyRatunek(struct pionek* [8][8], int [2][2], int );
int czyPoprawny(int, int, int, int, struct pionek* [8][8], int, int [3][2]);
void zamienZawartoscPola(int, int, int, int, struct pionek* [8][8], int zbite[2]);
void ktoAtakuje(struct pionek* [8][8], int, int [2][2]);
void poczRuch(struct pionek* [8][8], int [3][2]);
int sprSzach(struct pionek* [8][8], int);
int sprOtocz(struct pionek* Szachownica[8][8], int kolor);
void przywrFig(struct pionek* Szachownica[8][8], int zbite[2], int x, int y, ALLEGRO_BITMAP* tab[12]);
int wylaczKryjace(struct pionek* Szachownica[8][8], int WspAtak[2][2], int kolor, int ukryte[2][8]);
void dodajUkryte(struct pionek* Szachownica[8][8], int i, int j, int ukryte[2][8], int licznik);
void pokazUkryte(struct pionek* Szachownica[8][8], int ukryte[2][8], int licznik, int kolor);