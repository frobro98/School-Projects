using System;

namespace SpaceInvaders
{
    class ShieldDissolveObserver : Observer
    {

        public ShieldDissolveObserver()
            : base()
        {
        }

        public override void notify()
        {
            if (subj.GameObj1 is ShieldBlock)
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
