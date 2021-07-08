#include "../pch.h"
#include "poziom.h"

enum typy {OBIEKT, GRACZ};

Poziom::Poziom()
{}

Poziom::~Poziom()
{
	usunZawartosc();
}

#pragma region Wczytywanie, zapisywanie
//wczytywanie spisu, który przechowuje nazwy plików z obrazami
void Poziom::wczytajSpis()
{
	spis.clear();
	std::ifstream plik;
	std::string dane;
	int id;
	plik.open("Spis/ID.txt", std::ios::in);
	if (!plik.is_open())
		throw Wyjatek("Nie mozna otworzyc pliku Spis/ID.txt");
	while (!plik.eof()) {
		getline(plik, dane);
		if (dane == "")
			break;
		id = atoi(dane.c_str());
		while (dane != "---") {
			getline(plik, dane);
			if (dane == "---")
				break;
			spis[id].push_back(dane);
		}
	}

	plik.close();
}

//przechodzenie pomiêdzy poziomami
void Poziom::przejdz(int x, int y)
{
	int nrPoprz = nrPoz;
	int nrNast = 0;
	Gracz* gr = nullptr;
	for (auto iter = plansza[x][y].begin(); iter != plansza[x][y].end(); iter++) {
		if (auto prz = dynamic_cast<Przejscie*>(*iter)) {
			nrNast = prz->podajNr();
			for(auto iterGracz = plansza[x][y].begin(); iterGracz != plansza[x][y].end(); iterGracz++)
				if (gr = dynamic_cast<Gracz*>(*iterGracz)) {
					plansza[x][y].extract(iterGracz);
					break;
				}
			zapiszPoziom();
			usunZawartosc();
			wczytajPoziom(nrNast);
			for (auto i = plansza.begin(); i != plansza.end(); i++)
				for (auto j = i->begin(); j != i->end(); j++)
					for (auto k = j->begin(); k != j->end(); k++)
						if (auto cel = dynamic_cast<Przejscie*>(*k)) {
							if (cel->podajNr() == nrPoprz) {
								gr->zmienX(cel->podajX());
								gr->zmienY(cel->podajY());
								j->emplace(new Gracz(*gr));
							}
						}
			break;
		}
	}
}

void Poziom::wczytajPoziom(int nrPoziomu)
{
	std::ostringstream konwersja;
	konwersja << nrPoziomu;

	std::ifstream plik;
	plik.open("Zapis/Poziomy/Gra/" + konwersja.str() + ".dat", std::ios::in | std::ios::binary);
	if(!plik.is_open())
		throw Wyjatek("Nie mozna otworzyc pliku Zapis/Poziomy/Gra/" + konwersja.str() + ".dat");
	nrPoz = nrPoziomu;

	//WCZYTYWANIE POZIOMU

	wczytajSpis();

	plik.seekg(1, std::ios_base::cur);
	char sprawdzenie;
	plik >> sprawdzenie;
	while (!plik.eof()) {
		plik.seekg(-1, std::ios_base::cur);

		std::string typ;
		plik >> typ >> typ;

		if (typ == "Obiekt")
			dodajObiekt(plik);
		else if (typ == "Gracz")
			dodajGracz(plik);
		else if (typ == "Bron")
			dodajBron(plik);
		else if (typ == "NPC")
			dodajNpc(plik);
		else if (typ == "Przejscie")
			dodajPrzejscie(plik);
		else if (typ == "Handlarz")
			dodajHandlarz(plik);
		else if (typ == "Pancerz")
			dodajPancerz(plik);

		std::string dane;
		plik >> dane;
		if (dane != "---") //czêœciowe zabezpieczenie przed niepoprawn¹ struktur¹ pliku
			throw Wyjatek("Plik Zapis/Poziomy/Gra/" + konwersja.str() + ".dat ma niepoprawna strukture.");

		plik.seekg(1, std::ios_base::cur);
		plik >> sprawdzenie;
	}
	plik.close();
}

