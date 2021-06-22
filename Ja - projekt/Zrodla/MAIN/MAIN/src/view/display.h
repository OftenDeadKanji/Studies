#pragma once

class Display
{
private:
	static ALLEGRO_DISPLAY* display;

	int width, height;

public:
	Display();
	Display(int, int);
	~Display();

	int getWidth();
	int getHeight();

	ALLEGRO_DISPLAY* getDisplay();
};