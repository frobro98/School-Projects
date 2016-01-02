
#ifndef TERRAINOBJECTMANAGER_H
#define TERRAINOBJECTMANAGER_H

#include <map>
#include <string>

class TerrainObject;
struct TriangleIndex;
struct VertexStride_VUN;

class TerrainObjectManager
{
public:
	static void loadTerrain(const char* const terrainKey, const char* const heightmapFile, const float& sideLength, const float& maxHeight, const float& terrainHeight, const int& repeatU, const int& repeatV, const char* const textureKey);
private:
	TerrainObjectManager(){};
	~TerrainObjectManager();
	TerrainObjectManager(const TerrainObjectManager&);
	const TerrainObjectManager operator=(const TerrainObjectManager&);

	void createTerrainModel( const char* const terrainKey, const char* const heightmapFile, const float& sideLength, const float& maxHeight, const float& terrainHeight, const int &RepeatU, const int &RepeatV, const char* const textureKey);
	const char* const SaveTerrainModel(const char* const terrainKey, const VertexStride_VUN* const pVerts, const int &num_verts, const TriangleIndex* const tlist, const int &num_tri); 

	typedef std::map<std::string, TerrainObject*> TerrainTable;
	TerrainTable table;

	static TerrainObjectManager& instance();

};

#endif TERRAINOBJECTMANAGER_H