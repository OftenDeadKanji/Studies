#include "stdafx.h"
#include "Rabbit.h"

#define col_rab 
using namespace std;

#pragma region Constructors
Rabbit::Rabbit() : Rabbit("Anonymous", 0, true, 0)
{}

Rabbit::Rabbit(string name) : Rabbit(name, 0, true, 0)
{}

Rabbit::Rabbit(std::string name, int age, bool isMale, WORD color) : Animal(name, age, isMale, color)
{}

Rabbit::Rabbit(const Rabbit &Rabbit) : Animal(Rabbit)
{}

Rabbit::Rabbit(Rabbit &&Rabbit) : Animal(move(Rabbit))
{}

Rabbit::~Rabbit()
{}
#pragma endregion

#pragma region Operators
Rabbit& Rabbit::operator= (const Rabbit& Rabbit)
{
	Animal::operator= (Rabbit);
	return *this;
}

Rabbit& Rabbit::operator= (Rabbit&& Rabbit)
{
	Animal::operator= (std::move(Rabbit));
	return *this;
}
#pragma endregion


#pragma region Virtual functions
Rabbit::Action Rabbit::ActionInfo(int index)
{
	return actionInfo[index];
}

string Rabbit::DoGetInfo()
{
	return "Rabbit " + Animal::DoGetInfo();
}
#pragma endregion


#pragma region Metods: actions

void Rabbit::DoAction(Console &console)
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

void Rabbit::ActionThinking(Console &console)
{
	dx = -0.5f + static_cast <float> (rand()) / static_cast <float> (RAND_MAX);
	dy = -0.5f + static_cast <float> (rand()) / static_cast <float> (RAND_MAX);
}

void Rabbit::ActionJumping(Console &console)
{
	if (x + dx < 0 || x + dx > console.GetWidth())
		dx = -dx;

	if (y + dy < 0 || y + dy > console.GetHeight())
		dy = -dy;

	x += 2*dx;
	y += 2*dy;
}

void Rabbit::ActionSpecial(Console &console)
{
	if (actionActualFrame == 20) console.DrawRectangleOnBackground((short)x, (short)y, 1, 1, BACKGROUND_RED | BACKGROUND_GREEN | BACKGROUND_BLUE);
	if (actionActualFrame == 80) console.DrawRectangleOnBackground((short)x - 1, (short)y - 1, 2, 2, BACKGROUND_RED | BACKGROUND_GREEN | BACKGROUND_BLUE);
}

void Rabbit::ActionSleeping(Console &console)
{
	if (actionActualFrame % 20 == 0) actionText = actionText + "..hrr";

}

#pragma endregion
