using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpriteAnimation;
using System.Diagnostics;

namespace OmegaRace
{
    abstract class Container : ManLink
    {
        // public methods: -----------------------------------------------------------------------

        protected Container()
        {
            this.Initialize();
        }

        protected override void Initialize()
        {
            base.Initialize();

            this.active = null;
            this.reserve = null;
            this.initalized = false;
            this.totalNum = 0;
            this.reserveGrow = 1;
        }

        abstract protected object privGetNewObj();


        // private: List functions  ---------------------------------------------------------------------

        private void privReserveAddToFront(ContainerLink node, ref ContainerLink head)
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
        private ContainerLink privReserveGetNodeFromFront(ref ContainerLink head)
        {
            Debug.Assert(head != null);

            ContainerLink node = head;
            head = node.next;
            if (node.next != null)
            {
                node.next.prev = node.prev;
            }
            return node;
        }
        private void privActiveRemoveNode(ContainerLink node, ref ContainerLink head)
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
        protected void privActiveAddToFront(ContainerLink node, ref ContainerLink head)
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

        // Dependent methods: -----------------------------------------------------------------------

        protected object privGetReserveObject()
        {
            if (this.reserve == null)
            {
                // fill pool with more nodes
                // OK now preload the timeEvents
                this.privFillPool(this.reserveGrow);
            }

            // make sure we have objects
            Debug.Assert(this.reserve != null);

            // Detach 1 object from the pool
            object pObj = (object)this.privReserveGetNodeFromFront(ref this.reserve);

            return pObj;
        }
        protected void privFillPool(int count)
        {
            // add to the count
            this.totalNum += count;

            // allocate more objects
            for (int i = 0; i < count; i++)
            {
                // create a new object
                object pObj = privGetNewObj();
                // move it to InActive list
                privReserveAddToFront((ContainerLink)pObj, ref this.reserve);
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
        protected object privFind(Enum _enumName)
        {
            // // Do we need to get more Objects
            ContainerLink pLink = this.active;

            while (pLink != null)
            {
                if (pLink.getName().Equals(_enumName))
                {
                    break;
                }
                pLink = pLink.next;
            }
            return pLink;
        }

        // private: Data --------------------------------------------------------------------------------

        public ContainerLink active;
        protected ContainerLink reserve;
        protected bool initalized;

        // private: stats -------------------------------------------------------------------------------

        protected int totalNum;
        protected int reserveGrow;
    }
}
