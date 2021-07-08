#pragma once

class NPC :
	public Postac
{
protected:
	int xDocelowy, yDocelowy;
	int xGracz, yGracz;
public:
	NPC();
	NPC(int, int, int, std::string);
	NPC(NPC &);
	virtual ~NPC();

	virtual std::ostream & zapis(std::ostream & strumien) const;
	virtual std::istream & odczyt(std::istream & strumien);

	void zaktualizujRozkaz();
	void ustalCel(int, int);
	void ustawWspGracza(int, int);
	void zmienKierunek();
};

