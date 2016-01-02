#ifndef SHADER_MAN_H
#define SHADER_MAN_H

#include "GLTools.h"

class ShaderMan
{
public:
	static GLShaderManager *Instance();

private:
	static GLShaderManager *privInstance();

};

#endif