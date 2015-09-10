using System;

namespace SpaceInvaders
{
    class AlienDeathObserver : Observer
    {
        public AlienDeathObserver()
            : base()
        {
        }

        public override void notify()
        {
            if (subj.GameObj1 is Alien)
            {
                DestroyManager.attach(subj.GameObj1);
            }
            else
            {
                DestroyManager.attach(subj.GameObj2); 
            }

            --GameManager.TotalAliens;
            GameManager.MoveFrameTime -= .0169f;
        }

    }
}
