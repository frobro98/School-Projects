
#include "Destroyable.h"
#include "DestroyableManager.h"

Destroyable::Destroyable()
{
	DisposalManager::registerDest(this);
	managingObj = &DestroyableManager::instance();
	this->remove = false;
	this->userManaged = false;
}

void Destroyable::willDestroy()
{
	managingObj->receiveObject(this);
	this->remove = true;
}

void Destroyable::userWillManage(DestroyableReceiver* const recy)
{
	userManaged = true;
	managingObj = recy;
}