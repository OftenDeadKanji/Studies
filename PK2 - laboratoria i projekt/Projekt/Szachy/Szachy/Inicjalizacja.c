#include "inicjalizacja.h"

void initTabWym(int tabWym[8][8][2], int szer, int wys, int wymPole) {
	for (int i = 0; i < 8; i++) 
		for (int j = 0; j < 8; j++) {
			tabWym[i][j][0] = 0.25*szer + i * wymPole;
			tabWym[i][j][1] = 0.04*wys + j * wymPole;
		}
}

void initSzachWym(struct pionek* Szachownica[8][8], int szer, int wys, int wymPole) {
	for (int i = 0; i < 8; ++i)
		for (int j = 0; j < 8; ++j) {
			Szachownica[i][j] = malloc(sizeof(struct pionek));
			Szachownica[i][j]->x = 0.25*szer + i * wymPole; //ka¿de pole ma wsp. x i wsp. y wyra¿one w pikselach
			Szachownica[i][j]->y = 0.04*wys + j * wymPole;
		}
}

void initSzachownica(struct pionek* Szachownica[8][8], ALLEGRO_BITMAP* tab[12]) {
	for (int i = 0; i < 8; i++)
		for (int j = 0; j < 8; j++) {
			Szachownica[i][j]->atak[0] = 0; //pole nie jest atakowane przez figurê bia³¹
			Szachownica[i][j]->atak[1] = 0; //pole nie jest atakowane przez figurê czarn¹

			if (j < 2) {
				Szachownica[i][j]->kolor = 1; //na tym pole znajduje siê figura czarna
			}
			else if (j > 5) {
				Szachownica[i][j]->kolor = 0; //na tym pole znajduje siê figura bia³a
			}
			else {
				Szachownica[i][j]->kolor = -1; //pole puste
				Szachownica[i][j]->typ = 0;
			}

			if (j == 1) {
				Szachownica[i][j]->typ = pi; //pionek
				Szachownica[i][j]->obraz = tab[0];
			}
			else if (j == 6) {
				Szachownica[i][j]->typ = pi;
				Szachownica[i][j]->obraz = tab[1];
			}
			else if ((i == 0 && j == 0) || (i == 7 && j == 0)) {
				Szachownica[i][j]->typ = wi; //wie¿a
				Szachownica[i][j]->obraz = tab[2];
			}
			else if ((i == 0 && j == 7) || (i == 7 && j == 7)) {
				Szachownica[i][j]->typ = wi;
				Szachownica[i][j]->obraz = tab[3];
			}
			else if ((i == 1 && j == 0) || (i == 6 && j == 0)) {
				Szachownica[i][j]->typ = ko; //konik
				Szachownica[i][j]->obraz = tab[4];
			}
			else if ((i == 1 && j == 7) || (i == 6 && j == 7)) {
				Szachownica[i][j]->typ = ko; 
				Szachownica[i][j]->obraz = tab[5];
			}
			else if ((i == 2 && j == 0) || (i == 5 && j == 0)) {
				Szachownica[i][j]->typ = go; //goniec
				Szachownica[i][j]->obraz = tab[6];
			}
			else if ((i == 2 && j == 7) || (i == 5 && j == 7)) {
				Szachownica[i][j]->typ = go;
				Szachownica[i][j]->obraz = tab[7];
			}
			else if (i == 3 && j == 0) {
				Szachownica[i][j]->typ = ka; //królowa
				Szachownica[i][j]->obraz = tab[8];
			}
			else if (i == 3 && j == 7) {
				Szachownica[i][j]->typ = ka;
				Szachownica[i][j]->obraz = tab[9];
			}
			else if (i == 4 && j == 0) {
				Szachownica[i][j]->typ = kr; //król
				Szachownica[i][j]->obraz = tab[10];
			}
			else if (i == 4 && j == 7) {
				Szachownica[i][j]->typ = kr;
				Szachownica[i][j]->obraz = tab[11];
			}
		}
}