void Poziom::wczytajPoziomEdytor(int nrPoziomu)
{
	std::ostringstream konwersja;
	konwersja << nrPoziomu;

	std::ifstream plik;
	plik.open("Zapis/Poziomy/Edytor/" + konwersja.str() + ".dat", std::ios::in | std::ios::binary);
	if(!plik.is_open())
		throw Wyjatek("Nie mozna otworzyc pliku Zapis/Poziomy/Edytor/" + konwersja.str() + ".dat");
	nrPoz = nrPoziomu;

	wczytajSpis();

	//WCZYTYWANIE POZIOMU
	std::string dane;
	
	char sprawdzenie;
	plik >> sprawdzenie;

	if (plik.eof())
		return;
	else
		plik.seekg(0);
	plik.seekg(1, std::ios_base::cur);
	while (!plik.eof()) {

		plik.seekg(-1, std::ios_base::cur);

		int id = 0, x = 0, y = 0;
		plik >> id >> x >> y;
		if (x < 0 || x > maxX || y < 0 || y > maxY)
			break;
		dodajElementPlanszy(id, x, y);
		plik >> dane;
		if (dane != "---") //czêœciowe zabezpieczenie przed niepoprawn¹ struktur¹ pliku
			throw Wyjatek("Plik Zapis/Poziomy/Edytor/" + konwersja.str() + ".dat ma niepoprawna strukture");
		plik.seekg(1, std::ios_base::cur);
		plik >> sprawdzenie;
	}
}

void Poziom::zapiszPoziom()
{
	std::ofstream plikStan;
	plikStan.open("Zapis/stan.dat", std::ios::binary | std::ios::out | std::ios::trunc);
	plikStan << nrPoz;
	plikStan.close();

	std::ostringstream konwersja;
	konwersja << nrPoz;

	std::ofstream plikEdytor;
	plikEdytor.open("Zapis/Poziomy/Edytor/" + konwersja.str() + ".dat", std::ios::out | std::ios::binary | std::ios::trunc);
	for (auto i = plansza.begin(); i != plansza.end(); i++)
		for (auto j = i->begin(); j != i->end(); j++)
			for (auto iter = j->begin(); iter != j->end(); iter++)
					plikEdytor	<< (*iter)->podajID() << std::endl
								<< (*iter)->podajX() << " " << (*iter)->podajY() << std::endl
								<< "---" << std::endl;
	plikEdytor.close();

	std::ofstream plikInformacje;
	plikInformacje.open("Zapis/Poziomy/Gra/" + konwersja.str() + ".dat", std::ios::out | std::ios::binary | std::ios::trunc);
	for (auto i = plansza.begin(); i != plansza.end(); i++)
		for (auto j = i->begin(); j != i->end(); j++)
			for (auto iter = j->begin(); iter != j->end(); iter++) {
				plikInformacje << typeid(**iter).name() << std::endl;
				plikInformacje << **iter;
				plikInformacje << std::endl << "---" << std::endl;
			}
	plikInformacje.close();
}
#pragma endregion

#pragma region Dodawanie i usuwanie obiektów
void Poziom::dodajElementPlanszy(int id, int wspX, int wspY)
{
	switch (id) {
	case 0:
	case 1: //œciana
	case 2:
	case 3:
	case 4: //trawa
	case 5: //kamienna droga
		plansza[wspX][wspY].emplace(new Obiekt(id, wspX, wspY, spis.find(id)->second[0]));
		break;
	case 7: //drogowskaz 1->2
	case 8: //drogowskaz 2->1
		plansza[wspX][wspY].emplace(new Przejscie(id, wspX, wspY, spis.find(id)->second[0]));
		break;
	case 10: //bron
		plansza[wspX][wspY].emplace(new Bron(id, wspX, wspY, spis.find(id)->second[0]));
		break;
	case 15:
	case 16: //pancerz
		plansza[wspX][wspY].emplace(new Pancerz(id, wspX, wspY, spis.find(id)->second[0]));
		break;
	case 21: //NPC
		plansza[wspX][wspY].emplace(new NPC(id, wspX, wspY, spis.find(id)->second[0]));
		break;
	case 30: //handlarz
		plansza[wspX][wspY].emplace(new Handlarz(id, wspX, wspY, spis.find(id)->second[0]));
		break;
	case 100: //gracz
		plansza[wspX][wspY].emplace(new Gracz(id, wspX, wspY, spis.find(id)->second[0]));
		break;
	}

	std::ifstream plik;
	plik.open("Spis/Info.txt", std::ios::in);
	if (!plik.is_open())
		throw Wyjatek("Nie mozna otworzyc pliku Spis/Info.txt");
	std::string wczytID;
	while (!plik.eof()) {
		plik >> wczytID;
		if (atoi(wczytID.c_str()) == id) {
			bool wejscie;
			plik >> wejscie;
			for (auto iter = plansza[wspX][wspY].begin(); iter != plansza[wspX][wspY].end(); iter++)
				if ((*iter)->podajID() == id) {
					(*iter)->zmienWejscie(wejscie);
					break;
				}
			break;
		}
	}
	plik.close();
}

