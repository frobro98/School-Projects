
#include "AlarmManager.h"
#include "DrawableManager.h"
#include "UpdateableManager.h"
#include "InputManager.h"
#include "CollisionManager.h"
#include "DestroyableManager.h"
#include "DisposalManager.h"
#include "SceneManager.h"
#include "Scene.h"

void SceneManager::initialize(Scene* sc)
{
	instance().Initialize(sc);
}

void SceneManager::Initialize(Scene* sc)
{
	nextScene = sc;
	currScene = sc;
	sc->hookupManagers();
	sc->initialize();
}

SceneManager::~SceneManager()
{
	if(currScene == nextScene)
	{
		delete currScene;
		currScene = 0;
		nextScene = 0;
	}
	else
	{
		delete currScene;
		delete nextScene;
		currScene = 0;
		nextScene = 0;
	}
}

SceneManager& SceneManager::instance()
{
	static SceneManager scmInstance;

	return scmInstance;
}

void SceneManager::changeScene(Scene* sc)
{
	instance().nextScene = sc;
}

void SceneManager::toNextScene()
{
	if(nextScene != currScene)
	{
		delete currScene;
		currScene = nextScene;
		currScene->hookupManagers();
		currScene->initialize();
	}
}

Scene* SceneManager::getCurrScene()
{
	return instance().currScene;
}

void SceneManager::Update()
{
	instance().toNextScene();
	instance().currScene->update();
}

void SceneManager::Draw()
{
	instance().currScene->draw();
}