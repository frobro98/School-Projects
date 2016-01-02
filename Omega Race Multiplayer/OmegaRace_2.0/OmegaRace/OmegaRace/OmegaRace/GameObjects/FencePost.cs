using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpriteAnimation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Box2D.XNA;

namespace CollisionManager
{
    class FencePost : GameObject
    {
        public FencePost(GameObjType _type, Sprite_Proxy _spriteRef)
        {
            type = _type;
            spriteRef = _spriteRef;
        }

        public override void Update()
        {
        }

        public override void doWork(OmegaRace.LocationHdr hdr)
        {
            this.location = hdr.position;
            this.rotation = hdr.rotation;
        }
    }
}
