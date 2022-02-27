#ifndef PERF_COUNTER_H
#define PERF_COUNTER_H

class PerfCounter
{
public:
	PerfCounter();
	virtual ~PerfCounter();

	bool start();
	double stop();


private:
	double _PCFreq;
	__int64 _CounterStart;

};

#endif