#include "../../pch.h"

Pancerz::Pancerz()
{}

Pancerz::Pancerz(int id, int x, int y, std::string nazwaPliku) : Przedmiot(id, x, y, nazwaPliku)
{}


Pancerz::~Pancerz()
{}

void Pancerz::zmienWartObrony(int wartObrony)
{
	this->wartObrony = wartObrony;
}

void Pancerz::zmienStatystyke(int stat)
{
	zmienWartObrony(stat);
}

int Pancerz::podajWartObrony()
{
	return wartObrony;
}

std::ostream & Pancerz::zapis(std::ostream strumien) const
{
	strumien << id << std::endl << x << " " << y << std::endl << wejscie << std::endl << wartObrony;

	return strumien;
}

std::istream & Pancerz::odczyt(std::istream strumien)
{
	strumien >> id >> x >> y >> wejscie >> wartObrony;

	return strumien;
}