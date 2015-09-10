using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class UFO : GameObject
    {

        public enum Side
        {
            Left,
            Right
        }

        private Side side;

        public UFO(Side side, float x, float y)
            : base(Name.UFO, SpriteEnum.UFO, Index.Index_Null, new Azul.Color(1.0f, 0.0f, 0.0f), new Azul.Color(1f, 1f, 1f), x, y)
        {
            this.side = side;
            this.sprite = new ProxySprite(SpriteEnum.UFO, Index.Index_Null, x, y);
        }

        public void set(Side side, float x, float y)
        {
            this.side = side;
            this.x = x;
            this.y = y;
        }

        public override void removeObject()
        {
            GameObjectManager.removeNode(this.name, this);

            BatchGroup group = this.sprite.getBatch();
            BatchGroup colGroup = this.colObj.getSpriteBatch();
            group.detach(this.sprite);
            colGroup.detach(this.colObj.Spr);

            UFOFactory.receiveUFO(this);
            Random rand = new Random();
            int time = rand.Next(15, 21);
            TimeEventManager.add((float)time, new SpawnUFO());
        }

        public override void accept(Visitor v, CollisionPair pair)
        {
            v.visitUFO(this, pair);
        }

        public override void visitLeftWall(LeftWall lw, CollisionPair p)
        {
            if (this.side.Equals(Side.Right))
            {
                p.notify(lw, this);
            }
        }

        public override void visitRightWall(RightWall rw, CollisionPair p)
        {
            if (side.Equals(Side.Left))
            {
                p.notify(rw, this);
            }
        }

        public override void visitWallNode(WallNode wn, CollisionPair p)
        {
            p.collision((GameObject)wn.Child, this);
        }

        public override void visitMissileNode(MissileNode mn, CollisionPair p)
        {
            p.collision((GameObject)mn.Child, this);
        }

        public override void visitMissile(Missile v, CollisionPair p)
        {
            p.notify(v, this);
        }

        public override void update()
        {
            if (side.Equals(Side.Left))
            {
                this.x += 4f;
            }
            else if(side.Equals(Side.Right))
            {
                this.x -= 4f;
            }

            this.sprite.setPos(x, y);
            this.colObj.setRectPos(x, y);
            this.sprite.Color = this.goColor;
        }

        public override void draw()
        {
            this.sprite.draw();
        }

        public Side WallSide
        {
            get
            {
                return side;
            }
        }
    }
}
