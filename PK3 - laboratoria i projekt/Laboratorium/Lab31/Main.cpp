// Lab 3-1 solution.cpp : Simple game - no function pointers
//

#include "stdafx.h"
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

	// create animals
	Dog fafik("Fafik");
	Dog faficzka("Faficzka", 4, 0, 0);
	Dog puszek("Puszek");
	Dog puszka("Puszka", 3, 0, 0);
	Dog borek("Borek");
	Dog borka("Borka", 5, 0, 0);
	Dog reksio("Reksio");
	Dog reksia("Reksia", 7, 0, 0);

	Rabbit zbigniew("Zbigniew");
	Rabbit staszek("Staszek");
	Rabbit krysia("Krysia", 4, 0, 0);
	Rabbit antosia("Antosia", 3, 0, 0);

	Mole jack("Jack");
	Mole jim("Jim");
	Mole joel("Joel");
	Mole john("John");

	Human adam("Adam");
	Human ewa("Ewa", 25, 0, 0);
	Human radowid("Radowid");
	Human adda("Adda", 19, 0, 0);
	Human palpatine("Palpatine");
	Human qira("Qi'ra", 28, 0, 0);
	// add animals to playground
	playground.AddDog(fafik);
	playground.AddDog(puszek);
	playground.AddDog(borek);
	playground.AddDog(reksio);

	playground.AddDog(faficzka);
	playground.AddDog(puszka);
	playground.AddDog(borka);
	playground.AddDog(reksia);
	
	playground.AddRabbit(zbigniew);
	playground.AddRabbit(staszek);
	playground.AddRabbit(krysia);
	playground.AddRabbit(antosia);

	playground.AddMole(jack);
	playground.AddMole(jim);
	playground.AddMole(joel);
	playground.AddMole(john);

	playground.AddHuman(adam);
	playground.AddHuman(ewa);
	playground.AddHuman(radowid);
	playground.AddHuman(adda);
	playground.AddHuman(palpatine);
	playground.AddHuman(qira);
	
	// simulation mail loop
	playground.Simulate();

	return 0;
}