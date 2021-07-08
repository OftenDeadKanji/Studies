#pragma once

class Obiekt
{
protected:
	ALLEGRO_BITMAP* obrazy[4];
	ALLEGRO_BITMAP* aktObraz;
	int id;
	int x = 0, y = 0; //wspó³rzêdne
	bool wejscie; //czy mo¿na wejœæ w pole w którym znajduje siê ten obiekt
	kierunki aktywanyObraz = DOL;
public:
	Obiekt();
	Obiekt(int x, int y);
	Obiekt(int id, int x, int y);
	Obiekt(int id, int x, int y, std::string nazwaPliku);
	Obiekt(Obiekt& ob);
	virtual ~Obiekt();

	bool operator<(Obiekt o);

	virtual std::ostream & zapis(std::ostream & strumien) const;
	virtual std::istream & odczyt(std::istream & strumien);

	void zmienObraz(ALLEGRO_BITMAP* obraz);
	void zmienX(int x);
	void zmienY(int y);
	void zmienWejscie(bool);
	void zmienAktObraz(kierunki kier);

	ALLEGRO_BITMAP* podajObraz();
	int podajX();
	int podajY();
	int podajID();
	bool czyWejsc();
	kierunki podajKierunek();

	void zaladujObraz(std::map <int, std::vector<std::string>>);
	virtual void rysuj();
};

class porownanieObiektow {
public:
	bool operator()(Obiekt* o1, Obiekt* o2) {
		if (o1->podajID() <= o2->podajID())
			return false;
		else
			return true;
	}
};

std::ostream & operator<<(std::ostream & strumien, const Obiekt & obiekt);
std::istream & operator>>(std::istream & strumien, Obiekt & obiekt);
