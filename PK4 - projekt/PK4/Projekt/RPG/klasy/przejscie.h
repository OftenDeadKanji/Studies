#pragma once
class Przejscie : public Obiekt
{
private:
	int nrDocelowego = 1;
public:
	Przejscie();
	Przejscie(int id, int x, int y, std::string nazwaPliku);
	~Przejscie();

	int podajNr();
	std::ostream & zapis(std::ostream & strumien) const;
	std::istream & odczyt(std::istream & strumien);
};

