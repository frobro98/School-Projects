using System;

namespace SpaceInvaders
{
    abstract class GameObject : TreeNode
    {
        public enum Name
        {
            Squid,
            Crab,
            Octopus,
            Bombs,

            UFO,
            Shields,
            Block,

            Player,
            Missiles,

            Wall,
            Grid,

            Not_Initialized
        }

        protected Name name;
        protected Index index;
        protected Azul.Color goColor;
        protected float x, y;
        protected float angle;
        protected float sx, sy;
        protected CollisionObject colObj;
        protected ProxySprite sprite;

        public GameObject(GameObject.Name goName, SpriteEnum name, Index index, Azul.Color color, Azul.Color colColor, float x, float y)
        {
            this.colObj = new CollisionObject(name, index, colColor);
            this.goColor = color;
            this.name = goName;
            this.index = index;
            this.x = x;
            this.y = y;
            angle = 0.0f;
            sx = 1;
            sy = 1;
        }

        abstract public void update();
        abstract public void draw();

        public virtual void removeObject()
        {
            GameObjectManager.removeNode(this.name, this);

            BatchGroup group = this.sprite.getBatch();
            BatchGroup colGroup = this.colObj.getSpriteBatch();
            group.detach(this.sprite);
            colGroup.detach(this.colObj.Spr);

        }

        public void setColor(Azul.Color color)
        {
            goColor = color;
        }

        public void setX(float x)
        {
            this.x = x;
        }
        public float getX()
        {
            return x;
        }
        public void setY(float y)
        {
            this.y = y;
        }
        public float getY()
        {
            return y;
        }
        public void setPos(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public float getAngle()
        {
            return angle;
        }
        public void setAngle(float angle)
        {
            this.angle = angle;
        }

        public float getScaleX()
        {
            return sx;
        }
        public float getScaleY()
        {
            return sy;
        }
        public void setScale(float scaleX, float scaleY)
        {
            this.sx = scaleX;
            this.sy = scaleY;
        }

        public override Enum getName()
        {
            return name;
        }

        public override Index getIndex()
        {
            return this.index;
        }

        public ProxySprite Spr
        {
            get
            {
                return this.sprite;
            }
        }

        public CollisionObject ColObj
        {
            get
            {
                return colObj;
            }
        }

    }
}
