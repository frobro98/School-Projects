
#ifndef TERRAINOBJECT_H
#define TERRAINOBJECT_H

#include "Drawable.h"
#include "Vect.h"
#include "GpuModel.h"

class GraphicsObjectFlatTexture;
class GraphicsObjectWireFrame;

struct Cell
{
	int v0;
	int v1;
	int v2;
	int v3;

	Vect max;
	Vect min;

};

class TerrainObject : public Drawable
{
public:
	TerrainObject();
	~TerrainObject();

	void draw() override;

	void setupRender(const char* const modelName, const char* texName);

private:

	Cell* cells;
	GraphicsObjectFlatTexture* renderModel;
	GraphicsObjectWireFrame* debugModel;
	Model* model;
	float cellLength;
	int sideLength;

	friend class TerrainObjectManager;
};

#endif // TERRAINOBJECT_H