#include <iostream>
#include <fstream>
#include <cmath>
#include <time.h>

using namespace std;

void generuj(ofstream& plik, int liczba)
{
	int* niewiadome = new int[liczba];
	for (int i = 0; i < liczba; i++) {

		niewiadome[i] = (rand() % 11) - 5;

		while (niewiadome[i] == 0)
			niewiadome[i] = (rand() % 11) - 5;
	}

	int** tab = new int* [liczba + 1];
	for (int i = 0; i < liczba + 1; i++) {
		tab[i] = new int[liczba + 1]{ 0 };
	}

	for (int i = 0; i < liczba; i++) {
		int suma = 0;
		for (int j = 0; j < liczba; j++) {
			if (i != j) {
				tab[i][j] = (rand() % 21) - 10;
				while (tab[i][j] == 0)
					tab[i][j] = (rand() % 21) - 10;
			}
			suma += abs(tab[i][j]);
			tab[i][liczba] += tab[i][j] * niewiadome[j];

		}

		tab[i][i] = (rand() % 101) + suma;
		if (!(rand() % 2))
			tab[i][i] *= -1;
		tab[i][liczba] += tab[i][i] * niewiadome[i];
		for (int j = 0; j < liczba; j++) {
			plik << tab[i][j] << '\t';
		}

		plik << tab[i][liczba] << "\t500" << endl;
		//cout << "Liczba wygenerowanych rownan: " << i + 1 << " z " << liczba << endl;
	}

	for (int i = 0; i < liczba + 1; i++) {
		delete tab[i];
	}
	delete[] tab;
	delete[] niewiadome;
}

int main()
{
	srand(time(NULL));

//#pragma region ASM_TEST
//	cout << "Tworzenie i otwieranie pliku asm.txt" << endl << endl;
//	ofstream plikAsm;
//	plikAsm.open("../../../Plik_exe/Dane testowe/asm.txt", ios::out | ios::trunc);
//
//	cout << "Generowanie ukladow rownan dla 8 niewiadomych i zapisywanie do pliku." << endl << endl;
//	generuj(plikAsm, 8);
//	plikAsm.close();
//#pragma endregion

#pragma region SMALL
	cout << "Tworzenie i otwieranie pliku small.txt" << endl << endl;
	ofstream plikSmall;
	plikSmall.open("../../../Plik_exe/Dane testowe/small.txt", ios::out | ios::trunc);

	cout << "Generowanie ukladow rownan dla 200 niewiadomych i zapisywanie do pliku." << endl << endl;
	generuj(plikSmall, 200);
	plikSmall.close();
#pragma endregion

#pragma region MEDIUM
	cout << endl << "Tworzenie i otwieranie pliku medium.txt" << endl;
	ofstream plikMedium;
	plikMedium.open("../../../Plik_exe/Dane testowe/medium.txt", ios::out | ios::trunc);

	cout << "Generowanie ukladow rownan dla 1000 niewiadomych." << endl << endl;
	generuj(plikMedium, 1000);
	plikMedium.close();
#pragma endregion

#pragma region LARGE
	cout << endl << "Tworzenie i otwieranie pliku large.txt" << endl;
	ofstream plikLarge;
	plikLarge.open("../../../Plik_exe/Dane testowe/large.txt", ios::out | ios::trunc);

	cout << "Generowanie ukladow rownan dla 7000 niewiadomych." << endl << endl;
	generuj(plikLarge, 7000);
	plikLarge.close();
#pragma endregion

	cin.get();
	return 0;
}