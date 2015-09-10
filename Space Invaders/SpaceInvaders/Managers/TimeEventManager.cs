using System;
using System.Diagnostics;

namespace SpaceInvaders
{

    // Doesn't derive from Manager because
    // a Priority Queue is needed
    class TimeEventManager
    {
        private float currTime;
        private ManNode activeHead;
        private ManNode reserveHead;
        private ListStats stats;
        private float prevTime;

        private static TimeEventManager tMan = null;

        public TimeEventManager(int toCreate, int willCreate)
        {
            activeHead = null;
            reserveHead = null;
            this.currTime = 0.0f;
            this.prevTime = 0f;
            this.stats.currActiveNodes = 0;
            this.stats.currReserveNodes = 0;
            this.stats.peakActiveNodes = 0;
            this.stats.peakNumNodes = 0;
            this.stats.currNumNodes = 0;
            this.stats.beginToCreate = toCreate;
            this.stats.willCreate = willCreate;


            this.createReserve(toCreate);
        }

        public static void setInstance(TimeEventManager instance)
        {
            if (tMan != null)
            {
                Instance.prevTime = Instance.currTime;
                instance.CurrentTime = Instance.CurrentTime;
            }

            tMan = instance;
            Instance.updateTime();
        }

        public static void initialize(int toCreate, int willCreate)
        {
            Debug.Assert(toCreate > 0);
            Debug.Assert(willCreate > 0);

            if (tMan == null)
            {
                tMan = new TimeEventManager(toCreate, willCreate);
            }
        }

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
                node = new TimeEvent();
                addReserve(node);
            }
        }

        public static void destroy()
        {

        }

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
            if (reserveHead != null)
                reserveHead.prev = node;
            reserveHead = node;

            this.stats.currReserveNodes++;
        }

        private void addActivePriority(TimeEvent node)
        {
            TimeEvent curr = (TimeEvent)this.activeHead;
            if (activeHead == null)
            {
                activeHead = node;
            }
            else
            {
                while (curr.next != null &&
                    ((TimeEvent)curr).time < ((TimeEvent)node).time)
                {
                    if (((TimeEvent)curr.next).time > ((TimeEvent)node).time)
                    {
                        break;
                    }

                    curr = (TimeEvent)curr.next;
                }
                if (this.activeHead == curr)
                {
                    
                    node.next = curr;
                    node.prev = curr.prev;
                    curr.prev = node;
                    this.activeHead = node;
                }
                else
                {
                    node.next = curr.next;
                    curr.next = node;
                    node.prev = curr;
                    if (node.next != null)
                    {
                        node.next.prev = node;
                    }
                }
            }
        }

        public static void add(float time, Command cObj, 
                                           TimeEvent.EventType name = TimeEvent.EventType.Animation,
                                           Index index = Index.Index_Null)
        {
            TimeEvent node = (TimeEvent)Instance.detachReserveHead();
            node.set(Instance.currTime, time, cObj, name, index);
            Instance.addActivePriority(node);
        }

        public static void remove(Command node)
        {
            TimeEvent te = (TimeEvent)Instance.activeHead;

            while (te != null)
            {
                if (te.TimeObject == node)
                {
                    if(te.next != null)
                        te.next.prev = te.prev;
                    if (te.prev != null)
                        te.prev.next = te.next;
                }

                te = (TimeEvent)te.next;
            }
            
            
        }

        public static void clear()
        {
            //while (Instance.activeHead != null)
            //{
            //    remove(Instance.activeHead);
            //}
        }

        public static void stopUpdate()
        {
            TimeEvent te = (TimeEvent)Instance.activeHead;
            Instance.prevTime = Instance.currTime;

            while (te != null)
            {
                te.CanUpdate = false;

                te = (TimeEvent)te.next;
            }



        }

        public static void startUpdate(float deltaTime)
        {
            TimeEvent te = (TimeEvent)Instance.activeHead;

            while (te != null)
            {
                te.CanUpdate = true;

                te = (TimeEvent)te.next;
            }

            Instance.updateTime();
        }

        public static void update(float time)
        {
            Instance.currTime = time;

            TimeEvent te = (TimeEvent)Instance.activeHead;

            while (te != null &&
                   te.time <= Instance.currTime)
            {
                if (te.CanUpdate)
                {
                    te.execute();
                    if (te.Equals(Instance.activeHead))
                    {
                        Instance.activeHead = Instance.activeHead.next;
                        Instance.addReserve(te);
                    }
                    te = (TimeEvent)Instance.activeHead;
                }
                else
                {
                    te = (TimeEvent)te.next;
                }
            }
            
        }

        private void updateTime()
        {
            TimeEvent te = (TimeEvent)Instance.activeHead;

            float diff = Instance.currTime - Instance.prevTime;

            while (te != null)
            {
                te.time += diff;

                te = (TimeEvent)te.next;
            }
        }

        public static TimeEventManager Instance
        {
            get
            {
                return tMan;
            }
        }

        public float CurrentTime
        {
            get
            {
                return currTime;
            }
            set
            {
                currTime = value;
            }
        }

        public static void print(string message = null)
        {
            ManNode curr = Instance.activeHead;
            while(curr != null)
            {
                Debug.WriteLine(message + " node:" + curr + " time:" + ((TimeEvent)curr).time);

                curr = curr.next;
            }
        }

    }
}