//usuwanie obiektów z pola w edytorze
void Poziom::usunElementPlanszy(int wspX, int wspY) {
	auto iter = plansza[wspX][wspY].end();
	if (iter == plansza[wspX][wspY].begin())
		return;
	delete *(--iter);
	plansza[wspX][wspY].extract(iter);
}

void Poziom::dodajObiekt(std::ifstream & plik)
{
	Obiekt ob;
	plik >> ob;
	ob.zaladujObraz(spis);
	plansza[ob.podajX()][ob.podajY()].emplace(new Obiekt(ob));
}

void Poziom::dodajGracz(std::ifstream & plik)
{
	Gracz gr;
	plik >> gr;
	gr.zaladujObraz(spis);
	plansza[gr.podajX()][gr.podajY()].emplace(new Gracz(gr));
}

void Poziom::dodajNpc(std::ifstream & plik)
{
	NPC npc;
	plik >> npc;
	npc.zaladujObraz(spis);
	plansza[npc.podajX()][npc.podajY()].emplace(new NPC(npc));
}

void Poziom::dodajBron(std::ifstream & plik)
{
	Bron br;
	plik >> br;
	br.zaladujObraz(spis);
	plansza[br.podajX()][br.podajY()].emplace(new Bron(br));
}

void Poziom::dodajPancerz(std::ifstream & plik)
{
	Pancerz pan;
	plik >> pan;
	pan.zaladujObraz(spis);
	plansza[pan.podajX()][pan.podajY()].emplace(new Pancerz(pan));
}

void Poziom::dodajPrzejscie(std::ifstream & plik)
{
	Przejscie prz;
	plik >> prz;
	prz.zaladujObraz(spis);
	plansza[prz.podajX()][prz.podajY()].emplace(new Przejscie(prz));
}

void Poziom::dodajHandlarz(std::ifstream & plik)
{
	Handlarz han;
	plik >> han;
	han.zaladujObraz(spis);
	plansza[han.podajX()][han.podajY()].emplace(new Handlarz(han));
}

void Poziom::usunZawartosc()
{
	for (auto i = plansza.begin(); i != plansza.end(); i++)
		for (auto j = i->begin(); j != i->end(); j++) {
			for (auto iter = j->begin(); iter != j->end(); iter++)
				delete *iter;
			j->clear();
		}
}
#pragma endregion

//funkcja sprawdza czy gracz znajduje siê na planszy i zwraca go
Gracz* Poziom::sprawdzGracz()
{
	for (auto i = plansza.begin(); i != plansza.end(); i++)
		for (auto j = i->begin(); j != i->end(); j++)
			for (auto iter = j->begin(); iter != j->end(); iter++)
				if (auto gr = dynamic_cast<Gracz*>(*iter))
					return gr;
	return nullptr;
}

//funkcja sprawdza czy któryœ NPC nie zgin¹³, jeœli tak dodaje XP 
void Poziom::umieranie(Gracz* gracz)
{
	for (auto i = plansza.begin(); i != plansza.end(); i++)
		for (auto j = i->begin(); j != i->end(); j++)
			for (auto k = j->begin(); k != j->end(); k++)
				if (auto postac = dynamic_cast<Postac*>(*k))
					if (postac->podajPktZycia() <= 0) {
						//œmieræ NPC
						gracz->dodajPktDos(postac->podajPktDosw());
						delete *k;
						j->extract(postac);
						break;
					}
}

