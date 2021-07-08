#pragma once
#include "Szachownica.h"

int ktorePole(int x, int y, int szer, int wys, int wymPole)
{
	//funkcja odnajduje pole na które klikn¹³ gracz
	for (int i = 0; i < 8; i++)
		for (int j = 0; j < 8; j++)
			if ((x > 0.25*szer + i * wymPole && x < 0.25*szer + (i + 1) * wymPole) && (y > 0.04*wys + j * wymPole && y < 0.04*wys + (j + 1) * wymPole))
				return (i * 10 + j);
}

int kolorPrzeciwny(int kolor)
{
	if (kolor == 0)
		return 1;
	else				//funkcja zwraca kolor przeciwny
		return 0;
}

void przywrFig(struct pionek* Szachownica[8][8], int zbite[2], int x, int y, ALLEGRO_BITMAP* tab[12])
{ 
	//funkcja przywraca "nies³usznie" zbit¹ figurê
	Szachownica[x][y]->kolor = zbite[0];
	Szachownica[x][y]->typ = zbite[1];
	switch (zbite[1]) {
	case pi:
		if (zbite[0] == 0)
			Szachownica[x][y]->obraz = tab[1];
		else
			Szachownica[x][y]->obraz = tab[0];
		break;
	case wi:
		if (zbite[0] == 0)
			Szachownica[x][y]->obraz = tab[3];
		else
			Szachownica[x][y]->obraz = tab[2];
		break;
	case ko:
		if (zbite[0] == 0)
			Szachownica[x][y]->obraz = tab[5];
		else
			Szachownica[x][y]->obraz = tab[4];
		break;
	case go:
		if (zbite[0] == 0)
			Szachownica[x][y]->obraz = tab[7];
		else
			Szachownica[x][y]->obraz = tab[6];
		break;
	case ka:
		if (zbite[0] == 0)
			Szachownica[x][y]->obraz = tab[9];
		else
			Szachownica[x][y]->obraz = tab[8];
		break;
	case kr:
		if (zbite[0] == 0)
			Szachownica[x][y]->obraz = tab[11];
		else
			Szachownica[x][y]->obraz = tab[10];
		break;
	}
}

