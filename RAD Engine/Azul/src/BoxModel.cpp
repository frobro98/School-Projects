#include <assert.h>
#include "Azul.h"
#include "BoxModel.h"

#include <string>
#include <vector>
#include <algorithm>


// Creates a bounding box, (0,0,0) center, height,width,length = 1
void boxCreateModel()
{
	// purposefully empty to be consistent
	std::vector<std::string> FBX_textNames;

	const int NUM_BOX_VERTS = 8;
	const int NUM_BOX_TRIANGLES = 12;

	TriangleIndex	tlist[NUM_BOX_TRIANGLES];
	VertexStride_VUN pVerts[NUM_BOX_VERTS];
  
	// top  - check
	tlist[0].v0 = 0;
	tlist[0].v1 = 1;
	tlist[0].v2 = 2;

	tlist[1].v0 = 2;
	tlist[1].v1 = 3;
	tlist[1].v2 = 0;

	// front - check
	tlist[2].v0 = 3;
	tlist[2].v1 = 2;
	tlist[2].v2 = 4;

	tlist[3].v0 = 4;
	tlist[3].v1 = 5;
	tlist[3].v2 = 3;

	// Right - check
	tlist[4].v0 = 2;
	tlist[4].v1 = 1;
	tlist[4].v2 = 6;

	tlist[5].v0 = 6;
	tlist[5].v1 = 4;
	tlist[5].v2 = 2;

	// left - check
	tlist[6].v0 = 0;
	tlist[6].v1 = 3;
	tlist[6].v2 = 5;

	tlist[7].v0 = 5;
	tlist[7].v1 = 7;
	tlist[7].v2 = 0;

	// Back - check
	tlist[8].v0 = 1;
	tlist[8].v1 = 0;
	tlist[8].v2 = 7;

	tlist[9].v0 = 7;
	tlist[9].v1 = 6;
	tlist[9].v2 = 1;

	// Bottom - check
	tlist[10].v0 = 5;
	tlist[10].v1 = 4;
	tlist[10].v2 = 6;

	tlist[11].v0 = 6;
	tlist[11].v1 = 7;
	tlist[11].v2 = 5;


	pVerts[0].txt = 0.05f;
	pVerts[0].x = -1.0f * 0.5f;
	pVerts[0].y = 1.0f * 0.5f;
	pVerts[0].z = -1.0f * 0.5f;
	pVerts[0].nx = 0.0f;
	pVerts[0].ny = 0.0f;
	pVerts[0].nz = 0.0f;
	pVerts[0].u = 0.0f;
	pVerts[0].v = 0.0f;

	pVerts[1].txt = 0.05f;
	pVerts[1].x = 1.0f * 0.5f;
	pVerts[1].y = 1.0f * 0.5f;
	pVerts[1].z = -1.0f * 0.5f;
	pVerts[1].nx = 0.0f;
	pVerts[1].ny = 0.0f;
	pVerts[1].nz = 0.0f;
	pVerts[1].u = 0.0f;
	pVerts[1].v = 0.0f;

	pVerts[2].txt = 0.05f;
	pVerts[2].x = 1.0f * 0.5f;
	pVerts[2].y = 1.0f * 0.5f;
	pVerts[2].z = 1.0f * 0.5f;
	pVerts[2].nx = 0.0f;
	pVerts[2].ny = 0.0f;
	pVerts[2].nz = 0.0f;
	pVerts[2].u = 0.0f;
	pVerts[2].v = 0.0f;

	pVerts[3].txt = 0.05f;
	pVerts[3].x = -1.0f * 0.5f;
	pVerts[3].y = 1.0f * 0.5f;
	pVerts[3].z = 1.0f * 0.5f;
	pVerts[3].nx = 0.0f;
	pVerts[3].ny = 0.0f;
	pVerts[3].nz = 0.0f;
	pVerts[3].u = 0.0f;
	pVerts[3].v = 0.0f;


	
	pVerts[7].txt = 0.05f;
	pVerts[7].x = -1.0f * 0.5f;
	pVerts[7].y = -1.0f * 0.5f;
	pVerts[7].z = -1.0f * 0.5f;
	pVerts[7].nx = 0.0f;
	pVerts[7].ny = 0.0f;
	pVerts[7].nz = 0.0f;
	pVerts[7].u = 0.0f;
	pVerts[7].v = 0.0f;


	pVerts[6].txt = 0.05f;
	pVerts[6].x = 1.0f * 0.5f;
	pVerts[6].y = -1.0f * 0.5f;
	pVerts[6].z = -1.0f * 0.5f;
	pVerts[6].nx = 0.0f;
	pVerts[6].ny = 0.0f;
	pVerts[6].nz = 0.0f;
	pVerts[6].u = 0.0f;
	pVerts[6].v = 0.0f;

	pVerts[4].txt = 0.05f;
	pVerts[4].x = 1.0f * 0.5f;
	pVerts[4].y = -1.0f * 0.5f;
	pVerts[4].z = 1.0f * 0.5f;
	pVerts[4].nx = 0.0f;
	pVerts[4].ny = 0.0f;
	pVerts[4].nz = 0.0f;
	pVerts[4].u = 0.0f;
	pVerts[4].v = 0.0f;


	pVerts[5].txt = 0.05f;
	pVerts[5].x = -1.0f * 0.5f;
	pVerts[5].y = -1.0f * 0.5f;
	pVerts[5].z = 1.0f * 0.5f;
	pVerts[5].nx = 0.0f;
	pVerts[5].ny = 0.0f;
	pVerts[5].nz = 0.0f;
	pVerts[5].u = 0.0f;
	pVerts[5].v = 0.0f;

	//// Write the data to a file ----------------------------
	{
	   FileHandle fh;
	   FileError  ferror;

	   // 1) Create a blank header

		  // // write the data
		  AzulFileHdr  azulFileHdr;
		  strcpy_s(azulFileHdr.objName, OBJECT_NAME_SIZE, "BoundingSphere");

	   // 2)  Write the data (Header, Buffers) to the file

	   // write the header (Take 1) 

		  // create the file, write the header
		  ferror = File::open(fh, "../Assets/BoundingBox.azul", FILE_READ_WRITE );
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
		  azulFileHdr.numVerts = NUM_BOX_VERTS;
   
		  // update the offset
		  ferror = File::tell( fh, azulFileHdr.vertBufferOffset );
		  assert( ferror == FILE_SUCCESS );

	   // write the vertex data
	   ferror = File::write( fh, pVerts, NUM_BOX_VERTS * sizeof(VertexStride_VUN) );
	   assert( ferror == FILE_SUCCESS );

	   // update the header: numTriList, triListBufferOffset

		  // update the number of verts
		  azulFileHdr.numTriangles = NUM_BOX_TRIANGLES;

		  // update the offset
		  ferror = File::tell( fh, azulFileHdr.triangleListBufferOffset );
		  assert( ferror == FILE_SUCCESS );

	   // write the triListBuffer data
	   ferror = File::write( fh, tlist, NUM_BOX_TRIANGLES * sizeof(TriangleIndex) );
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