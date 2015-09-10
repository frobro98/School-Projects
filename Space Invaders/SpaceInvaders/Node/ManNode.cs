using System;

namespace SpaceInvaders
{

    abstract class ManNode
    {
        public ManNode next;
        public ManNode prev;

        abstract public Enum getName();
        abstract public Index getIndex();

        protected ManNode()
        {
            next = null;
            prev = null;
        }

        
    }
}
