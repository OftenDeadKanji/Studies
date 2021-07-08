#include "../../pch.h"
#include "gracz.h"

Gracz::Gracz()
{}

Gracz::Gracz(int id, int x, int y, std::string nazwaPliku) : Postac(id, x, y, nazwaPliku)
{}

Gracz::Gracz(Gracz& gr) : Postac(gr)
{}

Gracz::~Gracz()
{}

void Gracz::zmienPoziom(int poziom)
{
	this->stat.poziom = poziom;
}

void Gracz::dodajPktDos(int pkt)
{
	this->pktDosw += pkt;
	if (pktDosw >= maxPktDosw) {
		stat.poziom++;
		stat.pktZycia = stat.maxPktZycia += 50;
		stat.szybkoscAtaku += 1;
		stat.szybkoscRuchu += 1;
		stat.wartAtaku += 4;
		stat.wartObrony += 2;
		pktDosw -= maxPktDosw;
	}
}

int Gracz::podajMaxPktDosw()
{
	return maxPktDosw;
}

void Gracz::zaktualizujRozkaz()
{}

void Gracz::zmienKierunekRuchu(kierunki kierunek)
{
	this->kierunek = kierunek;
}

std::ostream & Gracz::zapis(std::ostream & strumien) const
{
	strumien << id << std::endl
		<< x << " " << y << std::endl
		<< wejscie << std::endl
		<< stat.pktZycia << " " << stat.maxPktZycia << " " << stat.szybkoscRuchu << " " << stat.szybkoscAtaku << " " << stat.zloto
		<< " " << stat.poziom << " " << stat.wartAtaku << " " << stat.wartObrony << " " << pktDosw << std::endl;
	Ekwipunek* chwil = glowa;
	while (chwil != NULL) {
		strumien << chwil->przedmiot->podajID() << " " << chwil->czyUzywane << " ";
		chwil = chwil->nast;
	}
	strumien << -1;

	return strumien;
}
std::istream & Gracz::odczyt(std::istream & strumien)
{
	strumien >> id >> x >> y >> wejscie >> stat.pktZycia >> stat.maxPktZycia >> stat.szybkoscRuchu >> stat.szybkoscAtaku >> stat.zloto >> stat.poziom >> stat.wartAtaku >> stat.wartObrony >> pktDosw;
	int idPrzedm;
	bool czyWyekwipowany;
	while (1) {
		strumien >> idPrzedm;
		if (idPrzedm == -1)
			break;
		strumien >> czyWyekwipowany;
		dodajPrzedmiotID(idPrzedm, czyWyekwipowany);
	}
	return strumien;
}