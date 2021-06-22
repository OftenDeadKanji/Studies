#include "../pch.h"

#pragma region Konstruktory i destruktor
PrzyciskPlik::PrzyciskPlik(const std::string& tekst, int x, int y, ControlType type, bool czyRamka) : Button(tekst, x, y, type, czyRamka)
{
	plik = al_create_native_file_dialog(NULL, "Plik wejsciowy", "*.txt", ALLEGRO_FILECHOOSER_FILE_MUST_EXIST);
}

PrzyciskPlik::PrzyciskPlik(const std::string& tekst, int x, int y, int szer, int wys, ControlType type, bool czyRamka) : Button(tekst, x, y, szer, wys, type, czyRamka)
{
	plik = al_create_native_file_dialog(NULL, "Plik wejsciowy", "*.txt", ALLEGRO_FILECHOOSER_FILE_MUST_EXIST);
}

PrzyciskPlik::PrzyciskPlik(PrzyciskPlik& przycisk) : Button(przycisk)
{
	plik = al_create_native_file_dialog(NULL, "Plik wejsciowy", "*.txt", ALLEGRO_FILECHOOSER_FILE_MUST_EXIST);
}

PrzyciskPlik::PrzyciskPlik(PrzyciskPlik&& przycisk) noexcept : Button(przycisk)
{
	plik = przycisk.plik;
}

PrzyciskPlik::~PrzyciskPlik()
{
	if (plik != NULL)
		al_destroy_native_file_dialog(plik);
}
#pragma endregion

void PrzyciskPlik::akcja()
{
	al_show_native_file_dialog(NULL, plik);
}

const char* PrzyciskPlik::pobierzSciezkePliku()
{
	return al_get_native_file_dialog_path(plik, 0);
}
