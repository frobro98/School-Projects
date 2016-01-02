using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using OmegaRace;

namespace SpriteAnimation
{
    

    class Image : ManLink
    {
        // Texture Coords
        public Rectangle sourceRec;

        // Texture itself
        public Text texture;
        public ImageEnum ImageName;

        

        public Image(ImageEnum _name, int x, int y, int w, int h, Text text)
        {
            sourceRec = new Rectangle(x, y, w, h);
            texture = text;
            ImageName = _name;
        }
        public Image()
        {
            sourceRec = new Rectangle();
            texture = null;
            ImageName = ImageEnum.Not_Initialized;
        }

        public override Enum getName()
        {
            return this.ImageName;
        }
        

    }
}
