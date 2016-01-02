#include <assert.h>
#include "GraphicsObject_ColorNoTexture.h"

GraphicsObjectColorNoTexture::GraphicsObjectColorNoTexture(Model *model)
: GraphicsObject(model, RenderMan::GetRender( RenderMaterial::ColorNoTexture)  )
{

}

void GraphicsObjectColorNoTexture::Render() 
{
	pRender->Process( this );
}