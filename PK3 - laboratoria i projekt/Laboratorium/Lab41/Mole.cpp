#include "stdafx.h"
#include "Mole.h"

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
Animal::Action Mole::ActionInfo(int index)
{
	return actionInfo[index];
}

string Mole::DoGetInfo()
{
	return "Mole " + Animal::DoGetInfo();
}
#pragma endregion

void Mole::SeeOtherAnimal(Animal &animal)
{
	if (animal.DoGetInfo()[0] != 'M') {
		dx -= 0.05*(animal.x - x);
		if (dx > 0.7)
			dx = 0.7;
		if (dx < -0.7)
			dx = -0.7;

		dy -= 0.05*(animal.y - y);
		if (dy > 0.7)
			dy = 0.7;
		if (dy < -0.7)
			dy = -0.7;
	}
}

#pragma region Metods: actions
void Mole::ActionThinking(Console &console)
{
	dx = -0.5f + static_cast <float> (rand()) / static_cast <float> (RAND_MAX);
	dy = -0.5f + static_cast <float> (rand()) / static_cast <float> (RAND_MAX);
}

void Mole::ActionMoving(Console &console)
{
	if (x + dx < 0 || x + dx > console.GetWidth())
		dx = -dx;

	if (y + dy < 0 || y + dy > console.GetHeight())
		dy = -dy;

	x += dx;
	y += dy;
}

void Mole::ActionSpecial(Console &console)
{
	if (actionActualFrame == 20) console.DrawRectangleOnBackground((short)x, (short)y, 1, 1, BACKGROUND_GREEN);
	if (actionActualFrame == 80) console.DrawRectangleOnBackground((short)x - 1, (short)y - 1, 3, 3, BACKGROUND_GREEN);
}

void Mole::ActionSleeping(Console &console)
{
	if (actionActualFrame % 20 == 0) actionText = actionText + "..hrr";

}

#pragma endregion
