#include "pch.h"

int main() {
	if (!al_init())
		std::cout << "Allegro nie mo¿e zostaæ zainicjalizowane." << std::endl;
	else {
		al_init_image_addon();
		al_init_native_dialog_addon();
		al_init_font_addon();
		al_init_ttf_addon();
		al_init_primitives_addon();
		al_init_acodec_addon();

		al_install_keyboard();
		al_install_mouse();

		Menu menu;
		menu.uruchom();
	}
	return 0;
}