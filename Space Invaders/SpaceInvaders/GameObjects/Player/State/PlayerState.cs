using System;

namespace SpaceInvaders
{
    abstract class PlayerState : State
    {
        public virtual void handle(Context context)
        {

        }

        abstract public float moveLeft();
        abstract public float moveRight();
        abstract public void shootMissile(PlayerShip player, float x, float y);

    }
}
