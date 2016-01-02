
#ifndef COLLISIONMANAGER_H
#define COLLISIONMANAGER_H

#include <set>

#include "CollisionPairProcessor.h"
#include "SingleCollisionProcessor.h"

class CollisionManager
{
public:
	template<class C1, class C2>
	static void setCollisionPair()
	{
		CollisionGroupBase* group1 = &CollisionGroup<C1>::instance();
		CollisionGroupBase* group2 = &CollisionGroup<C2>::instance();

		
		if(group1 != group2)
		{
			instance().colGroupList.insert(group1);
			instance().colGroupList.insert(group2);
			instance().colProcessors.insert(new CollisionPairProcessor<C1, C2>());
		}
		else
		{
			instance().colGroupList.insert(group1);
			instance().colProcessors.insert(new SingleCollisionProcessor<C1>());
		}
	}

private:
	CollisionManager(){};
	~CollisionManager()
	{
		while(!colGroupList.empty())
		{
			CollisionGroupBase* toDel = *colGroupList.begin();
			colGroupList.erase(toDel);
			delete toDel;
			toDel = 0;
		}
		while(!colProcessors.empty())
		{
			CollisionProcessorBase* toDel = *colProcessors.begin();
			colProcessors.erase(toDel);
			delete toDel;
			toDel = 0;
		}

	}

	void processCollisions();

	typedef std::set<CollisionGroupBase*> CollsionGroups;
	typedef std::set<CollisionProcessorBase*> ProcessorGroups;
	CollsionGroups colGroupList;
	ProcessorGroups colProcessors;

	static CollisionManager& instance();
	static CollisionManager* cmInstance;

	friend class Scene;

};

#endif // COLLISIONMANAGER_H