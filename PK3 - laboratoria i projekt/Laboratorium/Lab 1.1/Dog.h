#pragma once

class Dog
{
private:
	std::string name = "Anonymous";
	std::string breed = "Mongrel";
	int power = 0;
	int aggresion = 0;
	int age = 0;
	bool isMale = true;
	bool isAlive = true;

public:
	// dodaæ konstruktory i destruktor

	//Konstruktory
	Dog(); //bez param.
	Dog(std::string name); //1 param.
	Dog(std::string name, int power, std::string breed, int aggression, int age, bool isMale); //wszystk. param.
	Dog(const Dog &); //kopiuj.
	//Destruktor
	~Dog();

	// Akcesory - setters
	void SetName(std::string);
	void SetBreed(std::string);
	void SetPower(int);
	void SetAggresion(int);
	void SetAge(int);

	// Akcesory - getters
	std::string GetName() const;
	std::string GetBreed() const;
	int GetPower() const;
	int GetAggresion() const;
	int GetAge() const;

	// Debug info
	std::string GetInfo();
	void PrintInfo();
};