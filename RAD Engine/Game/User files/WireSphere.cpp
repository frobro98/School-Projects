
#include "WireSphere.h"
#include "Azul.h"
#include "..\RAD\CollisionGroup.h"

WireSphere::WireSphere(Model* const mod)
{
	Matrix Scale, Rot, Trans;

	this->go = new GraphicsObjectWireFrame(mod);

	Scale.set(SCALE,10,10,10);
	//Rot.set( ROT_XYZ, angleX, angleY, 0.25f*angleZ );
	Trans.set(TRANS,0, 0, 0);
	*world = Scale * Trans;

	this->setupBoundingVolume(mod, SPHERE);

	CollisionGroup<WireSphere>::registerCollision(this);
}

WireSphere::~WireSphere()
{
	delete go;
	go = 0;
}

void WireSphere::collision(Collidable* c)
{
	c;
	printf("WireSphere colliding with Collidable\n");
}

void WireSphere::collision(SpaceShip* s)
{
	s;
	printf("WireSphere on SpaceShip!!\n");
}

void WireSphere::Alarm0()
{

}

void WireSphere::keyPressed(Inputs i, bool shiftKey, bool altKey, bool ctrlKey)
{
	i; shiftKey; altKey; ctrlKey;
	printf("WireSphere keyPressed\n");
}

void WireSphere::update()
{
	Matrix Scale, Rot, Trans, world;

	Scale.set(SCALE,10,10,10);
	//Rot.set( ROT_XYZ, angleX, angleY, 0.25f*angleZ );
	Trans.set(TRANS,-40, 30, 0);
	world = Scale * Trans;
	this->go->setWorld(world);

	this->go->color = Vect(1.f, 0.f, 0.f);
}

void WireSphere::draw()
{
	//this->showBoundingSphere();
	//this->gObj->Render();
	go->Render();
}

void WireSphere::destroy()
{

}