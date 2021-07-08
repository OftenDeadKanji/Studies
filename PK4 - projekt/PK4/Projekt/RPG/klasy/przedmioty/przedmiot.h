#pragma once

class Przedmiot :
	public Obiekt
{
private:
	int wartosc = 10;
public:
	Przedmiot();
	Przedmiot(int, int, int, std::string);
	~Przedmiot();

	void zmienWartosc(int);
	virtual void zmienStatystyke(int);
	int podajWartosc();

	bool operator==(const Przedmiot &) const;
};

