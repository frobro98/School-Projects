using System;

namespace SpaceInvaders
{
    abstract class Alien : GameObject
    {

        public Alien(GameObject.Name goName, SpriteEnum sprName, Index index, float x, float y)
            : base(goName, sprName, index, new Azul.Color(1f, 1f, 1f), new Azul.Color(1.0f, 0.0f, 0.0f), x, y)
        {
            sprite = new ProxySprite(sprName, index, x, y);
        }

        public override void accept(Visitor v, CollisionPair pair)
        {
            v.visitAlien(this, pair);
        }

        public override void visitShield(ShieldBlock v, CollisionPair p)
        {
            p.notify(this, v);
        }

        public override void visitMissile(Missile v, CollisionPair p)
        {

        }

        public override void visitPlayer(PlayerShip v, CollisionPair p)
        {

        }

    }
}
