
#ifndef COLLISIONGROUP_H
#define COLLISIONGROUP_H

#include <set>

#include "Vect.h"
#include "CollisionGroupBase.h"
#include "Collidable.h"
#include "Visualizer.h"
#include "Tools.h"

template <class T>
class CollisionGroup : public CollisionGroupBase
{
public:

	~CollisionGroup()
	{
		collideCollection.clear();
		cgInstance = 0;
		minAABB = Vect(FLT_MAX, FLT_MAX, FLT_MAX);
		maxAABB = Vect(-FLT_MAX, -FLT_MAX, -FLT_MAX);
	}

	static void registerCollision(T* collObj);
	static void deregisterCollision(T* collObj);

	typedef std::set<T*> CollidableSet;
	CollidableSet collideCollection;

	const CollidableSet& getCollection()
	{
		return instance().collideCollection;
	}

	const Vect getMinPoint() const
	{
		return minAABB;
	}
	const Vect getMaxPoint() const
	{
		return maxAABB;
	}

	static CollisionGroup<T>& instance();

	void calcGroupStats() override;


private:
	static CollisionGroup<T>* cgInstance;
	Vect  maxAABB;
	Vect  minAABB;
	
};

template <class T>
CollisionGroup<T>* CollisionGroup<T>::cgInstance = 0;

template <class T>
CollisionGroup<T>& CollisionGroup<T>::instance()
{
	if(cgInstance == 0)
	{
		cgInstance = new CollisionGroup<T>();
	}

	return *cgInstance;
}

template <class T>
void CollisionGroup<T>::calcGroupStats()
{
	minAABB = Vect(FLT_MAX, FLT_MAX, FLT_MAX);
	maxAABB = Vect(-FLT_MAX, -FLT_MAX, -FLT_MAX);
	for(CollidableSet::iterator it = collideCollection.begin(); it != collideCollection.end(); ++it)
	{
		(*it)->calcColStats();
		minAABB = Tools::min(minAABB, (*it)->getMinAABBPoint());
		maxAABB = Tools::max(maxAABB, (*it)->getMaxAABBPoint());
		//Visualizer::showAABB(minAABB, maxAABB);
	}
}

template <class T>
void CollisionGroup<T>::registerCollision(T* cObj)
{
	instance().collideCollection.insert(cObj);
}

template <class T>
void CollisionGroup<T>::deregisterCollision(T* cObj)
{
	instance().collideCollection.erase(cObj);
}
#endif // COLLISIONGROUP_H