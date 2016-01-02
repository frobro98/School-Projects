
#include "TerrainObject.h"
#include "AssetManager.h"
#include "Azul.h"

TerrainObject::TerrainObject()
{

}

void TerrainObject::draw()
{
	renderModel->Render();
}

void TerrainObject::setupRender(const char* const modelName, const char* texName)
{
	this->model = AssetManager::retrieveModel(modelName);
	this->renderModel = new GraphicsObjectFlatTexture(model, AssetManager::retrieveTexture(texName));
	this->debugModel = new GraphicsObjectWireFrame(model);
}

TerrainObject::~TerrainObject()
{

}