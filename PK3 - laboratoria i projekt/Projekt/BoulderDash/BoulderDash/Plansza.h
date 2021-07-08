#pragma once

class Plansza
{
private:
	Obiekt* tabObiekt[lbObiekt];
	Obiekt* Poziom[20][20];
	mutex tabMutex[20][20];

	Puste* tabPuste[MAXOBIEKTOW];
	int lbPuste = 0;
	Ziemia* tabZiemia[MAXOBIEKTOW];
	int lbZiemia = 0;
	Skala* tabSkala[MAXOBIEKTOW];
	int lbSkala = 0;
	Sciana* tabSciana[MAXOBIEKTOW];
	int lbSciana = 0;
	Drzwi* tabDrzwi[MAXOBIEKTOW];
	int lbDrzwi = 0;
	Gracz* tabGracz[MAXOBIEKTOW];
	int lbGracz = 0;
	Diament* tabDiament[MAXOBIEKTOW];
	int lbDiament = 0;
	Dynamit* tabDynamit[MAXOBIEKTOW];
	int lbDynamit = 0;
	AktDynamit* tabAktDynamit[MAXOBIEKTOW];
	int lbAktDynamit = 0;

public:
	Plansza();
	~Plansza();

	void dodajPuste(Puste&);
	void dodajZiemia(Ziemia&);
	void dodajSkala(Skala&);
	void dodajSciana(Sciana&);
	void dodajDrzwi(Drzwi&);
	void dodajGracz(Gracz&);
	void dodajDiament(Diament&);
	void dodajDynamit(Dynamit&);
	void dodajAktDynamit(AktDynamit&);

	void wczytajPoziom(int nrPoz);
	void rysuj();
	void usun();
	void zmienTrybDyn();
	void obslugaSpadania2(Obiekt* tab[20][20], mutex tabMut[20][20], int x, int y);
	void graj();
};

