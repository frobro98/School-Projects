
#ifndef SINGLECOLLISIONPROCESSOR_H
#define SINGLECOLLISIONPROCESSOR_H

#include "CollisionProcessorBase.h"
#include "CollisionGroup.h"

template <class C1>
class SingleCollisionProcessor : public CollisionProcessorBase
{
public:
	SingleCollisionProcessor()
	{
		colGroup = &CollisionGroup<C1>::instance();
	}

	void testCollision() override;

private:
	CollisionGroup<C1>* colGroup;
};

template <class C1>
void SingleCollisionProcessor<C1>::testCollision()
{
	for(CollisionGroup<C1>::CollidableSet::iterator it = colGroup->getCollection().begin(); it != colGroup->getCollection().end(); ++it)
	{
		(*it)->calcColStats();
	}

	for(CollisionGroup<C1>::CollidableSet::iterator it1 = colGroup->getCollection().begin(); it1 != colGroup->getCollection().end(); ++it1)
	{
		for(CollisionGroup<C1>::CollidableSet::iterator it2 = std::next(it1); it2 != colGroup->getCollection().end(); ++it2)
		{
			if(Collidable::testCollisionPair(*it1, *it2))
			{
				(*it1)->collision(*it2);
				(*it2)->collision(*it1);
			}
		}
	}
}

#endif // SINGLECOLLISIONPROCESSOR_H