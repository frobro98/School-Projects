
#include "..\RAD\RAD.h"
#include "Bullet.h"
#include "SpaceShip.h"

Bullet::Bullet(SpaceShip* s)
{
	this->gObj = new GraphicsObjectWireFrame(AssetManager::retrieveModel("sphere"));
	gObj->color = Vect(1.0f, 0.0f, 0.0f);

	ship = s;

	pos = ship->getPos();
	rot = ship->getRot();
	scale.set(SCALE, 2.f, 2.f, 7.f);


	*world =  scale * rot * Matrix(TRANS, pos);
	gObj->setWorld(*world);

	//setWorld(world);

	AlarmManager::registerAlarm(this, ALARM_0, 3.0f);
}

void Bullet::setActive(SpaceShip* ship)
{
	prerecycling();
	this->ship = ship;
	pos = ship->getPos();
	rot = ship->getRot();
	AlarmManager::registerAlarm(this, ALARM_0, 3.0f);
}

void Bullet::Alarm0()
{
	this->willDestroy();
}

void Bullet::update()
{
	pos += Vect(0,0,5) * rot;
	*world = scale * rot * Matrix(TRANS, pos);
	
	gObj->setWorld(*world);

}

void Bullet::draw()
{
	gObj->Render();
}