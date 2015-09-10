using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameSpriteManager : Manager
    {
        #region Data Members

        // Instance of the singleton manager
        private static GameSpriteManager iSprMan;
        // The only instance of a NullSprite one will use
        private NullGameSprite nullObj;

        #endregion

        private GameSpriteManager(int toCreate, int willCreate)
            : base(toCreate, willCreate)
        {
        }

        // Must call this in INITIALIZE method
        public static void initialize(int toCreate, int willCreate)
        {
            Debug.Assert(toCreate > 0);
            Debug.Assert(willCreate > 0);

            if (iSprMan == null)
            {
                iSprMan = new GameSpriteManager(toCreate, willCreate);
                iSprMan.nullObj = new NullGameSprite();
            }
        }

        public static void destroy()
        {
            Instance.baseDestroy();
        }

        public override ManNode getManObject()
        {
            ManNode node = new GameSprite();
            return node;
        }

        public static void add(SpriteEnum sName, Index index, ImageEnum iName, float x, float y, float width, float height)
        {
            GameSprite sprite = (GameSprite)Instance.baseAdd();

            sprite.set(sName, index, iName, x, y, width, height);

        }

        public static void remove(SpriteEnum se)
        {
            Instance.baseRemove(se);
        }

        public static GameSprite find(SpriteEnum se, Index index = Index.Index_Null)
        {
            GameSprite spr;

            if (se.Equals(SpriteEnum.Null))
            {
                spr = Instance.nullObj;
            }
            else
            {
                spr = (GameSprite)Instance.baseFind(se, index);
            }

            return spr;
        }

        public static void print(string obj)
        {
            Instance.PrintStats(obj);
        }

        private static GameSpriteManager Instance
        {
            get
            {
                return iSprMan;
            }
        }

        

    }
}
