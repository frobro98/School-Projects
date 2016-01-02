using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using OmegaRace;

namespace SpriteAnimation
{
    abstract class DisplayObject : ManLink
    {
        //public DisplayObject next;

        public DisplayObject()
        {
        }

        public virtual void Draw(SpriteBatch batch)
        {

        }

        public virtual void Update(GameTime gameTime)
        {
        }

    }
}
