#include "PodmodulA1.h"
#include "BibliotekaX.h"
#include <stdio.h>

void PodmodulA1_toString(int n) {
	for (int i = 0;i < n;i++)
		printf("\t");
	printf("PodmodulA1\n");
	BibliotekaX_toString(n + 1);
}