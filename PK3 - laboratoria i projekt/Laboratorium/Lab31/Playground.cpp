#include "stdafx.h"
#include "Playground.h"
using namespace std;


#pragma region Constructors
Playground::Playground(Console &console): console(console)
{}

Playground::~Playground()
{}
#pragma endregion


#pragma region Methods: Playground manipulation
void Playground::AddDog(Dog &dog)
{
	if (noOfDogs < MAXDOGS)
		dogs[noOfDogs++] = &dog;
}

void Playground::AddPuppy(Dog puppy) //funkcja ta dodaje obiekt do tablicy obiektów
{
	if (noOfDogs < MAXDOGS)
		puppies[noOfPuppies++] = puppy;
}

// add methods for adding cats and rabbits
void Playground::AddRabbit(Rabbit &rabbit)
{
	if (noOfRabbits < MAXRABBITS)
		rabbits[noOfRabbits++] = &rabbit;
}

void Playground::AddLittleRabbit(Rabbit rabbit)
{
	if (noOfRabbits < MAXRABBITS)
		littleRabbits[noOfLittleRabbits++] = rabbit;
}

void Playground::AddMole(Mole &mole)
{
	if (noOfMoles < MAXMOLES)
		moles[noOfMoles++] = &mole;
}

void Playground::AddHuman(Human &human)
{
	if (noOfHumans < MAXDOGS)
		humans[noOfHumans++] = &human;
}

void Playground::AnimalsDoDraw()
{
	for (int i = 0; i < noOfDogs; i++)
		dogs[i]->DoDraw(console);
	// add action for drawing cats and rabbits
	for (int i = 0; i < noOfRabbits; i++)
		rabbits[i]->DoDraw(console);
	for (int i = 0; i < noOfMoles; i++)
		moles[i]->DoDraw(console);
	for (int i = 0; i < noOfHumans; i++)
		humans[i]->DoDraw(console);
}

void Playground::AnimalsCheckCollision()
{
	//Psy:
	//- walcz¹
	//- rozmna¿aj¹ siê
	CheckDogs();
	//Króliki:
	//- rozmna¿aj¹ siê (za ka¿dym razem tworzone s¹ 2 króliki)
	CheckRabbits();
	//Ludzie
	//- kradn¹ sobie pieni¹dze
	//- po zgromadzeniu odpowiedniej sumy zostaj¹ politykami
	CheckHumans();
}

void Playground::CheckDogs()
{
	for (int n = 0; n < noOfDogs; n++)
		for (int i = n + 1; i < noOfDogs; i++)
			if (((int)dogs[n]->x == (int)dogs[i]->x) && ((int)dogs[n]->y == (int)dogs[i]->y)) {
				if ((dogs[n]->ifMale() != dogs[i]->ifMale())&&noOfDogs<MAXDOGS) {
					//dwa psy ró¿nej p³ci tworz¹ nowego psa
					int isMale = rand() % 2;
					Dog puppy (dogs[n]->GetName() + " + " + dogs[i]->GetName(), 0, isMale, 0);
					AddPuppy(puppy);					//wymagane by³o stworzenie nowej funkcji i tablicy obiektów, gdy¿ po wyjœciu 
					AddDog(puppies[noOfPuppies - 1]);		//z AnimalCheckCollision() wywo³ywany jest destruktor dla obiektu puppy
														//przez co wskaŸnik w tablicy Dogs[] traci³by obiekt, na który wskazuje

				}
				else {
					//dwa psy tej samej p³ci tocz¹ walkê
					int winner = rand() % 2;
					if (winner) { //walkê zwyciê¿a dogs[n]
						int index = -1;
						for (int j = 0; j < noOfPuppies; j++)
							if (dogs[i]->GetName() == puppies[j].GetName())
 								if ((dogs[i]->x == puppies[j].x) && (dogs[i]->y == puppies[j].y))
									index = j;
						dogs[i]->~Dog();
						if (index != -1) {
							for (int j = index + 1; j < noOfPuppies; j++)
								puppies[j - 1] = puppies[j];
							noOfPuppies--;
						}
						for (int j = i + 1; j < noOfDogs; j++)
							dogs[j - 1] = dogs[j];
						noOfDogs--;
					}
					else { //walkê zwyciê¿a dogs[i]
						int index = -1;
						for (int j = 0; j < noOfPuppies; j++)
							if (dogs[i]->GetName() == puppies[j].GetName())
								if ((dogs[i]->x == puppies[j].x) && (dogs[i]->y == puppies[j].y))
									index = j;
						dogs[n]->~Dog();
						if (index != -1) {
							for (int j = index + 1; j < noOfPuppies; j++)
								puppies[j - 1] = puppies[j];
							noOfPuppies--;
						}
						for (int j = n + 1; j < noOfDogs; j++)
							dogs[j - 1] = dogs[j];
						noOfDogs--;
					}
				}
			}
}

