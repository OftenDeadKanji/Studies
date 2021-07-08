#include "pch.h"
#include <iostream>

int main()
{
	thread t1;
	if (!al_init()) {
		cout << "Blad z allegro.\n\nWcisnij dowolny przycisk, aby zamknac program." << std::endl;
		cin.get();
	}
	else
	{
		al_init_native_dialog_addon();
		al_init_font_addon();
		al_init_ttf_addon();
		al_init_image_addon();
		al_init_primitives_addon();
		al_install_audio();
		al_init_acodec_addon();
		al_install_keyboard();
		al_install_mouse();

		Menu();
	}
	return 0;
}