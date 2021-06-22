#pragma once

class Control
{
protected:
	//wspó³rzêdne kontrolki
	int x, y;
	//szerokoœæ i wysokoœæ kontrolki
	int w, h;
	//stan myszy - zmiana koloru
	static ALLEGRO_MOUSE_STATE mouseState;
	//kolor kontrolki
	ALLEGRO_COLOR colors[2];
	//tryb koloru - 0 lub 1
	unsigned short colorMode;
	//typ kontrolki
	ControlType type;
public:
	Control(int, int);
	Control(int, int, ControlType);
	Control(int, int, int, int);
	Control(int, int, int, int, ControlType);
	Control(Control&);
	Control(Control&&) noexcept;

	void setDimentions(int, int);
	virtual void draw() = 0;
	virtual void doAction() = 0;
	virtual void update() = 0;

	int getX();
	int getY();
	int getW();
	int getH();
	void getDimensions(int*, int*);
	ALLEGRO_MOUSE_STATE& getMouseState();
	ControlType getType();

	virtual bool isClicked();
};

