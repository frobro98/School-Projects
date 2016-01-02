
#ifndef PLANE_H
#define PLANE_H

#include "..\RAD\GameObject.h"

class GraphicsObjectFlatTexture;

class Plane : public GameObject
{
public:
	Plane();
	~Plane();

	void update() override;
	void draw() override;
	void destroy() override;

private:
	GraphicsObjectFlatTexture* go;
};


#endif // PLANE_H