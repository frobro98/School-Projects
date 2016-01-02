#ifndef GRAPHICS_OBJECT_FLAT_TEXTURE_H
#define GRAPHICS_OBJECT_FLAT_TEXTURE_H

#include "Azul.h"

class GraphicsObjectFlatTexture :public GraphicsObject
{
public:
	GraphicsObjectFlatTexture(Model *model, Texture *text0, Texture *text1=0,Texture *text2=0,Texture *text3=0);
	virtual void Render() override;

// data:
	Texture			*pTexture0;
	Texture			*pTexture1;
	Texture			*pTexture2;
	Texture			*pTexture3;

};
#endif