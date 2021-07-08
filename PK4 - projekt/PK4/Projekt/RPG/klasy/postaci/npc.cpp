#include "../../pch.h"
#include "npc.h"


NPC::NPC() : Postac()
{
	obrazy[0] = al_load_bitmap("Obrazy/NPC.png");
	aktObraz = obrazy[0];
}

NPC::NPC(int id, int x, int y, std::string nazwaPliku) : Postac(id, x, y, nazwaPliku)
{}

NPC::NPC(NPC& npc) : Postac(npc)
{
	//this->id = npc.id;
	//this->x = npc.x;
	//this->y = npc.y;
	//this->wejscie = npc.wejscie;
	//for (int i = 0; i < 4; i++)
	//	if (npc.obrazy[i] != NULL)
	//		obrazy[i] = al_clone_bitmap(npc.obrazy[i]);
	//aktywanyObraz = DOL;
	//aktObraz = obrazy[aktywanyObraz];
}

NPC::~NPC()
{}

std::ostream & NPC::zapis(std::ostream & strumien) const
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
std::istream & NPC::odczyt(std::istream & strumien)
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

void NPC::zaktualizujRozkaz()
{
	if (stanWalki) {
		dodajRozkaz(SCIEZKA_DO_GRACZA);
		dodajRozkaz(ZMIEN_KIERUNEK);
		dodajRozkaz(RUCH);

		if (abs(x - xGracz) == 1 && abs(y - yGracz) == 0) {
			if (x > xGracz)
				if (kierunek == LEWO)
					dodajRozkaz(ATAK);
				else {
					kierunek = LEWO;
					dodajRozkaz(RUCH);
				}
			else
				if (kierunek == PRAWO)
					dodajRozkaz(ATAK);
				else {
					kierunek = PRAWO;
					dodajRozkaz(RUCH);
				}
		}
		else if (abs(x - xGracz == 0 && abs(y - yGracz) == 1)) {
			if (y > yGracz)
				if (kierunek == GORA)
					dodajRozkaz(ATAK);
				else {
					kierunek = GORA;
					dodajRozkaz(RUCH);
				}
			else
				if (kierunek == DOL)
					dodajRozkaz(ATAK);
				else {
					kierunek = DOL;
					dodajRozkaz(RUCH);
				}
		}
	}
}

void NPC::ustalCel(int x, int y)
{
	xDocelowy = x;
	yDocelowy = y;
}

void NPC::ustawWspGracza(int x, int y)
{
	xGracz = x;
	yGracz = y;
}

void NPC::zmienKierunek()
{
	if (abs(x - xDocelowy) == 1 && abs(y - yDocelowy) == 0) {
		if (x > xDocelowy) {
			if (kierunek != LEWO) {
				kierunek = LEWO;
				dodajRozkaz(RUCH);
			}
		}
		else
			if (kierunek != PRAWO) {
				kierunek = PRAWO;
				dodajRozkaz(RUCH);
			}
	}
	else if (abs(x - xDocelowy == 0 && abs(y - yDocelowy) == 1)) {
		if (y > yDocelowy) {
			if (kierunek != GORA) {
				kierunek = GORA;
				dodajRozkaz(RUCH);
			}
		}
		else
			if (kierunek != DOL) {
				kierunek = DOL;
				dodajRozkaz(RUCH);
			}
	}
}
