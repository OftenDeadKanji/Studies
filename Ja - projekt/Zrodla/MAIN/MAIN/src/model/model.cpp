#include "../pch.h"

Model::Model() : A(nullptr)
{
	threadsNumber = System::getInstance().getThreadsNumber();
}

Model::~Model()
{
	if (A != nullptr) {
		for (int i = 0; i < numberOfVariables; i++) {
			delete[] A[i];
		}
		delete[] A;
		delete[] B;
	}
}

double Model::getTime()
{
	return time;
}

void Model::setPath(const std::string& path)
{
	this->filePath = path;
}

void Model::setThreadsNumber(int number)
{
	this->threadsNumber = number;
}

void Model::setDllChoice(DllChoice choice)
{
	this->dllChoice = choice;
}

bool Model::checkFile()
{
	if (filePath.size() == 0)
		return false;
	else {
		//otwieranie pliku
		std::ifstream inFile;
		inFile.open(filePath, std::ios::in);

		if (!inFile.is_open())
			return false;

		//pierwszy wiersz
		numberOfVariables = 0;
		int numberOfVariablesNext = 0;
		int i = 0;
		while (i != 500) {
			inFile >> i;
			numberOfVariables++;
		}
		if (numberOfVariables < 3) //3 to minimum dla jednego równania
			return false;

		while (inFile.eof()) {
			while (i != 500) {
				inFile >> i;
				numberOfVariablesNext++;
			}
			if (numberOfVariablesNext != numberOfVariables)
				return false;
		}
		numberOfVariables -= 2;
		inFile.close();
	}

	return true;
}

void Model::loadEquations()
{
	if (A != nullptr) {
		for (int i = 0; i < numberOfVariables; i++) {
			delete[] A[i];
		}
		delete[] A;
		delete[] B;
	}

	checkFile();

	//tworzenie tablic
	A = new float* [numberOfVariables];
	for (int i = 0; i < numberOfVariables; i++) {
		A[i] = new float[numberOfVariables] {0};
	}
	B = new float[numberOfVariables] {0};

	//wczytywanie danych
	std::ifstream inFile;
	inFile.open(filePath, std::ios::in);

	int warden = 0;
	for (int i = 0; i < numberOfVariables; i++) {
		for (int j = 0; j < numberOfVariables; j++) {
			inFile >> A[i][j];
		}
		inFile >> B[i];
		inFile >> warden;
	}
	inFile.close();
}

void Model::calculate()
{
	double beginTime, endTime;
	time = 0.0f;
	//for (int i = 0; i < 66; i++) {
		beginTime = (double)clock() / (double)CLOCKS_PER_SEC;

		solver = new Solver(A, B, numberOfVariables, threadsNumber, dllChoice);
		X = solver->calculate();

		endTime = (double)clock() / (double)CLOCKS_PER_SEC;
		time += endTime - beginTime;

		writeToFile();

		delete solver;
	//}
	//time /= 66.0;
}

void Model::writeToFile()
{
	std::ofstream outFile;
	outFile.open("result.txt", std::ios::out | std::ios::trunc);

	for (int i = 0; i < numberOfVariables; i++)
		outFile << std::setprecision(3) << X[i] << std::endl;
}