void zaznaczAtakowane(struct pionek* Szachownica[8][8], int pionek, int krol)
{ 
	//zaznaczane s¹ pola atakowane przez figury
	for (int i = 0; i < 8; ++i)
		for (int j = 0; j < 8; ++j) {
			Szachownica[i][j]->atak[0] = 0;
			Szachownica[i][j]->atak[1] = 0;
		}
	int kolor;
	for (int i = 0; i < 8; ++i)
		for (int j = 0; j < 8; ++j) {
			kolor = Szachownica[i][j]->kolor;
			if (kolor != -1) {
				//------------------------------------------------------------------pionek
				if (Szachownica[i][j]->typ == pi) {
					if (!pionek) { //ró¿ny sposób zaznaczania atakowanych pól przez pionka wynika z faktu, ¿e dalsze funkcje
								  //sprawdzaj¹ z u¿yciem atak[] czy jakaœ figura mo¿e wejœæ na to miejsce
								 //sposób atakowania i przemieszczania siê pionka jest ró¿ny
								//w funkcji: pionek = 1 - dla przemieszczania, pionek = 0 - dla atakowania 
						if (kolor == 0) {
							if (i - 1 >= 0 && j - 1 >= 0)
								Szachownica[i - 1][j - 1]->atak[0] = 1;
							if (i + 1 < 8 && j - 1 >= 0)
								Szachownica[i + 1][j - 1]->atak[0] = 1;
						}
						if (kolor == 1) {
							if (i - 1 >= 0 && j + 1 <= 7)
								Szachownica[i - 1][j + 1]->atak[1] = 1;
							if (i + 1 < 8 && j + 1 <= 7)
								Szachownica[i + 1][j + 1]->atak[1] = 1;
						}
					}
					else {
						if (kolor == 0) {
							if (j - 1 >= 0 && Szachownica[i][j - 1]->kolor == -1)
								Szachownica[i][j - 1]->atak[0] = 1;
							if (j == 6 && Szachownica[i][5]->kolor == -1 && Szachownica[i][4]->kolor == -1)
								Szachownica[i][4]->atak[0] = 1;
						}
						if (kolor == 1) {
							if (j + 1 <= 7 && Szachownica[i][j + 1]->kolor == -1)
								Szachownica[i][j + 1]->atak[1] = 1;
							if (j == 1 && Szachownica[i][2]->kolor == -1 && Szachownica[i][3]->kolor == -1)
								Szachownica[i][3]->atak[1] = 1;
						}
					}
				}
				//------------------------------------------------------------------wie¿a
				if (Szachownica[i][j]->typ == wi) {
					for (int m = i + 1; m < 8; ++m) {
						Szachownica[m][j]->atak[kolor] = 1;
						if (Szachownica[m][j]->kolor == kolorPrzeciwny(Szachownica[i][j]->kolor) && Szachownica[m][j]->typ == kr) {
							if (Szachownica[m + 1][j]->kolor == kolorPrzeciwny(Szachownica[i][j]->kolor))
								break;
							continue;
						}
						if (Szachownica[m][j]->kolor != -1)
							break;
					}
					for (int m = i - 1; m >= 0; --m) {
						Szachownica[m][j]->atak[kolor] = 1;
						if (Szachownica[m][j]->kolor == kolorPrzeciwny(Szachownica[i][j]->kolor) && Szachownica[m][j]->typ == kr) {
							if (Szachownica[m - 1][j]->kolor == kolorPrzeciwny(Szachownica[i][j]->kolor))
								break;
							continue;
						}
						if (Szachownica[m][j]->kolor != -1)
							break;
					}
					for (int m = j + 1; m < 8; ++m) {
						Szachownica[i][m]->atak[kolor] = 1;
						if (Szachownica[i][m]->kolor == kolorPrzeciwny(Szachownica[i][j]->kolor) && Szachownica[i][m]->typ == kr) {
							if (Szachownica[i][m + 1]->kolor == kolorPrzeciwny(Szachownica[i][j]->kolor))
								break;
							continue;
						}
						if (Szachownica[i][m]->kolor != -1)
							break;
					}
					for (int m = j - 1; m >= 0; --m) {
						Szachownica[i][m]->atak[kolor] = 1;
						if (Szachownica[i][m]->kolor == kolorPrzeciwny(Szachownica[i][j]->kolor) && Szachownica[i][m]->typ == kr) {
							if (Szachownica[i][m - 1]->kolor == kolorPrzeciwny(Szachownica[i][j]->kolor))
								break;
							continue;
						}
						if (Szachownica[i][m]->kolor != -1)
							break;
					}
				}
				//------------------------------------------------------------------konik
				if (Szachownica[i][j]->typ == ko) {
					if (i - 2 >= 0 && j - 1 >= 0)
						Szachownica[i - 2][j - 1]->atak[kolor] = 1;
					if (i - 2 >= 0 && j + 1 <= 7)
						Szachownica[i - 2][j + 1]->atak[kolor] = 1;
					if (i - 1 >= 0 && j - 2 >= 0)
						Szachownica[i - 1][j - 2]->atak[kolor] = 1;
					if (i - 1 >= 0 && j + 2 <= 7)
						Szachownica[i - 1][j + 2]->atak[kolor] = 1;
					if (i + 2 <= 7 && j - 1 >= 0)
						Szachownica[i + 2][j - 1]->atak[kolor] = 1;
					if (i + 2 <= 7 && j + 1 <= 7)
						Szachownica[i + 2][j + 1]->atak[kolor] = 1;
					if (i + 1 <= 7 && j - 2 >= 0)
						Szachownica[i + 1][j - 2]->atak[kolor] = 1;
					if (i + 1 <= 7 && j + 2 <= 7)
						Szachownica[i + 1][j + 2]->atak[kolor] = 1;
				}
				//------------------------------------------------------------------goniec
				if (Szachownica[i][j]->typ == go) {
					for (int m = i - 1, n = j - 1; m >= 0 && n >= 0; --m, --n) {
						Szachownica[m][n]->atak[kolor] = 1;
						if (Szachownica[m][n]->kolor == kolorPrzeciwny(Szachownica[i][j]->kolor) && Szachownica[m][n]->typ == kr)
							continue;
						if (Szachownica[m][n]->kolor != -1)
							break;
					}
					for (int m = i + 1, n = j - 1; m <= 7 && n >= 0; ++m, --n) {
						Szachownica[m][n]->atak[kolor] = 1;
						if (Szachownica[m][n]->kolor == kolorPrzeciwny(Szachownica[i][j]->kolor) && Szachownica[m][n]->typ == kr)
							continue;
						if (Szachownica[m][n]->kolor != -1)
							break;
					}
					for (int m = i - 1, n = j + 1; m >= 0 && n <= 7; --m, ++n) {
						Szachownica[m][n]->atak[kolor] = 1;
						if (Szachownica[m][n]->kolor == kolorPrzeciwny(Szachownica[i][j]->kolor) && Szachownica[m][n]->typ == kr)
							continue;
						if (Szachownica[m][n]->kolor != -1)
							break;
					}
					for (int m = i + 1, n = j + 1; m <= 7 && n <= 7; ++m, ++n) {
						Szachownica[m][n]->atak[kolor] = 1;
						if (Szachownica[m][n]->kolor == kolorPrzeciwny(Szachownica[i][j]->kolor) && Szachownica[m][n]->typ == kr)
							continue;
						if (Szachownica[m][n]->kolor != -1) 
							break;	
					}
				}
				//------------------------------------------------------------------królowa
				if (Szachownica[i][j]->typ == ka) {
					for (int m = i + 1; m < 8; ++m) {
						Szachownica[m][j]->atak[kolor] = 1;
						if (Szachownica[m][j]->kolor == kolorPrzeciwny(Szachownica[i][j]->kolor) && Szachownica[m][j]->typ == kr)
							continue;
						if (Szachownica[m][j]->kolor != -1)
							break;
					}
					for (int m = i - 1; m >= 0; --m) {
						Szachownica[m][j]->atak[kolor] = 1;
						if (Szachownica[m][j]->kolor == kolorPrzeciwny(Szachownica[i][j]->kolor) && Szachownica[m][j]->typ == kr)
							continue;
						if (Szachownica[m][j]->kolor != -1)
							break;
					}
					for (int m = j + 1; m < 8; ++m) {
						Szachownica[i][m]->atak[kolor] = 1;
						if (Szachownica[i][m]->kolor == kolorPrzeciwny(Szachownica[i][j]->kolor) && Szachownica[i][m]->typ == kr)
							continue;
						if (Szachownica[i][m]->kolor != -1)
							break;
					}
					for (int m = j - 1; m >= 0; --m) {
						Szachownica[i][m]->atak[kolor] = 1;
						if (Szachownica[i][m]->kolor == kolorPrzeciwny(Szachownica[i][j]->kolor) && Szachownica[i][m]->typ == kr)
							continue;
						if (Szachownica[i][m]->kolor != -1)
							break;
					}
					for (int m = i - 1, n = j - 1; m >= 0 && n >= 0; --m, --n) {
						Szachownica[m][n]->atak[kolor] = 1;
						if (Szachownica[m][n]->kolor == kolorPrzeciwny(Szachownica[i][j]->kolor) && Szachownica[m][n]->typ == kr)
							continue;
						if (Szachownica[m][n]->kolor != -1)
							break;
					}
					for (int m = i + 1, n = j - 1; m <= 7 && n >= 0; ++m, --n) {
						Szachownica[m][n]->atak[kolor] = 1;
						if (Szachownica[m][n]->kolor == kolorPrzeciwny(Szachownica[i][j]->kolor) && Szachownica[m][n]->typ == kr)
							continue;
						if (Szachownica[m][n]->kolor != -1)
							break;
					}
					for (int m = i - 1, n = j + 1; m >= 0 && n <= 7; --m, ++n) {
						Szachownica[m][n]->atak[kolor] = 1;
						if (Szachownica[m][n]->kolor == kolorPrzeciwny(Szachownica[i][j]->kolor) && Szachownica[m][n]->typ == kr)
							continue;
						if (Szachownica[m][n]->kolor != -1)
							break;
					}
					for (int m = i + 1, n = j + 1; m <= 7 && n <= 7; ++m, ++n) {
						Szachownica[m][n]->atak[kolor] = 1;
						if (Szachownica[m][n]->kolor == kolorPrzeciwny(Szachownica[i][j]->kolor) && Szachownica[m][n]->typ == kr)
							continue;
						if (Szachownica[m][n]->kolor != -1)
							break;
					}
				}
				//------------------------------------------------------------------król
				if (!krol) { //w przypadku gdy sprawdza siê czy jakaœ figura mo¿e zas³oniæ króla przed atakiem
							//on sam nie mo¿e powodowaæ zmiany zmiennej wartoœci atak[kolor] na 1
					if (Szachownica[i][j]->typ == kr) {
						if (i + 1 <= 7 && j + 1 <= 7)
							Szachownica[i + 1][j + 1]->atak[kolor] = 1;
						if (i - 1 >= 0 && j + 1 <= 7)
							Szachownica[i - 1][j + 1]->atak[kolor] = 1;
						if (i + 1 <= 7 && j - 1 >= 0)
							Szachownica[i + 1][j - 1]->atak[kolor] = 1;
						if (i - 1 >= 0 && j - 1 >= 0)
							Szachownica[i - 1][j - 1]->atak[kolor] = 1;
						if (i + 1 <= 7)
							Szachownica[i + 1][j]->atak[kolor] = 1;
						if (j + 1 <= 7)
							Szachownica[i][j + 1]->atak[kolor] = 1;
						if (i - 1 >= 0)
							Szachownica[i - 1][j]->atak[kolor] = 1;
						if (j - 1 >= 0)
							Szachownica[i][j - 1]->atak[kolor] = 1;
					}
				}
			}
		}
}

