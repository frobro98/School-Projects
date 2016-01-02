
#include "BulletFactory.h"
#include "..\RAD\Destroyable.h"

Bullet* BulletFactory::create(SpaceShip* ship)
{
	Bullet* bul;
 	if(instance().bullRec.empty())
	{
		bul = new Bullet(ship);

		bul->userWillManage(&instance());
	}
	else
	{
		bul = instance().bullRec.back();
		bul->setActive(ship);
		instance().bullRec.pop_back();
	}

	return bul;
}

void BulletFactory::receiveObject(Destroyable* des)
{
	Bullet* bul = (Bullet *)des;
	bul->predestruction();

	instance().bullRec.push_back(bul);

	printf("Bullet recycled!\n");
}