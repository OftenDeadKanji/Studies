#pragma once

class RadioButtons :
	public Control {
private:
	std::list <std::pair<Text*, std::pair<int, bool>>> texts;

	int mode;

	int interval;
	double radius;

public:
	RadioButtons(int, int, int);
	~RadioButtons();

	void addRadioButton(const std::string&);

	int getChoice();

	void draw();
	void doAction();
	void update();

	virtual bool isClicked();
};