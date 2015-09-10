using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PlayerNode : Hierarchy
    {

        public PlayerNode(Azul.Color color)
            : base(color, Name.Player)
        {
        }

        public override void removeObject()
        {

        }

        public override void accept(Visitor v, CollisionPair pair)
        {
            v.visitPlayerNode(this, pair);
        }

        public override void process()
        {
            throw new NotImplementedException();
        }


    }
}
