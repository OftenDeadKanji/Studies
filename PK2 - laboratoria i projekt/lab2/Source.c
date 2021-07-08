#include <stdio.h>
#include <stdlib.h>
#include <string.h>

struct Student {
	char* nazwisko;
	struct Student* nast;
};

void alokuj(void **buf, int rozmiar) {
	*buf = malloc(rozmiar);
}

void dealokuj(void **buf) {
	free(*buf);
	*buf = NULL;
}

void dodaj(struct Student** glowa, char* naz) {
	struct Student* nowy = malloc(sizeof(struct Student));
	nowy->nazwisko = _strdup(naz);
	nowy->nast = *glowa;
	*glowa = nowy;
}

void druk_usun(struct Student** glowa) {
	struct Student* chwil = *glowa;
	struct Student* chwil2 = *glowa;
	*glowa = NULL;
	while (chwil != NULL) {
		printf("%s\n", chwil->nazwisko);
		chwil = chwil->nast;
		free(chwil2->nazwisko);
		free(chwil2);
		chwil2 = chwil;
	}
}
float op(float a, float b)
{
	return a + b;
}

void transform(const float* A, const float* B, float* C, int n, float(*op)(float, float))
{
	for (int i = 0;i < n;i++)
		C[i] = op(A[i], B[i]);
}

int main()
{
	char* string = NULL;
	alokuj(&string, 40);
	scanf("%s", string);
	dealokuj(&string);

	struct Student* glowa = NULL;

	dodaj(&glowa, "Kowalski");
	dodaj(&glowa, "Nowak");

	druk_usun(&glowa);
	float A[5];
	float B[5];
	float C[5];
	for (int i = 0;i < 5;i++)
	{
		A[i] = i;
		B[i] = i;
	}

	transform(A, B, C, 5, op);

	int l;
	scanf("%d", &l);
	return 0;
}