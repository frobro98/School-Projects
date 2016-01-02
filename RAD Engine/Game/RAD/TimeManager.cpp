
#include "TimeManager.h"
#include "InputManager.h"

TimeManager::TimeManager()
{
	StopWatch::initStopWatch();
}

TimeManager& TimeManager::instance()
{
	static TimeManager tMan;

	return tMan;
}

const float TimeManager::getTotalTime()
{
	return instance().totalTime.timeInSeconds();
}

const float TimeManager::getFrameTime()
{
	return 1/instance().frameTime.timeInSeconds();
}

void TimeManager::update()
{
	instance().frameTime.toc();
	instance().totalTime.toc();

	instance().frameTimeSum += instance().frameTime.timeInSeconds();
	instance().freezeFrameProcessing();

	instance().frameTime.tic();
	
}

void TimeManager::freezeFrameProcessing()
{
	static bool freezeModeActive = false;

	if(InputManager::getKeyState(FREEZE_KEY) || freezeModeActive)
	{
		waitForRelease(FREEZE_KEY);

		freezeModeActive = true;
		bool singleFrame = false;

		while(freezeModeActive && !singleFrame)
		{
			if(InputManager::getKeyState(FREEZE_KEY))
			{
				waitForRelease(FREEZE_KEY);
				freezeModeActive = false;
				singleFrame = false;
			}

			else if(InputManager::getKeyState(SINGLE_FRAME_KEY))
			{
				waitForRelease(SINGLE_FRAME_KEY);
				singleFrame = true;
			}

			glfwPollEvents();
		}
	}
}

void TimeManager::waitForRelease(Inputs i)
{
	while(InputManager::getKeyState(i))
		glfwPollEvents();
}
