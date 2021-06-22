#pragma once
class Slider :
	public Control {
private:
	//minimalna, maksymalna i wybrana warto�� na suwaku
	int minValue, maxValue, setValue;
	//wsp�rz�dne �rodka wska�nika suwaka
	int pointerX, pointerY;
	//ten kolor dla suwaka si� nie zmiena
	ALLEGRO_COLOR constColor;
	//czcionka do wy�wietlania liczb
	ALLEGRO_FONT* font;
public:
	Slider(int, int, int, int, int, int);
	~Slider();

	void draw();
	void doAction();
	void update();

	int getValue();
	int getMinValue();
	int getMaxValue();
 };