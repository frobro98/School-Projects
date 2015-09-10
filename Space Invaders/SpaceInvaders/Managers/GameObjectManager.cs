using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameObjectManager : Manager
    {
        public static GameObjectManager iGOMan;


        public GameObjectManager(int toCreate, int willCreate)
            : base(toCreate, willCreate)
        {
        }

        // Doesn't ever use default constructor
        private GameObjectManager()
            : base()
        {

        }

        public static void setInstance(GameObjectManager instance)
        {
            iGOMan = instance;
        }

        public static void initialize(int toCreate, int willCreate)
        {
            Debug.Assert(toCreate > 0);
            Debug.Assert(willCreate > 0);

            if (iGOMan == null)
            {
                iGOMan = new GameObjectManager(toCreate, willCreate);
            }
        }

        public override ManNode getManObject()
        {
            return new GameObjectNode();
        }

        public static void destroy()
        {
            Instance.baseDestroy();
        }

        private static GameObjectManager Instance
        {
            get
            {
                return iGOMan;
            }
        }

        public static void addRoot(GameObject gameObj)
        {
            GameObjectNode spr = (GameObjectNode)Instance.baseAdd();
            // Setting the default position of the ProxySprite
            spr.set(gameObj);
        }

        public static void insert(TreeNode toAdd, TreeNode parent)
        {
            Debug.Assert(parent != null);
            Debug.Assert(toAdd != null);

            toAdd.Parent = parent;
            if (parent.Child == null)
            {
                parent.Child = toAdd;
                toAdd.Parent = parent;
            }
            else
            {
                TreeNode node = parent.Child;
                toAdd.Sibling = node;
                parent.Child = toAdd;
            }
        }

        public static void detach(SpriteEnum sName, Index index = Index.Index_Null)
        {
            Instance.baseRemove(sName, index);
        }

        public static void removeNode(GameObject.Name tree, GameObject toRemove)
        {
            GameObject foundTree = GameObjectManager.find(tree);
            Debug.Assert(foundTree != null);

            TreeIterator it = new TreeIterator(foundTree);
            while (!it.atEnd())
            {
                if (it.getCurrent() == toRemove)
                {
                    GameObject obj = it.getCurrent();

                    // Child of parent removal
                    if (obj.Parent.Child == obj)
                    {
                        obj.Parent.Child = obj.Sibling;
                        obj.Sibling = null;
                    }
                    else
                    {
                        TreeNode node = obj.Parent.Child;
                        while (node != null && node.Sibling != obj)
                        {
                            node = node.Sibling;
                        }
                        Debug.Assert(node.Sibling == obj);

                        if (obj.Sibling != null)
                        {
                            node.Sibling = obj.Sibling;
                            obj.Sibling = null;
                        }
                        else
                        {
                            node.Sibling = null;
                        }
                    }

                    return;
                }

                it.moveNext();
            }

            
        }

        public static GameObject find(GameObject.Name goName, Index index = Index.Index_Null)
        {
            return ((GameObjectNode)Instance.baseFind(goName, index)).getGameObject();
        }

        public static void update()
        {
            GameObjectNode goNode = (GameObjectNode)Instance.activeHead;
            while (goNode != null)
            {
                GameObject go = goNode.getGameObject();
                //TreeIterator it = new TreeIterator(go);
                ReverseTreeIterator it = new ReverseTreeIterator(go);
                while (!it.atEnd())
                {
                    it.getCurrent().update();

                    it.moveNext();
                }
                
                goNode = (GameObjectNode)goNode.next;
            }
        }

        public static void print(string obj)
        {
            Instance.PrintStats(obj);
        }
        
    }
}
