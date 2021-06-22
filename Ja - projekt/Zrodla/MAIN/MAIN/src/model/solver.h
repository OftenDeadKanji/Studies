#pragma once

class Solver {
	//v-----------------------dane zwi¹zane z DLL -----------------------v
	/*
		dane
		wejœciowe
	*/
	//liczba niewiadomych
	int numberOfVariables;
	//wspó³czynniki niewiadomych
	float** A;
	//wyrazy wolne
	float* B;
	//maksymalna liczba iteracji
	const int maxIterations;
	//dok³adnoœæ
	const float precision;
	/*
		dane
		poœrednie
	*/
	float** alfa;
	float* beta;
	/*
		dane
		wyjœciowe
	*/
	float* xOld;
	float* xNew;
	//^-----------------------dane zwi¹zane z DLL -----------------------^

	int threadsNumber;
	std::thread* threads;
	DllChoice dllChoice;
	
public:
	Solver(float** A, float* B, int variablesNumber, int threadsNumber, DllChoice dllChoice);

	void setThreadsNumber(int);
	void setDllChoice(DllChoice);

	float* calculate();
};