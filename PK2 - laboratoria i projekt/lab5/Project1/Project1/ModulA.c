#include "ModulA.h"
#include "PodmodulA1.h"
#include "PodmodulA2.h"
#include "BibliotekaX.h"
#include <stdio.h>

void ModulA_toString(int n) {
	for (int i = 0;i < n;i++)
		printf("\t");
	printf("ModulA\n");
	BibliotekaX_toString(n + 1);
	PodmodulA1_toString(n + 1);
	PodmodulA2_toString(n + 1);

}