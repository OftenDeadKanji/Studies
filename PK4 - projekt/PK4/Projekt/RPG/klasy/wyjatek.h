#pragma once

class Wyjatek :
	public std::exception
{
private:
	std::string raport;
public:
	Wyjatek(std::string);
	virtual const char* what() const throw() override;
};