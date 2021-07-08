#include "../../pch.h"

Przedmiot::Przedmiot()
{
}

Przedmiot::Przedmiot(int id , int x, int y , std::string nazwaPliku) : Obiekt(id, x, y, nazwaPliku)
{}


Przedmiot::~Przedmiot()
{
}

void Przedmiot::zmienWartosc(int wartosc)
{
	this->wartosc = wartosc;
}

void Przedmiot::zmienStatystyke(int)
{}

int Przedmiot::podajWartosc()
{
	return wartosc;
}

bool Przedmiot::operator==(const Przedmiot & przedm) const
{
	return this->id == przedm.id ? true : false;
}
