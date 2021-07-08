#include "BibliotekaY.h"
#include "BibliotekaX.h"
#include <stdio.h>

void BibliotekaY_toString(int n) {
	for (int i = 0;i < n;i++)
		printf("\t");
	printf("BibliotekaY\n");
	BibliotekaX_toString(n + 1);
}