using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class TimeEvent : ManNode
    {
        public enum EventType
        {
            Animation,
            Movement,
            BombSpawn,
            UFO,
            Not_Initialized
        }

        float changeInTime;
        float trigger;
        EventType name;
        Index index;
        Command comEvent;
        bool canUpdate;

        public TimeEvent()
            : base()
        {
            name = EventType.Not_Initialized;
            index = Index.Index_Null;
        }

        public void set(float totalTime, float deltaTime, Command cObj, TimeEvent.EventType name, Index index = Index.Index_Null)
        {
            this.comEvent = cObj;
            this.trigger = totalTime + deltaTime;
            this.changeInTime = deltaTime;
            this.name = name;
            this.index = index;
            canUpdate = true;
        }

        public override Enum getName()
        {
            return name;
        }

        public override Index getIndex()
        {
            return index;
        }

        public void execute()
        {
            this.comEvent.execute(this.changeInTime);
        }

        public float time
        {
            get
            {
                return this.trigger;
            }
            set
            {
                this.trigger = value;
            }
        }
        public Command TimeObject
        {
            get
            {
                return this.comEvent;
            }
        }
        public bool CanUpdate
        {
            get
            {
                return canUpdate;
            }
            set
            {
                canUpdate = value;
            }

        }
    }
}
