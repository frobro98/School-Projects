

#include "Level.h"
#include "..\RAD\SceneManager.h"
#include "SpaceShip.h"
#include "WireSphere.h"
#include "Cottage.h"
#include "Plane.h"
#include "..\RAD\AssetManager.h"
#include "..\RAD\CollisionManager.h"
#include "Azul.h"
#include "..\RAD\Game.h"
#include "..\RAD\TerrainModel.h"
#include "..\RAD\TerrainObjectManager.h"

void Level::initialize()
{
	Visualizer::initialize();
	new SpaceShip(AssetManager::retrieveModel("ship"), AssetManager::retrieveTexture("shipTex"));
	//new SpaceShip(Vect(-50.f, 10.f, 0.f), Vect(0.f, 0.f, 0.f));
	//new WireSphere(AssetManager::retrieveModel("sphere"));
	new Cottage();
	//new Plane();
	//new TerrainModel("Test.tga", 12.f, 1.f, 0.f, "planeTex", 1, 1);
	//TerrainObjectManager::loadTerrain("PlaneTerrain", "Test.tga", 150.f, 10.f, 0.f, 3, 3, "planeTex");
	//TerrainObjectManager::loadTerrain("PlaneTerrain", "4x4.tga", 150.f, 10.f, 0.f, 3, 3, "planeTex");
	TerrainObjectManager::loadTerrain("PlaneTerrain", "Big hill.tga", 150.f, 10.f, 0.f, 3, 3, "planeTex");

	CollisionManager::setCollisionPair<SpaceShip, Cottage>();

}