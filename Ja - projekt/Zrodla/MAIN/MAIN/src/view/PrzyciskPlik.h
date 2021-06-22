#pragma once

class PrzyciskPlik
	: public Button
{
private:
	ALLEGRO_FILECHOOSER* plik;
public:
	PrzyciskPlik(const std::string&, int, int, ControlType = CONTROL_NONE, bool = false);
	PrzyciskPlik(const std::string&, int, int, int, int, ControlType = CONTROL_NONE, bool = false);
	PrzyciskPlik(PrzyciskPlik&);
	PrzyciskPlik(PrzyciskPlik&&) noexcept;
	~PrzyciskPlik();

	void akcja();
	const char* pobierzSciezkePliku();
};

