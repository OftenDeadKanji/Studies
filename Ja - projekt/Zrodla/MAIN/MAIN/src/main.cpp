#include "pch.h"

int main() 
{
	/*
	//Testowanie ASM
	int n = 4;
	float precision = 0.0001;
	int maxIterations = 1000;

	float** A = new float* [n];
	float** alfa = new float* [n];
	for (int i = 0; i < n; i++) {
		A[i] = new float[n] {0};
		alfa[i] = new float[n] {0};
	}

	float* B = new float[n] {0};
	float* beta = new float[n] {0};
	float* xOld = new float[n] {0};
	float* xNew = new float[n] {0};
	int lowerBound = 0;
	int upperBound = n;
	float* condition = new float[n] {0};
	bool** isReady = new bool*[n];
	for (int i = 0; i < n; i++)
		isReady[i] = new bool[n] {false};
	
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++)
			A[i][j] = i + j + 3;
		B[i] = i * 0.5;
	}
	
	float a = 1.1;
	float b = 2.2;
	float c;
	c = a - b;
	if (c < 0)
		c = -c;

	SeidelAsm(A, B, alfa, beta, n, xOld, xNew, lowerBound, upperBound, condition, isReady, precision, maxIterations);
	*/
	
#pragma region Inicjalizacja Allegro
	try {
		if (!al_init())
			throw InitFailException("Allegro");
		if (!al_init_font_addon())
			throw InitFailException("Font addon");
		if (!al_init_ttf_addon())
			throw InitFailException("ttf addon");
		if (!al_init_primitives_addon())
			throw InitFailException("Primitives addon");
		if (!al_init_native_dialog_addon())
			throw InitFailException("Native dialog addon");
		if (!al_install_mouse())
			throw InitFailException("Mysz");
	}
	catch (InitFailException exception) {
		exception.writeToFile();
	}
#pragma endregion

	Controller controller;
	controller.run();
	
	return 0;
}