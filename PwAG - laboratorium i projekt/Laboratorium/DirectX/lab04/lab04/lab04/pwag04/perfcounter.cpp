#include "common.h"
#include "PerfCounter.h"

PerfCounter::PerfCounter() : _PCFreq(0), _CounterStart(0)
{}

PerfCounter::~PerfCounter()
{}

bool PerfCounter::start()
{
    LARGE_INTEGER li;
    if(!QueryPerformanceFrequency(&li))
        return false;

    _PCFreq = double(li.QuadPart)/1000.0;

    QueryPerformanceCounter(&li);
    _CounterStart = li.QuadPart;

	return true;
}
double PerfCounter::stop()
{
    LARGE_INTEGER li;
    QueryPerformanceCounter(&li);
    return double(li.QuadPart - _CounterStart)/_PCFreq;
}
