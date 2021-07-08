#pragma once
#include "AnimalSprite.h"
#include "Console.h"

class Mole : public AnimalSprite
{
private:
	const Action actionInfo[5] = {
		{ 1, "thinking", 1, &AnimalSprite::ActionThinking },
		{ 60, "digging", 400, &AnimalSprite::ActionMoving },
		{ 20, "fixing", 100, &AnimalSprite::ActionSpecial },
		{ 19, "sleeping", 100, &AnimalSprite::ActionSleeping },
	};
public:
	// konstruktory
	Mole();
	Mole(const Mole &Mole);
	Mole(Mole &&Mole);
	Mole(std::string name);
	Mole(std::string name, int age, bool isMale, WORD color);
	~Mole();

	// Operatory
	Mole& operator= (const Mole &Mole);
	Mole& operator= (Mole &&Mole);

	// Mole virtual actions
	virtual std::string DoGetInfo();
	virtual void SeeOtherAnimal(AnimalSprite &animal);
	// Action implementation
	Action ActionInfo(int);
	void ActionThinking(Console &console);
	void ActionMoving(Console &console);
	void ActionSpecial(Console &console);
	void ActionSleeping(Console &console);
};

