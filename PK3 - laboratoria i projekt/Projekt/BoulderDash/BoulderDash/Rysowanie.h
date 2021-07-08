#pragma once

void rysujPrzejscie(char tryb);
void rysujBrame();
void rysujEdytor(Obiekt* tabSzbl[], class Obiekt* tabEdt[][20]);
void rysujPoziom(Obiekt* tabPoz[][20]);
void rysujDynamit(Obiekt* Poziom[][20], Obiekt* puste, Gracz* gracz, class AktDynamit* dynamit, ALLEGRO_BITMAP* tabBitmap[4], ALLEGRO_SAMPLE* eksplozja, bool* czyDzwiek, int tabWsp[4][2], int xGracz, int yGracz, int trybDyn[], bool przejscie);
void rysujPrzyciski(Przycisk* tab[], int rozmiar);
void rysujPomocnicze(Przycisk* pkt, ALLEGRO_FONT* czcionka);