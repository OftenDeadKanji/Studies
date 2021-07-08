#pragma once

void pozycjaMyszki(float xy[2]);
void podajWsp(int* x, int* y);
int sprPrzycisk(class Przycisk* tab[], int rozmiar);
void zapiszPoziom(class Obiekt* tabEdyt[][20]);
void zniszczEksplozja(class Obiekt* Poziom[][20], class Obiekt* puste, int i, int xGracz, int yGracz, class Gracz* gracz, int aktDyn[][2]);
void Gra();
void GrajPoziom(class Obiekt* Poziom[][20], int nrPoz);
void Menu();
void Edytor(ALLEGRO_DISPLAY* okno);
void Autorzy();