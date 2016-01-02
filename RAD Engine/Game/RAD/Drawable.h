
#ifndef DRAWABLE_H
#define DRAWABLE_H

class GraphicsObject;

class Drawable
{
public:

	/**
	 \brief Enables Drawable object to be drawn. A Drawable object, with this
	 method, can be drawn every single frame. 
	 \ingroup DRAWABLE
	 */

	virtual void draw() = 0;

protected:
	Drawable();
	virtual ~Drawable();
};

#endif // DRAWABLE_H