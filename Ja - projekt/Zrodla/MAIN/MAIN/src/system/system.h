#pragma once

class System {
private:
	System();
	System(const System&);

	const double programmerScreenWidth;
	const double programmerScreenHeight;

	const double displayWidth;
	const double displayHeight;

	double screenWidth;
	double screenHeight;

	double widthRatio;
	double heightRatio;
	double sizeRatio;

	const int threadsNumber;
	
public:
	static System& getInstance();

	double getScreenWidth();
	double getScreenHeight();

	double getWidthRatio();
	double getHeightRatio();
	double getSizeRatio();

	double getDisplayWidth();
	double getDisplayHeight();

	int getThreadsNumber();

	//double getXMousePos();
	//double getYMousePos();
};