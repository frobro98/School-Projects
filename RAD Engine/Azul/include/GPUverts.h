#ifndef GPU_VERTS_H
#define GPU_VERTS_H


struct VertexStride_VUN
{
	float x;    // Vert - V
	float y;
	float z;

	float u;    // UV tex coor - U
	float v;
	float txt;

	float nx;   // Norm verts - N
	float ny;
	float nz;

	float r;
	float g;
	float b;
};


struct TriangleIndex
{
	unsigned int v0;
	unsigned int v1;
	unsigned int v2;
};


#endif