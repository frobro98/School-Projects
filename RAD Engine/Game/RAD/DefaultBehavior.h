
#ifndef DEFAULTBEHAVIOR_H
#define DEFAULTBEHAVIOR_H

#include "CameraBehavior.h"

class DefaultBehavior : public CameraBehavior
{
public:
	DefaultBehavior(Camera* const cam)
		: CameraBehavior(cam, 0)
	{}

	void update() override { this->cam->updateCamera(); }
};

#endif // DEFAULTBEHAVIOR_H