#pragma once

class Gracz :
	public Obiekt
{
private:
	bool czyMartwy = false;
	int posPkt = 0;
	int lbDyn = 0;
public:
	Gracz();
	Gracz(int, int);
	Gracz(Gracz&);
	~Gracz();

	char podajZapis();
	bool czyWejsc();
	bool czyZniszczyc();
	void smierc();
	bool podajStan();
	void zmienPkt(int);
	int podajPkt();
	int podajLbDyn();
	void zmniejszLbDyn();

	void ruchDol(class Plansza* pl, Obiekt* Poziom[][20], Puste* tabPuste[MAXOBIEKTOW], int lbPuste, Obiekt* ob, mutex tabMutex[][20]);
	void ruchGora(class Plansza* pl, Obiekt* Poziom[][20], Puste* tabPuste[MAXOBIEKTOW], int lbPuste, Obiekt* ob, mutex tabMutex[][20]);
	void ruchLewo(class Plansza* pl, Obiekt* Poziom[][20], Puste* tabPuste[MAXOBIEKTOW], int lbPuste, Obiekt* ob, mutex tabMutex[][20]);
	void ruchPrawo(class Plansza* pl, Obiekt* Poziom[][20], Puste* tabPuste[MAXOBIEKTOW], int lbPuste, Obiekt* ob, mutex tabMutex[][20]);
};

