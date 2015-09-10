using System;
using System.Diagnostics;

namespace SpaceInvaders
{

    struct ListStats
    {
        public int currActiveNodes;
        public int peakActiveNodes;
        public int currReserveNodes;
        public int currNumNodes;
        public int peakNumNodes;
        public int beginToCreate;
        public int willCreate;

    }

    abstract class Manager
    {
        protected ManNode activeHead;
        protected ManNode reserveHead;
        protected ListStats stats;

        protected Manager(int toCreate, int willCreate)
        {
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

        // Prevents use of default constructor
        protected Manager()
        {
        }


        #region FactoryMethods

        // Helps createReserve create reserves of the
        // correct object
        abstract public ManNode getManObject();

        // Creates and adds the ManNodes created to the list
        private void createReserve(int numNodes)
        {
            this.stats.currNumNodes += numNodes;
            this.stats.currReserveNodes += numNodes;
            if (stats.currNumNodes > stats.peakNumNodes)
            {
                stats.peakNumNodes = stats.currNumNodes;
            }

            ManNode node;
            for (int i = 0; i < numNodes; i++)
            {
                // Derived class implements this
                // returns the correct object
                node = getManObject();
                addReserve(node);
            }
        }

        protected void baseDestroy()
        {
            activeHead = null;
        }

        #endregion

        protected ManNode detachReserveHead()
        {
            if (this.reserveHead == null)
            {
                // Create more so that we can detatch
                this.createReserve(stats.willCreate);
            }

            ManNode node = this.reserveHead;
            this.reserveHead = this.reserveHead.next;

            // Taking it off the list
            if (node.next != null)
            {
                node.next.prev = node.prev;
            }

            this.stats.currReserveNodes--;

            node.next = null;
            node.prev = null;

            return node;

        }

        private void addReserve(ManNode node)
        {
            node.next = reserveHead;
            if(reserveHead != null)
                reserveHead.prev = node;
            reserveHead = node;
        }

        private void addActive(ManNode node)
        {
            node.next = activeHead;
            if (activeHead != null)
                activeHead.prev = node;
            activeHead = node;

            this.stats.currActiveNodes++;
            if (stats.currActiveNodes > stats.peakActiveNodes)
            {
                stats.peakActiveNodes = stats.currActiveNodes;
            }
        }

        protected ManNode baseAdd()
        {
            ManNode node = detachReserveHead();

            addActive(node);

            return node;
        }

        protected void baseRemove(Enum imgName, Index index = Index.Index_Null)
        {
            ManNode node = this.baseFind(imgName, index);

            Debug.Assert(node != null);

            if (activeHead == node)
            {
                activeHead = activeHead.next;
                if(activeHead != null)
                    activeHead.prev = null;
            }
            else if (node.prev != null)
            {
                node.prev.next = node.next;
                if (node.next != null)
                {
                    node.next.prev = node.prev;
                }
            }

            addReserve(node);

            this.stats.currActiveNodes--;


        }

        protected ManNode baseFind(Enum name, Index index = Index.Index_Null)
        {
            ManNode ret = activeHead;
            while (ret != null)
            {
                if (ret.getName().Equals(name) && ret.getIndex().Equals(index))
                {
                    break;
                }

                ret = ret.next;
            }

            return ret;
        }

        protected void PrintStats(string objName)
        {
            Debug.WriteLine(objName);
            Debug.WriteLine("Current number of active nodes:      " + this.stats.currActiveNodes);
            Debug.WriteLine("Current number of reserve nodes:     " + this.stats.currReserveNodes);
            Debug.WriteLine("Current number of nodes:             " + this.stats.currNumNodes);
            Debug.WriteLine("Biggest number of active nodes:      " + this.stats.peakActiveNodes);
            Debug.WriteLine("Biggest number of nodes:             " + this.stats.peakNumNodes);
            Debug.WriteLine("Number of nodes created at start:    " + this.stats.beginToCreate);
            Debug.WriteLine("Number of nodes created after start: " + this.stats.willCreate);
            if (this.stats.beginToCreate < this.stats.peakActiveNodes)
            {
                Debug.WriteLine("Change initial create to: " + this.stats.peakActiveNodes);
            }
            Debug.WriteLine("");
            Debug.WriteLine("");
        }

    } // Manager

} // SpaceInvaders
