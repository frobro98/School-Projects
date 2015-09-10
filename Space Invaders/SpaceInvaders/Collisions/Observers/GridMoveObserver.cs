using System;


namespace SpaceInvaders
{
    class GridMoveObserver : Observer
    {

        public GridMoveObserver()
            : base()
        {
        }

        public override void notify()
        {
            if (this.subj.GameObj1 is GridNode)
            {
                GridNode node = (GridNode)subj.GameObj1;
                node.MoveVert = true;
            }
            else
            {
                GridNode node = (GridNode)subj.GameObj2;
                node.MoveVert = true;
            }
        }

    }
}
