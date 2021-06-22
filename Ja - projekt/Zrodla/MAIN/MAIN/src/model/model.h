#pragma once

class Model {
private:
	std::string filePath;
	//wspó³czynniki niewiadomych
	float** A;
	//wyrazy wolne
	float* B;
	//wyliczone X
	float* X;

	Solver* solver;

	//liczba niewiadomych
	int numberOfVariables;
	//liczba watkow
	int threadsNumber;
	//wybor dll
	DllChoice dllChoice;
	double time;
public:
	Model();
	~Model();

	//get
	double getTime();

	//set
	void setPath(const std::string&);
	void setThreadsNumber(int);
	void setDllChoice(DllChoice);
	//inne
	bool checkFile();
	void loadEquations();
	void calculate();
	void writeToFile();
};