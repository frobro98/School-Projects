#include "CameraMan.h"



Camera * CameraMan::GetCurrent()
{
	return CameraMan::privInstance()->pCam;
}

void CameraMan::SetCamera(Camera* const cam)
{
	privInstance()->pCam = cam;
}

CameraMan *CameraMan::privInstance()
{
	static CameraMan camMan;
	return &camMan;
}

CameraMan::CameraMan()
{
	this->pCam = new Camera();
}

CameraMan::~CameraMan()
{
	delete this->pCam;
}