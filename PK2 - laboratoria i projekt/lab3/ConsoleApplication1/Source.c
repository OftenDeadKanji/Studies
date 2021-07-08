#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void copy(char* tab, int rozmiar, FILE* wyj) 
{
	fwrite(tab, sizeof(char), rozmiar, wyj);
}

void replace(char* tab, int rozmiar, FILE* wyj)
{
	for (int i = 0;i < rozmiar;i++) {
		if (islower(tab[i]))
			tab[i] = toupper(tab[i]);
		else if (isupper(tab[i]))
			tab[i] = tolower(tab[i]);
	}
	copy(tab, rozmiar, wyj);
}

void palindrom(char* tab, int rozmiar, FILE* wyj)
{
	char sep[5] = { 32, 9, 13, 10, 0};
	char* wyraz;
	char* wyraz2 = malloc(rozmiar + 1);

	wyraz = strtok(tab, sep);
	while (wyraz != NULL) {
		strncpy(wyraz2, wyraz, 30);
		_strrev(wyraz);
		if (wyraz != NULL && !strcmp(wyraz, wyraz2))
			fprintf(wyj, "%s%c", wyraz2, 32);
		wyraz = strtok(NULL, sep);
	}
	free(wyraz2);
}

int main(int argc, char** argv)
{
	if (argc != 4) {
		printf("Za malo parametrow.");
		return 0;
	}
	if (strcmp(argv[3], "-copy") && strcmp(argv[3], "-replace") && strcmp(argv[3], "-palindrom")) {
		printf("Bledny tryb przetwarzania.");
		return 0;
	}

	FILE* wej = fopen(argv[1], "rb");
	FILE* wyj = fopen(argv[2], "wb");

	fseek(wej, 0, SEEK_END);
	int rozmiar = ftell(wej);
	fseek(wej, 0, SEEK_SET);

	char* tab = malloc(rozmiar + 1);
	fread(tab, sizeof(char), rozmiar, wej);
	tab[rozmiar] = 0;
	
	if (!strcmp(argv[3], "-copy"))
		copy(tab, rozmiar, wyj);
	else if (!strcmp(argv[3], "-replace"))
		replace(tab, rozmiar, wyj);
	else if (!strcmp(argv[3], "-palindrom"))
		palindrom(tab, rozmiar, wyj);

	free(tab);
	fclose(wej);
	fclose(wyj);

	return 0;
}