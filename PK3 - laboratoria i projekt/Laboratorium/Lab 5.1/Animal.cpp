#include "stdafx.h"
#include "Animal.h"

using namespace std;

#pragma region Constructors
Animal::Animal(): Animal("Noname animal", 0, true, 0)
{}

Animal::Animal(std::string name, int age, bool isMale, WORD color): name(name), age(age), isMale(isMale), color(color)
{}

Animal::Animal(const Animal &animal) 
{
	color = animal.color;

	if (animal.imageData)		
	{
		imageData = new char[strlen(animal.imageData) + 1];
		memcpy(imageData, animal.imageData, strlen(animal.imageData) + 1);
	}
}

Animal::Animal(Animal &&animal): name(animal.name), age(animal.age), isMale(animal.isMale), imageData(animal.imageData)
{
	color = animal.color;

	animal.imageData = nullptr;
}

Animal::~Animal()
{
	if (imageData)
		delete[] imageData;
}
#pragma endregion

#pragma region Accessors
// Akcesory - setters
void Animal::SetName(std::string name)
{
	this->name = name;
}

void Animal::SetAge(int age)
{
	this->age = age;
}

void Animal::SetImage(char *imageData)
{
	if (this->imageData) // != nullptr
		delete[] imageData;

	if (imageData)
	{
		imageData = new char[strlen(imageData) + 1];
		memcpy(this->imageData, imageData, strlen(imageData) + 1);
	}
}

// Akcesory - getters
std::string Animal::GetName() const
{
	return name.empty() ? "Anonymous" : name;
}

int Animal::GetAge() const
{
	return age;
}

char* Animal::GetImage() const
{
	return imageData;
}

WORD Animal::GetColor() const
{
	return color;
}

#pragma endregion

#pragma region Operators
Animal& Animal::operator= (const Animal& animal)
{

	name = animal.name;
	age = animal.age;
	isMale = animal.isMale;

	if (imageData)
	{
		delete[] imageData;
		imageData = nullptr;
	}

	if (animal.imageData)
	{
		imageData = new char[strlen(animal.imageData) + 1];
		memcpy(imageData, animal.imageData, strlen(animal.imageData) + 1);
	}


	return *this;
}

Animal& Animal::operator= (Animal&& animal)
{

	name = animal.name;
	age = animal.age;
	isMale = animal.isMale;

	if (imageData)
		delete[] imageData;

	imageData = animal.imageData;
	animal.imageData = nullptr;


	return *this;
}
#pragma endregion
