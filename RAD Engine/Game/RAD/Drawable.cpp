
#include "Drawable.h"
#include "Scene.h"
#include "SceneManager.h"
#include "DrawableManager.h"

Drawable::Drawable()
{
	SceneManager::getCurrScene()->getDrawManager()->registerDrawable(this);
}

Drawable::~Drawable()
{
}