#include "ShaderMan.h"



GLShaderManager * ShaderMan::Instance()
{
	return ShaderMan::privInstance();
}

GLShaderManager *ShaderMan::privInstance()
{
	static GLShaderManager glShaderMan;
	return &glShaderMan;
}
