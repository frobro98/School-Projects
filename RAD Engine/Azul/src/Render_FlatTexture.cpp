#include <assert.h>
#include "Azul.h"
          
RenderFlatTexture::RenderFlatTexture()
: type( RenderMaterial::FlatTexture )
{
}

void RenderFlatTexture::State( GraphicsObject *p )
{	
	GraphicsObjectFlatTexture *pGObj = (GraphicsObjectFlatTexture *)p;
	// Get camera
	Camera *pCamera = CameraMan::GetCurrent();

	// Bind the texture  (have to be locations 0-3) to allow shader to work
	glActiveTexture(GL_TEXTURE0);
	glBindTexture( GL_TEXTURE_2D, pGObj->pTexture0->texID );
	glActiveTexture(GL_TEXTURE1);
	glBindTexture( GL_TEXTURE_2D, pGObj->pTexture1->texID );
	glActiveTexture(GL_TEXTURE2);
	glBindTexture( GL_TEXTURE_2D, pGObj->pTexture2->texID );
	glActiveTexture(GL_TEXTURE3);
	glBindTexture( GL_TEXTURE_2D, pGObj->pTexture3->texID );

	// calculated model view
	Matrix ModelViewProj = pGObj->getWorld() * pCamera->getViewMatrix() * pCamera->getProjMatrix();

	// Use the stock shader
	ShaderMan::Instance()->UseStockShader(GLT_SHADER_TEXTURE_REPLACE, 
										  &ModelViewProj, 
										  0);
}

void RenderFlatTexture::Draw( GraphicsObject *p )
{	     
	GraphicsObjectFlatTexture *pGObj = (GraphicsObjectFlatTexture *)p;
	// set the vao
	glBindVertexArray(pGObj->getModel()->vao);
	
	//  render primitives from array data, start from offset 0 (last param)
	glDrawElements(GL_TRIANGLES, pGObj->getModel()->numTris * 3, GL_UNSIGNED_INT, 0);   
}


