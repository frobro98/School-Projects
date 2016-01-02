#include <assert.h>
#include "Azul.h"

RenderWireFrame::RenderWireFrame()
: type( RenderMaterial::WireFrame )
{
}

void RenderWireFrame::State( GraphicsObject *p )
{
	GraphicsObjectWireFrame *pGObj = (GraphicsObjectWireFrame *)p;
	// Get camera
	Camera *pCamera = CameraMan::GetCurrent();

	// calculated model view
	Matrix ModelViewProj = pGObj->getWorld() * pCamera->getViewMatrix() * pCamera->getProjMatrix();

	// Use the stock shader
	ShaderMan::Instance()->UseStockShader(GLT_SHADER_FLAT, 
								&ModelViewProj, 
								pGObj->getColor());
}

void RenderWireFrame::Draw( GraphicsObject *p ) 
{	     
	GraphicsObjectWireFrame *pGObj = (GraphicsObjectWireFrame *)p;
	// set the vao
	glBindVertexArray(pGObj->getModel()->vao);
	
	// Store state
		int polyMode[2];
		glGetIntegerv( GL_POLYGON_MODE, polyMode);
		int cullMode[1];
		glGetIntegerv( GL_CULL_FACE_MODE, cullMode);

	glPolygonMode(GL_FRONT_AND_BACK, GL_LINE);
	glDisable(GL_CULL_FACE);

	//  render primitives from array data, start from offset 0 (last param)
	glDrawElements(GL_TRIANGLES, pGObj->getModel()->numTris*3 , GL_UNSIGNED_INT, 0);   

	// Restore state
		glPolygonMode(GL_FRONT_AND_BACK, polyMode[1]);
		glEnable(cullMode[0]);
}

