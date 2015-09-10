using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class HierarchyFactory
    {
        private static HierarchyFactory hfInstance = null;
        private BatchGroup batch;

        private HierarchyFactory()
        {
        }

        public static void initialize(BatchGroup.BatchType type)
        {
            Instance.batch = SpriteBatchManager.find(type);
        }

        public static Hierarchy create(Hierarchy.Grid grid, Azul.Color color)
        {
            Hierarchy node = new GridNode(color, GameObject.Name.Grid);
            GameObjectManager.addRoot(node);
            SpriteBatchManager.attachToGroup(node.ColObj.Spr, BatchGroup.BatchType.Collisions);
            return node;
        }

        public static Hierarchy create(Hierarchy.Column col, Azul.Color color)
        {
            Hierarchy node = new GridNode(color, GameObject.Name.Grid);
            SpriteBatchManager.attachToGroup(node.ColObj.Spr, BatchGroup.BatchType.Collisions);
            TreeNode grid = GameObjectManager.find(GameObject.Name.Grid);
            GameObjectManager.insert(node, grid);
            return node;
        }

        public static Hierarchy create(Hierarchy.Bombs bomb, Azul.Color color)
        {
            Hierarchy node = new BombNode(color);
            GameObjectManager.addRoot(node);
            SpriteBatchManager.attachToGroup(node.ColObj.Spr, BatchGroup.BatchType.Collisions);
            return node;
        }

        public static Hierarchy create(Hierarchy.Walls wall, Azul.Color color)
        {
            Hierarchy node = new WallNode(color, GameObject.Name.Wall);
            GameObjectManager.addRoot(node);
            SpriteBatchManager.attachToGroup(node.ColObj.Spr, BatchGroup.BatchType.Collisions);
            return node;
        }

        public static Hierarchy create(Hierarchy.Players player, Azul.Color color)
        {
            Hierarchy node = new PlayerNode(color);
            GameObjectManager.addRoot(node);
            SpriteBatchManager.attachToGroup(node.ColObj.Spr, BatchGroup.BatchType.Collisions);
            return node;
        }

        public static Hierarchy create(Hierarchy.Shields shield, Azul.Color color)
        {
            Hierarchy node = new ShieldNode(color);
            GameObjectManager.addRoot(node);
            SpriteBatchManager.attachToGroup(node.ColObj.Spr, BatchGroup.BatchType.Collisions);
            return node;
        }

        public static Hierarchy create(Hierarchy.ShieldCol col, Azul.Color color)
        {
            Hierarchy node = new ShieldNode(color);
            SpriteBatchManager.attachToGroup(node.ColObj.Spr, BatchGroup.BatchType.Collisions);
            TreeNode subRoot = GameObjectManager.find(GameObject.Name.Shields);
            GameObjectManager.insert(node, subRoot);
            return node;
        }

        public static Hierarchy create(Hierarchy.UFOs ufo, Azul.Color color)
        {
            Hierarchy node = new UFONode(color);
            GameObjectManager.addRoot(node);
            SpriteBatchManager.attachToGroup(node.ColObj.Spr, BatchGroup.BatchType.Collisions);
            return node;
        }

        public static Hierarchy create(Hierarchy.Missiles missile, Azul.Color color)
        {
            Hierarchy node = new MissileNode(color);
            GameObjectManager.addRoot(node);
            SpriteBatchManager.attachToGroup(node.ColObj.Spr, BatchGroup.BatchType.Collisions);
            return node;
        }

        private static HierarchyFactory Instance
        {
            get
            {
                if(hfInstance == null)
                {
                    hfInstance = new HierarchyFactory();
                }

                return hfInstance;
            }
        }

    }
}
