
#include "AlarmManager.h"
#include "Alarmable.h"
#include "TimeManager.h"

AlarmManager* AlarmManager::amInstance = 0;

AlarmManager& AlarmManager::instance()
{
	if(amInstance == 0)
	{
		amInstance = new AlarmManager();
	}

	return *amInstance;
}

AlarmManager::~AlarmManager()
{
	while(!aList.empty())
	{
		float time = aList.begin()->first;
		Alarm* alarm = aList.begin()->second;
		delete alarm;
		aList.erase(time);
	}
}

void AlarmManager::registerAlarm(Alarmable* const alarm, const ALARM_ID& id, const float &time)
{
	Alarm* marker = new Alarm(alarm, id);
	float newTime = TimeManager::getTotalTime() + time;
	instance().aList.insert(std::pair<float, Alarm*>(newTime, marker));

	alarm->times[id] = newTime;
}

void AlarmManager::changeAlarmTime(Alarmable* const alarm, const float &newTime, const ALARM_ID &id)
{
	float oldTime = alarm->times[id];


	AlarmList::iterator it = instance().aList.find(oldTime);
	while(it->second->ao != alarm)
	{
		it++;
	}

	if(it->second->ao == alarm)
	{
		Alarm* al = it->second;
		instance().aList.erase(it);
		al->ao = alarm;
		al->id = id;

		float officialTime = newTime + TimeManager::getTotalTime();

		instance().aList.insert(std::pair<float, Alarm*>(officialTime, al));
	}

}

void AlarmManager::deregisterAlarm(const Alarmable* const alarm, const ALARM_ID& id, const float& time)
{
	AlarmList::const_iterator it = instance().aList.find(time);
	while(it->first == time)
	{
		if(it->second->ao == alarm && it->second->id == id)
		{
			instance().aList.erase(it);
			break;
		}
		++it;
	}

}

void AlarmManager::update()
{
	while(!instance().aList.empty() && instance().aList.begin()->first <= TimeManager::getTotalTime())
	{
		ALARM_ID id = instance().aList.begin()->second->id;
		Alarmable* toRemove = instance().aList.begin()->second->ao;
		toRemove->activateAlarm(id);
		deregisterAlarm(toRemove, id, instance().aList.begin()->first);
	}

}