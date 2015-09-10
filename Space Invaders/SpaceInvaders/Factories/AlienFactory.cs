using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienFactory
    {
        private static AlienFactory afInstance = null;
        private BatchGroup batch;
        private Hierarchy cols;
        //private Hierarchy rootTree;

        private AlienFactory()
        {
        }

        public static void initialize(BatchGroup.BatchType batchGroupName)
        {
            Instance.batch = SpriteBatchManager.find(batchGroupName);
        }

        private static void attachTree(Hierarchy treeNode)
        {
            Instance.cols = treeNode;
        }

        private static Crab create(Crab.CrabName name, Index index, float x, float y)
        {
            Crab crab = new Crab(GameObject.Name.Grid, index, SpriteEnum.Crab, x, y);
            Debug.Assert(crab.Spr != null);
            Instance.batch.attach(crab.Spr);
            SpriteBatchManager.attachToGroup(crab.ColObj.Spr, BatchGroup.BatchType.Collisions);
            GameObjectManager.insert(crab, Instance.cols);
            return crab;
        }

        private static Squid create(Squid.SquidName name, Index index, float x, float y)
        {
            Squid squid = new Squid(GameObject.Name.Grid, SpriteEnum.Squid, index, x, y);
            Debug.Assert(squid.Spr != null);
            Instance.batch.attach(squid.Spr);
            SpriteBatchManager.attachToGroup(squid.ColObj.Spr, BatchGroup.BatchType.Collisions);
            GameObjectManager.insert(squid, Instance.cols);
            return squid;
        }

        private static Octopus create(Octopus.Name name, Index index, float x, float y)
        {
            Octopus octo = new Octopus(GameObject.Name.Grid, index, SpriteEnum.Octo, x, y);
            Debug.Assert(octo.Spr != null);
            Instance.batch.attach(octo.Spr);
            SpriteBatchManager.attachToGroup(octo.ColObj.Spr, BatchGroup.BatchType.Collisions);
            GameObjectManager.insert(octo, Instance.cols);
            return octo;
        }

        public static void createGrid(int waveNum)
        {
            const int numColumns = 11;

            SoundManager.playMovement();

            for (int i = 0; i < numColumns; i++)
            {
                Hierarchy col = HierarchyFactory.create(GridNode.Column.Column, new Azul.Color(0.0f, 0.0f, 1.0f));
                AlienFactory.attachTree(col);

                Squid p0 = AlienFactory.create(Squid.SquidName.Squid, Index.Index_0 + i, 100 + 85 * i, 725 - waveNum*50);
                Crab p1 = AlienFactory.create(Crab.CrabName.Crab, Index.Index_0 + i, 100 + 85 * i, 660 - waveNum * 50);
                Crab p2 = AlienFactory.create(Crab.CrabName.Crab, Index.Index_11 + i, 100 + 85 * i, 585 - waveNum * 50);
                Octopus p3 = AlienFactory.create(Octopus.Name.Octopus, Index.Index_0 + i, 100 + 85 * i, 510 - waveNum * 50);
                Octopus p4 = AlienFactory.create(Octopus.Name.Octopus, Index.Index_11 + i, 100 + 85 * i, 440 - waveNum * 50);
            }
        }

        private static AlienFactory Instance
        {
            get
            {
                if (afInstance == null)
                {
                    afInstance = new AlienFactory();
                }

                return afInstance;
            }
        }
    }
}
