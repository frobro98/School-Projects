using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShieldFactory
    {
        private static ShieldFactory sfInstance = null;
        private GameObject root;
        private BatchGroup batch;

        private ShieldFactory()
        {
        }

        public static void initialize(BatchGroup.BatchType type)
        {
            Instance.batch = SpriteBatchManager.find(type);
        }

        public static void setRoot(GameObject root)
        {
            Instance.root = root;
        }

        public static void createShield(GameObject.Name shield, float x, float y)
        {
            float baseX = x;
            float baseY = y;
            const float blockWidth = 15f - 1f;
            const float blockHeight = 5f;
            float offsetX = 0f;

            int numIndex = 0;

            // Column 1
            Hierarchy shieldCol = HierarchyFactory.create(Hierarchy.ShieldCol.Column, new Azul.Color(1f, 1f, 0f));
            ShieldFactory.setRoot(shieldCol);
            ShieldFactory.create(ShieldBlock.LeftTopBlock.LeftTop, Index.Index_1, baseX, baseY + 13 * blockHeight);
            ShieldFactory.create(ShieldBlock.LeftTopBlock.LeftTop, Index.Index_0, baseX, baseY + 12 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX, baseY + 11 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX, baseY + 10 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX, baseY + 9 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX, baseY + 8 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX, baseY + 7 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX, baseY + 6 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX, baseY + 5 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX, baseY + 4 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX, baseY + 3 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX, baseY + 2 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX, baseY + blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX, baseY);

            // Column 2
            offsetX += blockWidth - 1;
            shieldCol = HierarchyFactory.create(Hierarchy.ShieldCol.Column, new Azul.Color(1f, 1f, 0f));
            ShieldFactory.setRoot(shieldCol);
            ShieldFactory.create(ShieldBlock.LeftTopBlock.LeftTop, Index.Index_3, baseX + offsetX, baseY + 15 * blockHeight);
            ShieldFactory.create(ShieldBlock.LeftTopBlock.LeftTop, Index.Index_2, baseX + offsetX, baseY + 14 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 13 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 12 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 11 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 10 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 9 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 8 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 7 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 6 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 5 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 4 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 3 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 2 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY);

            // Column 3
            offsetX += blockWidth;
            shieldCol = HierarchyFactory.create(Hierarchy.ShieldCol.Column, new Azul.Color(1f, 1f, 0f));
            ShieldFactory.setRoot(shieldCol);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 15 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 14 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 13 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 12 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 11 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 10 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 9 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 8 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 7 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 6 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 5 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 4 * blockHeight);
            ShieldFactory.create(ShieldBlock.LeftBottomBlock.LeftBottom, Index.Index_1, baseX + offsetX, baseY + 3 * blockHeight);
            ShieldFactory.create(ShieldBlock.LeftBottomBlock.LeftBottom, Index.Index_0, baseX + offsetX, baseY + 2 * blockHeight);

            // Column 4
            offsetX += blockWidth;
            shieldCol = HierarchyFactory.create(Hierarchy.ShieldCol.Column, new Azul.Color(1f, 1f, 0f));
            ShieldFactory.setRoot(shieldCol);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 15 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 14 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 13 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 12 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 11 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 10 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 9 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 8 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 7 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 6 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 5 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 4 * blockHeight);

            // Column 5
            offsetX += blockWidth;
            shieldCol = HierarchyFactory.create(Hierarchy.ShieldCol.Column, new Azul.Color(1f, 1f, 0f));
            ShieldFactory.setRoot(shieldCol);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 15 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 14 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 13 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 12 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 11 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 10 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 9 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 8 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 7 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 6 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 5 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 4 * blockHeight);

            // Column 6
            offsetX += blockWidth;
            shieldCol = HierarchyFactory.create(Hierarchy.ShieldCol.Column, new Azul.Color(1f, 1f, 0f));
            ShieldFactory.setRoot(shieldCol);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 15 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 14 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 13 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 12 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 11 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 10 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 9 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 8 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 7 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 6 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 5 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 4 * blockHeight);
            ShieldFactory.create(ShieldBlock.RightBottomBlock.RightBottom, Index.Index_0, baseX + offsetX, baseY + 3 * blockHeight);
            ShieldFactory.create(ShieldBlock.RightBottomBlock.RightBottom, Index.Index_1, baseX + offsetX, baseY + 2 * blockHeight);

            // Column 7
            offsetX += blockWidth;
            shieldCol = HierarchyFactory.create(Hierarchy.ShieldCol.Column, new Azul.Color(1f, 1f, 0f));
            ShieldFactory.setRoot(shieldCol);
            ShieldFactory.create(ShieldBlock.RightTopBlock.RightTop, Index.Index_0, baseX + offsetX, baseY + 15 * blockHeight);
            ShieldFactory.create(ShieldBlock.RightTopBlock.RightTop, Index.Index_1, baseX + offsetX, baseY + 14 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 13 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 12 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 11 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 10 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 9 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 8 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 7 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 6 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 5 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 4 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 3 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 2 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY);


            // Column 8
            offsetX += blockWidth;
            shieldCol = HierarchyFactory.create(Hierarchy.ShieldCol.Column, new Azul.Color(1f, 1f, 0f));
            ShieldFactory.setRoot(shieldCol);
            ShieldFactory.create(ShieldBlock.RightTopBlock.RightTop, Index.Index_2, baseX + offsetX, baseY + 13 * blockHeight);
            ShieldFactory.create(ShieldBlock.RightTopBlock.RightTop, Index.Index_3, baseX + offsetX, baseY + 12 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 11 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 10 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 9 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 8 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 7 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 6 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 5 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 4 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 3 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + 2 * blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY + blockHeight);
            ShieldFactory.create(ShieldBlock.Block.Block, Index.Index_0 + numIndex++, baseX + offsetX, baseY);
        }

        public static ShieldBlock create(ShieldBlock.Block type, Index index, float x, float y)
        {
            ShieldBlock block = new ShieldBlock(GameObject.Name.Shields, index, SpriteEnum.ShieldBlock, x, y);
            GameObjectManager.insert(block, Instance.root);
            Debug.Assert(block.Spr != null);
            Instance.batch.attach(block.Spr);
            SpriteBatchManager.attachToGroup(block.ColObj.Spr, BatchGroup.BatchType.Collisions);
            return block;
        }

        public static ShieldBlock create(ShieldBlock.LeftTopBlock type, Index index, float x, float y)
        {
            ShieldBlock block;
            if (index.Equals(Index.Index_0))
            {
                block = new ShieldBlock(GameObject.Name.Shields, index, SpriteEnum.LeftTop_0, x, y);
            }
            else if (index.Equals(Index.Index_1))
            {
                block = new ShieldBlock(GameObject.Name.Shields, index, SpriteEnum.LeftTop_1, x, y);
            }
            else if (index.Equals(Index.Index_2))
            {
                block = new ShieldBlock(GameObject.Name.Shields, index, SpriteEnum.LeftTop_2, x, y);
            }
            else
            {
                block = new ShieldBlock(GameObject.Name.Shields, index, SpriteEnum.LeftTop_3, x, y);
            }

            GameObjectManager.insert(block, Instance.root);
            Instance.batch.attach(block.Spr);
            SpriteBatchManager.attachToGroup(block.ColObj.Spr, BatchGroup.BatchType.Collisions);
            return block;
        }

        public static ShieldBlock create(ShieldBlock.LeftBottomBlock type, Index index, float x, float y)
        {
            ShieldBlock block;
            if (index.Equals(Index.Index_0))
            {
                block = new ShieldBlock(GameObject.Name.Shields, index, SpriteEnum.LeftBottom_0, x, y);
            }
            else if (index.Equals(Index.Index_1))
            {
                block = new ShieldBlock(GameObject.Name.Shields, index, SpriteEnum.LeftBottom_1, x, y);
            }
            else
            {
                block = null;
            }
            Debug.Assert(block != null);
            
            GameObjectManager.insert(block, Instance.root);
            Instance.batch.attach(block.Spr);
            SpriteBatchManager.attachToGroup(block.ColObj.Spr, BatchGroup.BatchType.Collisions);
            return block;
        }

        public static ShieldBlock create(ShieldBlock.RightTopBlock type, Index index, float x, float y)
        {
            ShieldBlock block;
            if (index.Equals(Index.Index_0))
            {
                block = new ShieldBlock(GameObject.Name.Shields, index, SpriteEnum.RightTop_0, x, y);
            }
            else if (index.Equals(Index.Index_1))
            {
                block = new ShieldBlock(GameObject.Name.Shields, index, SpriteEnum.RightTop_1, x, y);
            }
            else if (index.Equals(Index.Index_2))
            {
                block = new ShieldBlock(GameObject.Name.Shields, index, SpriteEnum.RightTop_2, x, y);
            }
            else
            {
                block = new ShieldBlock(GameObject.Name.Shields, index, SpriteEnum.RightTop_3, x, y);
            }

            GameObjectManager.insert(block, Instance.root);
            Instance.batch.attach(block.Spr);
            SpriteBatchManager.attachToGroup(block.ColObj.Spr, BatchGroup.BatchType.Collisions);
            return block;
        }

        public static ShieldBlock create(ShieldBlock.RightBottomBlock type, Index index, float x, float y)
        {
            ShieldBlock block;
            if (index.Equals(Index.Index_0))
            {
                block = new ShieldBlock(GameObject.Name.Shields, index, SpriteEnum.RightBottom_0, x, y);
            }
            else if (index.Equals(Index.Index_1))
            {
                block = new ShieldBlock(GameObject.Name.Shields, index, SpriteEnum.RightBottom_1, x, y);
            }
            else
            {
                block = null;
            }
            Debug.Assert(block != null);

            GameObjectManager.insert(block, Instance.root);
            Instance.batch.attach(block.Spr);
            SpriteBatchManager.attachToGroup(block.ColObj.Spr, BatchGroup.BatchType.Collisions);
            return block;
        }

        public static ShieldFactory Instance
        {
            get
            {
                if (sfInstance == null)
                {
                    sfInstance = new ShieldFactory();
                }

                return sfInstance;
            }
        }

    }
}
