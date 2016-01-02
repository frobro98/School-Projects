
#ifndef ALARMMANAGER_H
#define ALARMMANAGER_H

#include <map>

class Alarmable;
enum ALARM_ID;

class AlarmManager
{
public:

	/**
	 \brief Registers an alarm for Alarmable objects. 
	
	 \param alarm				An Alarmable object pointer.
	 \param	id				 	The identifier.
	 \param	time			 	The time til activation.
	
	 \return	A float.
	 */
	static void registerAlarm(Alarmable* const alarm, const ALARM_ID& id, const float &time);

	static void changeAlarmTime(Alarmable* const alarm, const float &newTime, const ALARM_ID& id);

	/**
	 \brief Deregisters an alarm for Alarmable objects.
	
	 \param	alarm	The alarm.
	 \param	id   	The identifier.
	 \param	time 	The time.
	 */
	static void deregisterAlarm(const Alarmable* const alarm, const ALARM_ID& id, const float &time);

	static void update();

private:
	AlarmManager(){};
	~AlarmManager();

	struct Alarm
	{
		Alarm(Alarmable* const alarmObj, const ALARM_ID& id)
		{
			ao = alarmObj;
			this->id = id;
		}

		Alarmable* ao;
		ALARM_ID id;
	};

	typedef std::multimap<float, Alarm*> AlarmList;

	static AlarmManager* amInstance;
	static AlarmManager& instance();

	AlarmList aList;

	friend class Scene;

};

#endif // ALARMMANAGER_H