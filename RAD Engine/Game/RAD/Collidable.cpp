
#include <assert.h>

#include "Collidable.h"
#include "BoundingSphere.h"
#include "AxisAlignedBoundingBox.h"
#include "OrientingBoundingBox.h"
#include "TreeBuilder.h"
#include "OctreeIterator.h"
#include "Azul.h"
#include "Visualizer.h"
#include "Tools.h"

Collidable* Collidable::instance = 0;

Collidable::Collidable()
{
	this->colWorld = new Matrix(IDENTITY);
	this->boundingVol = 0;
	this->aabbSphere = 0;
	instance = this;
}

Collidable::~Collidable()
{
	colModel = 0;

	delete colWorld;
	delete boundingVol;
}

void Collidable::setupAABBSphere(Model* const mod)
{
	aabbSphere = new BoundingSphere(mod);
}

const Vect Collidable::getMaxAABBPoint() const
{
	Vect center = aabbSphere->getCenter();
	float radius = aabbSphere->getRadius();
	return Vect(center[x]+radius, center[y]+radius, center[z]+radius);
}

const Vect Collidable::getMinAABBPoint() const
{
	
	Vect center = aabbSphere->getCenter();
	float radius = aabbSphere->getRadius();
	return Vect(center[x]-radius, center[y]-radius, center[z]-radius);
}

void Collidable::setupCollision(Model* const model, Sphere sEnum, ColType type, const int& level)
{
	setupBoundingVolume(model, sEnum);
	if(type == COL_PRECISE)
	{
		setupPreciseCollision(model, level);
	}
}

void Collidable::setupCollision(Model* const model, AxisAligned aabbEnum, ColType type, const int& level)
{
	setupBoundingVolume(model, aabbEnum);
	if(type == COL_PRECISE)
	{
		setupPreciseCollision(model, level);
	}
}

void Collidable::setupCollision(Model* const model, Oriented obbEnum, ColType type, const int& level)
{
	setupBoundingVolume(model, obbEnum);
	if(type == COL_PRECISE)
	{
		setupPreciseCollision(model, level);
	}
}

void Collidable::setupPreciseCollision(Model* const model, const int& level)
{
	TreeBuilder treeBuilder(OCT, level);

	treeBuilder.constructTree(model, (BoundingBox *)boundingVol);
	//boundingVol->setChild(volChildern);
}

void Collidable::setupBoundingVolume(Model* const model, Sphere sEnum)
{
	assert(model != 0);
	UNUSED_VAR(sEnum);
	boundingVol = new BoundingSphere(model);
	setupAABBSphere(model);
}

void Collidable::setupBoundingVolume(Model* const model, AxisAligned aabbEnum)
{
	assert(model != 0);
	UNUSED_VAR(aabbEnum);
	boundingVol = new AxisAlignedBoundingBox(model);
	setupAABBSphere(model);
}

void Collidable::setupBoundingVolume(Model* const model, Oriented obbEnum)
{
	assert(model != 0);
	UNUSED_VAR(obbEnum);
	boundingVol = new OrientingBoundingBox(model);
	setupAABBSphere(model);
}

void Collidable::showBoundingVolume() const
{
	//aabbSphere->showDebugVolume(*colWorld);
	OctreeIterator oIt(boundingVol);
	boundingVol->showDebugVolume(*colWorld);
	oIt.next();
	while(!oIt.atEnd())
	{
		PartialBoundingBox* sph = (PartialBoundingBox *)oIt.current();
		Visualizer::showSphere(sph->getCenter()* (*colWorld), sph->getRadius());
		oIt.next();
	}
	
}

void Collidable::calcColStats()
{
	OctreeIterator oIt(boundingVol);
	while (!oIt.atEnd())
	{
		CollisionVolume* cVol = (CollisionVolume *)oIt.current();
		cVol->calculateColStats(*colWorld);
		oIt.next();
	}
	aabbSphere->calculateColStats(*colWorld);
}

bool Collidable::testCollisionPair(Collidable* c1, Collidable* c2)
{
	return c1->boundingVol->collisionWithVolume(c2->boundingVol);
}