
#include "Cottage.h"
#include "..\RAD\AssetManager.h"
#include "..\RAD\SceneManager.h"
#include "..\RAD\CollisionManager.h"
#include "Azul.h"

#include "Level2.h"

Cottage::Cottage()
	: GameObject()
{
	Model* mod = AssetManager::retrieveModel("cottage");

	go = new GraphicsObjectFlatTexture(mod, AssetManager::retrieveTexture("cottageTex0"),
											AssetManager::retrieveTexture("cottageTex1"),
											AssetManager::retrieveTexture("cottageTex2"),
											AssetManager::retrieveTexture("cottageTex3"));
	pos = Vect(0.f, 0.f, 0.f);
	rot = Matrix(ROT_XYZ, 0, 0, 0);
	scale = Matrix(SCALE, 1.5f, 1.5f, 1.5f);
	*world = scale * rot * Matrix(TRANS,pos);
	go->setWorld(*world);

	CollisionGroup<Cottage>::registerCollision(this);

	//setupBoundingVolume(mod, OBB);
	setupCollision(mod, OBB, COL_REGULAR);
}

Cottage::~Cottage()
{
	delete go;
	go = 0;
}

void Cottage::collision(SpaceShip* s)
{
	s;
	printf("Cottage collided with SpaceShip\n");
	willDestroy();
	SceneManager::changeScene(new Level2());
}

void Cottage::update()
{
	rot *= Matrix(ROT_Y, .01f);
	*world = scale*rot*Matrix(TRANS,pos);

	go->setWorld(*world);
}

void Cottage::draw()
{
	go->Render();
	showBoundingVolume();
}

void Cottage::destroy()
{
	printf("Cottage destroyed\n");
	CollisionGroup<Cottage>::deregisterCollision(this);
}