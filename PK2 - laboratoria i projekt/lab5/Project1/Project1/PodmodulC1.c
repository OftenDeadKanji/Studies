#include "BibliotekaY.h"
#include "PodmodulC1.h"
#include <stdio.h>

void PodmodulC1_toString(int n) {
	for (int i = 0;i < n;i++)
		printf("\t");
	printf("PodmodulC1\n");
	BibliotekaY_toString(n + 1);
}