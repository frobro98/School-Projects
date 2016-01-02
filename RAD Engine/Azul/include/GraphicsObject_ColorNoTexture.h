#ifndef GRAPHICS_OBJECT_COLOR_NO_TEXTURE_H
#define GRAPHICS_OBJECT_COLOR_NO_TEXTURE_H

#include "Azul.h"

class GraphicsObjectColorNoTexture :public GraphicsObject
{
public:
	GraphicsObjectColorNoTexture(Model *model);
	virtual void Render() override;

// data:

};
#endif