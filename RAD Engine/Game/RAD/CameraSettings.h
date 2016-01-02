
#ifndef CAMERASETTINGS_H
#define CAMERASETTINGS_H

#include "CameraBehavior.h"

class CameraBehavior;

enum CamTypes
{
	NO_BEHAVIOR,
	THIRD_PERSON,
	FIRST_PERSON,
	FIXED_POS = 0xA0000000
};

class CameraSettings
{
public:
	CameraSettings();
	CameraSettings(CamTypes type, float x = 0.0f, float y = 0.0f, float z = 0.0f);
	CameraSettings(Camera* const cam);
	~CameraSettings();

	void setDefault();
	void setDefault(Camera* const cam);

	void setCameraBehavior(CamTypes type, const GameObject* const go);
	
	void hookCameraToInput(/*Possible parameters for input*/);

	Camera* const getCamera() const { return behavior->getCamera(); }

	void update();

	// Think of more behaviors

private:
	CamTypes type;
	CameraBehavior* behavior;

};

#endif // CAMERASETTINGS_H