
#include "Scene.h"
#include "AlarmManager.h"
#include "DrawableManager.h"
#include "UpdateableManager.h"
#include "InputManager.h"
#include "CollisionManager.h"
#include "DestroyableManager.h"
#include "DisposalManager.h"

Scene::Scene()
{
	aMan = new AlarmManager();
	cMan = new CollisionManager();
	destMan = new DestroyableManager();
	drawMan = new DrawableManager();
	disMan = new DisposalManager();
	iMan = new InputManager();
	uMan = new UpdateableManager();
	
}

Scene::~Scene()
{
	delete aMan;
	aMan = 0;
	delete cMan;
	cMan = 0;
	delete iMan;
	iMan = 0;
	delete drawMan;
	drawMan = 0;
	delete destMan;
	destMan = 0;
	delete disMan;
	disMan = 0;
	delete uMan;
	uMan = 0;

	AlarmManager::amInstance = 0;
	CollisionManager::cmInstance = 0;
	DestroyableManager::dmInstance = 0;
	DrawableManager::dmInstance = 0;
	DisposalManager::dmInstance = 0;
	InputManager::imInstance = 0;
	UpdateableManager::umInstance = 0;
}

void Scene::hookupManagers()
{
	AlarmManager::amInstance = aMan;
	CollisionManager::cmInstance = cMan;
	DestroyableManager::dmInstance = destMan;
	DrawableManager::dmInstance = drawMan;
	DisposalManager::dmInstance = disMan;
	InputManager::imInstance = iMan;
	UpdateableManager::umInstance = uMan;
}

void Scene::update() const
{
	cMan->processCollisions();

	iMan->update();
	uMan->Update();
	aMan->update();

	destMan->terminateObjs();
}

void Scene::draw() const
{
	drawMan->Draw();
}