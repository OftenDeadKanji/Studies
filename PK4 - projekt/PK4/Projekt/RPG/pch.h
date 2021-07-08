#ifndef PCH_H
#define PCH_H

#define CZARNY 0,0,0
#define CZERWONY 250,0,0
#define ZOLTY 255, 218, 89
#define BIALY 250,250,250
#define SZARY 150,150,150
#define LB_WIERSZY_GRACZ 3
#define SZER_MONITORA GetSystemMetrics(SM_CXSCREEN)
#define WYS_MONITORA GetSystemMetrics(SM_CYSCREEN)

#define SZER_PODST 1920
#define WYS_PODST 1080
#define SZER_OKNA 1600
#define WYS_OKNA 900

#define WSP_SZER SZER_MONITORA/SZER_PODST
#define WSP_WYS WYS_MONITORA/WYS_PODST
#define WSP_WLK (SZER_MONITORA * WYS_MONITORA) / (SZER_PODST * WYS_PODST) 

#define SZER_GRANICA 1300
#define WYM_OBRAZ 100
#define WLK_CZCIONKI 50

#define START_PKT_ZYC 100

#define YRSAM_SCIEZKA "Czcionki/YrsaM.ttf"

enum kierunki {DOL, GORA, LEWO, PRAWO};
enum trybOkienka {OKIENKO_MENU, OKIENKO_EKWIPUNEK, OKIENKO_HANDEL};
enum rozkazy {NIC, RUCH, SCIEZKA_DO_GRACZA, ATAK, ZMIEN_KIERUNEK};

#include <iostream>
#include <string>
#include <sstream>
#include <fstream>
#include <array>
#include <vector>
#include <map>
#include <set>
#include <queue>
#include <filesystem>
#include <typeinfo>
#include <Windows.h>
#include <cmath>
#include <exception>
#include <algorithm>
#include <thread>

#include "allegro5/allegro.h"
#include "allegro5/allegro_native_dialog.h"
#include "allegro5/allegro_image.h"
#include "allegro5/allegro_audio.h"
#include "allegro5/allegro_acodec.h"
#include "allegro5/allegro_font.h"
#include "allegro5/allegro_ttf.h"
#include "allegro5/allegro_primitives.h"

#include "klasy/wyjatek.h"
#include "klasy/obiekt.h"

#include "klasy/przejscie.h"
#include "klasy/przedmioty/przedmiot.h"
#include "klasy/przedmioty/bron.h"
#include "klasy/przedmioty/pancerz.h"

#include "klasy/postaci/postac.h"
#include "klasy/postaci/gracz.h"
#include "klasy/postaci/npc.h"
#include "klasy/postaci/handlarz.h"

#include "klasy/poziom.h"

#include "klasy/GUI/tekst.h"
#include "klasy/GUI/przycisk.h"
#include "klasy/GUI/okienko.h"
#include "klasy/GUI/okno.h"

#include "klasy/tryby gry/tryb_gry.h"
#include "klasy/tryby gry/menu.h"
#include "klasy/tryby gry/edytor.h"
#include "klasy/tryby gry/gra.h"

#endif