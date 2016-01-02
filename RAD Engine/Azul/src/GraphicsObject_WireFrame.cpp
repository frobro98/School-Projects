#include <assert.h>
#include "Azul.h"

GraphicsObjectWireFrame::GraphicsObjectWireFrame(Model *model)
	: GraphicsObject(model,RenderMan::GetRender( RenderMaterial::WireFrame)),
	color(0.0f,0.0f, 1.0)
{

}

void GraphicsObjectWireFrame::Render()
{
	pRender->Process( this );
}


Vect *GraphicsObjectWireFrame::getColor() 
{
	return &color;
}

