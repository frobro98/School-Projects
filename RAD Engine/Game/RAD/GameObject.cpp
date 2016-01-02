
#include "GameObject.h"
#include "UpdateableManager.h"
#include "DrawableManager.h"
#include "Azul.h"

GameObject::GameObject()
	:Drawable(), Inputable(), Updateable(), Alarmable(), Collidable()
{
	this->world = colWorld;
}

GameObject::~GameObject()
{
	world = 0;
}

void GameObject::predestruction()
{
	UpdateableManager::deregisterUpdateable(this);
	DrawableManager::deregisterDrawable(this);
}

void GameObject::prerecycling()
{
	UpdateableManager::registerUpdateable(this);
	DrawableManager::registerDrawable(this);
}

Vect GameObject::getPos()
{
	return pos;
}

Matrix GameObject::getRot()
{
	return rot;
}

Matrix GameObject::getScale()
{
	return scale;
}

void GameObject::setWorld(Matrix* world)
{
	this->world = world;

}