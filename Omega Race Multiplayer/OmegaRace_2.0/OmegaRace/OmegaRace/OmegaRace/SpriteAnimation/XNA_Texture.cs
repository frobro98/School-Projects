using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;


namespace SpriteAnimation
{
    abstract class XNA_Texture
    {
        

        public XNA_Texture()
        {
            
        }

    }


    class XNA_Text2D : XNA_Texture
    {
        public Texture2D src;

        public XNA_Text2D()
        {
            
        }
        
    }

    class XNA_Font : XNA_Texture
    {
        public SpriteFont src;

        public XNA_Font()
        {

        }
    }
}
