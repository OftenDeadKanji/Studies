#pragma once

class Pancerz :
	public Przedmiot
{
private:
	int wartObrony = 1;
public:
	Pancerz();
	Pancerz(int, int, int, std::string);
	~Pancerz();

	void zmienWartObrony(int);
	virtual void zmienStatystyke(int);
	int podajWartObrony();

	virtual std::ostream & zapis(std::ostream strumien) const;
	virtual std::istream & odczyt(std::istream strumien);
};

