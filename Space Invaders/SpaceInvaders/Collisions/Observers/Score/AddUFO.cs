using System;


namespace SpaceInvaders
{
    class AddUFO : Observer
    {
        public override void notify()
        {
            ScoreManager.killedUFO();
        }
    }
}
