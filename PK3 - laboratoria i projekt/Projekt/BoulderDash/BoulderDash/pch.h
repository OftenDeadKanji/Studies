// Porady dotycz�ce rozpoczynania pracy:
//   1. U�yj okna Eksploratora rozwi�za�, aby doda� pliki i zarz�dza� nimi
//   2. U�yj okna programu Team Explorer, aby nawi�za� po��czenie z kontrol� �r�d�a
//   3. U�yj okna Dane wyj�ciowe, aby sprawdzi� dane wyj�ciowe kompilacji i inne komunikaty
//   4. U�yj okna Lista b��d�w, aby zobaczy� b��dy
//   5. Wybierz pozycj� Projekt > Dodaj nowy element, aby utworzy� nowe pliki kodu, lub wybierz pozycj� Projekt > Dodaj istniej�cy element, aby doda� istniej�ce pliku kodu do projektu
//   6. Aby w przysz�o�ci ponownie otworzy� ten projekt, przejd� do pozycji Plik > Otw�rz > Projekt i wybierz plik sln

#ifndef PCH_H
#define PCH_H

#include <iostream>
#include <fstream>
#include <string>
#include <cmath>
#include <sstream>
#include <experimental/filesystem>
#include <mutex>
#include <thread>
//#include <Windows.h>

#include "allegro5/allegro.h"
#include "allegro5/allegro_native_dialog.h"
#include "allegro5/allegro_font.h"
#include "allegro5/allegro_ttf.h"
#include "allegro5/allegro_image.h"
#include "allegro5/allegro_primitives.h"
#include "allegro5/allegro_audio.h"
#include "allegro5/allegro_acodec.h"

#include "BoulderDash.h"
#include "Rysowanie.h"
#include "Main.h"

#include "Przycisk.h"
#include "Obiekt.h"
#include "Puste.h"
#include "Gracz.h"
#include "Drzwi.h"
#include "Ziemia.h"
#include "Skala.h"
#include "Diament.h"
#include "Sciana.h"
#include "Dynamit.h"
#include "AktDynamit.h"

#include "Plansza.h"
// TODO: w tym miejscu dodaj nag��wki, kt�re maj� by� wst�pnie kompilowane

#endif //PCH_H