
#include "Plane.h"
#include "..\RAD\AssetManager.h"
#include "Azul.h"

Plane::Plane()
{
	Texture* tex = AssetManager::retrieveTexture("planeTex");
	Model* mod = AssetManager::retrieveModel("plane");
	go = new GraphicsObjectFlatTexture(mod, tex);

	this->world = new Matrix(SCALE, 300, 300, 300);
	go->setWorld(*world);
}

Plane::~Plane()
{
	delete go;
	go = 0;
}

void Plane::update()
{

}

void Plane::draw()
{
	go->Render();
}

void Plane::destroy()
{

}