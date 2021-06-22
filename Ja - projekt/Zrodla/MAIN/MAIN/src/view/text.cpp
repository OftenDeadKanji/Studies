#include "../pch.h"

Text::Text(const std::string& text, int x, int y, bool isInteractive, int size) : Control(x,y), text(text), isInteractive(isInteractive), size(size)
{
	font = al_load_font("res/Segan.ttf", size, NULL);

	int tmpX, tmpY, tmpW, tmpH;
	al_get_text_dimensions(font, text.c_str(), &tmpX, &tmpY, &tmpW, &tmpH);
	this->w = tmpX + tmpW;
	this->h = tmpY + tmpH;
}

Text::Text(Text& text) : Control(text), text(text.text), isInteractive(text.isInteractive), size(text.size)
{
	font = al_load_font("res/Segan.ttf", size, NULL);
}

Text::Text(Text&& text) noexcept : Control(x, y), text(text.text), isInteractive(text.isInteractive), size(text.size), font(text.font)
{}

Text::~Text()
{
	if (font != NULL)
		al_destroy_font(font);
}

void Text::draw()
{
	al_draw_text(font, colors[colorMode], this->x, this->y, NULL, text.c_str());
}

void Text::doAction()
{}

void Text::update()
{
	if (isInteractive && mouseState.x > this->x && mouseState.x < this->x + w && mouseState.y > this->y && mouseState.y < this->y + h)
		colorMode = 1;
	else
		colorMode = 0;
}

void Text::setText(const std::string& text)
{
	this->text = text;
}