bool Poziom::ruch(Postac & postac)
{
	int x = postac.podajX();
	int y = postac.podajY();

	std::set<Obiekt*>::iterator iterPostac; //iterator do "przechwycenia" postaci, by móc j¹ potem usun¹æ z aktualnego pola
	for (iterPostac = plansza[x][y].begin(); iterPostac != plansza[x][y].end(); iterPostac++)
		if (auto post = dynamic_cast<Postac*>(*iterPostac))
			break;

	if (postac.podajKierunekRuchu() != postac.podajKierunek()) {
		postac.zmienAktObraz(postac.podajKierunekRuchu());
		postac.zmienCzasRuchu();
		return true;
	}

	if (postac.czyRuch()) {
		switch (postac.podajKierunekRuchu()) {
		case DOL:
			if (y < maxY) {
				for (auto iter = plansza[x][y + 1].begin(); iter != plansza[x][y + 1].end(); iter++)
					if (!(*iter)->czyWejsc())
						return false;
				postac.zmienCzasRuchu();
				plansza[x][y + 1].insert(*iterPostac);
				postac.zmienY(y + 1);
				plansza[x][y].extract(iterPostac);
				return true;
			}
			break;
		case GORA:
			if (y > 0) {
				for (auto iter = plansza[x][y - 1].begin(); iter != plansza[x][y - 1].end(); iter++)
					if (!(*iter)->czyWejsc())
						return false;
				postac.zmienCzasRuchu();
				plansza[x][y - 1].insert(*iterPostac);
				postac.zmienY(y - 1);
				plansza[x][y].extract(iterPostac);
				return true;
			}
			break;
		case LEWO:
			if (x > 0) {
				for (auto iter = plansza[x - 1][y].begin(); iter != plansza[x - 1][y].end(); iter++)
					if (!(*iter)->czyWejsc())
						return false;
				postac.zmienCzasRuchu();
				plansza[x - 1][y].insert(*iterPostac);
				postac.zmienX(x - 1);
				plansza[x][y].extract(iterPostac);
				return true;
			}
			break;
		case PRAWO:
			if (x < maxX) {
				for (auto iter = plansza[x + 1][y].begin(); iter != plansza[x + 1][y].end(); iter++)
					if (!(*iter)->czyWejsc())
						return false;
				postac.zmienCzasRuchu();
				plansza[x + 1][y].insert(*iterPostac);
				postac.zmienX(x + 1);
				plansza[x][y].extract(iterPostac);
				return true;
			}
			break;
		}
	}

	return false;
}

