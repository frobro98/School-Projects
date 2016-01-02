
#ifndef SPACESHIP_H
#define SPACESHIP_H

#include "..\RAD\GameObject.h"
class Cottage;

class SpaceShip : public GameObject
{
public:
	SpaceShip(Model* const mod, Texture* const tex);
	SpaceShip(const Vect& pos, const Vect& rot);
	~SpaceShip();

	void Alarm0() override;
	void Alarm1() override;
	void Alarm2() override;

	void collision(Collidable* c) override;
	void collision(Cottage* ws);

	void keyPressed(Inputs input, bool shiftKey, bool altKey, bool ctrlKey) override;
	void keyDown(Inputs input, bool shiftKey, bool altKey, bool ctrlKey) override;

	void update() override;
	void draw() override;
	void destroy() override;

private:

	GraphicsObjectFlatTexture* gObj;

	float rotAngle;
};

#endif //SPACESHIP_H