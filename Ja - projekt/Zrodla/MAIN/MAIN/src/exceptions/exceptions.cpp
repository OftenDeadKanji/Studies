#include "../pch.h"


InitFailException::InitFailException(const char* message) : std::exception(message)
{}

void InitFailException::writeToFile()
{
	std::ofstream plik;
	plik.open("LOGS.txt", std::ios::out | std::ios::ate);

	if (plik.is_open()) {
		plik << "B³¹d przy inicjalizacji: " << this->what() << std::endl;
	}

	plik.close();
}