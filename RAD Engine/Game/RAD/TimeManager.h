
#ifndef TIMEMANAGER_H
#define TIMEMANAGER_H

#include "StopWatch.h"
#include "Inputable.h"

class TimeManager
{
public:
	static const float getTotalTime();
	static const float getFrameTime();

	static void update();

private:
	TimeManager();
	~TimeManager(){};

	StopWatch totalTime;
	StopWatch frameTime;
	float frameTimeSum;

	void freezeFrameProcessing();
	void waitForRelease(Inputs i);

	static const Inputs FREEZE_KEY = Inputs::NUM_1;
	static const Inputs SINGLE_FRAME_KEY = Inputs::NUM_2;

	static TimeManager& instance();
};

#endif // TIMEMANAGER_H