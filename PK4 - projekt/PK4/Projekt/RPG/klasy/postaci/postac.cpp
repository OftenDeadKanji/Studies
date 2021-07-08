#include "../../pch.h"
#include "postac.h"

#pragma region Konstruktory i destruktor
Postac::Postac(): Obiekt()
{}

Postac::Postac(int x, int y) : Obiekt(x, y)
{}

Postac::Postac(int id, int x, int y, std::string nazwaPliku) : Obiekt(id, x, y, nazwaPliku)
{}

Postac::Postac(Postac& pos) : Obiekt(pos)
{
	this->stat.pktZycia = pos.stat.pktZycia;
	this->stat.maxPktZycia = pos.stat.maxPktZycia;
	this->stat.szybkoscRuchu = pos.stat.szybkoscRuchu;
	this->stat.szybkoscAtaku = pos.stat.szybkoscAtaku;
	this->stat.zloto = pos.stat.zloto;
	this->stat.poziom = pos.stat.poziom;

	this->stat.wartAtaku = pos.stat.wartAtaku;
	this->stat.wartObrony = pos.stat.wartObrony;

	this->pktDosw = pos.pktDosw;

	Ekwipunek* chwil = pos.glowa;
	while (chwil != NULL) {
		if (chwil->przedmiot != NULL) {
			this->dodajPrzedmiot(new Przedmiot(*chwil->przedmiot));
			this->zdejmijPrzedmiot(podajLiczbePrzedmiotow() - 1);
		}
		else
			this->dodajPrzedmiotID(chwil->id, chwil->czyUzywane);
		chwil = chwil->nast;
	}
}

Postac::~Postac()
{
	usunEkwipunek();
}
#pragma endregion

#pragma region Ekwipunek
Przedmiot * Postac::podajPrzedmiot(int pozycja)
{
	Ekwipunek* wsk = this->glowa;
	while (wsk)
		if (!pozycja)
			return wsk->przedmiot;
		else {
			pozycja--;
			wsk = wsk->nast;
		}
	return nullptr;
}

void Postac::ustawEkwipunek()
{
	Ekwipunek* chwil = this->glowa;
	while (chwil != NULL) {
		switch (chwil->id) {
		case 10: {
			int idSzukaj;
			int stat;
			int wartosc;
			std::string sciezka;
			std::string dane;

			std::ifstream plikBitmapa;
			plikBitmapa.open("Spis/ID.txt", std::ios::in);
			if (!plikBitmapa.is_open())
				throw Wyjatek("Nie mozna otworzyc pliku Spis/ID.txt");

			std::ifstream plikAtak;
			plikAtak.open("Spis/Info.txt", std::ios::in);
			if (!plikAtak.is_open())
				throw Wyjatek("Nie mozna otworzyc pliku Spis/Info.txt");

			while (!plikBitmapa.eof()) {
				plikBitmapa >> dane;
				idSzukaj = atoi(dane.c_str());
				if (idSzukaj == chwil->id) {
					plikBitmapa >> sciezka;
					break;
				}
			}
			while (!plikAtak.eof()) {
				plikAtak >> dane;
				idSzukaj = atoi(dane.c_str());
				if (idSzukaj == chwil->id) {
					plikAtak >> stat >> stat >> wartosc;
					break;
				}
				else {
					while (dane != "---")
						plikAtak >> dane;
				}
			}
			if (chwil->przedmiot == NULL) {
				Bron* nowy = new Bron(chwil->id, this->x, this->y, sciezka);
				nowy->zmienWartAtaku(stat);
				nowy->zmienWartosc(wartosc);
				chwil->przedmiot = nowy;
			}
			else {
				chwil->przedmiot->zmienStatystyke(stat);
				chwil->przedmiot->zmienWartosc(wartosc);
			}
			plikAtak.close();
			plikBitmapa.close();
		}
				 break;
		case 15:
		case 16: {
			int idSzukaj;
			int stat;
			int wartosc;
			std::string sciezka;
			std::string dane;

			std::ifstream plikBitmapa;
			plikBitmapa.open("Spis/ID.txt", std::ios::in);
			if (!plikBitmapa.is_open())
				throw Wyjatek("Nie mozna otworzyc pliku Spis/ID.txt");

			std::ifstream plikObrona;
			plikObrona.open("Spis/Info.txt", std::ios::in);
			if (!plikObrona.is_open())
				throw Wyjatek("Nie mozna otworzyc pliku Spis/ID.txt");

			while (!plikBitmapa.eof()) {
				plikBitmapa >> dane;
				idSzukaj = atoi(dane.c_str());
				if (idSzukaj == chwil->id) {
					plikBitmapa >> sciezka;
					break;
				}
			}
			while (!plikObrona.eof()) {
				plikObrona >> dane;
				idSzukaj = atoi(dane.c_str());
				if (idSzukaj == chwil->id) {
					plikObrona >> stat >> stat >> wartosc;
					break;
				}
				else {
					while (dane != "---")
						plikObrona >> dane;
				}

			}
			if (chwil->przedmiot == NULL) {
				Pancerz* nowy = new Pancerz(chwil->id, this->x, this->y, sciezka);
				nowy->zmienWartObrony(stat);
				nowy->zmienWartosc(wartosc);
				chwil->przedmiot = nowy;
			}
			else {
				chwil->przedmiot->zmienStatystyke(stat);
				chwil->przedmiot->zmienWartosc(wartosc);
			}
			plikObrona.close();
			plikBitmapa.close();
		}
				 break;
		}
		chwil = chwil->nast;
	}

}

