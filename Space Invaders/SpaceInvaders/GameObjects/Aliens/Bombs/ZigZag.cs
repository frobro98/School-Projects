using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ZigZag : BombBehavior
    {
        public ZigZag()
            : base()
        {
        }

        public override void updateBehavior(ProxySprite sprite)
        {
            float sx = sprite.getScaleX();
            sprite.setScale(sx * -1f, sprite.getScaleY());
        }
    }
}
