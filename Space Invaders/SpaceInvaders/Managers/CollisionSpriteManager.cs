using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionSpriteManager : Manager
    {

        private static CollisionSpriteManager cmInstance = null;
        private NullCollisionSprite nullSpr;

        public static void initialize(int toCreate, int willCreate)
        {
            Debug.Assert(toCreate > 0);
            Debug.Assert(willCreate > 0);

            if (cmInstance == null)
            {
                cmInstance = new CollisionSpriteManager(toCreate, willCreate);
            }
        }

        private CollisionSpriteManager(int toCreate, int willCreate)
            : base(toCreate, willCreate)
        {
            nullSpr = new NullCollisionSprite();
        }

        public override ManNode getManObject()
        {
            return new CollisionSprite();
        }

        public static CollisionSprite add(SpriteEnum sName, Index index, Azul.Color color, float x, float y, float width, float height)
        {
            CollisionSprite sprite = (CollisionSprite)Instance.baseAdd();

            // Needs to be adjusted for the rectangle
            x -= width / 2;
            y -= height / 2;

            sprite.set(sName, index, color, x, y, width, height);

            return sprite;
        }

        public static void remove(SpriteEnum name, Index index = Index.Index_Null)
        {
            Instance.baseRemove(name, index);
        }

        public static CollisionSprite find(SpriteEnum name, Index index = Index.Index_Null)
        {
            CollisionSprite ret;

            if (name.Equals(SpriteEnum.Null))
            {
                ret = Instance.nullSpr;
            }
            else
            {
                ret = (CollisionSprite)Instance.baseFind(name, index);
            }

            return ret;
        }


        public static CollisionSpriteManager Instance
        {
            get
            {
                return cmInstance;
            }
        }

        public static void print(string obj)
        {
            Instance.PrintStats(obj);
        }

    }
}
