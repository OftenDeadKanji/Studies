#pragma once

class Solver {
	//v-----------------------dane zwi�zane z DLL -----------------------v
	/*
		dane
		wej�ciowe
	*/
	//liczba niewiadomych
	int numberOfVariables;
	//wsp�czynniki niewiadomych
	float** A;
	//wyrazy wolne
	float* B;
	//maksymalna liczba iteracji
	const int maxIterations;
	//dok�adno��
	const float precision;
	/*
		dane
		po�rednie
	*/
	float** alfa;
	float* beta;
	/*
		dane
		wyj�ciowe
	*/
	float* xOld;
	float* xNew;
	//^-----------------------dane zwi�zane z DLL -----------------------^

	int threadsNumber;
	std::thread* threads;
	DllChoice dllChoice;
	
public:
	Solver(float** A, float* B, int variablesNumber, int threadsNumber, DllChoice dllChoice);

	void setThreadsNumber(int);
	void setDllChoice(DllChoice);

	float* calculate();
};