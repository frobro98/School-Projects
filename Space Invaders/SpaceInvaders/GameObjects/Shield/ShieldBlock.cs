using System;

namespace SpaceInvaders
{
    class ShieldBlock : GameObject
    {

        public enum Block
        {
            Block
        }

        public enum LeftTopBlock
        {
            LeftTop
        }

        public enum LeftBottomBlock
        {
            LeftBottom
        }

        public enum RightTopBlock
        {
            RightTop
        }

        public enum RightBottomBlock
        {
            RightBottom
        }

        public ShieldBlock(Name name, Index index, SpriteEnum type, float x, float y)
            : base(name, type, index, new Azul.Color(0f, 1f, 0f), new Azul.Color(0f, 0f, 1f), x, y)
        {
            this.sprite = new ProxySprite(type, index, x, y);
        }

        public override void accept(Visitor v, CollisionPair pair)
        {
            v.visitShield(this, pair);
        }

        public override void visitMissile(Missile v, CollisionPair p)
        {
            p.notify(this, v);
        }

        public override void visitBomb(Bomb v, CollisionPair p)
        {
            GameObject shieldBlock = this;
            while (shieldBlock.Sibling != null)
            {
                shieldBlock = (GameObject)shieldBlock.Sibling;
            }
            p.notify(shieldBlock, v);
        }

        public override void visitGridNode(GridNode gn, CollisionPair p)
        {
            p.collision(this, (GameObject)gn.Child);
        }

        public override void visitAlien(Alien a, CollisionPair p)
        {
            p.notify(this, a);
        }

        public override void update()
        {
            this.sprite.Color = this.goColor;
            this.colObj.setRectPos(this.x, this.y);
            this.colObj.update();
        }

        public override void draw()
        {
            
        }
    }
}
