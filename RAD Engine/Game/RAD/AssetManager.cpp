
#include "AssetManager.h"
#include "Azul.h"

void AssetManager::initialize()
{
	instance().Initialize();
}

void AssetManager::Initialize()
{
	Model* sphere = createModel("BoundingSphere.azul");
	Model* box = createModel("BoundingBox.azul");

	pLoadModel(sphere, "sphere");
	pLoadModel(box, "box");
}

AssetManager& AssetManager::instance()
{
	static AssetManager am;

	return am;
}

Texture* const AssetManager::createTexture(const char* const filename) const
{
	return GpuTexture::Create(filename);
}

Model* const AssetManager::createModel( const char* const filename) const
{
	return GpuModel::Create(filename);
}

void AssetManager::loadTexture(const std::string &fName, const std::string &texName)
{
	
	Texture* tex = instance().createTexture(fName.c_str());

	instance().pLoadTexture(tex, texName);
}

Texture* AssetManager::retrieveTexture(const std::string &texName)
{
	return instance().pRetrieveTexture(texName);
}

void AssetManager::pLoadTexture(Texture* tex, const std::string texName)
{
	tList[texName] = tex;
}

Texture* const AssetManager::pRetrieveTexture(const std::string &texName) 
{
	return tList[texName];
}

void AssetManager::loadModel(const std::string &fName, const std::string &modName)
{
	size_t index = fName.find(".fbx");
	std::string name = fName;
	if(index != std::string::npos )
	{
		convertModel(fName.c_str());
		
		name = fName.substr(0, index) + ".azul";
	}

	Model* mod = instance().createModel(name.c_str());

	instance().pLoadModel(mod, modName);
}

Model* AssetManager::retrieveModel(const std::string &modName)
{
	return instance().pRetrieveModel(modName);
}

void AssetManager::pLoadModel(Model* mod,  const std::string modName)
{
	mList[modName] = mod;
}

Model* const AssetManager::pRetrieveModel(const std::string &modName) 
{
	return mList[modName];
}

void AssetManager::convertModel(const char* const mTC)
{
	printf("Converting FBX to AZUL\n");
	char command[LEN_CONVERT];
	sprintf_s(command, LEN_CONVERT, "ConverterDebug %s > DebugInfo.txt", mTC);
	system(command);
	printf("Converting completed\n");
}