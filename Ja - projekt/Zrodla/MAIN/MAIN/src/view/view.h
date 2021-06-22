#pragma once

class View {
private:
	std::vector <Control*> controls;
	std::map <TextDesc, Text*> texts;

	Slider* slider;
	RadioButtons* radio;
	Text* time;

	Display* display;
	ALLEGRO_MOUSE_STATE* mouseState;
	ALLEGRO_EVENT_QUEUE* queue;

	bool mouseButtonHeld;
public:
	//Konstruktory i destruktor
	View();
	~View();
	//settery
	void setMouse(ALLEGRO_MOUSE_STATE&);
	void setModelTime(double);

	//gettery
	ALLEGRO_EVENT_QUEUE* getEventQueue();
	Slider& getSlider();
	RadioButtons& getRadio();

	//pozosta³e
	void addControl(Control*);
	void addText(TextDesc, Text*);
	void addSlider(Slider*);
	void addRadio(RadioButtons*);
	void addTimeText(Text*);
	ControlType getPressedControlType();
	void draw();
	void doAction(bool);
	void update();
};