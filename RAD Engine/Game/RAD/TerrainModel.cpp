#include "TerrainModel.h"
#include <Azul.h>
#include <assert.h>
#include <string>
#include <vector>
#include <assert.h>

#include "Debug.h"
#include "Tools.h"

// Note: the heightmap file should not be a pre-loaded texture from the texture manager
TerrainModel::TerrainModel( const char* const heightmapFile, const float &Sidelenght, const float &maxheight, const float &zeroHeight, const char* const TextureKey, const int &RepeatU, const int& RepeatV)
{
	// Create the model 
	// *** and save it to an .azul file ***
	// *** and loads in the the Model Manager ***
	CreateTerrainModel( heightmapFile, Sidelenght, maxheight, zeroHeight, RepeatU, RepeatV);

	// and then load it back in through the model manager... Because it's easier than modding AZUL
	AssetManager::loadModel("AZULTERRAIN.azul", "AzulTerrain");

	// Scale and adjust position if needed

	WorldMat = Matrix(IDENTITY);

	//// Connect the model to a graphics object
	pGObjFT = new GraphicsObjectFlatTexture( AssetManager::retrieveModel("AzulTerrain"), AssetManager::retrieveTexture(TextureKey)	);
	pGObjFT->setWorld( WorldMat );

	//*  
	// This is for debugging only
	pGObjFT2 = new GraphicsObjectWireFrame( AssetManager::retrieveModel("AzulTerrain"));
	pGObjFT2->color = Vect(1.f, 0.f, 0.f);
	pGObjFT2->setWorld( WorldMat );
	//*/

	UNUSED_VARS(Sidelenght, maxheight, zeroHeight);
}

void TerrainModel::draw()
{
	//pGObjFT->Render();
	pGObjFT2->Render();  // Debug tool only
}

// Creates the actual model mesh
void TerrainModel::CreateTerrainModel( const char* const heightmapFile, const float& sideLen, const float& maxHeight, const float& terrainHeight, const int &RepeatU, const int &RepeatV)
{
	// Using GLTools to read in the file
	int imgWidth, imgHeigth, icomp;
	unsigned int dtype;
	GLbyte* imgData = gltReadTGABits( heightmapFile, &imgWidth, &imgHeigth, &icomp, &dtype);
	assert( imgWidth == imgHeigth); // We need square images for heightmaps

	/// Insert much work to create and the model
	const float sideLength = sideLen;
	const int numVertsPerRow = imgWidth;
	const int numCellsPerRow = imgWidth - 1;
	const int numCells = numCellsPerRow * numCellsPerRow;
	const float cellLength = (float)sideLength / numCellsPerRow;
	const float uCellLen = (float)RepeatU / numCellsPerRow;
	const float vCellLen = (float)RepeatV / numCellsPerRow;
	const float heightRatio = maxHeight / 255;
	cells = new Cell[numCells];

	const int numVerts = imgWidth * imgHeigth;
	const int numTris = numCells * 2;
	VertexStride_VUN* verts = new VertexStride_VUN[numVerts];
	TriangleIndex* triIndex = new TriangleIndex[numTris];

	float offsetZ = sideLength / 2.f;
	float offsetX = sideLength / 2.f;
	float offsetU = 0.f;
	float offsetV = (float)RepeatV;

	int triOffset = -1;
	int pixelIndex = numVerts*3;

	for(int i = 0; i < numVertsPerRow; ++i)
	{
		for(int j = 0; j < numVertsPerRow; ++j)
		{
			const int index = Tools::find1DIndex(i, j, numVertsPerRow);

			pixelIndex -= 3;
			unsigned char heightData = static_cast<unsigned char>(imgData[pixelIndex]);

			verts[index].y = heightData * heightRatio + terrainHeight;
			verts[index].x = offsetX;
			verts[index].z = offsetZ;

			verts[index].u = offsetU;
			verts[index].v = offsetV;

			verts[index].txt = 0.f;
			verts[index].nx = 0.f;
			verts[index].ny = 0.f;
			verts[index].nz = 0.f;

			offsetX -= cellLength;
			offsetU += uCellLen;
		}
		offsetX = sideLength / 2.f;
		offsetZ -= cellLength;
		offsetV -= vCellLen;
		offsetU = 0.f;
	}

	for(int i = 0; i < numCellsPerRow; ++i)
	{
		for(int j = 0; j < numCellsPerRow; ++j)
		{
			Cell* cell = &cells[i];
			cell->v0 = Tools::find1DIndex(i, j, numVertsPerRow);
			cell->v1 = Tools::find1DIndex(i, j + 1, numVertsPerRow);
			cell->v2 = Tools::find1DIndex(i + 1, j, numVertsPerRow);
			cell->v3 = Tools::find1DIndex(i+1, j+1, numVertsPerRow);

			VertexStride_VUN max = Tools::max(verts[cell->v0], Tools::max(verts[cell->v1], Tools::max(verts[cell->v2], verts[cell->v3])));
			VertexStride_VUN min = Tools::min(verts[cell->v0], Tools::min(verts[cell->v1], Tools::min(verts[cell->v2], verts[cell->v3])));
			cell->max = Vect(max.x, max.y, max.z);
			cell->min = Vect(min.x, min.y, min.z);

			++triOffset;
			triIndex[triOffset].v0 = cell->v0;
			triIndex[triOffset].v1 = cell->v2;
			triIndex[triOffset].v2 = cell->v1;

			++triOffset;
			triIndex[triOffset].v0 = cell->v1;
			triIndex[triOffset].v1 = cell->v2;
			triIndex[triOffset].v2 = cell->v3;
		}
	}

	SaveTerrainModel(verts, numVerts, triIndex, numTris);

	delete[] verts;
	delete[] triIndex;
}

