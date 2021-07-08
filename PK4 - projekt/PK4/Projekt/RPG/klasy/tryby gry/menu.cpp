#include "../../pch.h"


Menu::Menu()
{
	tlo = al_load_bitmap("Obrazy/Tlo.png");
}


Menu::~Menu()
{
	al_destroy_bitmap(tlo);
	al_destroy_event_queue(kolejka);
}

void Menu::uruchom()
{
	okno.stworz(500 * WSP_SZER, 500* WSP_WYS);
	//nr 0
	okno.dodajPrzycisk("Graj", 200* WSP_SZER, 100 * WSP_WYS, WLK_CZCIONKI * WSP_WLK);
	//nr 1
	okno.dodajPrzycisk("Edytor", 200 * WSP_SZER, 200 * WSP_WYS, WLK_CZCIONKI * WSP_WLK);
	//nr 2
	okno.dodajPrzycisk("Wyjdz", 200 * WSP_SZER, 300 * WSP_WYS, WLK_CZCIONKI * WSP_WLK);

	kolejka = al_create_event_queue();
	al_register_event_source(kolejka, al_get_mouse_event_source());
	al_register_event_source(kolejka, al_get_display_event_source(okno.pobOkno()));

	int warunek = 1;

	while (warunek) {
		while (al_get_next_event(kolejka, &zdarzenie))
			switch (zdarzenie.type) {
			case ALLEGRO_EVENT_DISPLAY_CLOSE:
				warunek = false;
				break;
			case ALLEGRO_EVENT_MOUSE_BUTTON_DOWN:
				al_get_mouse_state(&stanMyszy);
				if (al_mouse_button_down(&stanMyszy, 1))
					switch (okno.ktoryPrzycisk()) {
					case 0: { //Graj
						Gra gra(okno.pobOkno());

						gra.uruchom();
						okno.zmienRozmiar(500 * WSP_SZER, 500 * WSP_WYS);
						al_flush_event_queue(kolejka);
					}
					break; 
					case 1: { //Edytor
						Edytor edytor(okno.pobOkno());

						edytor.uruchom();
						okno.zmienRozmiar(500 * WSP_SZER, 500 * WSP_WYS);
						al_flush_event_queue(kolejka);
					}
						break;
					case 2: //Wyjdz
						warunek = 0;
						break;
					}
				break;
			}
		rysuj();
	}
}

void Menu::rysuj()
{
	al_clear_to_color(al_map_rgb(BIALY));
	al_draw_scaled_bitmap(tlo, 0, 0, 500, 500, 0, 0, 500 * WSP_SZER, 500 * WSP_WYS, NULL);
	okno.rysuj();
	al_flip_display();
}