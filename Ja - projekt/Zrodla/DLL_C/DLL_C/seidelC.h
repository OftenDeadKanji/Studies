#pragma once

#ifdef SEIDEL_EXPORTS
#define SEIDEL_API __declspec(dllexport)
#else
#define SEIDEL_API __declspec(dllimport)
#endif

extern "C" SEIDEL_API void SeidelC(float** A, float* B, float** alfa, float* beta, int n, float* xOld, float* xNew, int lowerBound, int upperBound, float* condition, bool** isReady, float precision, int maxIterations);