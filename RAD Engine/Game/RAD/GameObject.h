

#ifndef GAMEOBJECT_H
#define GAMEOBJECT_H

#include <iostream>

#include "Inputable.h"
#include "Drawable.h"
#include "Updateable.h"
#include "Alarmable.h"
#include "Collidable.h"
#include "Destroyable.h"

struct Texture;
class Matrix;

class GameObject : public Drawable, 
				   public Inputable, 
				   public Updateable, 
				   public Alarmable,
				   public Collidable,
				   public Destroyable
{
public:
	GameObject();
	virtual ~GameObject();

	void setWorld(Matrix* world);
	Matrix* getWorld()
	{
		return world;
	}

	void destroy() override{};
	void predestruction() override;
	void prerecycling();

	Vect getPos();
	Matrix getRot();
	Matrix getScale();

protected:
	Vect pos;
	Matrix rot;
	Matrix scale;

	Matrix* world;

};

#endif // GAMEOBJECT_H