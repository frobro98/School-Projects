
#ifndef COTTAGE_H
#define COTTAGE_H

#include "..\RAD\GameObject.h"

class GraphicsObjectFlatTexture;
class SpaceShip;

class Cottage : public GameObject
{
public:

	Cottage();
	~Cottage();

	void collision(Collidable* c){c;};
	void collision(SpaceShip* s);

	void update() override;
	void draw() override;
	void destroy() override;

private:
	GraphicsObjectFlatTexture* go;
};

#endif // COTTAGE_H