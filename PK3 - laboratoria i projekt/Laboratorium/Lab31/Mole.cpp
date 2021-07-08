#include "stdafx.h"
#include "Mole.h"

#define col_rab 
using namespace std;

#pragma region Constructors
Mole::Mole() : Mole("Anonymous", 0, true, 0)
{}

Mole::Mole(string name) : Mole(name, 0, true, 0)
{}

Mole::Mole(std::string name, int age, bool isMale, WORD color) : Animal(name, age, isMale, color)
{}

Mole::Mole(const Mole &Mole) : Animal(Mole)
{}

Mole::Mole(Mole &&Mole) : Animal(move(Mole))
{}

Mole::~Mole()
{}
#pragma endregion

#pragma region Operators
Mole& Mole::operator= (const Mole& Mole)
{
	Animal::operator= (Mole);
	return *this;
}

Mole& Mole::operator= (Mole&& Mole)
{
	Animal::operator= (std::move(Mole));
	return *this;
}
#pragma endregion


#pragma region Virtual functions
Mole::Action Mole::ActionInfo(int index)
{
	return actionInfo[index];
}

string Mole::DoGetInfo()
{
	return "Mole " + Animal::DoGetInfo();
}
#pragma endregion


#pragma region Metods: actions

void Mole::DoAction(Console &console)
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

void Mole::ActionThinking(Console &console)
{
	dx = -0.5f + static_cast <float> (rand()) / static_cast <float> (RAND_MAX);
	dy = -0.5f + static_cast <float> (rand()) / static_cast <float> (RAND_MAX);
}

void Mole::ActionJumping(Console &console)
{
	if (x + dx < 0 || x + dx > console.GetWidth())
		dx = -dx;

	if (y + dy < 0 || y + dy > console.GetHeight())
		dy = -dy;

	x += 0.5*dx;
	y += 0.5*dy;
}

void Mole::ActionSpecial(Console &console)
{
	if (actionActualFrame == 20) console.DrawRectangleOnBackground((short)x, (short)y, 1, 1, BACKGROUND_GREEN);
	if (actionActualFrame == 50) console.DrawRectangleOnBackground((short)x - 1, (short)y - 1, 2, 2, BACKGROUND_GREEN);
	if (actionActualFrame == 80) console.DrawRectangleOnBackground((short)x - 2, (short)y - 2, 3, 3, BACKGROUND_GREEN);
}

void Mole::ActionSleeping(Console &console)
{
	if (actionActualFrame % 20 == 0) actionText = actionText + "..hrr";

}

#pragma endregion