#include <assert.h>
#include "Azul.h"
          
RenderColorNoTexture::RenderColorNoTexture()
: type( RenderMaterial::ColorNoTexture )
{
}

void RenderColorNoTexture::State( GraphicsObject *p )
{	
	GraphicsObjectColorNoTexture *pGObj = (GraphicsObjectColorNoTexture *)p;

	// Get camera
	Camera *pCamera = CameraMan::GetCurrent();

	// calculated model view
	Matrix ModelViewProj = pGObj->getWorld() * pCamera->getViewMatrix() * pCamera->getProjMatrix();

	// Use the stock shader
	ShaderMan::Instance()->UseStockShader(GLT_SHADER_COLOR_NO_TEXTURE, 
										  &ModelViewProj);
}

void RenderColorNoTexture::Draw( GraphicsObject *p )
{	     
	GraphicsObjectColorNoTexture *pGObj = (GraphicsObjectColorNoTexture *)p;
	// set the vao
	glBindVertexArray(pGObj->getModel()->vao);
	
	//  render primitives from array data, start from offset 0 (last param)
	glDrawElements(GL_TRIANGLES, pGObj->getModel()->numTris * 3, GL_UNSIGNED_INT, 0);   
}


