using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Missile : GameObject
    {

        public enum MissileName
        {
            Missile
        }

        private PlayerShip playerInstance;

        public Missile(float x, float y, PlayerShip player)
            : base(Name.Missiles, SpriteEnum.Missile, Index.Index_Null, new Azul.Color(1f, 1f, 1f), new Azul.Color(0.0f, 1.0f, 0.0f), x, y)
        {
            this.sprite = new ProxySprite(SpriteEnum.Missile, Index.Index_Null, x, y);
            this.playerInstance = player;
            //this.goColor = new Azul.Color(1.0f, 1, 1);
        }

        public override void accept(Visitor v, CollisionPair pair)
        {
            v.visitMissile(this, pair);
        }

        public override void visitUFONode(UFONode u, CollisionPair p)
        {
            p.collision((GameObject)u.Child, this);
        }

        public override void visitAlien(Alien a, CollisionPair p)
        {
            p.notify(a, this);
        }

        public override void visitBombNode(BombNode bn, CollisionPair p)
        {
            p.collision(this, (GameObject)bn.Child);
        }

        public override void visitBomb(Bomb v, CollisionPair p)
        {
            p.notify(this, v);
        }

        public override void visitGridNode(GridNode gn, CollisionPair p)
        {
            p.collision((GameObject)gn.Child, this);
        }

        public override void visitShieldNode(ShieldNode sb, CollisionPair p)
        {
            p.collision((GameObject)sb.Child, this);
        }

        public override void visitShield(ShieldBlock v, CollisionPair p)
        {
            p.notify(v, this);
        }

        public override void visitUFO(UFO v, CollisionPair p)
        {
            //p.notify(v, this);
        }

        public override void update()
        {
            this.y += 20.0f;
            this.sprite.setPos(this.x, this.y);
            this.sprite.Color = this.goColor;
            this.ColObj.setRectPos(this.x, this.y);
        }
        public override void draw()
        {
            this.sprite.draw();
        }

        public PlayerShip CurrentPlayer
        {
            get
            {
                return playerInstance;
            }
        }
    }
}
