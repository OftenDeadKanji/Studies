#pragma once
#include "Main.h"

class Obiekt
{
protected:
	int x, y;
	ALLEGRO_BITMAP* obraz;
	bool koniec = false;
public:
	Obiekt();
	Obiekt(Obiekt&);
	~Obiekt();

	int pobX();
	int pobY();
	void zmienX(int);
	void zmienY(int);

	ALLEGRO_BITMAP* pobObraz();
	virtual void zmienObraz(int);
	void zmienTryb(bool tryb);
	virtual void rysuj();
	int czyKoniec();
	virtual void odtworzDzwiek();
	virtual char podajZapis() = 0;
	virtual bool czyWejsc() = 0;
	virtual bool czyZniszczyc() = 0;
	virtual void spadanie(Obiekt* tab[20][20], mutex tabMutex[20][20]);
	virtual void smierc();
	virtual bool podajStan();

	/*void ruchDol(Obiekt &);
	void ruchGora(Obiekt &);
	void ruchLewo(Obiekt &);
	void ruchPrawo(Obiekt &);*/
};

