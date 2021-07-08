#include "stdafx.h"
#include "Playground.h"
#include <cmath>
using namespace std;


#pragma region Constructors
Playground::Playground(Console &console): console(console)
{}

Playground::~Playground()
{}
#pragma endregion


#pragma region Methods: Playground manipulation
void Playground::AddAnimal(Animal &animal)
{
	if (noOfAnimals < MAXANIMALS)
		animals[noOfAnimals++] = &animal;
}

void Playground::AnimalsDoDraw()
{
	for (int i = 0; i < noOfAnimals; i++)
		animals[i]->DoDraw(console);
}

void Playground::AnimalsDoAction()
{
	for (int i = 0; i<noOfAnimals; i++)
		animals[i]->DoAction(console);
}
void Playground::AnimalsCheckCollisions()
{
	for (int n = 0;n < noOfAnimals;n++)
		for (int i = n + 1;i < noOfAnimals;i++)
		{
			if ((abs(animals[i]->x - animals[n]->x) < 3) && (abs(animals[i]->y - animals[n]->y) < 3)) {
				animals[n]->SeeOtherAnimal(*animals[i]);
				animals[i]->SeeOtherAnimal(*animals[n]);
			}
		}
}
void Playground::Simulate()
{
	DWORD currentTickCount;
	DWORD lastDrawTickCount = 0;

	while (!console.KeyPressed(VK_ESCAPE))
	{
		currentTickCount = GetTickCount();				//tickcount in ms

		if (currentTickCount - lastDrawTickCount > 20)	// 50 frames per second
		{
			AnimalsDoAction();
			AnimalsCheckCollisions();
			AnimalsCheckCollisions();
			console.CopyBackgroundToPlayground();
			AnimalsDoDraw();
			console.CopyPlaygroundToScreen();

			lastDrawTickCount = GetTickCount();
		}
	}
}
#pragma endregion