int czyRatunek(struct pionek* Szachownica[8][8], int WspAtak[2][2], int kolor)
{
	//funkcja sprawdza czy króla da siê "uratowaæ" przed matowaniem - poprzez zas³oniêcie lub zbicie figury atakuj¹cej
	int x = WspAtak[0][0], y = WspAtak[0][1];
	int xA = WspAtak[1][0], yA = WspAtak[1][1];

	//inaczej trzeba spojrzeæ na pionki
	//bia³e atakuj¹ tylko "do góry"
	//czarne atakuj¹ tylko "w dó³"
	if (Szachownica[xA][yA]->kolor == 0) 
		if (yA - 1 >= 0) {
			if (xA - 1 >= 0)
				if (Szachownica[xA - 1][yA - 1]->typ == pi && Szachownica[xA - 1][yA - 1]->kolor == 1)
					return 1;
			if (xA + 1 <= 7)
				if (Szachownica[xA + 1][yA - 1]->typ == pi && Szachownica[xA + 1][yA - 1]->kolor == 1)
					return 1;
		}
	if (Szachownica[xA][yA]->kolor == 1)
		if (yA + 1 <= 7) {
			if (xA - 1 >= 0)
				if (Szachownica[xA - 1][yA + 1]->typ == pi && Szachownica[xA - 1][yA + 1]->kolor == 0)
					return 1;
			if (xA + 1 <= 7)
				if (Szachownica[xA + 1][yA + 1]->typ == pi && Szachownica[xA + 1][yA + 1]->kolor == 0)
					return 1;
		}
	if (Szachownica[xA][yA]->typ == ko)
		if (Szachownica[xA][yA]->atak[kolorPrzeciwny(kolor)])
			return 1;
		else
			return 0;
	zaznaczAtakowane(Szachownica, 1, 1);

	//sprawdzanie rozpoczynamy z pozycji figury atakuj¹cej i przemieszczamy siê w stronê króla

	//----------------------------------------------------------------------------ukos
	//-----------------------------------------------------------prawo
	if (xA < x) {
		//---------------------------------------------góra
		if (yA > y) {
			for (int i = xA, j = yA; i < x, j > y; i++, j--)
				if (Szachownica[i][j]->atak[kolor])
					return 1;
			return 0;
		}
		//---------------------------------------------dó³
		if (yA < y) {
			for (int i = xA, j = yA; i < x, j < y; i++, j++)
				if (Szachownica[i][j]->atak[kolor])
					return 1;
			return 0;
		}
	}
	//-----------------------------------------------------------lewo
	if (xA > x) {
		//---------------------------------------------góra
		if (yA > y) {
			for (int i = xA, j = yA; i > x, j > y; i--, j--)
				if (Szachownica[i][j]->atak[kolor])
					return 1;
			return 0;
		}
		//---------------------------------------------dó³
		if (yA < y) {
			for (int i = xA, j = yA; i > x, j < y; i--, j++)
				if (Szachownica[i][j]->atak[kolor])
					return 1;
			return 0;
		}
	}
	//----------------------------------------------------------------------------W pionie
	if (xA == x) {
		//-----------------------------------------------------------dó³
		if (yA < y) {
			for (int i = yA; i < y; i++)
				if (Szachownica[x][i]->atak[kolor])
					return 1;
			return 0;
		}
		//-----------------------------------------------------------góra
		if (yA > y) {
			for (int i = yA; i > y; i--)
				if (Szachownica[x][i]->atak[kolor])
					return 1;
			return 0;
		}
	}
	//----------------------------------------------------------------------------W poziomie
	if (yA == y) {
		//-----------------------------------------------------------prawo
		if (xA < x) {
			for (int i = xA; i < x; i++)
				if (Szachownica[i][y]->atak[kolor])
					return 1;
			return 0;
		}
		//-----------------------------------------------------------lewo
		if (xA > x) {
			for (int i = xA; i > x; i--)
				if (Szachownica[i][y]->atak[kolor])
					return 1;
			return 0;
		}
	}
	if (Szachownica[xA][yA]->atak[kolor])
		return 1;

	return 0;
}

