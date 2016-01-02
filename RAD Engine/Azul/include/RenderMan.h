#ifndef RENDER_MAN_H
#define RENDER_MAN_H

#include "Azul.h"

class RenderMan
{
public:
	static RenderMaterial *GetRender( RenderMaterial::RenderType type);
	~RenderMan();

private:
	static RenderMan *privInstance();
	RenderMan();
	
	// Data
	RenderFlatTexture	 renderFlatTexture;
	RenderWireFrame		 renderWireFrame;
	RenderColorNoTexture renderColorNoTexture;
};


#endif