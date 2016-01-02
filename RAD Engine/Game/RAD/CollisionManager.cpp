
#include "CollisionManager.h"

CollisionManager* CollisionManager::cmInstance = 0;

void CollisionManager::processCollisions()
{
	CollsionGroups::iterator itGroup;
	for(itGroup = colGroupList.begin(); itGroup != colGroupList.end(); ++itGroup)
	{
		(*itGroup)->calcGroupStats();
	}

	ProcessorGroups::iterator itProcess;
	for(itProcess = colProcessors.begin(); itProcess != colProcessors.end(); ++itProcess)
	{
		(*itProcess)->testCollision();
	}
}

CollisionManager& CollisionManager::instance()
{
	if(cmInstance == 0)
	{
		cmInstance = new CollisionManager();
	}

	return *cmInstance;
}