// Saves the model to file in the Azul format 
// (realistically, the filename should be parametrized)
void TerrainModel::SaveTerrainModel( const VertexStride_VUN* const pVerts, const int &num_verts, const TriangleIndex* const tlist, const int &num_tri)
{
	char* TerrainName = "AZULTERRAIN";
	char* TerrainFilename = "../Assets/AZULTERRAIN.azul";

	//// Write the data to a file ----------------------------
	FileHandle fh;
	FileError  ferror;
	std::vector<std::string> FBX_textNames; // (Ed) purposefully empty to be consistent 

	// 1) Create a blank header

		// // write the data
		AzulFileHdr  azulFileHdr;
		strcpy_s(azulFileHdr.objName, OBJECT_NAME_SIZE, TerrainName);

	// 2)  Write the data (Header, Buffers) to the files

	// write the header (Take 1) 

		// create the file, write the header
		ferror = File::open(fh, TerrainFilename, FILE_READ_WRITE );
		assert( ferror == FILE_SUCCESS );

		// write the data
		ferror = File::write( fh, &azulFileHdr, sizeof(azulFileHdr) );
		assert( ferror == FILE_SUCCESS );

	// update the header: numTextures, textureNamesOffset
		azulFileHdr.numTextures = FBX_textNames.size();

		// update the offset
		ferror = File::tell( fh, azulFileHdr.textureNamesOffset );
		assert( ferror == FILE_SUCCESS );

	
	std::vector<std::string>::iterator FBX_textNames_iterator;

	int i=0;
	for( FBX_textNames_iterator = FBX_textNames.begin(); 
		    FBX_textNames_iterator != FBX_textNames.end();
		    FBX_textNames_iterator++ )
	{
		const char *ss = (*FBX_textNames_iterator).c_str();
		// write the vertex data
		ferror = File::write( fh, ss, strlen(ss) + 1);
		assert( ferror == FILE_SUCCESS );
		i++;
	}

	// update the header: numVerts, VertBufferOffset

		// update the number of verts
		azulFileHdr.numVerts = num_verts;
   
		// update the offset
		ferror = File::tell( fh, azulFileHdr.vertBufferOffset );
		assert( ferror == FILE_SUCCESS );

	// write the vertex data
	ferror = File::write( fh, pVerts, num_verts * sizeof(VertexStride_VUN) );
	assert( ferror == FILE_SUCCESS );

	// update the header: numTriList, triListBufferOffset

		// update the number of verts
		azulFileHdr.numTriangles = num_tri;

		// update the offset
		ferror = File::tell( fh, azulFileHdr.triangleListBufferOffset );
		assert( ferror == FILE_SUCCESS );

	// write the triListBuffer data
	ferror = File::write( fh, tlist, num_tri * sizeof(TriangleIndex) );
	assert( ferror == FILE_SUCCESS );
	    
	// write the header (Take 2) now with updated data

		azulFileHdr.textureNamesInBytes = azulFileHdr.vertBufferOffset - azulFileHdr.textureNamesOffset;

		// reset to the beginning of file
		ferror = File::seek( fh, FILE_SEEK_BEGIN, 0 );
		assert( ferror == FILE_SUCCESS );

		// write the buffer
		ferror = File::write( fh, &azulFileHdr, sizeof(azulFileHdr) );
		assert( ferror == FILE_SUCCESS );

	// All done - bye bye
	ferror = File::close( fh );
	assert( ferror == FILE_SUCCESS );
}
