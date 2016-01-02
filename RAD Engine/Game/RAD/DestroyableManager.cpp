
#include "DestroyableManager.h"
#include "AlarmManager.h"
#include "DrawableManager.h"
#include "UpdateableManager.h"
#include "InputManager.h"
#include "CollisionManager.h"
#include "GameObject.h"
#include "SceneManager.h"
#include "Scene.h"

DestroyableManager* DestroyableManager::dmInstance = 0;

DestroyableManager::~DestroyableManager()
{
	while(!dList.empty())
	{
		dList.pop_back();
	}
}

DestroyableManager& DestroyableManager::instance()
{
	if(dmInstance == 0)
	{
		dmInstance = new DestroyableManager();
	}

	return *dmInstance;
}

void DestroyableManager::receiveObject(Destroyable* d)
{
	instance().dList.push_back(d);
}

void DestroyableManager::terminateObjs()
{
	while(!dList.empty())
	{
		GameObject* go = (GameObject *)dList.back();
		dList.pop_back();

		go->predestruction();
		go->destroy();

		DisposalManager::unused(go);

	}
}