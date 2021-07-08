// Lab 3-1 solution.cpp : Simple game - no function pointers
//

#include "stdafx.h"
#include "Dog.h"
#include "Mole.h"
#include "Playground.h"
#include "Console.h"

using namespace std;
#define WIDTH 80
#define HEIGHT 25


int main()
{
	// initialize random generator
	srand((unsigned int) time(0));

	// create console 
	Console console(WIDTH, HEIGHT);

	// create playground for animals
	Playground playground(console);

	vector<Dog> dogs;


	// create animals
	Dog fafik("Fafik");
	Dog puszek("Puszek");
	Dog borek("Borek");

	Mole marian("Marian");
	Mole zbigniew("Zbigniew");
	Mole stefan("Stefan");

	// add animals to playground
	playground.AddAnimal(fafik);
	playground.AddAnimal(puszek);
	playground.AddAnimal(borek);

	playground.AddAnimal(marian);
	playground.AddAnimal(zbigniew);
	playground.AddAnimal(stefan);

	// simulation mail loop
	playground.Simulate();

	return 0;
}