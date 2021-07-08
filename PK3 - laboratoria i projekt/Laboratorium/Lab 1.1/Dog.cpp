#include "stdafx.h"
#include "Dog.h"
using namespace std;


//Konstruktory
Dog::Dog() //bez parametru
{
	cout << "Constructor [parameterless]: "<< GetInfo() << " created." << endl;
}

Dog::Dog(std::string nazwa) //z jednym parametrem
{
	name = nazwa;
	cout << "Constructor[one - parameter]: " << GetInfo() << " created." << endl;
}

Dog::Dog(std::string nazwa, int sila, std::string rasa, int agresja, int wiek, bool czySamiec) //ze wszystkimi parametrami
{
	name = nazwa;
	power = sila;
	breed = rasa;
	aggresion = agresja;
	age = wiek;
	isMale = czySamiec;

	cout << "Constructor [multi-parameter]: " << GetInfo() << " created." << endl;
}

Dog::Dog(const Dog &pies) //kopiuj¹cy
{
	name = pies.name;
	power = pies.power;
	breed = pies.breed;
	aggresion = pies.aggresion;
	age = pies.age;
	isMale = pies.isMale;
	cout << "Constructor [copy]: " << GetInfo() << " created." << endl;
}

//Destruktor
Dog::~Dog()
{
	cout << "Destructor: " << GetInfo() << " destroyed." << endl;
}

//Akcesory
void Dog::SetName(std::string nazwa)
{
	cout << this->name << " name modified to " << nazwa << " by setter function." << endl;
	this->name = nazwa;
}

void Dog::SetBreed(std::string rasa)
{
	cout << this->name << " breed modified to " << rasa << " by setter function." << endl;
	this->breed = rasa;
}

void Dog::SetPower(int sila)
{
	cout << this->name << " power modified to " << sila << " by setter function." << endl;
	this->power = sila;
}

void Dog::SetAggresion(int agresja)
{
	cout << this->name << " aggression modified to " << agresja << " by setter function." << endl;
	this->aggresion = agresja;
}

void Dog::SetAge(int wiek)
{
	cout << this->name << " age modified to " << wiek << " by setter function." << endl;
	this->age = wiek;
}

std::string Dog::GetName() const
{
	return this->name;
}

std::string Dog::GetBreed() const
{
	return this->breed;
}

int Dog::GetPower() const
{
	return this->power;
}

int Dog::GetAggresion() const
{
	return this->aggresion;
}

int Dog::GetAge() const
{
	return this->age;
}

// Debug methods
string Dog::GetInfo()
{
	string liveDesc = isAlive ? "Dog " : "Dead dog";
	string infoString = liveDesc + GetName() + " of breed " + GetBreed() + " and age " + std::to_string(age) + " and power " + std::to_string(power);
	return infoString;
}

void Dog::PrintInfo()
{
	cout << GetInfo() << endl;
}