using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MissileDestroyObserver : Observer
    {

        public override void notify()
        {
            if (subj.GameObj1 is Missile)
            {
                Missile m = (Missile)subj.GameObj1;
                m.CurrentPlayer.request();
                DestroyManager.attach(subj.GameObj1);
            }
            else
            {
                Missile m = (Missile)subj.GameObj2;
                m.CurrentPlayer.request();
                DestroyManager.attach(subj.GameObj2);
            }
        }
    }
}
