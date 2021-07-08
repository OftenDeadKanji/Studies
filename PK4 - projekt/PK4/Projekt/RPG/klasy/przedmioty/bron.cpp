#include "../../pch.h"

Bron::Bron()
{}

Bron::Bron(int id, int x, int y, std::string nazwaPliku) : Przedmiot(id, x, y, nazwaPliku)
{}


Bron::~Bron()
{}

void Bron::zmienWartAtaku(int wartAtaku)
{
	this->wartAtaku = wartAtaku;
}

void Bron::zmienStatystyke(int wartAtaku)
{
	this->wartAtaku = wartAtaku;
}

int Bron::podajWartAtaku()
{
	return wartAtaku;
}

std::ostream & Bron::zapis(std::ostream strumien) const
{
	strumien << id << std::endl << x << " " << y << std::endl << wejscie << std::endl << wartAtaku;

	return strumien;
}

std::istream & Bron::odczyt(std::istream strumien)
{
	strumien >> id >> x >> y >> wejscie >> wartAtaku;

	return strumien;
}