int czyPoprawny(int x1, int x2, int y1, int y2, struct pionek* Szachownica[8][8], int kolor, int czyRuch[3][2])
{
	struct pionek* pole = Szachownica[x1][y1];
	struct pionek* cel = Szachownica[x2][y2];

	//funkcja sprawdza czy ruch jest poprawny dla danej figury
	//---------------------------pionek
	if (pole->typ == pi) {
		if (x2 == x1 && (y1 == 1 || y1 == 6) && (y2 - y1 == 2 || y2 - y1 == -2)) //sprawdzanie pocz¹tkowego ruchu o dwa pola do przodu
			return 1;
		if (pole->kolor == 0) {
			if (y1 - y2 != 1 || abs(x2 - x1) > 1)
				return 0;
			if (x2 == x1)
				if (cel->kolor != -1)
					return 0;
			if (abs(x2 - x1) == 1)
				if (cel->kolor == -1 || cel->kolor == pole->kolor || cel->typ == kr)
					return 0;
		}
		else {
			if (y2 - y1 != 1 || (x2 - x1 > 2 || x2 - x1 < -2))
				return 0;
			if (x2 == x1)
				if (cel->kolor != -1)
					return 0;
			if (x2 - x1 == 1 || x2 - x1 == -1)
				if (cel->kolor == -1)
					return 0;
		}
	}
	//---------------------------wie¿a
	else if (pole->typ == wi) {
		if (!((y2 != y1 && x2 == x1) || (y2 == y1 && x2 != x1)))
			return 0;
		if (x2 == x1) {
			if (y2 > y1)
				for (int i = 1; i < y2 - y1; i++)
					if (Szachownica[x1][y1 + i]->kolor != -1)
						return 0;
			if (y2 < y1)
				for (int i = 1; i < y1 - y2; i++)
					if (Szachownica[x1][y1 - i]->kolor != -1)
						return 0;
		}
		if (y2 == y1) {
			if (x2 > x1)
				for (int i = 1; i < x2 - x1; i++)
					if (Szachownica[x1 + 1][y1]->kolor != -1)
						return 0;
			if (x2 < x1)
				for (int i = 1; i < x1 - x2; i++)
					if (Szachownica[x1 - i][y1]->kolor != -1)
						return 0;
		}
	}
	//---------------------------konik
	else if (pole->typ == ko) {
		if (!((abs(x2 - x1) == 1 && abs(y2 - y1) == 2) || (abs(x2 - x1) == 2 && abs(y2 - y1) == 1)))
			return 0;
	}
	//---------------------------goniec
	else if (pole->typ == go) {
		if (abs(x2 - x1) != abs(y2 - y1))
			return 0;
		if (x2 > x1 && y2 > y1)
			for (int i = 1; i < x2 - x1; i++)
				if (Szachownica[x1 + i][y1 + i]->kolor != -1)
					return 0;
		if (x2 > x1 && y2 < y1)
			for (int i = 1; i < x2 - x1; i++)
				if (Szachownica[x1 + i][y1 - i]->kolor != -1)
					return 0;
		if (x2 < x1 && y2 > y1)
			for (int i = 1; i < x1 - x2; i++)
				if (Szachownica[x1 - i][y1 + i]->kolor != -1)
					return 0;
		if (x2 < x1 && y2 < y1)
			for (int i = 1; i < x1 - x2; i++)
				if (Szachownica[x1 - i][y1 - i]->kolor != -1)
					return 0;
	}
	//---------------------------królowa
	else if (pole->typ == ka) {
		if (!((abs(x2 - x1) == abs(y2 - y1)) || (x2 == x1 && y2 != y1) || (x2 != x1 && y2 == y1)))
			return 0;
		//-----tak jak goniec
		if (x2 > x1 && y2 > y1)
			for (int i = 1; i < x2 - x1; i++)
				if (Szachownica[x1 + i][y1 + i]->kolor != -1)
					return 0;
		if (x2 > x1 && y2 < y1)
			for (int i = 1; i < x2 - x1; i++)
				if (Szachownica[x1 + i][y1 - i]->kolor != -1)
					return 0;
		if (x2 < x1 && y2 > y1)
			for (int i = 1; i < x1 - x2; i++)
				if (Szachownica[x1 - i][y1 + i]->kolor != -1)
					return 0;
		if (x2 < x1 && y2 < y1)
			for (int i = 1; i < x1 - x2; i++)
				if (Szachownica[x1 - i][y1 - i]->kolor != -1)
					return 0;
		//-----tak jak wie¿a
		if (x2 == x1) {
			if (y2 > y1)
				for (int i = 1; i < y2 - y1; i++)
					if (Szachownica[x1][y1 + i]->kolor != -1)
						return 0;
			if (y2 < y1)
				for (int i = 1; i < y1 - y2; i++)
					if (Szachownica[x1][y1 - i]->kolor != -1)
						return 0;
		}
		if (y2 == y1) {
			if (x2 > x1)
				for (int i = 1; i < x2 - x1; i++)
					if (Szachownica[x1 + 1][y1]->kolor != -1)
						return 0;
			if (x2 < x1)
				for (int i = 1; i < x1 - x2; i++)
					if (Szachownica[x1 - i][y1]->kolor != -1)
						return 0;
		}
	}
	//---------------------------król
	else if (pole->typ == kr) {
		//--------------------------------roszada
		if (y2 == y1)
			if (x2 - x1 == 2 || x1 - x2 == 2) {
				if (pole->atak[kolorPrzeciwny(kolor)] == 1)
					return 0;
				if (czyRuch[1][1] == 0) {
					if (x2 - x1 == 2)
						if (czyRuch[2][1] == 0)
							if (Szachownica[x1 + 1][y1]->kolor == -1 && cel->kolor == -1)
								if (Szachownica[x1 + 1][y1]->atak[kolorPrzeciwny(kolor)] == 0 && cel->atak[kolorPrzeciwny(kolor)] == 0)
									return 1;
					if (x1 - x2 == 2)
						if (czyRuch[0][1] == 0)
							if (Szachownica[x1 - 1][y1]->kolor == -1 && cel->kolor == -1)
								if (Szachownica[x1 - 1][y1]->atak[kolorPrzeciwny(kolor)] == 0 && cel->atak[kolorPrzeciwny(kolor)] == 0)
									return 1;
				}
			}
		if (abs(x2 - x1) > 1 || abs(y2 - y1) > 1)
			return 0;
		if (cel->atak[kolorPrzeciwny(kolor)])
			return 0;
	}
	if (cel->kolor == -1)
		return 1;
	if (cel->kolor == pole->kolor) //nie mo¿na zbiæ swojego
		return 0;
	if (cel->typ == kr) //nie mo¿na zbiæ króla
		return 0;
	return 1;
}

