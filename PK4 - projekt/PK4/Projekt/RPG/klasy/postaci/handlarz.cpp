#include "../../pch.h"

Handlarz::Handlarz()
{}

Handlarz::Handlarz(int id, int x, int y, std::string nazwaPliku) : NPC(id, x, y, nazwaPliku)
{}

Handlarz::Handlarz(Handlarz& han) : NPC(han)
{}

Handlarz::~Handlarz()
{}
