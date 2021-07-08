#include "stdafx.h"
#include "AnimalSprite.h"


AnimalSprite::AnimalSprite() : Animal("Noname animal", 0, true, 0), Sprite()
{}

AnimalSprite::AnimalSprite(std::string name, int age, bool isMale, WORD color): Animal(name, age, isMale, color), Sprite()
{}

AnimalSprite::AnimalSprite(const AnimalSprite &animal): Animal(animal), Sprite()
{}

AnimalSprite::AnimalSprite(AnimalSprite &&animal): Animal(animal)
{}

AnimalSprite::~AnimalSprite()
{
	if (imageData)
		delete[] imageData;
}

std::string AnimalSprite::DoGetInfo()
{
	return GetName() + " [" + actionText + "]";
}

void AnimalSprite::DoDraw(Console &console)
{
	console.DrawTextOnPlayground((short)x, (short)y, DoGetInfo(), GetColor());
}

void AnimalSprite::DoAction(Console &console)
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
	actionActualFrame++;
}