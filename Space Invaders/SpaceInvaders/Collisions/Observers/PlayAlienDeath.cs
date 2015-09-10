using System;

namespace SpaceInvaders
{
    class PlayAlienDeath : Observer
    {
        public override void notify()
        {
            SoundManager.playAlienDeath();
        }
    }
}
