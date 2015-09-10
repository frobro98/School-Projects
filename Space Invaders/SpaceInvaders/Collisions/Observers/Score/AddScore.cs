using System;

namespace SpaceInvaders
{
    class AddScore : Observer
    {
        public override void notify()
        {
            if (subj.GameObj1 is Alien)
            {
                Alien alien = (Alien)subj.GameObj1;
                if (alien is Octopus)
                {
                    ScoreManager.killedOctopus();
                }
                else if (alien is Crab)
                {
                    ScoreManager.killedCrab();
                }
                else if (alien is Squid)
                {
                    ScoreManager.killedSquid();
                }
            }
            else
            {
                Alien alien = (Alien)subj.GameObj2;
                if (alien is Octopus)
                {
                    ScoreManager.killedOctopus();
                }
                else if (alien is Crab)
                {
                    ScoreManager.killedCrab();
                }
                else if (alien is Squid)
                {
                    ScoreManager.killedSquid();
                }
            }
        }
    }
}
