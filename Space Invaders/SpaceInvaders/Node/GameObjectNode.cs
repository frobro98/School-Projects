using System;

namespace SpaceInvaders
{
    class GameObjectNode : ManNode
    {
        private GameObject go;
        GameObject.Name name;
        Index index;

        public GameObjectNode()
        {
            go = null;
            name = GameObject.Name.Not_Initialized;
            index = Index.Index_Null;
        }

        public void set(GameObject gObj)
        {
            go = gObj;
            name = (GameObject.Name)go.getName();
            index = go.getIndex();
        }

        public GameObject getGameObject()
        {
            return go;
        }

        public override Index getIndex()
        {
            return index;
        }

        public override Enum getName()
        {
            return name;
        }

    }
}
