#pragma once

class Sciana :
	public Obiekt
{
	char rodzaj;
public:
	Sciana(char);
	Sciana(char, int, int);
	Sciana(Sciana&);
	~Sciana();

	char podajZapis();
	bool czyWejsc();
	bool czyZniszczyc();
};