void Playground::CheckRabbits()
{
	if (noOfRabbits < MAXRABBITS)
		for (int n = 0; n < noOfRabbits; n++)
			for (int i = n + 1; i < noOfRabbits; i++)
				if (((int)rabbits[n]->x == (int)rabbits[i]->x) && ((int)rabbits[n]->y == (int)rabbits[i]->y)) {
					if (rabbits[n]->ifMale() != rabbits[i]->ifMale()) {
						int isMale = rand() % 2;
						Rabbit firstLittle(rabbits[n]->GetName() + " + " + rabbits[i]->GetName(), 0, isMale, 0);
						Rabbit secondLittle(rabbits[n]->GetName() + " + " + rabbits[i]->GetName(), 0, isMale, 0);
						AddLittleRabbit(firstLittle);
						AddRabbit(littleRabbits[noOfLittleRabbits - 1]);
						AddLittleRabbit(secondLittle);
						AddRabbit(littleRabbits[noOfLittleRabbits - 1]);
					}
				}
}

void Playground::CheckHumans()
{
	for (int n = 0; n < noOfHumans; n++)
		for (int i = n + 1; i < noOfHumans; i++)
			if (((int)humans[n]->x == (int)humans[i]->x) && ((int)humans[n]->y == (int)humans[i]->y)) {
				int robber = rand() % 2;
				if (robber) { //kradnie osoba humans[n]
					if (humans[i]->GetMoney() > 0) {
						humans[i]->SetMoney(humans[i]->GetMoney() - 5);
						humans[n]->SetMoney(humans[n]->GetMoney() + 5);
					}
					if (humans[n]->GetMoney() >= 30) {
						string name = humans[n]->GetName();
						if (name.length() > 7)
							if (name[7] != ' ')
								humans[n]->SetName("Politic " + humans[n]->GetName());
					}
				}
				else { //kradnie osoba humans[i]		 
					if (humans[n]->GetMoney() > 0) {
						humans[n]->SetMoney(humans[n]->GetMoney() - 5);
						humans[i]->SetMoney(humans[i]->GetMoney() + 5);
					}
					if (humans[i]->GetMoney() >= 30) {
						string name = humans[i]->GetName();
						if (name.length() > 7)
							if (name[7] != ' ')
								humans[i]->SetName("Politic " + humans[i]->GetName());
					}
				}
			}
}

void Playground::AnimalsDoAction()
{
	for (int i = 0; i<noOfDogs; i++)
		dogs[i]->DoAction(console);
	// add action for cats and rabbits
	for (int i = 0; i<noOfRabbits; i++)
		rabbits[i]->DoAction(console);
	for (int i = 0; i < noOfMoles; i++)
		moles[i]->DoAction(console);
	for (int i = 0; i < noOfHumans; i++)
		humans[i]->DoAction(console);
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
			AnimalsCheckCollision();
			console.CopyBackgroundToPlayground();
			AnimalsDoDraw();
			console.CopyPlaygroundToScreen();

			lastDrawTickCount = GetTickCount();
		}
	}
}
#pragma endregion

