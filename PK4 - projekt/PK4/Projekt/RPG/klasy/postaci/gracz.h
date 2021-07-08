#pragma once

class Gracz : public Postac
{
private:
	int poziom = 1;
	int maxPktDosw = 100;
public:
	Gracz();
	Gracz(int, int, int, std::string);
	Gracz(Gracz &);
	~Gracz();

	void zmienPoziom(int);
	void dodajPktDos(int);

	int podajMaxPktDosw();
	//int podajLiczbePrzedmiotow();

	void zaktualizujRozkaz();
	void zmienKierunekRuchu(kierunki);

	virtual std::ostream & zapis(std::ostream & strumien) const;
	virtual std::istream & odczyt(std::istream & strumien);
};

