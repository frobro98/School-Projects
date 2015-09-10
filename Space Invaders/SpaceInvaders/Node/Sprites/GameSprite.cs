using System;

namespace SpaceInvaders
{
    class GameSprite : BaseSprite
    {

        #region Data Members
        protected Image img;
        protected Azul.Sprite2D sprite;
        protected Azul.Rect sprRect;
        protected float angle;
        protected float scaleX;
        protected float scaleY;
        #endregion

        public GameSprite()
            : base()
        {
            sprite = null;
        }

        protected GameSprite(SpriteEnum name, Index index)
        {
            base.setBase(name, index, 0.0f, 0.0f);
        }

        public void set(SpriteEnum sName, Index index, ImageEnum iName, float x, float y, float width, float height)
        {
            base.setBase(sName, index, x, y);
            this.img = ImageManager.find(iName);
            this.sprite = new Azul.Sprite2D(this.img.getTexture(), this.img.TexCoords, new Azul.Rect(x, y, width, height));
            this.sprRect = new Azul.Rect(x, y, width, height);
            angle = 0;
            scaleX = this.sprite.sx;
            scaleY = this.sprite.sy;
        }

        public void setColor(Azul.Color color)
        {
            if(sprite != null)
                sprite.setColor(color);
        }

        public override void update()
        {
                this.sprite.swapImage(this.img.TexCoords);
                this.sprite.angle = angle;
                this.sprite.sx = scaleX;
                this.sprite.sy = scaleY;
                this.sprite.x = xPos;
                this.sprite.y = yPos;
        }

        override public void draw()
        {
            sprite.Draw();
        }

        public void setScale(float sx, float sy)
        {
            this.scaleX = sx;
            this.scaleY = sy;
        }
        public float getScaleX()
        {
            return scaleX;
        }
        public float getScaleY()
        {
            return scaleY;
        }

        public void setAngle(float angle)
        {
            this.angle = angle;
        }
        public float getAngle()
        {
            return this.angle;
        }

        public Azul.Sprite2D Spr
        {
            get
            {
                return sprite;
            }
            set
            {   
                sprite = value;
            }
        }

        public Azul.Rect Rect
        {
            get
            {
                return this.sprRect;
            }
        }

        public Image Img
        {
            get
            {
                return this.img;
            }
            set
            {
                this.img = value;
            }
        }

    }
}
