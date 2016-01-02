#ifndef GRAPHICS_OBJECT_H
#define GRAPHICS_OBJECT_H

#include "Azul.h"
class RenderMaterial;

class GraphicsObject 
{
public:
	virtual void Render() = 0;

	GraphicsObject(Model *model, RenderMaterial *render);

	Model *getModel() const;
	RenderMaterial *getRender() const;

	Matrix &getWorld() ;
	void setWorld( Matrix &_world);

protected:
	Model			*pModel;
	RenderMaterial	*pRender;
	Matrix			world;

};

#endif