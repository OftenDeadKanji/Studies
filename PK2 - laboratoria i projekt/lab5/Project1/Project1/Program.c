#include "Program.h"
#include "ModulA.h"
#include "ModulB.h"
#include "ModulC.h"
#include "ModulD.h"
#include "BibliotekaX.h"
#include <stdio.h>

void Program_toString(int n) {
	for (int i = 0;i < n;i++)
		printf("\t");
	printf("Program\n");
	BibliotekaX_toString(n + 1);
	ModulA_toString(n + 1);
	ModulB_toString(n + 1);
	ModulC_toString(n + 1);
	ModulD_toString(n + 1);
}

int main()
{
	Program_toString(0);
	return 0;
}