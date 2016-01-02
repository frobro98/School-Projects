

#include "CameraController.h"
#include "Camera.h"
#include "CameraSettings.h"
#include "CameraMan.h"

void CameraController::initialize()
{
	CameraSettings* cSettings = new CameraSettings();
	instance().currCam = cSettings;
	CameraMan::SetCamera(cSettings->getCamera());

	instance().camList.push_front(cSettings);
}

void CameraController::addCamera(Camera* const cam)
{
	CameraSettings* cSettings = new CameraSettings(cam);

	instance().camList.push_front(cSettings);
}

void CameraController::updateCurrentCamera()
{
	instance().currCam->update();
}

CameraController& CameraController::instance()
{
	static CameraController ccInstance;

	return ccInstance;
}