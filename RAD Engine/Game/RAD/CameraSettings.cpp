
#include "CameraSettings.h"
#include "DefaultBehavior.h"
#include "Game.h"
#include "Tools.h"

CameraSettings::CameraSettings()
{
	this->setDefault();
}

CameraSettings::~CameraSettings()
{
	delete behavior;
}

CameraSettings::CameraSettings(Camera* const cam)
{
	this->setDefault(cam);
}

CameraSettings::CameraSettings(CamTypes type, float x, float y, float z)
{
	UNUSED_VARS(x, y, z);

	switch(type)
	{
	case FIXED_POS:
		setDefault();
		break;
	default:
		break;
	}
}

void CameraSettings::setDefault()
{
	type = FIXED_POS;
	Camera* cam =  new Camera();

	Vect pos(35.f, 160.f, 120.f);//(0.f, 100.f, 100.f);
	Vect up(0.f, 1.f, 0.f);
	Vect lookAt(0.f, 0.f, 0.f);

	cam->setViewport(0, 0, Game::ScreenWidth(), Game::ScreenHeight());
	cam->setPerspective(45, float(Game::ScreenWidth())/float(Game::ScreenHeight()), 1, 5000);
	cam->setOrientAndPosition(up, lookAt, pos);

	cam->updateCamera();

	behavior = new DefaultBehavior(cam);
}

void CameraSettings::setDefault(Camera* const cam)
{
	type = FIXED_POS;
	behavior = new DefaultBehavior(cam);
}

void CameraSettings::update()
{
	behavior->update();
}