using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Cross : BombBehavior
    {
        public Cross()
            : base()
        {
        }

        public override void updateBehavior(ProxySprite sprite)
        {
            float sy = sprite.getScaleY();
            sprite.setScale(sprite.getScaleX(), sy * -1f);
        }
    }
}
