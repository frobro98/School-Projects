
#ifndef CAMERABEHAVIORS_H
#define CAMERABEHAVIORS_H

#include "Camera.h"

class GameObject;

class CameraBehavior
{
public:

	CameraBehavior(Camera* const camera, const GameObject* const go)
		: cam(camera), obj(go)
	{}

	virtual ~CameraBehavior(){}
	CameraBehavior(const CameraBehavior&);
	const CameraBehavior operator=(const CameraBehavior&);

	Camera* const getCamera() const { return cam; }

	virtual void update() = 0;

protected:

	Camera* const cam;
	const GameObject* const obj;
};

#endif // CAMERABEHAVIORS_H