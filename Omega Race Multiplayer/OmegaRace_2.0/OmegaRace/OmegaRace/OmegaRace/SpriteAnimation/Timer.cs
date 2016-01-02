using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace SpriteAnimation
{
    class Timer
    {
        // public static methods: -----------------------------------------------------------------------

        public static void Create( int numReserve, int deltaGrow )
        {
            Debug.WriteLine("Timer:Create(): reserve:{0} delta:{1}", numReserve, deltaGrow);
            Instance().privCreate(numReserve, deltaGrow);
        }
        public static void Destroy()
        {
            // get instance
            Timer pTimer = Instance();
            // start the walk
            TimeEvent pEvent = pTimer.active;
            while (pEvent != null)
            {
                pTimer.privActiveRemoveNode(pEvent, ref pTimer.active);
                pEvent = pEvent.next;
            }
            // disable
            pTimer.initalized = false;
        }
        public static void Process(GameTime gameTime)
        {
            // get instance
            Timer pTimer = Instance();

            // Get the time from the beginning of game
            pTimer.currTime = gameTime.TotalGameTime;

            // start the walk
            TimeEvent pEvent = pTimer.active;

            while (pEvent != null)
            {
                if (pTimer.currTime >= pEvent.time)
                {
                    // remove node
                    pTimer.privActiveRemoveNode( pEvent, ref pTimer.active );
                    // call the callback
                    pEvent.funcCB( pEvent.dataCB );
                }
                // goto next time
                pEvent = pEvent.next;
            }
        }
        public static TimeEvent Add(TimeSpan time, object obj, TimeEvent.callback callbackFunc)
        {
            TimeEvent te;
            te = Instance().privAddEvent(time, obj, callbackFunc);
            return te;
        }
        public static void Remove( TimeEvent tE )
        {
            Debug.Assert(tE != null);

            Timer pTimer = Instance();
            pTimer.privActiveRemoveNode(tE, ref pTimer.active);
        }
        public static TimeSpan GetCurrentTime()
        {
            return Instance().currTime;
        }

        // private: (reusable for other classes, just change types0: ------------------------------------

        private void      privInActiveAddToFront(TimeEvent node, ref TimeEvent head)
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
        private TimeEvent privInActiveGetNodeFromFront(ref TimeEvent head)
        {
            Debug.Assert(head != null);

            TimeEvent node = head;
            head = node.next;
            if (node.next != null)
            {	
                node.next.prev = node.prev;
            }
            
            return node;
        }
        private void      privActiveRemoveNode(TimeEvent node, ref TimeEvent head)
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
        
        // private: unique methods for this class: ------------------------------------------------------

        private TimeEvent privAddEvent(TimeSpan _time, object obj, TimeEvent.callback _callbackFunc)
        {
            // Do we need to get more TimeEvents?

                if (this.inActive == null)
                {
                    // fill pool with more nodes
                    // OK now preload the timeEvents
                    this.privFillPool( this.deltaGrow );
                }

            // make sure we have TimeEvents

                Debug.Assert(this.inActive != null);

            // Detach 1 TimeEvent from the pool

                TimeEvent te;
                te = privInActiveGetNodeFromFront(ref this.inActive);
  
            // Initialize our TimeEvent

                te.next = null;
                te.prev = null;
                te.dataCB = obj;
                te.time = _time;
                te.funcCB = _callbackFunc;
                
            // need to add the TimeEvent to active;

                // insert in TimeSpan order (lowest closes to head)

                TimeEvent pEvent = this.active;

                if (this.active == null)
                { 
                    // nothing on the list, just insert
                    this.active = te;
                }
                else
                {
                    // walk the list and insert before
                    TimeEvent LastEvent = pEvent;
                    while ( pEvent != null )
                    {
                        if (te.time <= pEvent.time)
                        {
                            // insert before pEvent
                            break;
                        }
                        // goto next
                        LastEvent = pEvent;
                        pEvent = pEvent.next;
                    }

                    // add the new event to active list
                    if (pEvent != null)
                    {
                        // install before
                        if (pEvent.prev == null)
                        {
                            // 1st on list
                            te.next = this.active;
                            this.active.prev = te;
                            this.active = te;
                        }
                        else
                        {
                            // middle of list
                            LastEvent.next = te;
                            te.prev = LastEvent;
                            pEvent.prev = te;
                            te.next = pEvent;
                        }
                    }
                    else
                    {
                        // install after: (last on list)
                        LastEvent.next = te;
                        te.prev = LastEvent;
                    }
                }

            return te;
        }
        private void privCreate(int _numReserve, int _deltaGrow)
        {
            // only initialize once
            Debug.Assert(this.initalized == false);
            this.initalized = true;

            this.deltaGrow = _deltaGrow; 

            // OK now preload the timeEvents
            this.privFillPool( _numReserve );
        }
        private void privFillPool( int count )
        {
            // add to the count
            this.totalNumEvents += count;

            // allocate timeEvents
            for (int i = 0; i < count; i++)
            {
                // create a new timeEvent
               // TimeEvent te = new TimeEvent(TimeZero, null);
                TimeEvent te = new TimeEvent(TimeSpan.Zero, null);
                // move it to InActive list
                privInActiveAddToFront(te, ref this.inActive);
            }
        }
        private Timer()
        {
            this.active = null;
            this.inActive = null;
            this.initalized = false;
            this.totalNumEvents = 0;
            this.deltaGrow = 3;
            this.currTime = TimeSpan.Zero;
        }
        public static Timer Instance()
        {
            if ( instance == null)
            {
                instance = new Timer();
            }
            return instance;
        }

        // Singleton magic: -----------------------------------------------------------------------------
        
        private static Timer instance;

        // private: Data --------------------------------------------------------------------------------

        private TimeEvent active;
        private TimeEvent inActive;
        private bool initalized;
        private TimeSpan currTime;

        // private: stats -------------------------------------------------------------------------------

        private int totalNumEvents;
        private int deltaGrow;


        public static void Clear()
        {
            instance = null;
        }
    }
}
