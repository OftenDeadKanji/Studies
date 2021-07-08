#pragma once
#include "Console.h"

class Animal
{
protected:
	WORD color = 0;
	std::string name;
	int age = 0;
	bool isMale = true;
	bool isAlive = true;
	char *imageData = nullptr;

public:
	// Constructors and destructor
	Animal();
	Animal(std::string, int, bool, WORD);
	Animal(const Animal &);
	Animal(Animal &&);
	~Animal();
	
	// Akcesory - setters
	void SetName(std::string);
	void SetAge(int);
	void SetImage(char *imageData);

	// Akcesory - getters
	std::string GetName() const;
	WORD GetColor() const;
	int GetAge() const;
	char* GetImage() const;

	// Operatory
	Animal& operator= (const Animal& animal); 
	Animal& operator= (Animal&& animal); 

};