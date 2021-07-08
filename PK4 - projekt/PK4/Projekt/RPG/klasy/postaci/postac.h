#pragma once

class Postac : public Obiekt
{
public:
	struct Ekwipunek {
		Przedmiot* przedmiot = nullptr;
		Ekwipunek* nast = nullptr;
		Ekwipunek* poprz = nullptr;
		int id;
		bool czyUzywane = false;
	};
protected:
	struct Statystyki {
		int pktZycia = START_PKT_ZYC;
		int maxPktZycia = START_PKT_ZYC;
		int szybkoscRuchu = 5;
		int szybkoscAtaku = 5;
		int zloto = 10;
		int poziom = 1;

		int wartAtaku = 5;
		int wartObrony = 1;
	};

	int pktDosw = 35;
	bool stanWalki = false;
	float czasRuch = 0, czasOdstepRuch = 0;
	float czasAtak = 0, czasOdstepAtak = 0;
	Statystyki stat;
	Ekwipunek* glowa = nullptr;
	Ekwipunek* ogon = nullptr;

	kierunki kierunek = aktywanyObraz;
	std::queue <rozkazy> rozkaz;
public:
	Postac();
	Postac(int x, int y);
	Postac(int, int, int, std::string);
	Postac(Postac& post);
	virtual ~Postac();

	int podajPktZycia();
	int podajMaxPktZycia();
	int podajWartAtaku();
	int podajWartObrony();
	int podajPktDosw();
	int podajPoziom();
	int podajSzybkoscRuchu();
	int podajSzybkoscAtaku();
	int podajZloto();

	Przedmiot* podajPrzedmiot(int pozycja);
	void dodajPrzedmiotID(int, bool);
	void ustawEkwipunek();
	void ekwipujBron(Bron*);
	void ekwipujPancerz(Pancerz*);
	void zalozPrzedmiot(Przedmiot * przedmiot);
	void zdejmijPrzedmiot(int pozycja);
	void dodajPrzedmiot(Przedmiot*);
	void usunPrzedmiot(Przedmiot*);
	int podajLiczbePrzedmiotow();
	void usunEkwipunek();

	void zmienPktZycia(int);
	void otrzymajObrazenia(int);
	void zmienStanWalki(bool);
	void zmienCzasRuchu();
	void zmienCzasAtaku();
	bool czyRuch();
	bool czyAtak();

	void zmienSzybkoscRuchu(int);
	void zmienZloto(int);

	rozkazy podajRozkaz();
	bool czyBrakRozkazow();
	kierunki podajKierunekRuchu();
	virtual void zaktualizujRozkaz();
	void dodajRozkaz(rozkazy);
	
	virtual std::ostream & zapis(std::ostream & strumien) const;
	virtual std::istream & odczyt(std::istream & strumien);

	virtual void rysuj();
};