void Poziom::sciezkaDijkstra(NPC * npc, Gracz* gracz, int & docelX, int & docelY)
{
	if (!sprawdzGracz()) {
		docelX = docelY = 0;
		return;
	}

	struct wierzcholek {
		int x, y;
		int odleglosc;
		int nr;
		bool czyRozwazany = false;
		int koszt = 1;
	};
	class porownanie {
	public:
		bool operator()(wierzcholek w1, wierzcholek w2) {
			if (w1.odleglosc > w2.odleglosc)
				return true;
			else
				return false;
		}
	};

	int licznik = 0;
	int liczbaKolumn = plansza.size();
	int liczbaWierszy = plansza[0].size();

#pragma region Tworzenie grafu
	wierzcholek** graf = new wierzcholek* [liczbaKolumn];
	for (int i = 0; i < liczbaKolumn; i++)
		graf[i] = new wierzcholek[liczbaWierszy];

	for (int i = 0; i < liczbaKolumn; i++)
		for (int j = 0; j < liczbaWierszy; j++) {
			graf[i][j].nr = licznik++;
			graf[i][j].x = i;
			graf[i][j].y = j;
			graf[i][j].odleglosc = 1000;

			for (auto k = plansza[i][j].begin(); k != plansza[i][j].end(); k++)
				if (!(*k)->czyWejsc())
					graf[i][j].koszt = 1000;
		}

	graf[npc->podajX()][npc->podajY()].odleglosc = 0;
	graf[gracz->podajX()][gracz->podajY()].koszt = 1;
#pragma endregion

	int s = graf[npc->podajX()][npc->podajY()].nr;
	int c = graf[gracz->podajX()][gracz->podajY()].nr;

	int* d = new int[licznik];
	int* poprzednik = new int[licznik];

	for (int i = 0; i < licznik; i++)
		d[i] = 1000;
	d[s] = 0;

	std::priority_queue<wierzcholek, std::vector<wierzcholek>, porownanie> Q;
	for (int i = 0; i < liczbaKolumn; i++)
		for (int j = 0; j < liczbaWierszy; j++)
			if (!graf[i][j].czyRozwazany)
				Q.push(graf[i][j]);

	while (!Q.empty()) {
		while (!Q.empty())
			Q.pop();

		for (int i = 0; i < liczbaKolumn; i++)
			for (int j = 0; j < liczbaWierszy; j++)
				if (!graf[i][j].czyRozwazany)
					Q.push(graf[i][j]);
		
		wierzcholek u = Q.top();
		Q.pop();

		if (u.x > 0)
			if (!graf[u.x - 1][u.y].czyRozwazany && (d[u.nr] + graf[u.x - 1][u.y].koszt < d[graf[u.x - 1][u.y].nr])) {
				graf[u.x - 1][u.y].odleglosc = d[graf[u.x - 1][u.y].nr] = d[u.nr] + 1;
				poprzednik[graf[u.x - 1][u.y].nr] = u.nr;
			}
		if (u.x < maxX)
			if (!graf[u.x + 1][u.y].czyRozwazany && (d[u.nr] + graf[u.x + 1][u.y].koszt < d[graf[u.x + 1][u.y].nr])) {
				graf[u.x + 1][u.y].odleglosc = d[graf[u.x + 1][u.y].nr] = d[u.nr] + 1;
				poprzednik[graf[u.x + 1][u.y].nr] = u.nr;
			}
		if (u.y > 0)
			if (!graf[u.x][u.y - 1].czyRozwazany && (d[u.nr] + graf[u.x][u.y - 1].koszt < d[graf[u.x][u.y - 1].nr])) {
				graf[u.x][u.y - 1].odleglosc = d[graf[u.x][u.y - 1].nr] = d[u.nr] + 1;
				poprzednik[graf[u.x][u.y - 1].nr] = u.nr;
			}
		if (u.y < maxY)
			if (!graf[u.x][u.y + 1].czyRozwazany && (d[u.nr] + graf[u.x][u.y + 1].koszt < d[graf[u.x][u.y + 1].nr])) {
				graf[u.x][u.y + 1].odleglosc = d[graf[u.x][u.y + 1].nr] = d[u.nr] + 1;
				poprzednik[graf[u.x][u.y + 1].nr] = u.nr;
			}
		u.czyRozwazany = true;
		graf[u.x][u.y].czyRozwazany = true;
	}

	int cel = 0;
	int nrPop = c;
	while (nrPop != s) {
		cel = nrPop;
		nrPop = poprzednik[nrPop];
	}

	for (int i = 0; i < liczbaKolumn; i++)
		for (int j = 0; j < liczbaWierszy; j++)
			if (graf[i][j].nr == cel) {
				docelX = graf[i][j].x;
				docelY = graf[i][j].y;
				i = liczbaKolumn;
				j = liczbaWierszy;
			}

	for (int i = 0; i < liczbaKolumn; i++)
		delete[] graf[i];
	delete[] graf;
	delete[] d;
	delete[] poprzednik;
}

