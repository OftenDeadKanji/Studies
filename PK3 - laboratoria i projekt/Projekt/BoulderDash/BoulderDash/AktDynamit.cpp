#include "pch.h"

AktDynamit::AktDynamit()
{
	dynamit1 = al_load_bitmap("Obrazy/dynamit_1z3.png");
	dynamit2 = al_load_bitmap("Obrazy/dynamit_2z3.png");
	dynamit3 = al_load_bitmap("Obrazy/dynamit_3z3.png");
	eksplozja = al_load_bitmap("Obrazy/eksplozja.png");
	obraz = dynamit1;
	eksploz = al_load_sample("muzyka/eksplozja.wav");
}

AktDynamit::AktDynamit(int wspX, int wspY)
{
	dynamit1 = al_load_bitmap("Obrazy/dynamit_1z3.png");
	dynamit2 = al_load_bitmap("Obrazy/dynamit_2z3.png");
	dynamit3 = al_load_bitmap("Obrazy/dynamit_3z3.png");
	eksplozja = al_load_bitmap("Obrazy/eksplozja.png");
	obraz = dynamit1;
	eksploz = al_load_sample("muzyka/eksplozja.wav");
	x = wspX;
	y = wspY;
}

AktDynamit::AktDynamit(AktDynamit& ob) : Dynamit(ob)
{
	dynamit1 = al_clone_bitmap(ob.dynamit1);
	dynamit2 = al_clone_bitmap(ob.dynamit2);
	dynamit3 = al_clone_bitmap(ob.dynamit3);
	eksplozja = al_clone_bitmap(ob.eksplozja);
	obraz = dynamit1;
	eksploz = al_load_sample("muzyka/eksplozja.wav");
}

AktDynamit::~AktDynamit()
{
	al_destroy_bitmap(dynamit1);
	al_destroy_bitmap(dynamit2);
	al_destroy_bitmap(dynamit3);
	al_destroy_bitmap(eksplozja);
	al_destroy_sample(eksploz);
}

void AktDynamit::zmienObraz()
{
	switch (++tryb) {
	case 1:
		obraz = dynamit1;
		break;
	case 2:
		obraz = dynamit2;
		break;
	case 3:
		obraz = dynamit3;
		break;
	case 4:
		obraz = eksplozja;
		break;
	}
}

void AktDynamit::wybuch(Gracz* gracz)
{
	al_play_sample(eksploz, 1.0, 0, 1.0, ALLEGRO_PLAYMODE_ONCE, NULL);
	if (abs(x - gracz->pobX()) <= 1 && abs(y - gracz->pobY()) <= 1)
		gracz->smierc();
}

bool AktDynamit::czyWejsc()
{
	return false;
}

int AktDynamit::podajTryb()
{
	return tryb;
}

void AktDynamit::rysuj(Obiekt* tab[][20])
{
	if (tryb <= 4)
		al_draw_bitmap(obraz, x * 32, y * 32, NULL);

	if (tryb == 4) {
		if (x - 1 >= 0) {
			if (y - 1 >= 0 && tab[x - 1][y - 1]->czyZniszczyc())
				al_draw_bitmap(obraz, (x - 1) * 32, (y - 1) * 32, NULL);
			if (tab[x - 1][y]->czyZniszczyc())
				al_draw_bitmap(obraz, (x - 1) * 32, y * 32, NULL);
			if (y + 1 <= 19 && tab[x - 1][y + 1]->czyZniszczyc())
				al_draw_bitmap(obraz, (x - 1) * 32, (y + 1) * 32, NULL);
		}

		if (y - 1 >= 0 && tab[x][y - 1]->czyZniszczyc())
			al_draw_bitmap(obraz, x * 32, (y - 1) * 32, NULL);
		if (y + 1 <= 19 && tab[x][y + 1]->czyZniszczyc())
			al_draw_bitmap(obraz, x * 32, (y + 1) * 32, NULL);

		if (x + 1 <= 19) {
			if (y - 1 >= 0 && tab[x + 1][y - 1]->czyZniszczyc())
				al_draw_bitmap(obraz, (x + 1) * 32, (y - 1) * 32, NULL);
			if (tab[x + 1][y]->czyZniszczyc())
				al_draw_bitmap(obraz, (x + 1) * 32, y * 32, NULL);
			if (y + 1 <= 19 && tab[x + 1][y + 1]->czyZniszczyc())
				al_draw_bitmap(obraz, (x + 1) * 32, (y + 1) * 32, NULL);
		}
	}
}