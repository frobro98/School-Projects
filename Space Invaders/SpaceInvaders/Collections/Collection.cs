using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class Collection : ManNode
    {
        protected CollectionNode activeHead;
        protected CollectionNode reserveHead;
        protected ListStats stats;

        protected Collection(int toCreate, int willCreate)
        {
            Debug.Assert(toCreate > 0);
            Debug.Assert(willCreate > 0);

            activeHead = null;
            reserveHead = null;
            this.stats.currActiveNodes = 0;
            this.stats.currReserveNodes = 0;
            this.stats.peakActiveNodes = 0;
            this.stats.peakNumNodes = 0;
            this.stats.currNumNodes = 0;
            this.stats.beginToCreate = toCreate;
            this.stats.willCreate = willCreate;

            this.createReserve(toCreate);
        }

        abstract public CollectionNode getCollectionObj();

        public void createReserve(int numNodes)
        {
            Debug.Assert(numNodes > 0);

            this.stats.currNumNodes += numNodes;
            this.stats.currReserveNodes += numNodes;
            if (stats.currNumNodes > stats.peakNumNodes)
            {
                stats.peakNumNodes = stats.currNumNodes;
            }

            CollectionNode rNode;

            for (int i = 0; i < numNodes; i++)
            {
                // Returns the correct object for
                // the derived class
                rNode = (CollectionNode)getCollectionObj();
                addReserve(rNode);
            }
        }

        public void destroy()
        {

        }

        // removes a node from the head of the reserve list
        public CollectionNode detachReserveHead()
        {
            if (reserveHead == null)
            {
                // Create more reserveNodes

                createReserve(stats.willCreate);
            }

            CollectionNode ret = this.reserveHead;
            reserveHead = reserveHead.next;

            if (ret.next != null)
            {
                ret.next.prev = ret.prev;
            }

            return ret;
        }

        // Adds a node to the head of the reserve list
        public void addReserve(CollectionNode node)
        {
            Debug.Assert(node != null);

            node.next = reserveHead;
            reserveHead = node;

            stats.currReserveNodes++;
        }

        public void addActive(CollectionNode node)
        {
            Debug.Assert(node != null);

            node.next = activeHead;
            if(activeHead != null)
                activeHead.prev = node;
            activeHead = node;

            this.stats.currActiveNodes++;
            if (stats.currActiveNodes > stats.peakActiveNodes)
            {
                stats.peakActiveNodes = stats.currActiveNodes;
            }
        }

        protected CollectionNode Add()
        {
            CollectionNode node = detachReserveHead();

            addActive(node);

            return node;
        }

        protected CollectionNode Find(Enum name, Index index = Index.Index_Null)
        {
            CollectionNode toRet = this.activeHead;

            while (toRet != null)
            {
                if (toRet.getName().Equals(name) &&
                    toRet.getIndex().Equals(index))
                {
                    break;
                }
                toRet = toRet.next;
            }

            return toRet;
        }

        protected void Remove(Enum name, Index index = Index.Index_Null)
        {
            CollectionNode node = Find(name, index);
            Debug.Assert(node != null);

            // If it's the head
            if (activeHead == node)
            {
                activeHead = node.next;
                if(activeHead != null)
                    activeHead.prev = null;
            }
            // Its now in the middle or end
            else if (node.prev != null)
            {
                node.prev.next = node.next;
                // It's in the middle! Hurray
                if (node.next != null)
                {
                    node.next.prev = node.prev;
                }
            }

            addReserve(node);

            stats.currActiveNodes--;
        }
    }
}
