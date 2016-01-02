
#ifndef BULLET_H
#define BULLET_H
#include "..\RAD\RAD.h"
#include "..\RAD\GameObject.h"

class SpaceShip;

class Bullet : public GameObject
{
public:
	Bullet(SpaceShip* s);

	void Alarm0() override;

	void setActive(SpaceShip* ship);

	void update() override;
	void draw() override;
private:
	GraphicsObjectWireFrame* gObj;
	SpaceShip* ship;

};

#endif // BULLET_H