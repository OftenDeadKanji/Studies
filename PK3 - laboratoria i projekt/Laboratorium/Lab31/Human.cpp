#include "stdafx.h"
#include "Human.h"

#define col_rab 
using namespace std;

#pragma region Constructors
Human::Human() : Human("Anonymous", 0, true, 0)
{}

Human::Human(string name) : Human(name, 0, true, 0)
{}

Human::Human(std::string name, int age, bool isMale, WORD color) : Animal(name, age, isMale, color)
{}

Human::Human(const Human &Human) : Animal(Human)
{}

Human::Human(Human &&Human) : Animal(move(Human))
{}

Human::~Human()
{}
#pragma endregion

int Human::GetMoney() const
{
	return money;
}

void Human::SetMoney(int cash)
{
	money = cash;
}

#pragma region Operators
Human& Human::operator= (const Human& Human)
{
	Animal::operator= (Human);
	return *this;
}

Human& Human::operator= (Human&& Human)
{
	Animal::operator= (std::move(Human));
	return *this;
}
#pragma endregion


#pragma region Virtual functions
Human::Action Human::ActionInfo(int index)
{
	return actionInfo[index];
}

string Human::DoGetInfo()
{
	return "Human " + Animal::DoGetInfo();
}
#pragma endregion


#pragma region Metods: actions

void Human::DoAction(Console &console)
{
	if (actionActualFrame == actionLastFrame)
	{
		Action action = ActionInfo(0);
		int random_number = rand() % 100;
		int newFunctionIndex = 0;
		int sum = action.probability;

		while (random_number > sum)
		{
			action = ActionInfo(++newFunctionIndex);
			sum += action.probability;
		}

		currentActionFunction = action.actionFunction;
		actionLastFrame = action.frameNumber;
		actionText = action.actionText;
		actionActualFrame = 0;
	}

	(this->*currentActionFunction)(console);
	/* this is conceptually the same as
	...
	switch (action_number) {
	case 1:  ActionThinking(console); break;
	case 2:  ActionMoving(console); break;
	case 3:  ActionSpecial(console); break;
	}
	*/

	actionActualFrame++;
}

void Human::ActionThinking(Console &console)
{
	dx = -0.5f + static_cast <float> (rand()) / static_cast <float> (RAND_MAX);
	dy = -0.5f + static_cast <float> (rand()) / static_cast <float> (RAND_MAX);
}

void Human::ActionJumping(Console &console)
{
	if (x + dx < 0 || x + dx > console.GetWidth())
		dx = -dx;

	if (y + dy < 0 || y + dy > console.GetHeight())
		dy = -dy;

	x += 0.75 * dx;
	y += 0.75 * dy;
}

void Human::ActionSpecial(Console &console)
{
	if (actionActualFrame % 20 == 0) actionText = actionText + " La..";
}

void Human::ActionSleeping(Console &console)
{
	if (actionActualFrame % 20 == 0) actionText = actionText + "..hrr";

}

#pragma endregion
