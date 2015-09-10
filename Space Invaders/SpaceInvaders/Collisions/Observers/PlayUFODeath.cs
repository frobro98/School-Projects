using System;

namespace SpaceInvaders
{
    class PlayUFODeath : Observer
    {
        public override void notify()
        {
            SoundManager.stopUFO();
            SoundManager.playUFODeath();
        }
    }
}
