
#ifndef TERRAINCOLLISIONPROCESSOR_H
#define TERRAINCOLLISIONPROCESSOR_H

#include "CollisionProcessorBase.h"
#include "CollisionGroup.h"
#include "TerrainManager.h"
#include "TerrainObject.h"

template <class C>
class TerrainCollisionProcessor : public CollisionProcessorBase
{
public:
	TerrainCollisionProcessor()
	{
		colGroup = CollisionGroup<C>::instance();
		terrObj = TerrainManager::getTerrain();
	}

	void testCollision() override;

private:
	CollisionGroup<C>* colGroup;
	TerrainObject* terrObj;
};


#endif // TERRAINCOLLISIONPROCESSOR_H