#include <assert.h>
#include "Azul.h"
#include "PyramidCreateModel.h"

#include <string>
#include <vector>
#include <algorithm>


void pyramidCreateModel()
{
	char *name = "pyramid";
	TriangleIndex	tlist[6];
	VertexStride_VUN pVerts[5*4];

	std::vector<std::string> FBX_textNames;

	std::string StoneName = "stone.tga";
	std::string RocksName = "Rocks.tga";
	std::string BrickName = "RedBrick.tga";
	std::string WeedName = "Duckweed.tga";

	FBX_textNames.push_back( StoneName );
	FBX_textNames.push_back( RocksName );
	FBX_textNames.push_back( BrickName );
	FBX_textNames.push_back( WeedName );


	// front
	tlist[0].v0 = 0;
	tlist[0].v1 = 2;
	tlist[0].v2 = 1;

	// left
	tlist[1].v0 = 0+5;
	tlist[1].v1 = 1+5;
	tlist[1].v2 = 3+5;

	// right
	tlist[2].v0 = 0+10;
	tlist[2].v1 = 3+10;
	tlist[2].v2 = 4+10;

	// back
	tlist[3].v0 = 0+15;
	tlist[3].v1 = 4+15;
	tlist[3].v2 = 2+15;

	// bottom 1
	tlist[4].v0 = 2;
	tlist[4].v1 = 3;
	tlist[4].v2 = 1;

	// bottom 2
	tlist[5].v0 = 2;
	tlist[5].v1 = 4;
	tlist[5].v2 = 3;

	// apex
	pVerts[0].txt = 0.05f;
	pVerts[0].x = 0.0f;
	pVerts[0].y = 1.0f;
	pVerts[0].z = 0.0f;
	pVerts[0].u = 0.5f;
	pVerts[0].v = 0.5f;
	pVerts[0].nx = 0.0f;
	pVerts[0].ny = 1.0f;
	pVerts[0].nz = 0.0f;

	// left front
	pVerts[1].txt = 0.05f;
	pVerts[1].x = -1.0f;
	pVerts[1].y = -1.0f;
	pVerts[1].z = -1.0f;
	pVerts[1].u = 0.0f;
	pVerts[1].v = 0.0f;
	pVerts[1].nx = -3.0f;
	pVerts[1].ny = -5.0f;
	pVerts[1].nz = -3.0f;

	// right front
	pVerts[2].txt = 0.05f;
	pVerts[2].x = 1.0f;
	pVerts[2].y = -1.0f;
	pVerts[2].z = -1.0f;
	pVerts[2].u = 1.0f;
	pVerts[2].v = 0.0f;
	pVerts[2].nx = 3.0f;
	pVerts[2].ny = -5.0f;
	pVerts[2].nz = -3.0f;

	// left back
	pVerts[3].txt = 0.05f;
	pVerts[3].x = -1.0f;
	pVerts[3].y = -1.0f;
	pVerts[3].z = 1.0f;
	pVerts[3].u = 0.0f;
	pVerts[3].v = 1.0f;
	pVerts[3].nx = -3.0f;
	pVerts[3].ny = -5.0f;
	pVerts[3].nz = 3.0f;

	// right back
	pVerts[4].txt = 0.05f;
	pVerts[4].x = 1.0f;
	pVerts[4].y = -1.0f;
	pVerts[4].z = 1.0f;
	pVerts[4].u = 1.0f;
	pVerts[4].v = 1.0f;
	pVerts[4].nx = 3.0f;
	pVerts[4].ny = -5.0f;
	pVerts[4].nz = 3.0f;


		// apex
	pVerts[5].txt = 1.05f;
	pVerts[5].x = 0.0f;
	pVerts[5].y = 1.0f;
	pVerts[5].z = 0.0f;
	pVerts[5].u = 0.5f;
	pVerts[5].v = 0.5f;
	pVerts[5].nx = 0.0f;
	pVerts[5].ny = 1.0f;
	pVerts[5].nz = 0.0f;

	// left front
	pVerts[6].txt = 1.05f;
	pVerts[6].x = -1.0f;
	pVerts[6].y = -1.0f;
	pVerts[6].z = -1.0f;
	pVerts[6].u = 0.0f;
	pVerts[6].v = 0.0f;
	pVerts[6].nx = -3.0f;
	pVerts[6].ny = -5.0f;
	pVerts[6].nz = -3.0f;

	// right front
	pVerts[7].txt = 1.05f;
	pVerts[7].x = 1.0f;
	pVerts[7].y = -1.0f;
	pVerts[7].z = -1.0f;
	pVerts[7].u = 1.0f;
	pVerts[7].v = 0.0f;
	pVerts[7].nx = 3.0f;
	pVerts[7].ny = -5.0f;
	pVerts[7].nz = -3.0f;

	// left back
	pVerts[8].txt = 1.05f;
	pVerts[8].x = -1.0f;
	pVerts[8].y = -1.0f;
	pVerts[8].z = 1.0f;
	pVerts[8].u = 0.0f;
	pVerts[8].v = 1.0f;
	pVerts[8].nx = -3.0f;
	pVerts[8].ny = -5.0f;
	pVerts[8].nz = 3.0f;

	// right back
	pVerts[9].txt = 1.05f;
	pVerts[9].x = 1.0f;
	pVerts[9].y = -1.0f;
	pVerts[9].z = 1.0f;
	pVerts[9].u = 1.0f;
	pVerts[9].v = 1.0f;
	pVerts[9].nx = 3.0f;
	pVerts[9].ny = -5.0f;
	pVerts[9].nz = 3.0f;

		// apex
	pVerts[10].txt = 2.05f;
	pVerts[10].x = 0.0f;
	pVerts[10].y = 1.0f;
	pVerts[10].z = 0.0f;
	pVerts[10].u = 0.5f;
	pVerts[10].v = 0.5f;
	pVerts[10].nx = 0.0f;
	pVerts[10].ny = 1.0f;
	pVerts[10].nz = 0.0f;

	// left front
	pVerts[11].txt = 2.05f;
	pVerts[11].x = -1.0f;
	pVerts[11].y = -1.0f;
	pVerts[11].z = -1.0f;
	pVerts[11].u = 0.0f;
	pVerts[11].v = 0.0f;
	pVerts[11].nx = -3.0f;
	pVerts[11].ny = -5.0f;
	pVerts[11].nz = -3.0f;

	// right front
	pVerts[12].txt = 2.05f;
	pVerts[12].x = 1.0f;
	pVerts[12].y = -1.0f;
	pVerts[12].z = -1.0f;
	pVerts[12].u = 1.0f;
	pVerts[12].v = 0.0f;
	pVerts[12].nx = 3.0f;
	pVerts[12].ny = -5.0f;
	pVerts[12].nz = -3.0f;

	// left back
	pVerts[13].txt = 2.05f;
	pVerts[13].x = -1.0f;
	pVerts[13].y = -1.0f;
	pVerts[13].z = 1.0f;
	pVerts[13].u = 0.0f;
	pVerts[13].v = 1.0f;
	pVerts[13].nx = -3.0f;
	pVerts[13].ny = -5.0f;
	pVerts[13].nz = 3.0f;

	// right back
	pVerts[14].txt = 2.05f;
	pVerts[14].x = 1.0f;
	pVerts[14].y = -1.0f;
	pVerts[14].z = 1.0f;
	pVerts[14].u = 1.0f;
	pVerts[14].v = 1.0f;
	pVerts[14].nx = 3.0f;
	pVerts[14].ny = -5.0f;
	pVerts[14].nz = 3.0f;


		// apex
	pVerts[15].txt = 3.05f;
	pVerts[15].x = 0.0f;
	pVerts[15].y = 1.0f;
	pVerts[15].z = 0.0f;
	pVerts[15].u = 0.5f;
	pVerts[15].v = 0.5f;
	pVerts[15].nx = 0.0f;
	pVerts[15].ny = 1.0f;
	pVerts[15].nz = 0.0f;

	// left front
	pVerts[16].txt = 3.05f;
	pVerts[16].x = -1.0f;
	pVerts[16].y = -1.0f;
	pVerts[16].z = -1.0f;
	pVerts[16].u = 0.0f;
	pVerts[16].v = 0.0f;
	pVerts[16].nx = -3.0f;
	pVerts[16].ny = -5.0f;
	pVerts[16].nz = -3.0f;

	// right front
	pVerts[17].txt = 3.05f;
	pVerts[17].x = 1.0f;
	pVerts[17].y = -1.0f;
	pVerts[17].z = -1.0f;
	pVerts[17].u = 1.0f;
	pVerts[17].v = 0.0f;
	pVerts[17].nx = 3.0f;
	pVerts[17].ny = -5.0f;
	pVerts[17].nz = -3.0f;

	// left back
	pVerts[18].txt = 3.05f;
	pVerts[18].x = -1.0f;
	pVerts[18].y = -1.0f;
	pVerts[18].z = 1.0f;
	pVerts[18].u = 0.0f;
	pVerts[18].v = 1.0f;
	pVerts[18].nx = -3.0f;
	pVerts[18].ny = -5.0f;
	pVerts[18].nz = 3.0f;

	// right back
	pVerts[19].txt = 3.05f;
	pVerts[19].x = 1.0f;
	pVerts[19].y = -1.0f;
	pVerts[19].z = 1.0f;
	pVerts[19].u = 1.0f;
	pVerts[19].v = 1.0f;
	pVerts[19].nx = 3.0f;
	pVerts[19].ny = -5.0f;
	pVerts[19].nz = 3.0f;

	//// Write the data to a file ----------------------------
	{
	   FileHandle fh;
	   FileError  ferror;

	   // 1) Create a blank header

		  // // write the data
		  AzulFileHdr  azulFileHdr;
		  strcpy_s(azulFileHdr.objName, OBJECT_NAME_SIZE, name);

	   // 2)  Write the data (Header, Buffers) to the file

	   // write the header (Take 1) 

		  // create the file, write the header
		  ferror = File::open(fh, "../Assets/pyramid.azul", FILE_READ_WRITE );
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
		  azulFileHdr.numVerts = 5*4;
   
		  // update the offset
		  ferror = File::tell( fh, azulFileHdr.vertBufferOffset );
		  assert( ferror == FILE_SUCCESS );

	   // write the vertex data
	   ferror = File::write( fh, pVerts, 5 *4* sizeof(VertexStride_VUN) );
	   assert( ferror == FILE_SUCCESS );

	   // update the header: numTriList, triListBufferOffset

		  // update the number of verts
		  azulFileHdr.numTriangles = 6;

		  // update the offset
		  ferror = File::tell( fh, azulFileHdr.triangleListBufferOffset );
		  assert( ferror == FILE_SUCCESS );

	   // write the triListBuffer data
	   ferror = File::write( fh, tlist, 6 * sizeof(TriangleIndex) );
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

}