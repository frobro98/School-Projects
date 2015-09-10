using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class UFOFactory
    {
        private static UFOFactory ufInstance = null;
        private BatchGroup batch;
        private TreeNode ufoTree;
        private UFO ufo;

        private UFOFactory()
        {
            this.ufo = null;
        }

        public static void initialize(BatchGroup.BatchType type)
        {
            Instance.batch = SpriteBatchManager.find(BatchGroup.BatchType.UFO);
        }

        public static void setTree(TreeNode tree)
        {
            Instance.ufoTree = tree;
        }

        public static UFO create(UFO.Side side)
        {
            UFO ufo;
            if (side.Equals(UFO.Side.Left))
            {
                if (Instance.ufo == null)
                {
                    ufo = new UFO(side, 0f, Constants.SCREEN_HEIGHT * .87f);
                }
                else
                {
                    ufo = Instance.ufo;
                    ufo.set(side, 0f, Constants.SCREEN_HEIGHT * .87f);
                }
            }
            else
            {
                if (Instance.ufo == null)
                {
                    ufo = new UFO(side, Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT * .87f);
                }
                else
                {
                    ufo = Instance.ufo;
                    ufo.set(side, Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT * .87f);
                }
            }
            Instance.batch.attach(ufo.Spr);
            SpriteBatchManager.attachToGroup(ufo.ColObj.Spr, BatchGroup.BatchType.Collisions);
            GameObjectManager.insert(ufo, Instance.ufoTree);
            return ufo;
        }

        public static void receiveUFO(UFO ufo)
        {
            Instance.ufo = ufo;
        }

        public static UFOFactory Instance
        {
            get
            {
                if (ufInstance == null)
                {
                    ufInstance = new UFOFactory();
                }

                return ufInstance;
            }
        }

    }
}
