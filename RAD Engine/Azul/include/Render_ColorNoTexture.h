#ifndef RENDER_COLOR_NO_TEXTURE_H
#define RENDER_COLOR_NO_TEXTURE_H

#include "Azul.h"
class GraphicsObjectColorNoTexture;

class RenderColorNoTexture: public RenderMaterial
{
public:
	RenderColorNoTexture();

private:
	void State( GraphicsObject *p) override;
	void Draw( GraphicsObject *p) override;

	RenderType type;
};

#endif