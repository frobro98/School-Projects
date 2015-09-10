using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class CommandNode : ManNode
    {
        private Index index;
        private TimeEvent.EventType evType;
        private Command obj;

        public CommandNode()
        {
            this.index = Index.Index_Null;
            this.evType = TimeEvent.EventType.Not_Initialized;
            this.obj = null;
        }

        public void set(Command cObj, TimeEvent.EventType type = TimeEvent.EventType.Not_Initialized, Index index = Index.Index_Null)
        {
            this.obj = cObj;
            this.evType = type;
            this.index = index;
        }

        public override Index getIndex()
        {
            return this.index;
        }

        public override Enum getName()
        {
            return this.evType;
        }

        public Command getObj()
        {
            return this.obj;
        }
    }
}
