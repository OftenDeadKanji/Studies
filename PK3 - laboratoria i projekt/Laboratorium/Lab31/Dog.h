#pragma once
#include "Animal.h"
#include "Console.h"

class Dog : public Animal
{
private:
	typedef void(Dog::*ActionFunction)(Console&);
	struct Action
	{
		int probability;
		std::string actionText;
		int frameNumber;
		ActionFunction actionFunction;
	};
	const Action actionInfo[5] = {
		{ 01, "thinking",   1, &Dog::ActionThinking },
		{ 60, "running",  200, &Dog::ActionMoving },
		{ 20, "pissing",  100, &Dog::ActionSpecial },
		{ 19, "sleeping", 100, &Dog::ActionSleeping },
	};
	ActionFunction currentActionFunction = &Dog::ActionThinking;
	int actionActualFrame = 0;
	int actionLastFrame = 1;

public:
	// konstruktory
	Dog();
	Dog(const Dog &dog);
	Dog(Dog &&dog);
	Dog(std::string name);
	Dog(std::string name, int age, bool isMale, WORD color);
	~Dog();

	// Operatory
	Dog& operator= (const Dog &dog);
	Dog& operator= (Dog &&dog); 
		
	// Dog virtual actions
	virtual std::string DoGetInfo();

	// Action implementation
	Action ActionInfo(int);
	void DoAction(Console &console);
	void ActionThinking(Console &console);
	void ActionMoving(Console &console);
	void ActionSpecial(Console &console);
	void ActionSleeping(Console &console);
};

