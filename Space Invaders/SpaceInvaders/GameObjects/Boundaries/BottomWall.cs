using System;

namespace SpaceInvaders
{
    class BottomWall : GameObject
    {

        public enum Side
        {
            Bottom
        }

        private Azul.Rect wallRect;

        public BottomWall(Name name, Index index)
            : base(name, SpriteEnum.Null, index, new Azul.Color(0f, 0f, 0f), new Azul.Color(0f, 0f, 1f), 0f, 15f)
        {
            wallRect = new Azul.Rect(0, 15, 1024.0f, 15.0f);
        }

        public override void accept(Visitor v, CollisionPair pair)
        {
            v.visitBottomWall(this, pair);
        }

        public override void visitBombNode(BombNode bn, CollisionPair p)
        {
            p.collision(this, (GameObject)bn.Child);
        }

        public override void visitBomb(Bomb v, CollisionPair p)
        {
            p.notify(this, v);
        }

        public override void update()
        {
            this.colObj.setRect(this.wallRect);
            this.colObj.update();
        }

        public override void draw()
        {
            
        }
    }
}
