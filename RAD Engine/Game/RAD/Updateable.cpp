
#include "Updateable.h"
#include "UpdateableManager.h"
#include "Scene.h"
#include "SceneManager.h"

Updateable::Updateable()
{
	SceneManager::getCurrScene()->getUpdateManager()->registerUpdateable(this);
}

Updateable::~Updateable()
{
	SceneManager::getCurrScene()->getUpdateManager()->deregisterUpdateable(this);
}
