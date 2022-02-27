#include "System.h"

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, PSTR pScmdline, int iCmdshow)
{
	System* system = new System;
	if (!system)
	{
		return 0;
	}

	bool result = system->Initialize();
	if (result)
	{
		system->Run();
	}

	system->Shutdown();
	delete system;
	system = 0;

	return 0;
}
