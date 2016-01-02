#ifndef CAMERA_MAN_H
#define CAMERA_MAN_H

#include "Camera.h"

class CameraMan
{
public:
	static Camera *GetCurrent();
	static void SetCamera(Camera* const cam);
	~CameraMan();

private:
	static CameraMan *privInstance();
	CameraMan();
	

	// Data
	Camera *pCam;
};

#endif