void zamienZawartoscPola(int x1, int x2, int y1, int y2, struct pionek* Szachownica[8][8], int zbite[2])
{
	//pole docelowe otrzymuje nowe wartoœci
	zbite[0] = Szachownica[x2][y2]->kolor;
	zbite[1] = Szachownica[x2][y2]->typ;
	Szachownica[x2][y2]->typ = Szachownica[x1][y1]->typ;
	Szachownica[x2][y2]->kolor = Szachownica[x1][y1]->kolor;
	Szachownica[x2][y2]->obraz = Szachownica[x1][y1]->obraz;
	Szachownica[x1][y1]->typ = 0;
	Szachownica[x1][y1]->kolor = -1;
	//w przypadku roszady przemieszczane s¹ dwie figury
	if (Szachownica[x2][y2]->typ == kr) {
		if (x2 - x1 == 2)
			zamienZawartoscPola(7, 5, y1, y1, Szachownica, zbite);
		if (x1 - x2 == 2)
			zamienZawartoscPola(0, 3, y1, y1, Szachownica, zbite);
	}
}

void ktoAtakuje(struct pionek* Szachownica[8][8], int kolor, int WspAtak[2][2])
{
	//funkcja sprawdza i wpisuje do WspAtak wsp. figury atakuj¹cej oraz wsp. króla
	for (int i = 0; i < 8; i++) { //szukanie atakowanego króla
		for (int j = 0; j < 8; j++)
			if (Szachownica[i][j]->kolor == kolor && Szachownica[i][j]->typ == kr) {
				WspAtak[0][0] = i;
				WspAtak[0][1] = j;
			}
	}
	//-------------------------------------------------------------------na ukos
	for (int i = WspAtak[0][0] - 1, j = WspAtak[0][1] - 1; i >= 0 && j >= 0; i--, j--) {
		if (Szachownica[i][j]->kolor == kolor)
			break;
		if (Szachownica[i][j]->kolor == -1)
			continue;
		if (Szachownica[i][j]->typ == pi)
			if (kolor == 0)
				if (abs(WspAtak[0][0] - i) == 1) {
					WspAtak[1][0] = i, WspAtak[1][1] = j;
					break;
				}
				else
					break;
			else 
				break;
		if (Szachownica[i][j]->typ != ka && Szachownica[i][j]->typ != go)
			break;
		WspAtak[1][0] = i, WspAtak[1][1] = j;
		break;
	}
	for (int i = WspAtak[0][0] + 1, j = WspAtak[0][1] - 1; i < 8 && j >= 0; i++, j--) {
		if (Szachownica[i][j]->kolor == kolor)
			break;
		if (Szachownica[i][j]->kolor == -1)
			continue;
		if (Szachownica[i][j]->typ == pi)
			if (kolor == 0)
				if (abs(WspAtak[0][0] - i) == 1) {
					WspAtak[1][0] = i, WspAtak[1][1] = j;
					return;
				}
				else
					break;
			else
				break;
		if (Szachownica[i][j]->typ != ka && Szachownica[i][j]->typ != go)
			break;
		WspAtak[1][0] = i, WspAtak[1][1] = j;
		return;
	}

	for (int i = WspAtak[0][0] - 1, j = WspAtak[0][1] + 1; i >= 0 && j < 8; i--, j++) {
		if (Szachownica[i][j]->kolor == kolor)
			break;
		if (Szachownica[i][j]->kolor == -1)
			continue;
		if (Szachownica[i][j]->typ == pi)
			if (kolor == 1)
				if (abs(WspAtak[0][0] - i) == 1) {
					WspAtak[1][0] = i, WspAtak[1][1] = j;
					return;
				}
				else
					break;
			else
				break;
		if (Szachownica[i][j]->typ != ka && Szachownica[i][j]->typ != go)
			break;
		WspAtak[1][0] = i, WspAtak[1][1] = j;
		return;
	}
	for (int i = WspAtak[0][0] + 1, j = WspAtak[0][1] + 1; i < 8 && j < 8; i++, j++) {
		if (Szachownica[i][j]->kolor == kolor)
			break;
		if (Szachownica[i][j]->kolor == -1)
			continue;
		if (Szachownica[i][j]->typ == pi)
			if (kolor == 1)
				if (abs(WspAtak[0][0] - i) == 1) {
					WspAtak[1][0] = i, WspAtak[1][1] = j;
					return;
				}
				else
					break;
			else
				break;
		if (Szachownica[i][j]->typ != ka && Szachownica[i][j]->typ != go)
			break;
		WspAtak[1][0] = i, WspAtak[1][1] = j;
		return;
	}
	//-------------------------------------------------------------------w górê
	for (int i = WspAtak[0][1] - 1; i >= 0; i--) {
		if (Szachownica[WspAtak[0][0]][i]->kolor == kolor)
			break;
		if (Szachownica[WspAtak[0][0]][i]->kolor == -1)
			continue;
		if (Szachownica[WspAtak[0][0]][i]->typ != ka && Szachownica[WspAtak[0][0]][i]->typ != wi)
			break;
		WspAtak[1][0] = WspAtak[0][0], WspAtak[1][1] = i;
		return;
	}
	//-------------------------------------------------------------------w dó³
	for (int i = WspAtak[0][1] + 1; i < 8; i++) {
		if (Szachownica[WspAtak[0][0]][i]->kolor == kolor)
			break;
		if (Szachownica[WspAtak[0][0]][i]->kolor == -1)
			continue;
		if (Szachownica[WspAtak[0][0]][i]->typ != ka && Szachownica[WspAtak[0][0]][i]->typ != wi)
			break;
		WspAtak[1][0] = WspAtak[0][0], WspAtak[1][1] = i;
		return;
	}
	//-------------------------------------------------------------------w lewo
	for (int i = WspAtak[0][0] - 1; i >= 0; i--) {
		if (Szachownica[i][WspAtak[0][1]]->kolor == kolor)
			break;
		if (Szachownica[i][WspAtak[0][1]]->kolor == -1)
			continue;
		if (Szachownica[i][WspAtak[0][1]]->typ != ka && Szachownica[i][WspAtak[0][1]]->typ != wi)
			break;
		WspAtak[1][0] = i, WspAtak[1][1] = WspAtak[0][1];
		return;
	}
	//-------------------------------------------------------------------w prawo
	for (int i = WspAtak[0][0] + 1; i < 8; i++) {
		if (Szachownica[i][WspAtak[0][1]]->kolor == kolor)
			break;
		if (Szachownica[i][WspAtak[0][1]]->kolor == -1)
			continue;
		if (Szachownica[i][WspAtak[0][1]]->typ != ka && Szachownica[i][WspAtak[0][1]]->typ != wi)
			break;
		WspAtak[1][0] = i, WspAtak[1][1] = WspAtak[0][1];
		return;
	}
	//-------------------------------------------------------------------konik
	if (WspAtak[0][0] - 2 >= 0 && WspAtak[0][1] - 1 >= 0)
		if (Szachownica[WspAtak[0][0] - 2][WspAtak[0][1] - 1]->kolor == kolorPrzeciwny(kolor) && Szachownica[WspAtak[0][0] - 2][WspAtak[0][1] - 1]->typ == ko) {
			WspAtak[1][0] = WspAtak[0][0] - 2, WspAtak[1][1] = WspAtak[0][1] - 1;
			return;
		}
	if (WspAtak[0][0] - 2 >= 0 && WspAtak[0][1] + 1 <= 7)
		if (Szachownica[WspAtak[0][0] - 2][WspAtak[0][1] + 1]->kolor == kolorPrzeciwny(kolor) && Szachownica[WspAtak[0][0] - 2][WspAtak[0][1] + 1]->typ == ko) {
			WspAtak[1][0] = WspAtak[0][0] - 2, WspAtak[1][1] = WspAtak[0][1] + 1;
			return;
		}

	if (WspAtak[0][0] + 2 <= 7 && WspAtak[0][1] - 1 >= 0)
		if (Szachownica[WspAtak[0][0] + 2][WspAtak[0][1] - 1]->kolor == kolorPrzeciwny(kolor) && Szachownica[WspAtak[0][0] + 2][WspAtak[0][1] - 1]->typ == ko) {
			WspAtak[1][0] = WspAtak[0][0] + 2, WspAtak[1][1] = WspAtak[0][1] - 2;
			return;
		}
	if (WspAtak[0][0] + 2 <= 7 && WspAtak[0][1] + 1 <= 7)
		if (Szachownica[WspAtak[0][0] + 2][WspAtak[0][1] + 1]->kolor == kolorPrzeciwny(kolor) && Szachownica[WspAtak[0][0] + 2][WspAtak[0][1] + 1]->typ == ko) {
			WspAtak[1][0] = WspAtak[0][0] + 2, WspAtak[1][1] = WspAtak[0][1] + 1;
			return;
		}

	if (WspAtak[0][0] - 1 >= 0 && WspAtak[0][1] - 2 >= 0)
		if (Szachownica[WspAtak[0][0] - 1][WspAtak[0][1] - 2]->kolor == kolorPrzeciwny(kolor) && Szachownica[WspAtak[0][0] - 1][WspAtak[0][1] - 2]->typ == ko) {
			WspAtak[1][0] = WspAtak[0][0] - 1, WspAtak[1][1] = WspAtak[0][1] - 2;
			return;
		}
	if (WspAtak[0][0] - 1 >= 0 && WspAtak[0][1] + 2 <= 7)
		if (Szachownica[WspAtak[0][0] - 1][WspAtak[0][1] + 2]->kolor == kolorPrzeciwny(kolor) && Szachownica[WspAtak[0][0] - 1][WspAtak[0][1] + 2]->typ == ko) {
			WspAtak[1][0] = WspAtak[0][0] - 1, WspAtak[1][1] = WspAtak[0][1] + 2;
			return;
		}

	if (WspAtak[0][0] + 1 <= 7 && WspAtak[0][1] - 2 >= 0)
		if (Szachownica[WspAtak[0][0] + 1][WspAtak[0][1] - 2]->kolor == kolorPrzeciwny(kolor) && Szachownica[WspAtak[0][0] + 1][WspAtak[0][1] - 2]->typ == ko) {
			WspAtak[1][0] = WspAtak[0][0] + 1, WspAtak[1][1] = WspAtak[0][1] - 2;
			return;
		}
	if (WspAtak[0][0] + 1 <= 7 && WspAtak[0][1] + 2 <= 7)
		if (Szachownica[WspAtak[0][0] + 1][WspAtak[0][1] + 2]->kolor == kolorPrzeciwny(kolor) && Szachownica[WspAtak[0][0] + 1][WspAtak[0][1] + 2]->typ == ko) {
			WspAtak[1][0] = WspAtak[0][0] + 1, WspAtak[1][1] = WspAtak[0][1] + 2;
			return;
		}
}

