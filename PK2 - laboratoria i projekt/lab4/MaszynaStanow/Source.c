#include <stdio.h>
#include <conio.h>

enum stany { wyb, odt, kon };
enum zdarzenia { roz, zat, zak };

int wybor(int a)
{
	printf("Wybor:\n1.pop\n2.rock\n3.blues\n4.disco\n5.jazz\n");
	int wybor;
	scanf("%d", &wybor);
	return wybor;
}

int odtwarzanie(int a)
{
	switch (a)	
	{
	case 1: printf("Leci pop.\n");
		break;
	case 2: printf("Leci rock.\n");
		break;
	case 3: printf("Leci blues.\n");
		break;
	case 4: printf("Leci disco.\n");
		break;
	case 5: printf("Leci jazz.\n");
		break;
	}
	return a;
}

void puste() {}

void rozp()
{
	printf("\nRozpoczeto odtwarzanie.\n");
}

void zatrz()
{
	printf("\nZatrzymano odtwarzanie.\n");
}


int main()
{
	enum stany przejscia[3][3] = { odt, wyb, kon, odt, wyb, kon, kon, kon, kon };
	void (*zmiany[3][3])() = {puste, rozp, puste, zatrz, puste, puste, puste, puste, puste};
	enum stany sa = wyb;
	enum stany sn;
	enum zdarzenia zd;
	char z;
	int a = 0;
	int zmiana = 1;
	int (*akcje[2])() = {wybor, odtwarzanie};
	while (sa != kon)
	{
		if (zmiana == 1)
			a = akcje[sa](a);

		z = _getch();
		switch (z)
		{
		case 27:
			zd = zak;
			break;
		case 112:
			zd = roz;
			break;
		case 115:
			zd = zat;
			break;
		}
		sn = przejscia[sa][zd];
		zmiany[sa][sn]();
		if (sa != sn) {
			zmiana = 1;
			sa = sn;
		}
		else
			zmiana = 0;
	}
	return 0;
}