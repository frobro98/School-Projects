using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionSprite : BaseSprite
    {

        public enum Name
        {
            Grid
        }

        private Azul.Line line;
        private float lineWidth;
        private Azul.Rect rect;
        //private Name colName;

        public CollisionSprite()
            : base()
        {
            lineWidth = 1.0f;
            line = null;
            rect = null;
        }

        public void set(SpriteEnum sName, Index index, Azul.Color color, float x, float y, float width, float height)
        {
            //Debug.Assert(color != null);

            this.setBase(sName, index, 0.0f, 0.0f);
            lineWidth = 1.0f;
            this.sprColor = color;
            rect = new Azul.Rect(x, y, width, height);
            line = new Azul.Line(this.lineWidth, this.sprColor, x, y, x + width, y + height);

        }

        public override void update()
        {
        }

        public override void draw()
        {
            Debug.Assert(this.sprColor != null);
            Debug.Assert(this.rect != null);

            this.line.setColor(this.sprColor);

            // Left line
            this.line.Draw(rect.x, rect.y, rect.x, (rect.y - rect.h));
            // Top line
            this.line.Draw(rect.x, rect.y, (rect.x + rect.w), rect.y);
            // Right line
            this.line.Draw((rect.x + rect.w), rect.y, (rect.x + rect.w), (rect.y - rect.h));
            // Bottom line
            this.line.Draw(rect.x, (rect.y - rect.h), (rect.x + rect.w), (rect.y - rect.h));
            
        }

        public Azul.Rect Rect
        {
            get
            {
                return this.rect;
            }
            set
            {
                this.rect = value;
            }
        }

    }
}
