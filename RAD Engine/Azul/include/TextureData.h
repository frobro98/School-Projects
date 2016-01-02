#ifndef TEXTURE_DATA_H
#define TEXTURE_DATA_H

#include <string.h>
#include "GLTools.h"

#define TEXTURE_NAME_SIZE  32

struct TextureData
{
	TextureData( const char * const _textureName, GLenum _target = GL_TEXTURE_2D,GLenum _minFilter =GL_LINEAR,GLenum _magFilter =GL_LINEAR,GLenum _wrapMode = GL_CLAMP_TO_EDGE)
	: target(_target), minFilter(_minFilter), magFilter(_magFilter), wrapMode(_wrapMode)
	{
			strncpy_s( this->textName, TEXTURE_NAME_SIZE, _textureName, _TRUNCATE);
	}

	~TextureData()
	{
		// do nothing
	}

	// data: ----------------------------------------------------
	char        textName[ TEXTURE_NAME_SIZE ]; 
	GLenum      target;     // texture target
	GLenum      minFilter;  // min filters
	GLenum      magFilter;	// mag filter
	GLenum      wrapMode;   // texture wrap moode

private:
	TextureData()
	{
		// should not be called
	}
};


#endif