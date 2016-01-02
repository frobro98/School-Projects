#ifndef GPU_MODEL_H
#define GPU_MODEL_H

class Vect;
struct TriangleIndex;

class Model
{
public:
	Model();
	~Model();

	// Model information
		int numTextures;
		int numVerts;
		int numTris;

	// Bounding Sphere: bounding volume
		Vect center;
		float radius;

	// AABB: axis aligned bounding box
		// Specifies the minimum extent of this AABB in the world space x, y and z axes.
		Vect minPointAABB;
		// Specifies the maximum extent of this AABB in the world space x, y and z axes
		Vect maxPointAABB;

	// Get the texture name
		char *getTextureName(int index);

	// Get access
		Vect *getVectList(void);
		TriangleIndex *getTriangleList(void);

	// Data that should be private below ---------------------------
	Vect *pVect;
	TriangleIndex *pTriList;


	char *textNames;

	unsigned int vao;
	unsigned int vbo[2];
};


class GpuModel
{
public:
   static Model *Create( const char * const _modelName );
   static void Unload( void );

private:
   static GpuModel *privGetInstance( void );
   void	  privCreateVAO( Model * const pModel, const char * const _modelName );

   GpuModel(void);

   // single link list of all the Models
   int         modelCount; 
};
#endif