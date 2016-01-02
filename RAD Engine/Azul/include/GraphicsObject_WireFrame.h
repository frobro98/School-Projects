#ifndef GRAPHICS_OBJECT_WIRE_FRAME_H
#define GRAPHICS_OBJECT_WIRE_FRAME_H

#include "Azul.h"

class GraphicsObjectWireFrame :public GraphicsObject
{
public:
	GraphicsObjectWireFrame(Model *model);
	virtual void Render() override;

	Vect *getColor();

// data:
	Vect color;
};


#endif