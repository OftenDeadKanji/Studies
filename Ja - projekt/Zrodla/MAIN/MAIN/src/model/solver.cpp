#include "../pch.h"

Solver::Solver(float** A, float* B, int variablesNumber, int threadsNumber, DllChoice dllChoice) : A(A), B(B), numberOfVariables(variablesNumber), threadsNumber(threadsNumber), dllChoice(dllChoice), maxIterations(1000), precision(0.0001)
{}

void Solver::setThreadsNumber(int threadsNumber)
{
	this->threadsNumber = threadsNumber;
}

void Solver::setDllChoice(DllChoice dllChoice)
{
	this->dllChoice = dllChoice;
}

float* Solver::calculate()
{
	alfa = new float* [numberOfVariables] {0};
	for (int i = 0; i < numberOfVariables; i++) {
		alfa[i] = new float[numberOfVariables] {0};
	}
	beta = new float[numberOfVariables] {0};
	xOld = new float[numberOfVariables] {0};
	xNew = new float[numberOfVariables] {0};

	int range = numberOfVariables / threadsNumber;
	int residual = numberOfVariables - threadsNumber * range;

	int* rangeTab = new int[threadsNumber + 1];

	rangeTab[0] = 0;
	for (int i = 1; i < threadsNumber + 1; i++) {
		rangeTab[i] = rangeTab[i - 1] + range;
		if (residual-- > 0)
			rangeTab[i]++;
	}

	bool** isReady = new bool* [4];
	for (int i = 0; i < 4; i++)
		isReady[i] = new bool[numberOfVariables];

	float* warunekTab = new float[numberOfVariables];
	float* condition = new float[numberOfVariables];

	for (int i = 0; i < numberOfVariables; i++) {
		condition[i] = 0;
		warunekTab[i] = 0;
		isReady[0][i] = false;
		isReady[1][i] = false;
		isReady[2][i] = false;
		isReady[3][i] = false;
	}

	threads = new std::thread[threadsNumber];
	
	if (dllChoice == DLL_C) 
		for (int i = 0; i < threadsNumber; i++)
			threads[i] = std::thread(SeidelC, A, B, alfa, beta, numberOfVariables, xOld, xNew, rangeTab[i], rangeTab[i + 1], condition, isReady, precision, maxIterations);
	
	else //if(dllChoice == DLL_ASM)
		for (int i = 0; i < threadsNumber; i++)
			threads[i] = std::thread(SeidelAsm, A, B, alfa, beta, numberOfVariables, xOld, xNew, rangeTab[i], rangeTab[i + 1], condition, isReady, precision, maxIterations, threadsNumber);

	for (int i = 0; i < threadsNumber; i++)
		threads[i].join();

	

	delete[] isReady[0];
	delete[] isReady[1];
	delete[] isReady[2];
	delete[] isReady[3];
	delete[] isReady;
	delete[] threads;
	delete[] rangeTab;
	delete[] warunekTab;
	delete[] condition;
	
	for (int i = 0; i < numberOfVariables; i++) {
		delete[] alfa[i];
	}
	delete[] alfa;
	delete[] beta;
	delete[] xOld;

	return xNew;
}