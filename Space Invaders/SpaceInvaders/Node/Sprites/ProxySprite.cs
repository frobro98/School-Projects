using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    class ProxySprite : BaseSprite
    {

        private GameSprite spriteRef;
        private float scaleX;
        private float scaleY;

        public ProxySprite(SpriteEnum sName, Index index, float x, float y)
            : base()
        {
            this.setBase(sName, index, x, y);
            this.spriteRef = GameSpriteManager.find(sName);
            Debug.Assert(spriteRef != null);
            this.sprColor = new Azul.Color(1, 1, 1);
            this.scaleX = spriteRef.getScaleX();
            this.scaleY = spriteRef.getScaleY();
        }

        public void set(SpriteEnum sName, Index index, float x, float y)
        {
            this.setBase(sName, index, x, y);
            this.spriteRef = GameSpriteManager.find(sName);
            Debug.Assert(spriteRef != null);
        }

        public void setScale(float sx, float sy)
        {
            this.scaleX = sx;
            this.scaleY = sy;
        }
        public float getScaleX()
        {
            return this.scaleX;
        }

        public float getScaleY()
        {
            return this.scaleY;
        }

        public override void update()
        {
            spriteRef.setPos(xPos, yPos);
            spriteRef.setColor(this.sprColor);
            spriteRef.setScale(this.scaleX, this.scaleY);
            spriteRef.update();
        }

        public override void draw()
        {
            spriteRef.draw();
        }
    }
}
