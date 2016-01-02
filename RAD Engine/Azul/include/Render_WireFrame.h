#ifndef RENDER_WIRE_FRAME_H
#define RENDER_WIRE_FRAME_H

#include "Azul.h"
class GraphicsObjectWireFrame;

class RenderWireFrame: public RenderMaterial
{
public:
	RenderWireFrame();

private:	
	void State( GraphicsObject *p) override;
	void Draw( GraphicsObject *p) override;

	RenderType type;
};

#endif