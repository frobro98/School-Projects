
#ifndef ALARMABLE_H
#define ALARMABLE_H


enum ALARM_ID
{
	ALARM_0 = 0,
	ALARM_1 = 1,
	ALARM_2 = 2,
	ALARM_3 = 3,
	ALARM_4 = 4 
};


class Alarmable
{
public:

	/**
	 \brief Callback for Alarm0
	 */
	virtual void Alarm0(){};

	/**
	 \brief Callback for Alarm1
	 */
	virtual void Alarm1(){};

	/**
	 \brief Callback for Alarm2
	 */
	virtual void Alarm2(){};

	/**
	 \brief Callback for Alarm3
	 */
	virtual void Alarm3(){};

	/**
	 \brief Callback for Alarm4
	 */
	virtual void Alarm4(){};

	void activateAlarm(const ALARM_ID &alarm)
	{
		switch(alarm)
		{
		case ALARM_0:
			Alarm0();
			break;
		case ALARM_1:
			Alarm1();
			break;
		case ALARM_2:
			Alarm2();
			break;
		case ALARM_3:
			Alarm3();
			break;
		case ALARM_4:
			Alarm4();
			break;
		default:
			break;
		}
	}

protected:
	Alarmable(){};
	virtual ~Alarmable()
	{
		for(int i = 0; i < NUM_ALARMS; i++)
		{
			times[i] = 0.0f;
		}
	};

	static const int NUM_ALARMS = 5;
	float times[NUM_ALARMS];

	friend class AlarmManager;
};

#endif // ALARMABLE_H