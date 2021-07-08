#include "ModulD.h"
#include "BibliotekaY.h"
#include <stdio.h>

void ModulD_toString(int n) {
	for (int i = 0;i < n;i++)
		printf("\t");
	printf("ModulD\n");
	BibliotekaY_toString(n + 1);
}