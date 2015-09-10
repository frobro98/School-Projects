using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MissileFactory
    {
        private static MissileFactory mfInstance = null;
        private BatchGroup batch;
        private TreeNode root;

        private MissileFactory()
        {

        }

        public static void initialize(BatchGroup.BatchType batch)
        {
            Instance.batch = SpriteBatchManager.find(batch);
        }

        public static void attachTree(TreeNode node)
        {
            Instance.root = node;
        }

        public static Missile create(Missile.MissileName m, float x, float y, PlayerShip player)
        {
            Missile node = new Missile(x, y, player);
            GameObject missile = GameObjectManager.find(GameObject.Name.Missiles);
            GameObjectManager.insert(node, missile);
            Debug.Assert(node.Spr != null);
            Instance.batch.attach(node.Spr);
            SpriteBatchManager.attachToGroup(node.ColObj.Spr, BatchGroup.BatchType.Collisions);
            return node;
        }

        private static MissileFactory Instance
        {
            get
            {
                if (mfInstance == null)
                {
                    mfInstance = new MissileFactory();
                }

                return mfInstance;
            }
        }
    }
}
