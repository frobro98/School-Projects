using System;

namespace SpaceInvaders
{
    class RightWall : GameObject
    {
        public enum Side
        {
            Right
        }

        private Azul.Rect wallRect;

        public RightWall(Name name, Index index)
            : base(name, SpriteEnum.Null, index, new Azul.Color(0f, 0f, 0f), new Azul.Color(0.0f, 1.0f, 0.0f), 1024.0f, 896.0f)
        {
            this.index = index;
            wallRect = new Azul.Rect(1009.0f, 896.0f, 15.0f, 896.0f);
        }

        public override Index getIndex()
        {
            return index;
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

        public override void accept(Visitor v, CollisionPair pair)
        {
            v.visitRightWall(this, pair);
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
