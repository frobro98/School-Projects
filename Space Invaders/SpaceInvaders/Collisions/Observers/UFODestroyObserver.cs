using System;

namespace SpaceInvaders
{
    class UFODestroyObserver : Observer
    {
        public override void notify()
        {
            if (subj.GameObj1 is UFO)
            {
                DestroyManager.attach(subj.GameObj1);
            }
            else if (subj.GameObj2 is UFO)
            {
                DestroyManager.attach(subj.GameObj2);
            }
        }
    }
}
