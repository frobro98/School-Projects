
#include "UpdateableManager.h"
#include "Updateable.h"

UpdateableManager* UpdateableManager::umInstance = 0;

UpdateableManager::~UpdateableManager()
{
	uList.clear();
}

void UpdateableManager::registerUpdateable(Updateable* uObj)
{
	instance().uList.push_back(uObj);
}

void UpdateableManager::deregisterUpdateable(Updateable* uObj)
{
	instance().uList.remove(uObj);
}

void UpdateableManager::Update()
{
	UpdateList::const_iterator it = uList.cbegin();
	while(it != uList.cend())
	{
		(*it)->update();
		it++;
	}
}