void Poziom::podniesPrzedmiot()
{
	Gracz* gracz;
	for (auto i = plansza.begin(); i != plansza.end(); i++)
		for (auto j = (*i).begin(); j != (*i).end(); j++)
			for (auto k = (*j).begin(); k != (*j).end(); k++)
				if (gracz = dynamic_cast<Gracz*>(*k)) {
					int xGracz = gracz->podajX();
					int yGracz = gracz->podajY();

					std::set<Obiekt*>::iterator iterPrzedmiot; //iterator do "znalezienia" przedmiotu
					Przedmiot* przedmiot = nullptr;
					switch (gracz->podajKierunek()) {
					case LEWO:
						if (xGracz > 0) {
							for (iterPrzedmiot = plansza[xGracz - 1][yGracz].begin(); iterPrzedmiot != plansza[xGracz - 1][yGracz].end(); iterPrzedmiot++)
								if (przedmiot = dynamic_cast<Przedmiot*>(*iterPrzedmiot))
									break;
							if (iterPrzedmiot == plansza[xGracz - 1][yGracz].end())
								break;
							gracz->dodajPrzedmiot(przedmiot);
							plansza[xGracz - 1][yGracz].extract(iterPrzedmiot);
						}
						break;
					case PRAWO:
						if (xGracz < maxX) {
							for (iterPrzedmiot = plansza[xGracz + 1][yGracz].begin(); iterPrzedmiot != plansza[xGracz + 1][yGracz].end(); iterPrzedmiot++)
								if (przedmiot = dynamic_cast<Przedmiot*>(*iterPrzedmiot))
									break;
							if (iterPrzedmiot == plansza[xGracz + 1][yGracz].end())
								break;
							gracz->dodajPrzedmiot(przedmiot);
							plansza[xGracz + 1][yGracz].extract(iterPrzedmiot);
						}
						break;
					case GORA:
						if (yGracz > 0) {
							for (iterPrzedmiot = plansza[xGracz][yGracz - 1].begin(); iterPrzedmiot != plansza[xGracz][yGracz - 1].end(); iterPrzedmiot++)
								if (przedmiot = dynamic_cast<Przedmiot*>(*iterPrzedmiot))
									break;
							if (iterPrzedmiot == plansza[xGracz][yGracz - 1].end())
								break;
							gracz->dodajPrzedmiot(przedmiot);
							plansza[xGracz][yGracz - 1].extract(iterPrzedmiot);
						}
						break;
					case DOL:
						if (yGracz < maxY) {
							for (iterPrzedmiot = plansza[xGracz][yGracz + 1].begin(); iterPrzedmiot != plansza[xGracz][yGracz + 1].end(); iterPrzedmiot++)
								if (przedmiot = dynamic_cast<Przedmiot*>(*iterPrzedmiot))
									break;
							if (iterPrzedmiot == plansza[xGracz][yGracz + 1].end())
								break;
							gracz->dodajPrzedmiot(przedmiot);
							plansza[xGracz][yGracz + 1].extract(iterPrzedmiot);
						}
						break;
					}
				}
}

void Poziom::zaatakuj(Postac & postac)
{
	if (!postac.czyAtak())
		return;
	else {
		postac.zmienCzasAtaku();
		switch (postac.podajKierunek()) {
		case DOL:
			if (postac.podajY() < maxY)
				for (auto iterPostac = plansza[postac.podajX()][postac.podajY() + 1].begin(); iterPostac != plansza[postac.podajX()][postac.podajY() + 1].end(); iterPostac++)
					if (auto post = dynamic_cast<Postac*>(*iterPostac)) {
						post->otrzymajObrazenia(postac.podajWartAtaku());
						post->zmienStanWalki(true);
					}
			break;
		case GORA:
			if (postac.podajY() > 0)
				for (auto iterPostac = plansza[postac.podajX()][postac.podajY() - 1].begin(); iterPostac != plansza[postac.podajX()][postac.podajY() - 1].end(); iterPostac++)
					if (auto post = dynamic_cast<Postac*>(*iterPostac)) {
						post->otrzymajObrazenia(postac.podajWartAtaku());
						post->zmienStanWalki(true);
					}
			break;
		case LEWO:
			if (postac.podajX() > 0)
				for (auto iterPostac = plansza[postac.podajX() - 1][postac.podajY()].begin(); iterPostac != plansza[postac.podajX() - 1][postac.podajY()].end(); iterPostac++)
					if (auto post = dynamic_cast<Postac*>(*iterPostac)) {
						post->otrzymajObrazenia(postac.podajWartAtaku());
						post->zmienStanWalki(true);
					}
			break;
		case PRAWO:
			if (postac.podajX() < maxX)
				for (auto iterPostac = plansza[postac.podajX() + 1][postac.podajY()].begin(); iterPostac != plansza[postac.podajX() + 1][postac.podajY()].end(); iterPostac++)
					if (auto post = dynamic_cast<Postac*>(*iterPostac)) {
						post->otrzymajObrazenia(postac.podajWartAtaku());
						post->zmienStanWalki(true);
					}
			break;
		}
	}
}

