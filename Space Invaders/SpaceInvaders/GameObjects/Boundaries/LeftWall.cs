using System;

namespace SpaceInvaders
{
    class LeftWall : GameObject
    {
        public enum Side
        {
            Left
        }

        private Azul.Rect wallRect;

        public LeftWall(Name name, Index index)
            : base(name, SpriteEnum.Null, index, new Azul.Color(0f, 0f, 0f), new Azul.Color(0.0f, 1.0f, 0.0f), 0.0f, 896.0f)
        {
            this.wallRect = new Azul.Rect(0.0f, 896.0f, 15.0f, 896.0f);
        }

        public override void accept(Visitor v, CollisionPair pair)
        {
            v.visitLeftWall(this, pair);
        }

        public override void visitGridNode(GridNode gn, CollisionPair p)
        {
            p.notify(gn, this);
        }
        public override void visitPlayerNode(PlayerNode p, CollisionPair pair)
        {
            pair.collision((GameObject)p.Child, this);
        }

        public override void visitPlayer(PlayerShip v, CollisionPair p)
        {
            p.notify(v, this);
        }

        public override void update()
        {
            this.colObj.setRect(wallRect);
            this.colObj.update();
        }

        public override void draw()
        {
            
        }
    }
}
