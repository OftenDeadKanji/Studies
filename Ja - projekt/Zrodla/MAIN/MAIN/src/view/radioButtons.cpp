#include "../pch.h"

RadioButtons::RadioButtons(int x, int y, int mode) : Control(x, y, CONTROL_RADIO_BUTTONS), mode(mode), interval(130), radius(15)
{}

RadioButtons::~RadioButtons()
{
	for (auto iter : texts)
		delete iter.first;
}

void RadioButtons::addRadioButton(const std::string& text)
{
	if (!texts.empty()) {
		int tmpX = texts.back().first->getX();
		int tmpY = texts.back().first->getY();
		int tmpW = texts.back().first->getW();
		int tmpH = texts.back().first->getH();

		int newX = tmpX + tmpW + interval + 2.0 * radius;
		int newY = tmpY;

		if (mode == 1) //u³o¿enie poziome
			texts.push_back(std::pair<Text*, std::pair<int, bool>>(new Text(text, newX, tmpY, false, 30 * System::getInstance().getSizeRatio()), std::pair<int, bool>(0, false)));
		else  //u³o¿enie pionowe
			texts.push_back(std::pair<Text*, std::pair<int, bool>>(new Text(text, tmpX, tmpY + tmpH + interval, false, 30 * System::getInstance().getSizeRatio()), std::pair<int, bool>(0, false)));
	}
	else
		texts.push_back(std::pair<Text*, std::pair<int, bool>>(new Text(text, x + 25.0 * System::getInstance().getWidthRatio(), y, false, 30 * System::getInstance().getSizeRatio()), std::pair<int, bool>(0, false)));
}

int RadioButtons::getChoice()
{
	int i = 0;
	for (auto iter : texts) {
		if (iter.second.second)
			return i;
		else
			i++;
	}
	return 0;
}

void RadioButtons::draw()
{
	for (auto iter : texts) {
		iter.first->draw();
		if (iter.second.second)
			al_draw_filled_circle(iter.first->getX() - 25.0 * System::getInstance().getWidthRatio(), iter.first->getY() + iter.first->getH() / 2.0, 0.75 * radius * System::getInstance().getSizeRatio(), colors[iter.second.first]);
		al_draw_circle(iter.first->getX() - 25.0 * System::getInstance().getWidthRatio(), iter.first->getY() + iter.first->getH()/2.0, radius * System::getInstance().getSizeRatio(), colors[iter.second.first], 3);
	}
}

void RadioButtons::doAction()
{}

void RadioButtons::update()
{
	for (auto iter = texts.begin(); iter != texts.end();iter++) {
		if (mouseState.x > (*iter).first->getX() - 25.0 * System::getInstance().getWidthRatio() - radius * System::getInstance().getSizeRatio() &&
			mouseState.x < (*iter).first->getX() - 25.0 * System::getInstance().getWidthRatio() + radius * System::getInstance().getSizeRatio() &&
			mouseState.y >(*iter).first->getY() + (*iter).first->getH() / 2.0 - radius * System::getInstance().getSizeRatio() &&
			mouseState.y < (*iter).first->getY() + (*iter).first->getH() / 2.0 + radius * System::getInstance().getSizeRatio()) {
			colorMode = 1;
			(*iter).second.first = 1;
			if (al_mouse_button_down(&mouseState, 1)) {
				for (auto iter2 = texts.begin(); iter2 != texts.end(); iter2++)
					(*iter2).second.second = false;
				(*iter).second.second = true;
				break;
			}
		}
		else {
			(*iter).second.first = 0;
		}
	}
}

bool RadioButtons::isClicked()
{
	for (auto iter = texts.begin(); iter != texts.end(); iter++) {
		if (mouseState.x > (*iter).first->getX() - 25.0 * System::getInstance().getWidthRatio() - radius * System::getInstance().getSizeRatio() &&
			mouseState.x < (*iter).first->getX() - 25.0 * System::getInstance().getWidthRatio() + radius * System::getInstance().getSizeRatio() &&
			mouseState.y >(*iter).first->getY() + (*iter).first->getH() / 2.0 - radius * System::getInstance().getSizeRatio() &&
			mouseState.y < (*iter).first->getY() + (*iter).first->getH() / 2.0 + radius * System::getInstance().getSizeRatio()) {
			return true;
		}
	}
	return false;
}


