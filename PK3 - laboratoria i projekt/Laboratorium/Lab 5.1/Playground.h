#pragma once
#include "AnimalSprite.h"
#include "Console.h"


#define MAXANIMALS 15
class Playground
{
private:
	// Object containers
	int noOfAnimals = 0;
	// array of references are illegal
	AnimalSprite *animals[MAXANIMALS];
	// Technical object grouping console operations
	Console &console;

public:
	// Constructors
	Playground(Console &console);
	~Playground();

	void AddAnimal(AnimalSprite &animal);
	void AnimalsDoDraw();
	void AnimalsDoAction();
	void AnimalsCheckCollisions();
	void Simulate();
};

