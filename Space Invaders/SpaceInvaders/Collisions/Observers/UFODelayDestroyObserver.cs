using System;

namespace SpaceInvaders
{
    class UFODelayDestroyObserver : Observer
    {
        public UFODelayDestroyObserver()
        {
        }

        public override void notify()
        {
            if (subj.GameObj1 is UFO)
            {
                TimeEventManager.add(1f, new RemoveUFO((UFO)subj.GameObj1));
            }
            else
            {
                TimeEventManager.add(1f, new RemoveUFO((UFO)subj.GameObj2));
            }
        }
    }
}
