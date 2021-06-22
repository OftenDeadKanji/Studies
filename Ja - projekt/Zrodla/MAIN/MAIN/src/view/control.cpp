#include "../pch.h"

ALLEGRO_MOUSE_STATE Control::mouseState;

Control::Control(int x, int y) : x(x), y(y), w(0), h(0), type(CONTROL_NONE), colors{ al_map_rgb(CONTROL_COLOR), al_map_rgb(CONTROL_LIGHT_COLOR) }
{}

Control::Control(int x, int y, ControlType type) : x(x), y(y), w(0), h(0), type(type), colors{ al_map_rgb(CONTROL_COLOR), al_map_rgb(CONTROL_LIGHT_COLOR) }
{}

Control::Control(int x, int y, int w, int h) :x(x), y(y), w(w), h(h), type(CONTROL_NONE), colors{ al_map_rgb(CONTROL_COLOR), al_map_rgb(CONTROL_LIGHT_COLOR) }
{}

Control::Control(int x, int y, int w, int h, ControlType type) : x(x), y(y), w(w), h(h), type(type), colors{ al_map_rgb(CONTROL_COLOR), al_map_rgb(CONTROL_LIGHT_COLOR) }
{}

Control::Control(Control& control) : x(control.x), y(control.y), w(control.w), h(control.h), type(control.type), colors{ control.colors[0], control.colors[1] }
{}

Control::Control(Control&& control) noexcept : x(control.x), y(control.y), w(control.w), h(control.h), type(control.type), colors{ control.colors[0], control.colors[1] }
{}

void Control::setDimentions(int w, int h)
{
	this->w = w;
	this->h = h;
}

int Control::getX()
{
	return x;
}

int Control::getY()
{
	return y;
}

int Control::getW()
{
	return w;
}

int Control::getH()
{
	return h;
}

void Control::getDimensions(int* w, int* h)
{
	*w = this->w;
	*h = this->h;
}

ALLEGRO_MOUSE_STATE& Control::getMouseState()
{
	return mouseState;
}

ControlType Control::getType()
{
	return type;
}

bool Control::isClicked()
{
	if (mouseState.x > this->x && mouseState.x < this->x + this->w && mouseState.y > this->y && mouseState.y < this->y + this->h)
		return true;
	else
		return false;
}