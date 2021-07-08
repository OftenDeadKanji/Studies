#pragma once
class Handlarz :
	public NPC
{
public:
	Handlarz();
	Handlarz(int, int, int, std::string);
	Handlarz(Handlarz &);
	~Handlarz();
};

