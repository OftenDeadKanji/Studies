#pragma once

class Poziom
{
private:
	std::array <std::array<std::set<Obiekt*>, 9>, 13> plansza; //g³ówna tablica wskaŸników
	int maxX = 12, maxY = 8;
	int nrPoz = 1;
	const float FPS = 60.0;
	std::map <int, std::vector<std::string>> spis;
	std::priority_queue <Obiekt*, std::vector<Obiekt*>, porownanieObiektow> kolejka;
public:
	Poziom();
	~Poziom();

	void wczytajPoziom(int);
	void wczytajPoziomEdytor(int);
	void ustawEkwipunek();
	void zapiszPoziom();

	void wczytajSpis();
	void przejdz(int, int);

	void dodajElementPlanszy(int, int, int);
	void usunElementPlanszy(int wspX, int wspY);
	void dodajObiekt(std::ifstream &);
	void dodajGracz(std::ifstream &);
	void dodajNpc(std::ifstream &);
	void dodajBron(std::ifstream &);
	void dodajPancerz(std::ifstream & plik);
	void dodajPrzejscie(std::ifstream & plik);
	void dodajHandlarz(std::ifstream & plik);

	Gracz* sprawdzGracz();
	void rysujPoziom();
	void usunZawartosc();
	void umieranie(Gracz*);

	//true - uda³o siê przemieœciæ, false - w przeciwnym przypadku
	bool ruch(Postac &);
	void sciezkaDijkstra(NPC * npc, Gracz* gracz, int & docelX, int & docelY);
	void analizujRozkazy();
	void podniesPrzedmiot();
	void zaatakuj(Postac &);
	void handluj();
};