void Poziom::handluj()
{
	Gracz* gracz = sprawdzGracz();
	
	switch (gracz->podajKierunek()) {
	case DOL:
		if (gracz->podajY() < maxY) {
			for(auto iter = plansza[gracz->podajX()][gracz->podajY()+1].begin();iter!= plansza[gracz->podajX()][gracz->podajY() + 1].end();iter++)
				if (auto han = dynamic_cast<Handlarz*>(*iter)) {
					wczytajSpis();
					Okienko ok(gracz, han, spis, OKIENKO_HANDEL);
					ok.obsluz();
				}
		}
		break;
	case GORA:
		if (gracz->podajY() > 0) {
			for (auto iter = plansza[gracz->podajX()][gracz->podajY() - 1].begin(); iter != plansza[gracz->podajX()][gracz->podajY() - 1].end(); iter++)
				if (auto han = dynamic_cast<Handlarz*>(*iter)) {
					wczytajSpis();
					Okienko ok(gracz, han, spis, OKIENKO_HANDEL);
					ok.obsluz();
				}
		}
		break;
	case LEWO:
		if (gracz->podajY() < maxX) {
			for (auto iter = plansza[gracz->podajX() - 1][gracz->podajY()].begin(); iter != plansza[gracz->podajX() - 1][gracz->podajY()].end(); iter++)
				if (auto han = dynamic_cast<Handlarz*>(*iter)) {
					wczytajSpis();
					Okienko ok(gracz, han, spis, OKIENKO_HANDEL);
					ok.obsluz();
				}
		}
		break;
	case PRAWO:
		if (gracz->podajY() > 0) {
			for (auto iter = plansza[gracz->podajX() + 1][gracz->podajY()].begin(); iter != plansza[gracz->podajX() + 1][gracz->podajY()].end(); iter++)
				if (auto han = dynamic_cast<Handlarz*>(*iter)) {
					wczytajSpis();
					Okienko ok(gracz, han, spis, OKIENKO_HANDEL);
					ok.obsluz();
				}
		}
		break;
	}
}

//analizowanie rozkazów (¿¹dañ) gracza, postaci
void Poziom::analizujRozkazy()
{
	for (auto i = plansza.begin(); i != plansza.end(); i++)
		for (auto j = i->begin(); j != i->end(); j++)
			for (auto k = j->begin(); k != j->end(); k++)
				if (auto postac = dynamic_cast<Postac*>(*k)) {
					postac->zaktualizujRozkaz();
					while (!postac->czyBrakRozkazow())
						switch (postac->podajRozkaz()) {
						case RUCH:
							ruch(*postac);
							break;
						case ZMIEN_KIERUNEK:
						{
							auto npc = dynamic_cast<NPC*>(*k);
							npc->zmienKierunek();
						}
						break;
						case ATAK:
							zaatakuj(*postac);
							break;
						case SCIEZKA_DO_GRACZA:
						{
							auto npc = dynamic_cast<NPC*>(*k);
							Gracz* gracz = sprawdzGracz();
							int x, y;
							sciezkaDijkstra(npc, gracz, x, y);
							npc->ustalCel(x, y);
							npc->ustawWspGracza(gracz->podajX(), gracz->podajY());
						}
						break;
						}
					break;
				}
}

//ustawianie statystyk ekwipunku
void Poziom::ustawEkwipunek()
{
	for (auto i = plansza.begin(); i != plansza.end(); i++)
		for (auto j = i->begin(); j != i->end(); j++)
			for (auto k = j->begin(); k != j->end(); k++)
				if (auto postac = dynamic_cast<Postac*>(*k))
					postac->ustawEkwipunek();
}

void Poziom::rysujPoziom()
{
	while (!kolejka.empty())
		kolejka.pop();
	for (auto i = plansza.begin(); i != plansza.end(); i++)
		for (auto j = i->begin(); j != i->end(); j++) {
			//obiekty s¹ rysowana z priorytetowaniem, np. "statyczne" obiekty -> przedmioty -> postacie
			for (auto k = j->begin(); k != j->end(); k++)
				kolejka.push(*k);
			while (!kolejka.empty()) {
				kolejka.top()->rysuj();
				kolejka.pop();
			}
		}
}
