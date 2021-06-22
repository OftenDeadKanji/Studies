#include "../pch.h"
#include "slider.h"

Slider::Slider(int x, int y, int w, int h, int min, int max) : Control(x, y, w, h, CONTROL_SLIDER), minValue(min), maxValue(max), constColor(al_map_rgb(CONTROL_COLOR))
{
	setValue = System::getInstance().getThreadsNumber();
	pointerX = x + (double)w * (double)setValue / (double)maxValue;
	pointerY = y + (double)h / 2.0;

	font = al_load_font("res/Segan.ttf", 30, NULL);
}

Slider::~Slider()
{
	al_destroy_font(font);
}

void Slider::draw()
{
	al_draw_rectangle(x, y, x + w, y + h, constColor, 3);
	al_draw_filled_rectangle(pointerX - 10.0 * System::getInstance().getWidthRatio(), pointerY - h, pointerX + 10.0 * System::getInstance().getWidthRatio(), pointerY + h, colors[colorMode]);

	al_draw_textf(font, constColor, x - 50, y, NULL, "%d", minValue);
	al_draw_textf(font, constColor, x + w + 25, y, NULL, "%d", maxValue);
	al_draw_textf(font, constColor, x + w/2, y+h+25, NULL, "%d", setValue);
	if (setValue == System::getInstance().getThreadsNumber())
		al_draw_text(font, constColor, x + w / 2 - 120, y + h + 75, NULL, "Optymalna wartosc!");
}

void Slider::doAction()
{}

void Slider::update()
{
	if (mouseState.x > pointerX - 10 && mouseState.x < pointerX + 10 && mouseState.y > pointerY - h && mouseState.y < pointerY + h) {
		colorMode = 1;
	}
	else
		colorMode = 0;

	if (al_mouse_button_down(&mouseState, 1) && mouseState.x > x && mouseState.x < x + w && mouseState.y > y && mouseState.y < y + h) {
		if (mouseState.x < this->x)
			pointerX = x;
		else if (mouseState.x > this->x + this->w)
			pointerX = x + w;
		else
			pointerX = mouseState.x;

		setValue = (double)(pointerX - x) / (double)w * 64 + 1;
	}
}

int Slider::getValue()
{
	return setValue;
}

int Slider::getMinValue()
{
	return minValue;
}

int Slider::getMaxValue()
{
	return maxValue;
}
