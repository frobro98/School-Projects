
#include "DrawableManager.h"
#include "Drawable.h"

DrawableManager* DrawableManager::dmInstance = 0;

DrawableManager::~DrawableManager()
{
	dList.clear();
}

void DrawableManager::registerDrawable(Drawable* const dObj)
{
	instance().dList.push_back(dObj);
}

void DrawableManager::deregisterDrawable(Drawable* const dObj)
{
	instance().dList.remove(dObj);
}

void DrawableManager::Draw()
{
	DrawList::const_iterator it = dList.cbegin();
	while(it != dList.cend())
	{
		(*it)->draw();
		it++;
	}
}