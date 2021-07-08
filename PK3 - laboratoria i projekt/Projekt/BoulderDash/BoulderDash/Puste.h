#pragma once

class Puste :
	public Obiekt
{
public:
	Puste();
	Puste(int, int);
	Puste(Puste&);
	~Puste();

	char podajZapis();
	bool czyWejsc();
	bool czyZniszczyc();
};

