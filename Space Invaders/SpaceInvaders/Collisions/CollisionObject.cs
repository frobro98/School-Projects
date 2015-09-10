using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollisionObject
    {
        private Azul.Rect colBounds;
        private ProxyCollisionSprite colSpr;

        public CollisionObject(SpriteEnum name, Index index, Azul.Color color)
        {
            if (!name.Equals(SpriteEnum.Null))
            {
                GameSprite spr = GameSpriteManager.find(name);
                this.colSpr = new ProxyCollisionSprite(color, name, index);
                this.colBounds = new Azul.Rect(spr.Rect.x, spr.Rect.y, spr.Rect.w, spr.Rect.h);
                this.colBounds.x -= colBounds.w / 2;
                this.colBounds.y += colBounds.h / 2;
            }
            else
            {
                this.colSpr = new ProxyCollisionSprite(color, name, index);
                this.colBounds = new Azul.Rect();
            }

        }

        public BatchGroup getSpriteBatch()
        {
            return this.colSpr.getBatch();
        }

        public void setRectPos(float x, float y)
        {
            this.colBounds.x = x - colBounds.w/2;
            this.colBounds.y = y + colBounds.h/2;
        }

        public void setRect(Azul.Rect newRect)
        {
            this.colBounds = newRect;

            //this.colBounds.x = newRect.x - newRect.w / 2;
            //this.colBounds.y = newRect.y + newRect.h / 2;
            //this.colBounds.w = newRect.w;
            //this.colBounds.h = newRect.h;
        }

        public void setRect(float x, float y, float width, float height)
        {
            colBounds.x = x;
            colBounds.y = y;
            colBounds.w = width;
            colBounds.h = height;
        }

        public void update()
        {
            this.colSpr.Rect = colBounds;
            //this.colSpr.draw();
        }

        public static Azul.Rect union(Azul.Rect rect0, Azul.Rect rect1)
        {
            float minX;
            float maxX;
            float minY;
            float maxY;

            // minX
            if (rect0.x < rect1.x)
            {
                minX = rect0.x;
            }
            else
            {
                minX = rect1.x;
            }

            // maxX
            if ((rect0.x + rect0.w) > (rect1.x + rect1.w))
            {
                maxX = (rect0.x + rect0.w);
            }
            else
            {
                maxX = (rect1.x + rect1.w);
            }

            // minY
            if (rect0.y > rect1.y)
            {
                maxY = rect0.y;
            }
            else
            {
                maxY = rect1.y;
            }

            // maxY
            if ((rect0.y - rect0.h) < (rect1.y - rect1.h))
            {
                minY = (rect0.y - rect0.h);
            }
            else
            {
                minY = (rect1.y - rect1.h);
            }

            return new Azul.Rect(minX, maxY, (maxX - minX), (maxY - minY));
        }

        public Azul.Rect Bounds
        {
            get
            {
                return colBounds;
            }
            set
            {
                colBounds = value;
            }
        }

        public ProxyCollisionSprite Spr
        {
            get
            {
                return colSpr;
            }
            set
            {
                colSpr = value;
            }
        }
    }
}
