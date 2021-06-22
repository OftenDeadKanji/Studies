#include "../pch.h"

System::System() : programmerScreenWidth(1920.0), programmerScreenHeight(1080.0), displayWidth(1024.0), displayHeight(600.0), threadsNumber(std::thread::hardware_concurrency())
{
#ifdef _WIN32
	this->screenWidth = (int)GetSystemMetrics(SM_CXSCREEN);
	this->screenHeight = (int)GetSystemMetrics(SM_CYSCREEN);
#elif __linux__
	Display* disp = XOpenDisplay(NULL);
	Screen* scrn = DefaultScreenOfDisplay(disp);
	this->screenWidth = scrn->width;
	this->screenHeight = scrn->height;
#endif

	widthRatio = screenWidth / this->programmerScreenWidth;
	heightRatio = screenHeight / this->programmerScreenHeight;
	sizeRatio = (screenWidth * screenHeight) / (programmerScreenWidth * programmerScreenHeight);
}

System& System::getInstance()
{
	static System system;
	return system;
}

double System::getScreenWidth()
{
	return screenWidth;
}

double System::getScreenHeight()
{
	return screenHeight;
}

double System::getWidthRatio()
{
	return widthRatio;
}

double System::getHeightRatio()
{
	return heightRatio;
}

double System::getSizeRatio()
{
	return sizeRatio;
}

double System::getDisplayWidth()
{
	return displayWidth;
}

double System::getDisplayHeight()
{
	return displayHeight;
}

int System::getThreadsNumber()
{
	return threadsNumber;
}
