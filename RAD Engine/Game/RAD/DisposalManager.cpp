
#include "Destroyable.h"

DisposalManager* DisposalManager::dmInstance = 0;

DisposalManager& DisposalManager::instance()
{
	if(dmInstance == 0)
	{
		dmInstance = new DisposalManager();
	}

	return *dmInstance;
}

DisposalManager::~DisposalManager()
{
	while(!objList.empty())
	{
		Destroyable* d = objList.back();
		objList.pop_back();
		
		delete d;
	}
}

void DisposalManager::registerDest(Destroyable* const dObj)
{
	instance().objList.push_back(dObj);
}

void DisposalManager::deregisterDest(Destroyable* const dObj)
{
	instance().objList.remove(dObj);
}

void DisposalManager::unused(Destroyable* const dObj)
{
	instance().objList.remove(dObj);
	delete dObj;
}

