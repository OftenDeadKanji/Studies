#pragma once

class Button :
	public Control
{
private:
	Text* text;
	bool hasFrame;
public:
	Button(const std::string&, int, int, ControlType = CONTROL_NONE, bool = false);
	Button(const std::string&, int, int, int, int, ControlType = CONTROL_NONE, bool = false);
	Button(Button&);
	Button(Button&&) noexcept;
	virtual ~Button();

	void getTextDimensions(int*, int*);
	virtual void draw();
	virtual void doAction();
	void update();
};

