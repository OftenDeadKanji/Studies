#include "pch.h"
#include "seidelC.h"
#include <cmath>

void SeidelC(float** A, float* B, float** alfa, float* beta, int variablesNumber, float* xOld, float* xNew, int lowerBound, int upperBound, float* condition, bool** isReady, float precision, int maxIterations)
{
	float divisor;
	float conditionSum = 0;
	int counter = 0;
	bool boolCondition = false;

	for (int i = lowerBound; i < upperBound; i++) {
		divisor = A[i][i];
		for (int j = 0; j < variablesNumber; j++)
			alfa[i][j] = -A[i][j] / divisor;

		beta[i] = B[i] / divisor;
		xNew[i] = beta[i];
		alfa[i][i] = 0;
		
		isReady[0][i] = true;
	}

	while (!boolCondition) {
		boolCondition = true;
		for (int i = 0; i < variablesNumber; i++)
			if (!isReady[0][i])
				boolCondition = false;
	}
	boolCondition = false;

	do {
		counter++;

		for (int i = lowerBound; i < upperBound; i++) {
			isReady[1][i] = false;
			isReady[2][i] = false;

			xOld[i] = xNew[i];

			isReady[1][i] = true;
		}

		while (!boolCondition) {
			boolCondition = true;
			for (int i = 0; i < variablesNumber; i++) {
				if (!isReady[1][i]) {
					boolCondition = false;
				}
			}
		}
		boolCondition = false;

		for (int i = lowerBound; i < upperBound; i++)
		{
			isReady[2][i] = false;
			isReady[3][i] = false;

			xNew[i] = beta[i];

			for (int j = i + 1; j < variablesNumber; j++)
				xNew[i] += alfa[i][j] * xOld[j];

			for (int j = 0; j < i; j++) {
				while (!isReady[2][j])
					;
				xNew[i] += alfa[i][j] * xNew[j];
			}
			isReady[2][i] = true;
		}

		while (!boolCondition) {
			boolCondition = true;
			for (int i = 0; i < variablesNumber; i++) {
				if (!isReady[2][i]) {
					boolCondition = false;
				}
			}
		}
		boolCondition = false;

		for (int i = lowerBound; i < upperBound; i++) {
			isReady[1][i] = false;
			isReady[3][i] = false;

			condition[i] = 0;
			condition[i] += abs(xNew[i] - xOld[i]);
			condition[i] /= variablesNumber;

			isReady[3][i] = true;
		}

		while (!boolCondition) {
			boolCondition = true;
			for (int i = 0; i < variablesNumber; i++) {
				if (!isReady[3][i])
					boolCondition = false;
			}
		}
		boolCondition = false;

		conditionSum = 0;
		for (int i = 0; i < variablesNumber; i++)
			conditionSum += condition[i];

	} while ((conditionSum > precision) && (counter < maxIterations));

}