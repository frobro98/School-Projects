using System;

namespace SpaceInvaders
{
    class DestroyManager : Manager
    {
        private static DestroyManager dmInstance = null;

        private DestroyManager(int toCreate, int willCreate)
            : base(toCreate, willCreate)
        {

        }

        public static void initialize(int toCreate = 1, int willCreate = 1)
        {
            if (dmInstance == null)
            {
                dmInstance = new DestroyManager(toCreate, willCreate);
            }
        }

        public override ManNode getManObject()
        {
            return new GameObjectNode();
        }

        public static void attach(GameObject go)
        {
            GameObjectNode node = (GameObjectNode)Instance.baseAdd();

            node.set(go);
        }

        public static void deleteObjects()
        {
            while (Instance.activeHead != null)
            {
                GameObject go = ((GameObjectNode)Instance.activeHead).getGameObject();
                go.removeObject();

                GameObject parent = (GameObject)go.Parent;

                if (parent.Child == null)
                {
                    parent.removeObject();
                }
                Instance.baseRemove(go.getName(), go.getIndex());
            }
        }


        public static DestroyManager Instance
        {
            get
            {
                return dmInstance;
            }
        }

    }
}
