using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CommandContainer : Manager
    {
        private static CommandContainer ccInstance = null;

        private CommandContainer(int toCreate, int willCreate)
            : base(toCreate, willCreate)
        {
        }

        public static void initialize(int toCreate, int willCreate)
        {
            Debug.Assert(toCreate > 0);
            Debug.Assert(willCreate > 0);

            if (ccInstance == null)
            {
                ccInstance = new CommandContainer(toCreate, willCreate);
            }
        }

        public override ManNode getManObject()
        {
            return new CommandNode();
        }

        public static void add(Command addedObj, TimeEvent.EventType type = TimeEvent.EventType.Not_Initialized, Index index = Index.Index_Null)
        {

            CommandNode node = (CommandNode)Instance.baseAdd();
            node.set(addedObj, type, index);
        }

        public static void dumpToTimer()
        {
            CommandNode node = (CommandNode)Instance.activeHead;
            while (node != null)
            {
                if (node.getName().Equals(TimeEvent.EventType.Animation))
                {
                    TimeEventManager.add(GameManager.MoveFrameTime, node.getObj());
                }
                else if (node.getName().Equals(TimeEvent.EventType.Movement))
                {
                    TimeEventManager.add(GameManager.MoveFrameTime, node.getObj());
                }
                else if (node.getName().Equals(TimeEvent.EventType.BombSpawn))
                {
                    TimeEventManager.add(2f, node.getObj());
                }
                else if (node.getName().Equals(TimeEvent.EventType.UFO))
                {
                    TimeEventManager.add(20f, node.getObj());
                }

                node = (CommandNode)node.next;
            }
        }

        private static CommandContainer Instance
        {
            get
            {
                return ccInstance;
            }
        }

    }
}