void poczRuch(struct pionek* Szachownica[8][8], int czyRuch[3][2])
{
	//sprawdzane jest czy wie¿a lub król przynajmniej raz siê przemieœcili (sprawdzane przy roszadzie)
	if (Szachownica[0][0]->typ != wi)
		czyRuch[0][0] = 1;
	if (Szachownica[4][0]->typ != kr)
		czyRuch[1][0] = 1;
	if (Szachownica[7][0]->typ != wi)
		czyRuch[2][0] = 1;
	if (Szachownica[0][7]->typ != wi)
		czyRuch[0][1] = 1;
	if (Szachownica[4][7]->typ != kr)
		czyRuch[1][1] = 1;
	if (Szachownica[0][7]->typ != wi)
		czyRuch[2][1] = 1;
}

int sprSzach(struct pionek* Szachownica[8][8], int kolor)
{
	//sprawdzane czy król jest szachowany
	for (int i = 0; i < 8; i++)
		for (int j = 0; j < 8; j++)
			if (Szachownica[i][j]->typ == kr) 
					if (Szachownica[i][j]->kolor==kolor && Szachownica[i][j]->atak[kolorPrzeciwny(kolor)] == 1)
						return 1;
	return 0;
}

int sprOtocz(struct pionek* Szachownica[8][8], int kolor)
{
	//sprawdzane czy król jest matowany (szach ju¿ sprawdzony)
	for (int i = 0; i < 8; i++)
		for (int j = 0; j < 8; j++)
			if (Szachownica[i][j]->kolor == kolor && Szachownica[i][j]->typ == kr) {
				if (i - 1 >= 0 && j - 1 >= 0)
					if (Szachownica[i - 1][j - 1]->atak[kolorPrzeciwny(kolor)] == 0 && Szachownica[i - 1][j - 1]->kolor != 0)
						return 0;
				if (i + 1 <= 7 && j + 1 <= 7)
					if (Szachownica[i + 1][j + 1]->atak[kolorPrzeciwny(kolor)] == 0 && Szachownica[i + 1][j + 1]->kolor != 0)
						return 0;
				if (i + 1 <= 7 && j - 1 >= 0)
					if (Szachownica[i + 1][j - 1]->atak[kolorPrzeciwny(kolor)] == 0 && Szachownica[i + 1][j - 1]->kolor != 0)
						return 0;
				if (i - 1 >= 0 && j + 1 <= 7)
					if (Szachownica[i - 1][j + 1]->atak[kolorPrzeciwny(kolor)] == 0 && Szachownica[i - 1][j + 1]->kolor != 0)
						return 0;
				if (i - 1 >= 0)
					if (Szachownica[i - 1][j]->atak[kolorPrzeciwny(kolor)] == 0 && Szachownica[i - 1][j]->kolor != 0)
						return 0;
				if (j - 1 >= 0)
					if (Szachownica[i][j - 1]->atak[kolorPrzeciwny(kolor)] == 0 && Szachownica[i][j - 1]->kolor != 0)
						return 0;
				if (i + 1 <= 7)
					if (Szachownica[i + 1][j]->atak[kolorPrzeciwny(kolor)] == 0 && Szachownica[i + 1][j]->kolor != 0)
						return 0;
				if (j + 1 <= 7)
					if (Szachownica[i][j + 1]->atak[kolorPrzeciwny(kolor)] == 0 && Szachownica[i][j + 1]->kolor != 0)
						return 0;
				return 1;
			}
}

