#ifndef RENDER_MATERIAL_H
#define RENDER_MATERIAL_H

#include "Azul.h"

class RenderMaterial
{
public:
enum RenderType
{
	WireFrame,
	FlatTexture,
	ColorNoTexture
};

public:
	virtual void State( GraphicsObject *p) = 0;
	virtual void Draw( GraphicsObject *p) = 0;

	void Process(  GraphicsObject *p );
};


#endif