#ifndef _TerrainModel
#define _TerrainModel

#include "RAD.h"// Replace with your equivalent engine #include
#include <tuple>

#include "TerrainObject.h"

class TerrainModel : public GameObject
{
private:
	GraphicsObject* pGObjFT;
	GraphicsObjectWireFrame* pGObjFT2;
	Matrix WorldMat;
	Cell* cells;

	void CreateTerrainModel( const char* const heightmapFile, const float& sideLen, const float& maxHeight, const float& terrainHeight, const int &RepeatU, const int &RepeatV);
	void SaveTerrainModel(const VertexStride_VUN* const pVerts, const int &num_verts, const TriangleIndex* const tlist, const int &num_tri); 

public:
	TerrainModel( const char* const heightmapFile, const float &Sidelenght, const float &maxheight, const float &zeroHeight, const char* const TextureKey, const int &RepeatU, const int& RepeatV);
	virtual void draw() override;
	virtual void update() override {};

};


#endif _TerrainModel