int wylaczKryjace(struct pionek* Szachownica[8][8], int WspAtak[2][2], int kolor, int ukryte[2][8])
{
	//funkcja sprawia, ¿e na pewien czas "ukrywane" s¹ figury, które zas³aniaj¹ króla przed szachowaniem
	//potrzebne to jest w sytuacji, gdy sprawdza siê czy król mo¿e zostaæ "uratowany", ale dana figura
	//nie mo¿e zbiæ figury atakuj¹cej lub zas³oniæ króla, gdy¿ ju¿ zas³ania go przed inn¹
	int x = WspAtak[0][0], y = WspAtak[0][1], xA = WspAtak[1][0], yA = WspAtak[1][1];

	Szachownica[xA][yA]->kolor = -1;
	zaznaczAtakowane(Szachownica, 0, 0);
	Szachownica[xA][yA]->kolor = kolorPrzeciwny(kolor);

	int licznik = 0; //licznik figur zas³aniaj¹cych króla

	for (int i = x - 1, j = y - 1; i >= 0 && j >= 0; i--, j--) {
		if (Szachownica[i][j]->kolor == -1)
			continue;
		if (Szachownica[i][j]->kolor == kolorPrzeciwny(kolor))
			break;
			if (Szachownica[i][j]->atak[kolorPrzeciwny(kolor)] == 1) {
				dodajUkryte(Szachownica, i, j, ukryte, licznik);
				licznik++;
				break;
			}
			break;
		break;
	}
	for (int i = x - 1, j = y + 1; i >= 0 && j <= 7; i--, j++) {
		if (Szachownica[i][j]->kolor == -1)
			continue;
		if (Szachownica[i][j]->kolor == kolorPrzeciwny(kolor))
			break;
			if (Szachownica[i][j]->atak[kolorPrzeciwny(kolor)] == 1) {
				dodajUkryte(Szachownica, i, j, ukryte, licznik);
				licznik++;
				break;
			}
			break;
		break;
	}
	for (int i = x + 1, j = y - 1; i <= 7 && j >= 0; i++, j--) {
		if (Szachownica[i][j]->kolor == -1)
			continue;
		if (Szachownica[i][j]->kolor == kolorPrzeciwny(kolor))
			break;
			if (Szachownica[i][j]->atak[kolorPrzeciwny(kolor)] == 1) {
				dodajUkryte(Szachownica, i, j, ukryte, licznik);
				licznik++;
				break;
			}
			break;
		break;
	}
	for (int i = x + 1, j = y + 1; i <= 7 && j <= 7; i++, j++) {
		if (Szachownica[i][j]->kolor == -1)
			continue;
		if (Szachownica[i][j]->kolor == kolorPrzeciwny(kolor))
			break;
			if (Szachownica[i][j]->atak[kolorPrzeciwny(kolor)] == 1) {
				dodajUkryte(Szachownica, i, j, ukryte, licznik);
				licznik++;
				break;
			}
			break;
		break;
	}

	for (int i = x + 1; i <= 7; i++) {
		if (Szachownica[i][y]->kolor == -1)
			continue;
		if (Szachownica[i][y]->kolor == kolorPrzeciwny(kolor))
			break;
			if (Szachownica[i][y]->atak[kolorPrzeciwny(kolor)] == 1) {
				dodajUkryte(Szachownica, i, y, ukryte, licznik);
				licznik++;
				break;
			}
			break;
		break;
	}
	for (int i = x - 1; i >= 0; i--) {
		if (Szachownica[i][y]->kolor == -1)
			continue;
		if (Szachownica[i][y]->kolor == kolorPrzeciwny(kolor))
			break;
			if (Szachownica[i][y]->atak[kolorPrzeciwny(kolor)] == 1) {
				dodajUkryte(Szachownica, i, y, ukryte, licznik);
				licznik++;
				break;
			}
			break;
		break;
	}
	for (int i = y + 1; i <= 7; i++) {
		if (Szachownica[x][i]->kolor == -1)
			continue;
		if (Szachownica[x][i]->kolor == kolorPrzeciwny(kolor))
			break;
			if (Szachownica[x][i]->atak[kolorPrzeciwny(kolor)] == 1) {
				dodajUkryte(Szachownica, x, i, ukryte, licznik);
				licznik++;
				break;
			}
			break;
		break;
	}
	for (int i = y - 1; i >= 0; i--) {
		if (Szachownica[x][i]->kolor == -1)
			continue;
		if (Szachownica[x][i]->kolor == kolorPrzeciwny(kolor))
			break;
			if (Szachownica[x][i]->atak[kolorPrzeciwny(kolor)] == 1) {
				dodajUkryte(Szachownica, x, i, ukryte, licznik);
				licznik++;
				break;
			}
			break;
		break;
	}
	//teraz sprawdza siê czy którêœ z pozosta³ych figur mog¹ "uratowaæ" króla
	int czy = czyRatunek(Szachownica, WspAtak, kolor);
	//"ukryte" figury s¹ teraz przywracane znowu na szachownicê
	pokazUkryte(Szachownica, ukryte, licznik, kolor);
	return czy;
}

void dodajUkryte(struct pionek* Szachownica[8][8], int i, int j, int ukryte[2][8], int licznik)
{
	//funkcja wpisuje wspó³rzêdne figury zas³aniaj¹cej króla do tablicy
	ukryte[0][licznik] = i;
	ukryte[1][licznik] = j;
	Szachownica[i][j]->kolor = -1;
}

void pokazUkryte(struct pionek* Szachownica[8][8], int ukryte[2][8], int licznik, int kolor)
{
	//funkcja "os³ania" ukryte wczeœniej figury
	for (int i = 0; i < licznik; i++)
		Szachownica[ukryte[0][i]][ukryte[1][i]]->kolor = kolor;
}