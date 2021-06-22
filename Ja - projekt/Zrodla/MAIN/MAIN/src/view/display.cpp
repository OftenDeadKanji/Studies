#include "../pch.h"
#include "display.h"

ALLEGRO_DISPLAY* Display::display;

Display::Display() : width(System::getInstance().getDisplayWidth()), height(System::getInstance().getDisplayHeight())
{
	//if(display == NULL)
	//	wyj¹tek!!!
}

Display::Display(int width, int height) : width(width), height(height)
{
	if (display == NULL)
		display = al_create_display((double)width * System::getInstance().getWidthRatio(), (double)height * System::getInstance().getHeightRatio());
	//else
	//	wyj¹tek!!!
}

Display::~Display()
{
	if (display != NULL) {
		al_destroy_display(display);
		display = NULL;
	}
}

int Display::getWidth()
{
	return width;
}

int Display::getHeight()
{
	return height;
}

ALLEGRO_DISPLAY* Display::getDisplay()
{
	return display;
}

