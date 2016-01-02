#include <assert.h>

#include "Azul.h"


Model::Model()
{
}

Model::~Model()
{
	// clean up GPU buffers
}

Model *GpuModel::Create( const char * const _modelName )
{
	GpuModel *pGpuModel = GpuModel::privGetInstance();

	Model *pModel = new Model();
	assert(pModel);
	pGpuModel->privCreateVAO( pModel, _modelName );

	return pModel;
}

char *Model::getTextureName(int index)
{
	assert( index < this->numTextures );
	assert( this->textNames );

	char *pTextureName = this->textNames;
	for( int i=0; i < this->numTextures; i++)
	{
		if( i == index )
		{
			break;
		}
		else
		{
			pTextureName += strlen(pTextureName)+1;
		}
	}

	return pTextureName;
}

Vect * Model::getVectList(void)
{
	return this->pVect;
}
		
TriangleIndex *Model::getTriangleList(void)
{
	return this->pTriList;
}

void GpuModel::privCreateVAO( Model * const pModel, const char * const _modelName )
{
	// Read from file
	FileHandle fh;
	FileError  ferror;

	ferror = File::open(fh, _modelName, FILE_READ );
	assert( ferror == FILE_SUCCESS );

	// write the data
	AzulFileHdr  azulFileHdr;

	// Read the header
	ferror = File::read( fh, &azulFileHdr, sizeof(AzulFileHdr) );
	assert( ferror == FILE_SUCCESS );

	// fill model data
	pModel->numTris = azulFileHdr.numTriangles;
	pModel->numVerts = azulFileHdr.numVerts;
	pModel->numTextures = azulFileHdr.numTextures;
	pModel->center = azulFileHdr.center;
	pModel->radius = azulFileHdr.radius;
	pModel->minPointAABB = azulFileHdr.minPointAABB;
	pModel->maxPointAABB = azulFileHdr.maxPointAABB;

	// load the texture names
	pModel->textNames =  (char *)malloc( azulFileHdr.textureNamesInBytes);

		// seek to the location
		ferror = File::seek( fh, FILE_SEEK_BEGIN, azulFileHdr.textureNamesOffset);
		assert( ferror == FILE_SUCCESS );

		// read it
		ferror = File::read( fh, pModel->textNames, azulFileHdr.textureNamesInBytes );
		assert( ferror == FILE_SUCCESS );

	// create the vertex buffer
	VertexStride_VUN *pVerts = new VertexStride_VUN[ azulFileHdr.numVerts ];

   // load the verts

		// seek to the location
		ferror = File::seek( fh, FILE_SEEK_BEGIN, azulFileHdr.vertBufferOffset );
		assert( ferror == FILE_SUCCESS );

		// read it
		ferror = File::read( fh, pVerts, azulFileHdr.numVerts * sizeof(VertexStride_VUN) );
		assert( ferror == FILE_SUCCESS );

		// Copy data to vect for game access
		pModel->pVect = new Vect[azulFileHdr.numVerts];
		for( int i=0; i<azulFileHdr.numVerts; i++)
		{
			pModel->pVect[i].set(pVerts[i].x, pVerts[i].y, pVerts[i].z);
		}

   // create the triLists buffer
   TriangleIndex	*tlist = new TriangleIndex[ azulFileHdr.numTriangles ];

   // load the triList

		// seek to the location
		ferror = File::seek( fh, FILE_SEEK_BEGIN, azulFileHdr.triangleListBufferOffset );
		assert( ferror == FILE_SUCCESS );

		// read it
		ferror = File::read( fh, tlist, azulFileHdr.numTriangles * sizeof(TriangleIndex)  );
		assert( ferror == FILE_SUCCESS );

		// Copy data to TriList for game access
		pModel->pTriList = new TriangleIndex[ azulFileHdr.numTriangles ];
		for( int i=0; i<azulFileHdr.numTriangles; i++)
		{
			pModel->pTriList[i] = tlist[i];
		}

	// close
	ferror = File::close( fh );
	assert( ferror == FILE_SUCCESS );

	// Now everything is loaded (vertList and triList)
	// Bind and load to GPU

	/* Allocate and assign a Vertex Array Object to our handle */
	glGenVertexArrays(1, &pModel->vao);
 
	/* Bind our Vertex Array Object as the current used object */
	glBindVertexArray(pModel->vao);
  
	/* Allocate and assign two Vertex Buffer Objects to our handle */
	glGenBuffers(2, &pModel->vbo[0]);
 
    // Load the combined data: ---------------------------------------------------------

		/* Bind our first VBO as being the active buffer and storing vertex attributes (coordinates) */
		glBindBuffer(GL_ARRAY_BUFFER, pModel->vbo[0]);
 
		/* Copy the vertex data to our buffer */
		// glBufferData(type, size in bytes, data, usage) 
		glBufferData(GL_ARRAY_BUFFER, sizeof(VertexStride_VUN) * azulFileHdr.numVerts, pVerts, GL_STATIC_DRAW);
		
   // VERTEX data: ---------------------------------------------------------

			// Set Attribute to 0
			//           WHY - 0? and not 1,2,3 (this is tied to the shader attribute, it is defined in GLShaderManager.h)
			//           GLT_ATTRIBUTE_VERTEX = 0

			// Specifies the index of the generic vertex attribute to be enabled
			glEnableVertexAttribArray(0);  

			/* Specify that our coordinate data is going into attribute index 0, and contains 3 floats per vertex */
			// ( GLuint index,  GLint size,  GLenum type,  GLboolean normalized,  GLsizei stride,  const GLvoid * pointer);
			void *offsetVert = (void *)((unsigned int)&pVerts[0].x - (unsigned int)pVerts);
			glVertexAttribPointer(0, 3, GL_FLOAT,  GL_FALSE, sizeof(VertexStride_VUN), offsetVert);

	// Color data: ---------------------------------------------------------

			// Set Attribute to 1
			//           WHY - 1? and not 1,2,3 (this is tied to the shader attribute, it is defined in GLShaderManager.h)
			//           GLT_ATTRIBUTE_COLOR = 1

			// Specifies the index of the generic Color attribute to be enabled
			glEnableVertexAttribArray(1);  

			/* Specify that our coordinate data is going into attribute index 0, and contains 3 floats per vertex */
			// ( GLuint index,  GLint size,  GLenum type,  GLboolean normalized,  GLsizei stride,  const GLvoid * pointer);
			void *offsetColor = (void *)((unsigned int)&pVerts[0].r - (unsigned int)pVerts);
			glVertexAttribPointer(1, 3, GL_FLOAT,  GL_FALSE, sizeof(VertexStride_VUN), offsetColor);
		
    // Texture data: ---------------------------------------------------------
     
			// Set Attribute to 3
			//           WHY - 3? and not 1,2,3 (this is tied to the shader attribute, it is defined in GLShaderManager.h)
			//           GLT_ATTRIBUTE_TEXTURE0 = 3

			// Specifies the index of the generic vertex attribute to be enabled
			glEnableVertexAttribArray(3);  

			/* Specify that our coordinate data is going into attribute index 3, and contains 2 floats per vertex */
			// ( GLuint index,  GLint size,  GLenum type,  GLboolean normalized,  GLsizei stride,  const GLvoid * pointer);
			void *offsetTex = (void *)((unsigned int)&pVerts[0].u - (unsigned int)pVerts);
			glVertexAttribPointer(3, 3, GL_FLOAT,  GL_FALSE, sizeof(VertexStride_VUN), offsetTex);

      // Normal data: ---------------------------------------------------------
		
			// Set Attribute to 2
			//           WHY - 2? and not 1,2,3 (this is tied to the shader attribute, it is defined in GLShaderManager.h)
			//           GLT_ATTRIBUTE_NORMAL = 2

			// Specifies the index of the generic vertex attribute to be enabled
			glEnableVertexAttribArray(2);  

			/* Specify that our coordinate data is going into attribute index 3, and contains 2 floats per vertex */
			// ( GLuint index,  GLint size,  GLenum type,  GLboolean normalized,  GLsizei stride,  const GLvoid * pointer);
			void *offsetNorm = (void *)((unsigned int)&pVerts[0].nx - (unsigned int)pVerts);
			glVertexAttribPointer(2, 3, GL_FLOAT,  GL_FALSE, sizeof(VertexStride_VUN), offsetNorm);
		 
      // Load the index data: ---------------------------------------------------------
	
			/* Bind our 2nd VBO as being the active buffer and storing index ) */
			glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, pModel->vbo[1]);

			/* Copy the index data to our buffer */
			// glBufferData(type, size in bytes, data, usage) 
			glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof(TriangleIndex)*azulFileHdr.numTriangles, tlist, GL_STATIC_DRAW);

	// Clean up temporary buffers

	delete[] pVerts;
	delete[] tlist;

}

void GpuModel::Unload( void )
{
	// todo: cleverly remove all pending models from the GPU
}

GpuModel *GpuModel::privGetInstance( void )
{
	// this is the real storage lies
	static GpuModel modelMan;

	return ( &modelMan );
}

GpuModel::GpuModel(void)
{
	this->modelCount = 0;
}