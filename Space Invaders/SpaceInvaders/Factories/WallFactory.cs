using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class WallFactory
    {
        private static WallFactory wfInstance = null;
        private BatchGroup group;
        private TreeNode treeRoot;

        private WallFactory(BatchGroup.BatchType type)
        {
            group = SpriteBatchManager.find(type);
            Debug.Assert(group != null);
        }

        public static void initialize(BatchGroup.BatchType type = BatchGroup.BatchType.Collisions)
        {
            if (wfInstance == null)
            {
                wfInstance = new WallFactory(type);
            }
        }

        public static void attachTree(Hierarchy treeRoot)
        {
            Instance.treeRoot = treeRoot;
        }

        public static LeftWall create(LeftWall.Side side)
        {
            LeftWall wall = new LeftWall(GameObject.Name.Wall, Index.Index_0);
            Instance.group.attach(wall.ColObj.Spr);
            GameObjectManager.insert(wall, Instance.treeRoot);
            return wall;
        }

        public static RightWall create(RightWall.Side side)
        {
            RightWall wall = new RightWall(GameObject.Name.Wall, Index.Index_2);
            Instance.group.attach(wall.ColObj.Spr);
            GameObjectManager.insert(wall, Instance.treeRoot);
            return wall;
        }

        public static TopWall create(TopWall.Side side)
        {
            TopWall wall = new TopWall(GameObject.Name.Wall, Index.Index_1);
            Instance.group.attach(wall.ColObj.Spr);
            GameObjectManager.insert(wall, Instance.treeRoot);
            return wall;
        }

        public static BottomWall create(BottomWall.Side side)
        {
            BottomWall wall = new BottomWall(GameObject.Name.Wall, Index.Index_3);
            Instance.group.attach(wall.ColObj.Spr);
            GameObjectManager.insert(wall, Instance.treeRoot);
            return wall;
        }

        public static WallFactory Instance
        {
            get
            {
                return wfInstance;
            }
        }
    }
}
