#include "../pch.h"

#pragma region Konstruktory i destruktor
Obiekt::Obiekt()
{}

Obiekt::Obiekt(int x, int y) : x(x), y(y)
{}

Obiekt::Obiekt(int id, int x, int y) : x(x), y(y), id(id)
{
	if (id == 0)
		obrazy[0] = al_load_bitmap("Obrazy/Sciana.png");
	aktObraz = obrazy[0];
}

Obiekt::Obiekt(int id, int x, int y, std::string nazwaPliku) : id(id), x(x), y(y)
{
	std::string sciezka = "Obrazy/" + nazwaPliku;
	obrazy[0] = al_load_bitmap(sciezka.c_str());
	aktObraz = obrazy[0];
}

Obiekt::Obiekt(Obiekt& ob) : x(ob.x), y(ob.y), id(ob.id), wejscie(ob.wejscie)
{
	for (int i = 0; i < 4; i++)
		if (ob.obrazy[i] != NULL)
			obrazy[i] = al_clone_bitmap(ob.obrazy[i]);
	aktywanyObraz = DOL;
	aktObraz = obrazy[aktywanyObraz];
}

Obiekt::~Obiekt()
{
	for (int i = 0; i < 4; i++)
		al_destroy_bitmap(obrazy[i]);
}
bool Obiekt::operator<(Obiekt o)
{
	if (this->id < o.id)
		return true;
	else 
		return false;
}
#pragma endregion

std::ostream & Obiekt::zapis(std::ostream & strumien) const
{
	strumien << id << std::endl << x << " " << y << std::endl << wejscie;

	return strumien;
}
std::istream & Obiekt::odczyt(std::istream & strumien)
{
	strumien >> id >> x >> y >> wejscie;

	return strumien;
}

#pragma region Settery
void Obiekt::zmienObraz(ALLEGRO_BITMAP * obraz)
{
	this->obrazy[0] = obraz;
}

void Obiekt::zmienX(int x)
{
	this->x = x;
}

void Obiekt::zmienY(int y)
{
	this->y = y;
}

void Obiekt::zmienWejscie(bool wejscie)
{
	this->wejscie = wejscie;
}

void Obiekt::zmienAktObraz(kierunki kier)
{
	aktywanyObraz = kier;
	aktObraz = obrazy[kier];
}
#pragma endregion

#pragma region Gettery
ALLEGRO_BITMAP* Obiekt::podajObraz()
{
	return aktObraz;
}

int Obiekt::podajX()
{
	return x;
}

int Obiekt::podajY()
{
	return y;
}

int Obiekt::podajID()
{
	return id;
}
bool Obiekt::czyWejsc()
{
	return wejscie;
}
kierunki Obiekt::podajKierunek()
{
	return aktywanyObraz;
}
#pragma endregion

void Obiekt::zaladujObraz(std::map <int, std::vector<std::string>> spis)
{
	for (int i = 0; i < spis[id].size(); i++) {
		std::string sciezka = "Obrazy/" + spis[id][i];
		obrazy[i] = al_load_bitmap(sciezka.c_str());
	}
}

void Obiekt::rysuj()
{
	al_draw_scaled_bitmap(aktObraz,0,0,100,100, x*WYM_OBRAZ * WSP_SZER, y*WYM_OBRAZ*WSP_WYS,100*WSP_SZER, 100*WSP_WYS, NULL);
}

std::ostream & operator<<(std::ostream & strumien, const Obiekt & obiekt)
{
	return obiekt.zapis(strumien);
}

std::istream & operator>>(std::istream & strumien, Obiekt & obiekt)
{
	return obiekt.odczyt(strumien);
}
