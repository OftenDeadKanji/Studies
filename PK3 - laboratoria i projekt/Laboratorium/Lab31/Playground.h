#pragma once
#include "Dog.h"
#include "Rabbit.h"
#include "Mole.h"
#include "Human.h"
#include "Console.h"


#define MAXDOGS 10
#define MAXRABBITS 10
#define MAXMOLES 10
#define MAXHUMANS 10

class Playground
{
private:
	// Array of dogs 
	int noOfDogs = 0;
	Dog *dogs[MAXDOGS];
	int noOfPuppies = 0;
	Dog puppies[MAXDOGS]; //tablica obiektów, przechowywane s¹ tu nowe psy tworzone przy spotkaniu siê dwóch psów

	// Add array of cats and rabbits
	int noOfRabbits = 0;
	Rabbit *rabbits[MAXRABBITS];
	int noOfLittleRabbits = 0;
	Rabbit littleRabbits[MAXRABBITS];

	int noOfHumans = 0;
	Human *humans[MAXHUMANS];

	int noOfMoles = 0;
	Mole *moles[MAXMOLES];

	// Technical object grouping console operations
	Console &console;

public:
	// Constructors
	Playground(Console &console);
	~Playground();

	void AddDog(Dog &dog);
	void AddPuppy(Dog puppy);
	void AddRabbit(Rabbit &rabbit);
	void AddLittleRabbit(Rabbit rabbit);
	void AddMole(Mole &mole);
	void AddHuman(Human &human);
	// add AddCat AddRabbit
	void AnimalsDoDraw();
	void AnimalsCheckCollision();
	void CheckDogs();
	void CheckRabbits();
	void CheckHumans();
	void AnimalsDoAction();
	void Simulate();
};

