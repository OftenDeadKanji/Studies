#pragma once
#include "Animal.h"
#include "Console.h"

class Human : public Animal
{
private:
	int money = 15;
	typedef void(Human::*ActionFunction)(Console&);
	struct Action
	{
		int probability;
		std::string actionText;
		int frameNumber;
		ActionFunction actionFunction;
	};
	const Action actionInfo[5] = {
		{ 01, "thinking",   1, &Human::ActionThinking },
		{ 50, "going",    150, &Human::ActionJumping },
		{ 25, "singing",  100, &Human::ActionSpecial },
		{ 24, "sleeping", 100, &Human::ActionSleeping },
	};
	ActionFunction currentActionFunction = &Human::ActionThinking;
	int actionActualFrame = 0;
	int actionLastFrame = 1;

public:
	// konstruktory
	Human();
	Human(const Human &dog);
	Human(Human &&dog);
	Human(std::string name);
	Human(std::string name, int age, bool isMale, WORD color);
	~Human();

	int GetMoney() const;
	void SetMoney(int);

	// Operatory
	Human& operator= (const Human &Human);
	Human& operator= (Human &&Human);

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