void Postac::ekwipujBron(Bron * bron)
{
	stat.wartAtaku = bron->podajWartAtaku();
}

void Postac::ekwipujPancerz(Pancerz * pancerz)
{
	stat.wartObrony = pancerz->podajWartObrony();
}

void Postac::zalozPrzedmiot(Przedmiot* przedmiot)
{
	if (auto bron = dynamic_cast<Bron*>(przedmiot)) {
		Ekwipunek* wsk = this->glowa;
		//zdjemowanie broni
		while (wsk != NULL) {
			if (wsk->czyUzywane)
				if (auto czyBron = dynamic_cast<Bron*>(wsk->przedmiot)) {
					stat.wartAtaku -= czyBron->podajWartAtaku();
					wsk->czyUzywane = false;
					break;
				}
			wsk = wsk->nast;
		}
		//zakladanie broni
		wsk = this->glowa;
		while (wsk != NULL) {
			if (wsk->przedmiot == przedmiot) {
				stat.wartAtaku += bron->podajWartAtaku();
				wsk->czyUzywane = true;
				break;
			}
			wsk = wsk->nast;
		}
		
	}
	else if (auto pancerz = dynamic_cast<Pancerz*>(przedmiot)) {
		Ekwipunek* wsk = this->glowa;
		//zdjemowanie broni
		while (wsk != NULL) {
			if (wsk->czyUzywane)
				if (auto czyPancerz = dynamic_cast<Pancerz*>(wsk->przedmiot)) {
					stat.wartObrony -= czyPancerz->podajWartObrony();
					wsk->czyUzywane = false;
					break;
				}
			wsk = wsk->nast;
		}
		//zakladanie broni
		wsk = this->glowa;
		while (wsk != NULL) {
			if (wsk->przedmiot == przedmiot) {
				stat.wartObrony += pancerz->podajWartObrony();
				wsk->czyUzywane = true;
				break;
			}
			wsk = wsk->nast;
		}
		
	}
}

void Postac::zdejmijPrzedmiot(int pozycja)
{
	Ekwipunek* wsk = this->glowa;
	while (wsk != NULL)
		if (!pozycja) {
			if (wsk->czyUzywane) {
				wsk->czyUzywane = false;
				if (auto bron = dynamic_cast<Bron*>(wsk->przedmiot))
					stat.wartAtaku -= bron->podajWartAtaku();
				else if (auto pancerz = dynamic_cast<Pancerz*>(wsk->przedmiot))
					stat.wartObrony -= pancerz->podajWartObrony();
			}
			break;
		}
		else {
			pozycja--;
			wsk = wsk->nast;
		}
}

void Postac::dodajPrzedmiot(Przedmiot * przedm)
{
	Ekwipunek* nowy = new Ekwipunek;
	nowy->przedmiot = przedm;
	if (glowa == nullptr) {
		glowa = ogon = nowy;
		glowa->id = przedm->podajID();
		return;
	}
	ogon->nast = nowy;
	nowy->poprz = ogon;
	ogon = nowy;
	ogon->id = przedm->podajID();
	
}

void Postac::dodajPrzedmiotID(int id, bool czyWyekwipowany)
{
	Ekwipunek* nowy = new Ekwipunek;
	nowy->id = id;
	nowy->czyUzywane = czyWyekwipowany;
	if (glowa == nullptr) {
		glowa = ogon = nowy;
		return;
	}
	ogon->nast = nowy;
	nowy->poprz = ogon;
	ogon = nowy;
}

void Postac::usunPrzedmiot(Przedmiot * przedm)
{
	Ekwipunek* chwil = glowa;
	Ekwipunek* chwil2 = ogon;
	int lb = podajLiczbePrzedmiotow();
	if (lb == 1) {
		if ((*chwil->przedmiot) == *przedm)
			glowa = ogon = glowa->nast = glowa->poprz = ogon->nast = ogon->poprz = nullptr;
		return;
	}
		
	if ((*chwil->przedmiot) == *przedm) {
		glowa = glowa->nast;
		glowa->poprz = nullptr;
		delete chwil;
		return;
	}
	if (ogon != NULL && (*chwil2->przedmiot) == *przedm) {
		ogon = ogon->poprz;
		ogon->nast = nullptr;
		delete chwil2;
		return;
	}
	while (chwil) {
		if ((*chwil->przedmiot) == *przedm) {
			chwil->poprz->nast = chwil->nast;
			chwil->nast->poprz = chwil->poprz;
			delete chwil;
			return;
		}
		chwil = chwil->nast;
	}
}

