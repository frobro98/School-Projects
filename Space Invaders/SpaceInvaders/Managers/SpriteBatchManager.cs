using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteBatchManager : Manager
    {
        // Instance of the SpriteBatchManager Singleton
        private static SpriteBatchManager iSBMan;

        public SpriteBatchManager(int toCreate, int willCreate)
            : base(toCreate, willCreate)
        {
            
        }

        public static void setInstance(SpriteBatchManager instance)
        {
            iSBMan = instance;
        }

        // MUST CALL THIS WHEN GAME STARTS
        public static void initialize(int toCreate, int willCreate)
        {
            Debug.Assert(toCreate > 0);
            Debug.Assert(willCreate > 0);

            if (iSBMan == null)
            {
                iSBMan = new SpriteBatchManager(toCreate, willCreate);
            }
        }

        public static void destroy()
        {
            Instance.baseDestroy();
        }

        public override ManNode getManObject()
        {
            ManNode node = new BatchGroup(stats.beginToCreate, stats.willCreate);
            return node;
        }

        public static void attachToGroup(BaseSprite spr, BatchGroup.BatchType bName, Index sprIndex = Index.Index_Null, Index batchIndex = Index.Index_Null)
        {
            BatchGroup group = find(bName, batchIndex);
            Debug.Assert(group != null);

            group.attach(spr);

        }

        public static BatchGroup add(BatchGroup.BatchType name, bool toDraw = true)
        {
            BatchGroup node = (BatchGroup)Instance.baseAdd();
            node.set(name, Index.Index_Null, toDraw);
            return node;
        }

        // Finds the BatchGroup of BatchType "name" with the index of "index"
        public static BatchGroup find(BatchGroup.BatchType name, Index index = Index.Index_Null)
        {
            return (BatchGroup)Instance.baseFind(name, index);
        }

        public static void remove(BatchGroup.BatchType name, Index index = Index.Index_Null)
        {
            Instance.baseRemove(name, index);
        }

        public static void draw()
        {
            BatchGroup node = (BatchGroup)Instance.activeHead;
            while (node != null)
            {
                node.draw();

                node = (BatchGroup)node.next;
            }
        }

        public static SpriteBatchManager Instance
        {
            get
            {
                return iSBMan;
            }
        }

        public static void print(string obj)
        {
            Instance.PrintStats(obj);
        }
    }
}
