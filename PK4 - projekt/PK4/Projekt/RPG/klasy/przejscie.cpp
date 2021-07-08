#include "../pch.h"

Przejscie::Przejscie()
{}

Przejscie::Przejscie(int id, int x, int y, std::string nazwaPliku) : Obiekt(id, x, y, nazwaPliku)
{
	if (id == 7)
		nrDocelowego = 2;
	else if (id == 8)
		nrDocelowego = 1;
}

Przejscie::~Przejscie()
{}

int Przejscie::podajNr()
{
	return nrDocelowego;
}

std::ostream & Przejscie::zapis(std::ostream & strumien) const
{
	strumien << id << std::endl << x << " " << y << std::endl << wejscie << std::endl << nrDocelowego;

	return strumien;
}

std::istream & Przejscie::odczyt(std::istream & strumien)
{
	strumien >> id >> x >> y >> wejscie >> nrDocelowego;

	return strumien;
}
