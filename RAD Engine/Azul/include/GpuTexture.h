#ifndef GPU_TEXTURE_H
#define GPU_TEXTURE_H

#include "TextureData.h"

struct Texture
{
   GLuint      texID;
};


class GpuTexture
{
public:
   static Texture *Create( const char * const textNameString );
   static void Unload( void );
   static Texture *DefaultTexture();

private:
   static GpuTexture *privGetInstance( void );
   Texture *privCreate( TextureData textData );
   void   privUnloadTextures( void );

   GpuTexture(void);

   // single link list of all the textureIDs
   Texture	   *pDefaultTexture;
   int         textureCount; 

};


#endif