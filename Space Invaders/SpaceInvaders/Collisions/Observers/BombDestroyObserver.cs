using System;

namespace SpaceInvaders
{
    class BombDestroyObserver : Observer
    {

        public BombDestroyObserver()
            : base()
        {
        }

        public override void notify()
        {
            if (subj.GameObj1 is Bomb)
            {
                DestroyManager.attach(subj.GameObj1);
            }
            else
            {
                DestroyManager.attach(subj.GameObj2);
            }
        }
    }
}
