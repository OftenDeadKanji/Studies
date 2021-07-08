#pragma once
#include "Animal.h"
#include "Console.h"
#include "Sprite.h"

class AnimalSprite : public Animal, public Sprite
{
protected:
	int actionActualFrame = 0;
	int actionLastFrame = 1;
	typedef void (AnimalSprite::*ActionFunction)(Console&);
	struct Action
	{
		int probability;
		std::string actionText;
		int frameNumber;
		ActionFunction actionFunction;
	};
	ActionFunction currentActionFunction = &AnimalSprite::ActionThinking;
	std::string actionText;
public:
	AnimalSprite();
	AnimalSprite(std::string, int, bool, WORD);
	AnimalSprite(const AnimalSprite &animal);
	AnimalSprite(AnimalSprite &&animal);
	~AnimalSprite();

	void DoDraw(Console &);
	void DoAction(Console &);
	std::string DoGetInfo();

	virtual Action ActionInfo(int index) = 0;
	virtual void ActionThinking(Console &console) = 0;
	virtual void ActionMoving(Console &console) = 0;
	virtual void ActionSpecial(Console &console) = 0;
	virtual void ActionSleeping(Console &console) = 0;
	virtual void SeeOtherAnimal(AnimalSprite &animal) = 0;
};

