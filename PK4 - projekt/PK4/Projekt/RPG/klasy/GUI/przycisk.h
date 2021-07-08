#pragma once
class Przycisk
{
private:
	Tekst* napis;
	float x1, y1, x2, y2; //wspolrzedne
	bool czyInteraktywne = true;
	bool czyRamka = true;
public:
	Przycisk();
	Przycisk(std::string napis, float x, float y, int wlk);
	Przycisk(std::string napis, float x, float y, int wlk, bool czyIn, bool czyRmk);
	~Przycisk();

	void zmienX(float);
	void zmienY(float);
	void zmienCzyInterakt(bool);
	void zmienCzyRamka(bool);
	void zmienNapis(std::string);
	void zmienWielkosc(int);

	void podajWymiary(int &, int &);

	bool czyKlik();
	void rysuj();
};

