using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BombFactory
    {
        private static BombFactory bfInstance = null;
        private BatchGroup batch;
        private TreeNode treeRoot;

        private BombFactory()
        {

        }

        public static void initialize(BatchGroup.BatchType type)
        {
            Instance.batch = SpriteBatchManager.find(type);
        }

        public static void setRoot(TreeNode root)
        {
            Instance.treeRoot = root;
        }

        public static Bomb create(Bomb.LineType type, float x, float y)
        {
            Bomb bomb = new Bomb(GameObject.Name.Bombs, Index.Index_Null, SpriteEnum.Line,
                        new Azul.Color(1f, 1f, 1f),
                        new Line(), x, y);
            Debug.Assert(bomb.Spr != null);
            Instance.batch.attach(bomb.Spr);
            SpriteBatchManager.attachToGroup(bomb.ColObj.Spr, BatchGroup.BatchType.Collisions);
            GameObjectManager.insert(bomb, Instance.treeRoot);
            return bomb;
        }

        public static Bomb create(Bomb.ZigZagType type, float x, float y)
        {
            Bomb bomb = new Bomb(GameObject.Name.Bombs, Index.Index_Null, SpriteEnum.ZigZag,
                        new Azul.Color(1f, 1f, 1f),
                        new ZigZag(), x, y);
            Debug.Assert(bomb.Spr != null);
            Instance.batch.attach(bomb.Spr);
            SpriteBatchManager.attachToGroup(bomb.ColObj.Spr, BatchGroup.BatchType.Collisions);
            GameObjectManager.insert(bomb, Instance.treeRoot);
            return bomb;
        }

        public static Bomb create(Bomb.CrossType type, float x, float y)
        {
            Bomb bomb = new Bomb(GameObject.Name.Bombs, Index.Index_Null, SpriteEnum.Cross,
                        new Azul.Color(1f, 1f, 1f),
                        new Cross(), x, y);
            Debug.Assert(bomb.Spr != null);
            Instance.batch.attach(bomb.Spr);
            SpriteBatchManager.attachToGroup(bomb.ColObj.Spr, BatchGroup.BatchType.Collisions);
            GameObjectManager.insert(bomb, Instance.treeRoot);
            return bomb;
        }

        public static BombFactory Instance
        {
            get
            {
                if (bfInstance == null)
                {
                    bfInstance = new BombFactory();
                }

                return bfInstance;
            }
        }
    }
}
