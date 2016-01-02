#include "Azul.h"


void RenderMaterial::Process(  GraphicsObject *p )
{
	this->State(p);
	this->Draw(p);
}

