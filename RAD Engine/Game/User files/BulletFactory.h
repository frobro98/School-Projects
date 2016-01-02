#ifndef BULLETFACTORY_H
#define BULLETFACTORY_H

#include <list>

#include "../RAD/DestroyableReceiver.h"
#include "Bullet.h"
#include "SpaceShip.h"

class Destroyable;

class BulletFactory : public DestroyableReceiver
{
public:
	static Bullet* create(SpaceShip* ship);

	void receiveObject(Destroyable* des);

private:
	static BulletFactory& instance()
	{
		static BulletFactory fac;

		return fac;
	}

	std::list<Bullet*> bullRec;

};

#endif 