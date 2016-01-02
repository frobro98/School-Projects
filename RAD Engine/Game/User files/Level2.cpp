
#include "Level2.h"
#include "WireSphere.h"
#include "Cottage.h"
#include "Plane.h"
#include "..\RAD\AssetManager.h"
#include "..\RAD\Game.h"

void Level2::initialize()
{
	new WireSphere(AssetManager::retrieveModel("sphere"));
	new Cottage();
	new Plane();
}