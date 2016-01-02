/*
 *  STOPWATCH.h
 */

#ifndef STOP_WATCH_H
#define STOP_WATCH_H

#include <windows.h>

class StopWatch
{
public:
	static void initStopWatch();

	StopWatch()
	{
		this->reset();
	}

	void tic();
	void toc();
	void reset();
	float timeInSeconds();

private:	
	LARGE_INTEGER getStopWatch();

	static float SecondsPerCycle;
	LARGE_INTEGER ticTime;
	LARGE_INTEGER tocTime;
	LARGE_INTEGER deltaTime;
	float		  timeSeconds;

};

#endif 