int Postac::podajLiczbePrzedmiotow()
{
	int licznik = 0;
	Ekwipunek* wsk = this->glowa;
	while (wsk) {
		licznik++;
		wsk = wsk->nast;
	}
	return licznik;
}

void Postac::usunEkwipunek()
{
	Ekwipunek* chwil = glowa;
	while (glowa != nullptr) {
		glowa = glowa->nast;
		delete chwil;
		chwil = glowa;
	}
}

#pragma endregion

#pragma region Zapis i odczyt
std::ostream & Postac::zapis(std::ostream & strumien) const
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
std::istream & Postac::odczyt(std::istream & strumien)
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
#pragma endregion

int Postac::podajPktZycia()
{
	return stat.pktZycia;
}

int Postac::podajMaxPktZycia()
{
	return stat.maxPktZycia;
}
int Postac::podajWartAtaku()
{
	return stat.wartAtaku;
}
int Postac::podajWartObrony()
{
	return stat.wartObrony;
}
int Postac::podajPktDosw()
{
	return pktDosw;
}
int Postac::podajPoziom()
{
	return stat.poziom;
}
void Postac::zmienPktZycia(int pkt)
{
	stat.pktZycia = pkt;
}

void Postac::otrzymajObrazenia(int obrazenia)
{
	if (obrazenia - this->podajWartObrony() > 0)
		this->zmienPktZycia(podajPktZycia() - (obrazenia - this->podajWartObrony()));
	if (auto gracz = dynamic_cast<Gracz*>(this))
		if(gracz->podajPktZycia() <= 0)
		throw Wyjatek("Zginales. Koniec gry.");
}

void Postac::zmienStanWalki(bool stanWalki)
{
	this->stanWalki = stanWalki;
}

void Postac::zmienCzasRuchu()
{
	czasRuch = clock() / static_cast<float>(CLOCKS_PER_SEC);
}

void Postac::zmienCzasAtaku()
{
	czasAtak = clock() / static_cast<float>(CLOCKS_PER_SEC);
}

bool Postac::czyRuch()
{
	czasOdstepRuch = clock() / static_cast<float>(CLOCKS_PER_SEC) - czasRuch;

	if (czasOdstepRuch >= 2.5 / (float)stat.szybkoscRuchu)
		return true;
	return false;
}

bool Postac::czyAtak()
{
	czasOdstepAtak = clock() / static_cast<float>(CLOCKS_PER_SEC) - czasAtak;

	if (czasOdstepAtak >= 2.5 / (float)stat.szybkoscAtaku)
		return true;
	return false;
}

void Postac::zmienSzybkoscRuchu(int szyb)
{
	stat.szybkoscRuchu = szyb;
}

void Postac::zmienZloto(int zloto)
{
	stat.zloto = zloto;
}

int Postac::podajSzybkoscRuchu()
{
	return stat.szybkoscRuchu;
}

int Postac::podajSzybkoscAtaku()
{
	return stat.szybkoscAtaku;
}

int Postac::podajZloto()
{
	return stat.zloto;
}

rozkazy Postac::podajRozkaz()
{
	if (this->rozkaz.empty())
		return NIC;
	rozkazy rozkaz = this->rozkaz.front();
	this->rozkaz.pop();
	return rozkaz;
}

bool Postac::czyBrakRozkazow()
{
	return rozkaz.empty();
}

kierunki Postac::podajKierunekRuchu()
{
	return kierunek;
}

void Postac::zaktualizujRozkaz()
{}

void Postac::dodajRozkaz(rozkazy rozkaz)
{
	this->rozkaz.push(rozkaz);
}

void Postac::rysuj()
{
	Obiekt::rysuj();

	if (stanWalki) {
		float procent = (float)stat.pktZycia / (float)stat.maxPktZycia;
		float x1 = (x + 0.2) * WYM_OBRAZ * WSP_SZER;
		float y1 = (y + 0.05) * WYM_OBRAZ * WSP_WYS;
		float x2 = x1 + 0.6 * WYM_OBRAZ * WSP_SZER;
		float y2 = y1 + 0.07 * WYM_OBRAZ * WSP_SZER;
		float szerPaska = x2 - x1;
		al_draw_rectangle(x1, y1, x2, y2, al_map_rgb(CZARNY), 1);
		al_draw_filled_rectangle(x1 + 1, y1 + 1, x1 + szerPaska * procent - 1, y2 - 1, al_map_rgb(CZERWONY));
	}
}
