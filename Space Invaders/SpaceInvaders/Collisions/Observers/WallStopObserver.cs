using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class WallStopObserver : Observer
    {

        public WallStopObserver()
            : base()
        {
        }

        public override void notify()
        {
            if (this.subj.GameObj1 is PlayerShip)
            {
                if (subj.GameObj2 is LeftWall)
                {
                    ((PlayerShip)subj.GameObj1).MoveLeft = false;
                }
                else if (subj.GameObj2 is RightWall)
                {
                    ((PlayerShip)subj.GameObj1).MoveRight = false;
                }
            }
            else
            {
                if (subj.GameObj1 is LeftWall)
                {
                    ((PlayerShip)subj.GameObj2).MoveLeft = false;
                }
                else if (subj.GameObj1 is RightWall)
                {
                    ((PlayerShip)subj.GameObj2).MoveRight = false;
                }
            }
        }
    }
}
