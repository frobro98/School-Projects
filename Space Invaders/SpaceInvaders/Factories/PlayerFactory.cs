using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class PlayerFactory
    {
        private static PlayerFactory pfInstance = null;
        private BatchGroup playerBatch;
        private TreeNode treeRoot;

        public PlayerFactory()
        {
            
        }

        public static void initialize(BatchGroup.BatchType batchName)
        {
            Instance.playerBatch = SpriteBatchManager.find(batchName);
        }

        public static void attachTree(TreeNode root)
        {
            Instance.treeRoot = root;
        }

        public static PlayerShip create(PlayerShip.PlayerName name, float x = 512, float y = 100)
        {
            PlayerShip player = new PlayerShip(x, y);
            Debug.Assert(player.Spr != null);
            Instance.playerBatch.attach(player.Spr);
            SpriteBatchManager.attachToGroup(player.ColObj.Spr, BatchGroup.BatchType.Collisions);
            GameObjectManager.insert(player, Instance.treeRoot);
            return player;
        }

        public static DeadPlayer create(DeadPlayer.Dead name, float x, float y)
        {
            DeadPlayer dead = new DeadPlayer(x, y);
            Instance.playerBatch.attach(dead.Spr);
            GameObjectManager.insert(dead, Instance.treeRoot);
            return dead;
        }

        private static PlayerFactory Instance
        {
            get
            {
                if (pfInstance == null)
                {
                    pfInstance = new PlayerFactory();
                }

                return pfInstance;
            }
        }
    }
}
