using System;

namespace SpaceInvaders
{
    abstract class BaseSprite : ManNode
    {
        #region Data Members

        protected SpriteEnum name;
        protected Index index;
        protected Azul.Color sprColor;
        protected float xPos;
        protected float yPos;
        protected BatchGroup batch;
       

        #endregion

        protected BaseSprite()
        {
            this.index = Index.Index_Null;
            this.name = SpriteEnum.Not_Initialized;
            this.batch = null;
            this.xPos = 0f;
            this.yPos = 0f;
            this.sprColor = null;
        }


        public abstract void update();
        public abstract void draw();

        #region SettersGetters

        protected void setBase(SpriteEnum spr, Index i, float x, float y)
        {
            this.name = spr;
            this.index = i;
            this.xPos = x;
            this.yPos = y;
        }

        public void setBatch(BatchGroup batch)
        {
            this.batch = batch;
        }

        public BatchGroup getBatch()
        {
            return batch;
        }

        public void setPos(float x, float y)
        {
            this.xPos = x;
            this.yPos = y;
        }
        public void setX(float x)
        {
            this.xPos = x;
        }
        public float getX()
        {
            return this.xPos;
        }

        public void setY(float y)
        {
            this.yPos = y;
        }
        public float getY()
        {
            return this.yPos;
        }

        #endregion

        override public Enum getName()
        {
            return this.name;
        }
        public void setName(SpriteEnum s)
        {
            this.name = s;
        }

        public override Index getIndex()
        {
            return this.index;
        }
        public void setIndex(Index index)
        {
            this.index = index;
        }

        public Azul.Color Color
        {
            get
            {
                return this.sprColor;
            }
            set
            {
                this.sprColor = value;
            }
        }

    }
}
