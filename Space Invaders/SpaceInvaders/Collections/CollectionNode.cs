using System;

namespace SpaceInvaders
{
    abstract class CollectionNode
    {
        public CollectionNode next;
        public CollectionNode prev;

        protected CollectionNode()
        {
            next = null;
            prev = null;
        }

        abstract public Enum getName();
        abstract public Index getIndex();

    }
}
