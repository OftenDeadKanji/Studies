#pragma once
class Slider :
	public Control {
private:
	//minimalna, maksymalna i wybrana wartoœæ na suwaku
	int minValue, maxValue, setValue;
	//wspó³rzêdne œrodka wskaŸnika suwaka
	int pointerX, pointerY;
	//ten kolor dla suwaka siê nie zmiena
	ALLEGRO_COLOR constColor;
	//czcionka do wyœwietlania liczb
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