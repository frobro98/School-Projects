using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TopWall : GameObject
    {

        public enum Side
        {
            Top
        }

        private Azul.Rect wallRect;

        public TopWall(Name name, Index index)
            : base(name, SpriteEnum.Null, index, new Azul.Color(0f, 0f, 0f), new Azul.Color(0.0f, 0.5f, 1.0f), 0.0f, 896.0f)
        {
            wallRect = new Azul.Rect(0.0f, 896.0f, 1024.0f, 15.0f);
        }

        public override void accept(Visitor v, CollisionPair pair)
        {
            v.visitTopWall(this, pair);
        }

        public override void visitMissile(Missile v, CollisionPair p)
        {
            p.notify(this, v);
        }

        public override void visitMissileNode(MissileNode mn, CollisionPair p)
        {
            p.collision(this, (GameObject)mn.Child);
        }

        public override void update()
        {
            colObj.setRect(wallRect);
            colObj.update();
        }

        public override void draw()
        {
            
        }
    }
}
