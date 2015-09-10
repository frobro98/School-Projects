using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Bomb : GameObject
    {
        public enum LineType
        {
            Line
        }

        public enum ZigZagType
        {
            ZigZag
        }

        public enum CrossType
        {
            Cross
        }

        private BombBehavior behavior;

        public Bomb(Name name, Index index, SpriteEnum sName, Azul.Color color, BombBehavior behavior, float x, float y)
            : base(name, sName, index, color, new Azul.Color(1f, 0f, 0f), x, y)
        {
            this.sprite = new ProxySprite(sName, index, x, y);
            this.behavior = behavior;
        }

        public override void accept(Visitor v, CollisionPair pair)
        {
            v.visitBomb(this, pair);
        }

        public override void visitMissileNode(MissileNode mn, CollisionPair p)
        {
            p.collision((GameObject)mn.Child, this);
        }

        public override void visitMissile(Missile v, CollisionPair p)
        {
            p.notify(v, this);
        }

        public override void visitPlayerNode(PlayerNode p, CollisionPair pair)
        {
            pair.collision((GameObject)p.Child, this);
        }

        public override void visitPlayer(PlayerShip v, CollisionPair p)
        {
            p.notify(v, this);
        }

        public override void visitWallNode(WallNode wn, CollisionPair p)
        {
            p.collision((GameObject)wn.Child, this);
        }

        public override void visitBottomWall(BottomWall bw, CollisionPair p)
        {
            p.notify(bw, this);
        }

        public override void visitShieldNode(ShieldNode sb, CollisionPair p)
        {
            p.collision((GameObject)sb.Child, this);
        }

        public override void visitShield(ShieldBlock v, CollisionPair p)
        {
            GameObject shieldBlock = v;
            while (shieldBlock.Sibling != null)
            {
                shieldBlock = (GameObject)shieldBlock.Sibling;
            }
            p.notify(shieldBlock, this);
        }

        public override void update()
        {
            this.y -= 12f;
            this.behavior.updateBehavior(this.sprite);

            this.sprite.setY(this.y);
            this.sprite.Color = this.goColor;
            this.colObj.setRectPos(this.x, this.y);
            this.colObj.update();
        }

        public override void draw()
        {
            
        }
    }
}
