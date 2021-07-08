#pragma once

class Bron :
	public Przedmiot
{
private:
	int wartAtaku = 3;
public:
	Bron();
	Bron(int, int, int, std::string);
	~Bron();

	void zmienWartAtaku(int);
	virtual void zmienStatystyke(int);
	int podajWartAtaku();

	virtual std::ostream & zapis(std::ostream strumien) const;
	virtual std::istream & odczyt(std::istream strumien);
};

