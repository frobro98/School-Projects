
#include "..\RAD\Game.h"
#include "..\RAD\AssetManager.h"
#include "..\RAD\SceneManager.h"
#include "..\RAD\InputManager.h"
#include "..\User files\Level.h"
#include "..\User files\SpaceShip.h"
#include "..\User files\WireSphere.h"

void Game::initialize()
{
	
}

void Game::loadUserContent()
{
	AssetManager::initialize();
	AssetManager::loadModel("space_frigate.fbx", "ship");
	AssetManager::loadModel("Cottage.fbx", "cottage");
	AssetManager::loadModel("Plane.fbx", "plane");

	AssetManager::loadTexture("space_frigate.tga", "shipTex");
	AssetManager::loadTexture("grid.tga", "planeTex");

	printf("Loading Cottage textures:\n");
	char* tNames[4];
	Model* pModelCottage = AssetManager::retrieveModel("cottage");
	for( int i=0; i< pModelCottage->numTextures; i++)
	{
		char *pTextureName = pModelCottage->getTextureName(i);
		char texName[15];
		sprintf_s(texName, 15, "cottageTex%d", i);
		tNames[i] = texName;
		AssetManager::loadTexture(pTextureName, texName);
		printf("\tTexture %i: %s\n", i,  &pTextureName[0]);			
	}
	printf("Done\n");
	
	SceneManager::initialize(new Level);		
}

void Game::unloadUserContent()
{

}

void Game::terminate()
{

}
