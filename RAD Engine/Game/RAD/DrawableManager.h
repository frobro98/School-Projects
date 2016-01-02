
#ifndef DRAWABLEMANAGER_H
#define DRAWABLEMANAGER_H

#include <list>

class Drawable;

class DrawableManager
{
public:

	/**
	 \brief Registers Drawable objects. The GameObject class registers to the 
	 DrawableManager automatically.
	
	 \param drawObj			Drawable object.
	 \ingroup DRAWABLE
	 */
	static void registerDrawable(Drawable* const drawObj);

	/**
	 \brief Deregisters Drawable objects.
	
	 \param	drawObj			Drawable object.
	 \ingroup DRAWABLE
	 */
	static void deregisterDrawable(Drawable* const drawObj);

	void Draw();

private:
	DrawableManager(){};
	~DrawableManager();
	DrawableManager(const DrawableManager&);
	const DrawableManager& operator=(const DrawableManager&);

	static DrawableManager& instance()
	{
		if(dmInstance == 0)
		{
			dmInstance = new DrawableManager();
		}

		return *dmInstance;
	}
	
	typedef std::list<Drawable*> DrawList;

	DrawList dList;
	static DrawableManager* dmInstance;

	friend class Scene;
};

#endif // DRAWABLEMANAGER_H