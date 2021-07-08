#include "../pch.h"

Wyjatek::Wyjatek(std::string raport)
{
	this->raport = raport;
}

const char * Wyjatek::what() const throw()
{
	return raport.c_str();
}
