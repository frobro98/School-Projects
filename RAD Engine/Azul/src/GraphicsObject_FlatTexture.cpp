#include <assert.h>
#include "GraphicsObject_FlatTexture.h"

GraphicsObjectFlatTexture::GraphicsObjectFlatTexture(Model *model, Texture *_text0, Texture *_text1,Texture *_text2,Texture *_text3)
: GraphicsObject(model, RenderMan::GetRender( RenderMaterial::FlatTexture)  )
{
	// load texture if valid otherwise load hotpink
	this->pTexture0 = _text0 ? _text0 : GpuTexture::DefaultTexture();
	this->pTexture1 = _text1 ? _text1 : GpuTexture::DefaultTexture();
	this->pTexture2 = _text2 ? _text2 : GpuTexture::DefaultTexture();
	this->pTexture3 = _text3 ? _text3 : GpuTexture::DefaultTexture();
}

void GraphicsObjectFlatTexture::Render() 
{
	pRender->Process( this );
}

