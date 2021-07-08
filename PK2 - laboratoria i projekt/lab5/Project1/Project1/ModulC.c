#include "ModulC.h"
#include "PodmodulC1.h"
#include <stdio.h>

void ModulC_toString(int n) {
	for (int i = 0;i < n;i++)
		printf("\t");
	printf("ModulC\n");
	PodmodulC1_toString(n + 1);
}