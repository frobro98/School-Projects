#ifndef RENDER_FLAT_TEXTURE_H
#define RENDER_FLAT_TEXTURE_H

#include "Azul.h"
class GraphicsObjectFlatTexture;

class RenderFlatTexture: public RenderMaterial
{
public:
	RenderFlatTexture();

private:
	void State( GraphicsObject *p) override;
	void Draw( GraphicsObject *p) override;

	RenderType type;
};

#endif