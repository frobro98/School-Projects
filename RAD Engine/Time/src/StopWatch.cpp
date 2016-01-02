/*
 *  Timer.cpp
*/

#include <windows.h>
#include <assert.h>

#include "StopWatch.h"

float StopWatch::SecondsPerCycle = 0.0f;

void StopWatch::initStopWatch() 
{
	LARGE_INTEGER Frequency;
	QueryPerformanceFrequency(&Frequency);
	SecondsPerCycle = 1.0f / Frequency.QuadPart;
}

LARGE_INTEGER StopWatch::getStopWatch()
{
	LARGE_INTEGER time;
	QueryPerformanceCounter(&time);
	return time;
}

void StopWatch::tic()
{
	ticTime = this->getStopWatch();
}

void StopWatch::toc()
{
	tocTime = this->getStopWatch();
	assert( tocTime.QuadPart >= ticTime.QuadPart );
	deltaTime.QuadPart = tocTime.QuadPart - ticTime.QuadPart;
}

void StopWatch::reset()
{
	LARGE_INTEGER tmpTime = this->getStopWatch();
	ticTime.QuadPart = tmpTime.QuadPart;
	tocTime.QuadPart =  tmpTime.QuadPart;
	deltaTime.QuadPart = 0;
}

float StopWatch::timeInSeconds()
{
	float floatTime;
	floatTime = static_cast<float>(deltaTime.QuadPart);
	floatTime *= SecondsPerCycle;
	return floatTime;
}