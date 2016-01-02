

#ifndef ASSETMANAGER_H
#define ASSETMANAGER_H

#include <map>
#include <string>
#include <stdio.h>

struct Texture;
class Model;

#define LEN_CONVERT 128

/**
 \ingroup ASSETS
 
 \brief Loads and manages external textures and 3D models
 
 */

class AssetManager
{
public:
	
	static void initialize();
	static void destroyManager();

	// converts a .fbx model into a .azul model
	static void convertModel( const char* const modelToConvert);

	/**
	 \brief Loads a texture for management and use
	
	 \param	fileName   	Filename of the texture file.
	 \param	textureName	Name of the texture.
	 */
	static void loadTexture(const std::string &fileName, const std::string &textureName);

	/**
	 \brief Loads a model for management and use. Converts .fbx files 
	 into .azul files
		
	 \param	fileName 	Filename of the .azul file.
	 \param	modelName	Name of the model.
	 */
	static void loadModel(const std::string &fileName, const std::string &modelName);

	/**
	 \brief Retrieves a texture
	
	
	 \param	texName	Name of the tex.
	
	 \return	null if it fails, else a Texture*.
	 */
	static Texture* retrieveTexture( const std::string &texName);

	/**
	 \brief Retrieves a model.
	
	 
	 \param	modName	Name of the modifier.
	
	 \return	null if it fails, else a Model*.
	 */
	static Model* retrieveModel(const std::string &modName);

private:

	// FACTORY: Creates a texture
	Texture* const createTexture( const char* const filename) const;
	// FACTORY: Creates a model
	Model* const createModel(const char* const filename) const;

	typedef std::map< std::string, Texture*> TextureList;
	typedef std::map< std::string, Model*> ModelList;

	// Map of Texture pointers
	TextureList tList;
	// Map of Model pointers
	ModelList mList;

	/********************************************
	*			  SINGLETON
	*			HELPER METHODS
	*********************************************/

	void Initialize();
	void pLoadTexture(Texture* tex, const std::string texName);
	void pLoadModel(Model* mod,  const std::string modName);
	Texture* const pRetrieveTexture(const std::string &texName);
	Model* const pRetrieveModel(const std::string &modName) ;

	static AssetManager& instance();

	AssetManager(){};
	AssetManager( const AssetManager& am);
	const AssetManager operator=( const AssetManager& am);
	~AssetManager(){};

};

#endif // ASSETMANAGER_H