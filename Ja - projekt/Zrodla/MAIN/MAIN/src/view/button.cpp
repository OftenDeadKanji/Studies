#include "../pch.h"

Button::Button(const std::string& napis, int x, int y, ControlType type, bool hasFrame) : Control(x, y, type), hasFrame(hasFrame)
{
	text = new Text(napis, x, y, true);

	int szer, wys;
	getTextDimensions(&szer, &wys);
	setDimentions(szer, wys);
	hasFrame = false;
}

Button::Button(const std::string& napis, int x, int y, int szer, int wys, ControlType type, bool hasFrame) : Control(x, y, szer, wys, type), hasFrame(hasFrame)
{
	text = new Text(napis, x, y, true);
}

Button::Button(Button& button) : Control(button), hasFrame(button.hasFrame)
{
	text = new Text(*button.text);
}

Button::Button(Button&& button) noexcept : Control(button), hasFrame(button.hasFrame)
{
	text = button.text;
}

Button::~Button()
{
	if (text != nullptr)
		delete text;
}

void Button::getTextDimensions(int* szer, int* wys)
{
	text->getDimensions(szer, wys);
}

void Button::draw()
{
	if (hasFrame)
		al_draw_rectangle(x - 10, y - 10, x + w + 10, y + h + 10, colors[colorMode], 2);
	text->draw();
}

void Button::doAction()
{}

void Button::update()
{
	if (mouseState.x > this->x&& mouseState.x < this->x + w && mouseState.y > this->y&& mouseState.y < this->y + h)
		colorMode = 1;
	else
		colorMode = 0;

	text->update();
}
