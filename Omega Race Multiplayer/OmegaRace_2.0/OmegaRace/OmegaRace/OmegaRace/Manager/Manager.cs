using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using SpriteAnimation;

namespace OmegaRace
{
    abstract class Manager
    {
        // public methods: -----------------------------------------------------------------------
        protected Manager()
        {
            this.active = null;
            this.reserve = null;
            this.initalized = false;
            this.totalNum = 0;
            this.reserveGrow = 0;
        }

        // private: (reusable for other classes, just change types0: ------------------------------------

        private void privReserveAddToFront(ManLink node, ref ManLink head)
        {
            Debug.Assert(node != null);

            if (head == null)
            {
                head = node;
                node.next = null;
                node.prev = null;
            }
            else
            {
                node.next = head;
                head.prev = node;
                head = node;
            }
        }
        private ManLink privReserveGetNodeFromFront(ref ManLink head)
        {
            Debug.Assert(head != null);

            ManLink node = head;
            head = node.next;
            if (node.next != null)
            {
                node.next.prev = node.prev;
            }
            return node;
        }
        protected void privActiveRemoveNode(ManLink node, ref ManLink head)
        {
            if (node.prev != null)
            {	// middle or last node
                node.prev.next = node.next;
            }
            else
            {  // first
                head = node.next;
            }

            if (node.next != null)
            {	// middle node
                node.next.prev = node.prev;
            }
        }
        protected void privActiveAddToFront(ManLink node, ref ManLink head)
        {
            Debug.Assert(node != null);

            if (head == null)
            {
                head = node;
                node.next = null;
                node.prev = null;
            }
            else
            {
                node.next = head;
                head.prev = node;
                head = node;
            }
        }

        // private methods ------------------------------------------------------------------------------

        protected object privFind(Enum _enumName)
        {
            // // Do we need to get more Images?
            ManLink pLink = this.active;

            while (pLink != null)
            {
                if (pLink.getName().Equals(_enumName))
                {
                    break;
                }
                pLink = pLink.next;
            }

            //return pImage;
            return pLink;
        }
        protected object privGetReserveObject()
        {
            if (this.reserve == null)
            {
                // fill pool with more nodes
                // OK now preload the timeEvents
                this.privFillPool(this.reserveGrow);
            }

            // make sure we have TimeEvents

            Debug.Assert(this.reserve != null);

            // Detach 1 Image from the pool
            object pObj = (object)this.privReserveGetNodeFromFront(ref this.reserve);

            return pObj;
        }
        protected void privFillPool(int count)
        {
            // add to the count
            this.totalNum += count;

            // allocate Objects
            for (int i = 0; i < count; i++)
            {
                // create a new Object
                object pObj = privGetNewObj();
                // move it to InActive list
                privReserveAddToFront((ManLink)pObj, ref this.reserve);
            }
        }
        protected void privCreate(int _numReserve, int _reserveGrow)
        {
            Debug.WriteLine("{0}:Create(): reserve:{1} delta:{2}", this, _numReserve, _reserveGrow);

            // only initialize once
            Debug.Assert(this.initalized == false);

            // Set variables
            this.initalized = true;
            this.reserveGrow = _reserveGrow;

            // OK now preload Nodes
            this.privFillPool(_numReserve);
        }

        // private: Data --------------------------------------------------------------------------------
        abstract protected object privGetNewObj();

        // private: links

        protected ManLink active;
        protected ManLink reserve;
        protected bool initalized;

        // private: stats -------------------------------------------------------------------------------

        protected int totalNum;
        protected int reserveGrow;

    }

    abstract class CopyOfMan
    {
        // public methods: -----------------------------------------------------------------------
        protected CopyOfMan()
        {
            this.active = null;
            this.reserve = null;
            this.initalized = false;
            this.totalNum = 0;
            this.reserveGrow = 0;
        }

        // private: (reusable for other classes, just change types0: ------------------------------------

        private void privReserveAddToFront(ManLink node, ref ManLink head)
        {
            Debug.Assert(node != null);

            if (head == null)
            {
                head = node;
                node.next = null;
                node.prev = null;
            }
            else
            {
                node.next = head;
                head.prev = node;
                head = node;
            }
        }
        private ManLink privReserveGetNodeFromFront(ref ManLink head)
        {
            Debug.Assert(head != null);

            ManLink node = head;
            head = node.next;
            if (node.next != null)
            {
                node.next.prev = node.prev;
            }
            return node;
        }
        protected void privActiveRemoveNode(ManLink node, ref ManLink head)
        {
            if (node.prev != null)
            {	// middle or last node
                node.prev.next = node.next;
            }
            else
            {  // first
                head = node.next;
            }

            if (node.next != null)
            {	// middle node
                node.next.prev = node.prev;
            }
        }
        protected void privActiveAddToFront(ManLink node, ref ManLink head)
        {
            Debug.Assert(node != null);

            if (head == null)
            {
                head = node;
                node.next = null;
                node.prev = null;
            }
            else
            {
                node.next = head;
                head.prev = node;
                head = node;
            }
        }

        // private methods ------------------------------------------------------------------------------

        protected object privFind(Enum _enumName)
        {
            // // Do we need to get more Images?
            ManLink pLink = this.active;

            while (pLink != null)
            {
                if (pLink.getName().Equals(_enumName))
                {
                    break;
                }
                pLink = pLink.next;
            }

            //return pImage;
            return pLink;
        }
        protected object privGetReserveObject()
        {
            if (this.reserve == null)
            {
                // fill pool with more nodes
                // OK now preload the timeEvents
                this.privFillPool(this.reserveGrow);
            }

            // make sure we have TimeEvents

            Debug.Assert(this.reserve != null);

            // Detach 1 Image from the pool


            object pObj = (object)this.privReserveGetNodeFromFront(ref this.reserve);

            return pObj;
        }
        protected void privFillPool(int count)
        {
            // add to the count
            this.totalNum += count;

            // allocate timeEvents
            for (int i = 0; i < count; i++)
            {
                // create a new timeEvent
                object pObj = privGetNewObj();
                // move it to InActive list
                privReserveAddToFront((ManLink)pObj, ref this.reserve);
            }
        }
        protected void privCreate(int _numReserve, int _reserveGrow)
        {
            Debug.WriteLine("{0}:Create(): reserve:{1} delta:{2}", this, _numReserve, _reserveGrow);

            // only initialize once
            Debug.Assert(this.initalized == false);

            // Set variables
            this.initalized = true;
            this.reserveGrow = _reserveGrow;

            // OK now preload Nodes
            this.privFillPool(_numReserve);
        }

        // private: Data --------------------------------------------------------------------------------
        abstract protected object privGetNewObj();

        // private: links

        protected ManLink active;
        protected ManLink reserve;
        protected bool initalized;

        // private: stats -------------------------------------------------------------------------------

        protected int totalNum;
        protected int reserveGrow;

    }
}
