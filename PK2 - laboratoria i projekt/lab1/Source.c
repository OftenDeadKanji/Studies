#include <stdio.h>
#include <stdlib.h>
#define N 5
void f(float *T, const int n) {
	for (int i = 0;i < n;i++) {
		scanf("%f", &T[i]);
	}
}

void druk(const float *P, int n) {
	float *w = P;
	for (int i = 0;i < n;i++, w++) {
		printf("%f", *w);
		printf("\n");
	}

}

void ind(const float *P, int n, int *min, int *max) {
	float *w = P;
	for (int i = 0;i < n;i++, w++) {
		if (*w > P[*max])
			*max = i;
		if (*w < P[*min])
			*min = i;
	}
}

int main()
{
	float t[N];
	f(t, N);
	druk(t, N);
	printf("\n");
	int min = 0;
	int max = 0;
	ind(t, N, &min, &max);
	printf("%d\n%f\n%d\n%f", min, t[min], max, t[max]);


	return 0;
}