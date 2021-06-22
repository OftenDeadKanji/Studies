#pragma once
class Controller
{
private:
	std::array<View*, 3> views;
	Model* model;

	const double cooldown;
	double lastTime;
	double newTime;

	short mode;
	bool condition;

	bool updatePath;
	bool updateThreadsNumber;
	bool updateDllChoice;
	bool updateViewTime;

	ALLEGRO_EVENT event;
	ALLEGRO_FILECHOOSER* file;
	std::string filePath;
public:
	//konstruktory  i destruktor
	Controller();
	~Controller();
	//settery

	//gettery
	int getMode();
	bool getRun();

	//pozosta³e metody
	void run();
	void processInput();
	void updateModel();
	void updateView();

};

