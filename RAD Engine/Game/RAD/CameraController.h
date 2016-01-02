
#ifndef CAMERACONTROLLER_H
#define COMERACONTROLLER_H

#include <list>

class Camera;
class CameraSettings;

class CameraController
{
public:
	static void initialize();

	static void addCamera(Camera* const cam);
	static CameraSettings* getCurrentCam() { return instance().currCam; }

	static void updateCurrentCamera();

private:
	static CameraController& instance();

	CameraSettings* currCam;
	std::list<CameraSettings *> camList;

};

#endif // CAMERACONTROLLER_H