
#include "TerrainManager.h"

TerrainManager* TerrainManager::tmInstance = 0;

TerrainManager& TerrainManager::instance()
{
	if(tmInstance == 0)
	{
		tmInstance = new TerrainManager();
	}

	return *tmInstance;
}