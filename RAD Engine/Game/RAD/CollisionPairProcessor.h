
#ifndef COLLISIONPAIRPROCESSOR_H
#define COLLISIONPAIRPROCESSOR_H

#include "CollisionProcessorBase.h"
#include "CollisionGroup.h"

template <class C1, class C2>
class CollisionPairProcessor : public CollisionProcessorBase
{
public:
	CollisionPairProcessor()
	{
		colGroup1 = &CollisionGroup<C1>::instance();
		colGroup2 = &CollisionGroup<C2>::instance();
	}

	void testCollision() override;

private:

	CollisionGroup<C1>* colGroup1;
	CollisionGroup<C2>* colGroup2;
};

template <class C1, class C2>
void CollisionPairProcessor<C1, C2>::testCollision()
{
	if(Tools::boxInteresction(colGroup1->getMinPoint(), colGroup1->getMaxPoint(), colGroup2->getMinPoint(), colGroup2->getMaxPoint()))
	{
		for(CollisionGroup<C1>::CollidableSet::iterator c1_it = colGroup1->getCollection().begin(); c1_it != colGroup1->getCollection().end(); ++c1_it)
		{
			if(Tools::boxInteresction((*c1_it)->getMinAABBPoint(), (*c1_it)->getMaxAABBPoint(), colGroup2->getMinPoint(), colGroup2->getMaxPoint()))
			{
				for(CollisionGroup<C2>::CollidableSet::iterator c2_it = colGroup2->getCollection().begin(); c2_it != colGroup2->getCollection().end(); ++c2_it)
				{
					if(Collidable::testCollisionPair(*c1_it, *c2_it))
					{
						(*c1_it)->collision(*c2_it);
						(*c2_it)->collision(*c1_it);
					}
				}
			}
		}
	}
}


#endif // COLLISIONPAIRPROCESSOR_H