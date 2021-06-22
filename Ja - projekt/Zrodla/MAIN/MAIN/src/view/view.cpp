#include "../pch.h"
#include "view.h"

View::View() : mouseState(NULL), mouseButtonHeld(false)
{
	display = new Display(System::getInstance().getDisplayWidth(), System::getInstance().getDisplayHeight());
	queue = al_create_event_queue();
	al_register_event_source(queue, al_get_display_event_source(display->getDisplay()));
	al_register_event_source(queue, al_get_mouse_event_source());
}

View::~View()
{
	for (auto iter : controls)
		delete iter;
	for (auto iter : texts)
		delete iter.second;
	delete display;
	al_destroy_event_queue(queue);
}

void View::setMouse(ALLEGRO_MOUSE_STATE& mouse)
{
	this->mouseState = &mouse;
}

void View::setModelTime(double time)
{
	std::ostringstream str;
	str << std::setprecision(3) << time;
	this->time->setText(str.str());
}

ALLEGRO_EVENT_QUEUE* View::getEventQueue()
{
	return queue;
}

Slider& View::getSlider()
{
	return *slider;
}

RadioButtons& View::getRadio()
{
	return *radio;
}

void View::addControl(Control* control)
{
	controls.push_back(control);
	if (mouseState == NULL)
		mouseState = &(control->getMouseState());
}

void View::addText(TextDesc desc, Text* text)
{
	texts.insert(std::pair<TextDesc, Text*>(desc, text));
	if (mouseState == NULL)
		mouseState = &(text->getMouseState());
}

void View::addSlider(Slider* slider)
{
	this->slider = slider;
	addControl(slider);
}

void View::addRadio(RadioButtons* radio)
{
	this->radio = radio;
	addControl(radio);
}

void View::addTimeText(Text* time)
{
	this->time = time;
	addText(TIME_VALUE, time);
}

ControlType View::getPressedControlType()
{
	for (auto iter : controls)
		if (iter->isClicked())
			return iter->getType();
	return CONTROL_NONE;
}

void View::draw()
{
	al_clear_to_color(al_map_rgb(BACKGROUND_COLOR));

	for (auto iter : controls)
		iter->draw();
	for (auto iter : texts)
		iter.second->draw();

	al_flip_display();
}

void View::doAction(bool isHeld)
{
	mouseButtonHeld = isHeld;
}

void View::update()
{
	al_get_mouse_state(mouseState);

	for (auto iter : controls)
		iter->update();
	for (auto iter : texts)
		iter.second->update();
}
