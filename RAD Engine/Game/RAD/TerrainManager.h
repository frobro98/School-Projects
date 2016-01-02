
#ifndef TERRAINMANAGER_H
#define TERRAINMANAGER_H

class TerrainObject;

class TerrainManager
{
	friend class Scene;
public:
	static TerrainObject* getTerrain() { return instance().scTerrObj; }
private:
	TerrainManager(){};
	~TerrainManager();

	static TerrainManager& instance();

	static TerrainManager* tmInstance;
	TerrainObject* scTerrObj;
};

#endif // TERRAINMANAGER_H