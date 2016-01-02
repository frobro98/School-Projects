
#ifndef WIRESPHERE_H
#define WIRESPHERE_H

#include "..\RAD\GameObject.h"

class SpaceShip;
class GraphicsObjectWireFrame;

class WireSphere : public GameObject
{
public:
	WireSphere(Model* const mod);
	~WireSphere();

	void collision(Collidable* c) override;
	void collision(SpaceShip* s);

	void Alarm0() override;

	void keyPressed(Inputs input, bool shiftKey, bool altKey, bool ctrlKey) override;

	void update() override;
	void draw() override;
	void destroy() override;

private:

	GraphicsObjectWireFrame* go;

};

#endif // WIRESPHERE_H