using System;

namespace SpaceInvaders
{
    abstract class HUDStrategy
    {
        ProxySprite spr;

        public HUDStrategy(ProxySprite s)
        {
            spr = s;
        }

        public virtual void draw()
        {
            spr.update();
            spr.draw();
        }
    }
}
