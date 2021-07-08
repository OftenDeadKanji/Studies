#pragma once
#include "Animal.h"
#include "Console.h"

class Mole : public Animal
{
private:
	typedef void(Mole::*ActionFunction)(Console&);
	struct Action
	{
		int probability;
		std::string actionText;
		int frameNumber;
		ActionFunction actionFunction;
	};
	const Action actionInfo[5] = {
		{ 01, "thinking",   1, &Mole::ActionThinking },
		{ 60, "digging",  400, &Mole::ActionJumping },
		{ 20, "fixing",	  100, &Mole::ActionSpecial },
		{ 19, "sleeping", 100, &Mole::ActionSleeping },
	};
	ActionFunction currentActionFunction = &Mole::ActionThinking;
	int actionActualFrame = 0;
	int actionLastFrame = 1;

public:
	// konstruktory
	Mole();
	Mole(const Mole &dog);
	Mole(Mole &&dog);
	Mole(std::string name);
	Mole(std::string name, int age, bool isMale, WORD color);
	~Mole();

	// Operatory
	Mole& operator= (const Mole &Mole);
	Mole& operator= (Mole &&Mole);

	// Dog virtual actions
	virtual std::string DoGetInfo();

	// Action implementation
	Action ActionInfo(int);
	void DoAction(Console &console);
	void ActionThinking(Console &console);
	void ActionJumping(Console &console);
	void ActionSpecial(Console &console);
	void ActionSleeping(Console &console);

};