#include <assert.h>
#include "Azul.h"

RenderMaterial *RenderMan::GetRender( RenderMaterial::RenderType type)
{
	RenderMan *pRenderMan = RenderMan::privInstance();
	
	RenderMaterial *p = 0;
	switch( type )
	{
	case RenderMaterial::FlatTexture:
		p = &pRenderMan->renderFlatTexture;
		break;
	case RenderMaterial::WireFrame:
		p = &pRenderMan->renderWireFrame;
		break;
	case RenderMaterial::ColorNoTexture:
		p = &pRenderMan->renderColorNoTexture;
		break;

	default:
		assert(0);
	}

	assert(p);
	return p;
}

RenderMan::RenderMan()
{
}

RenderMan::~RenderMan()
{
}

RenderMan *RenderMan::privInstance()
{
	static RenderMan renderMan;
	return &renderMan;
}

