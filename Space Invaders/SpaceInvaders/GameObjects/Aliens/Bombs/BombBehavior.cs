using System;

namespace SpaceInvaders
{
    abstract class BombBehavior
    {
        public BombBehavior()
        {
        }

        abstract public void updateBehavior(ProxySprite sprite);
    }
}
