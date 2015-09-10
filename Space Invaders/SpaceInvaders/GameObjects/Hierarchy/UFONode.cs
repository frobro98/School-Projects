using System;

namespace SpaceInvaders
{
    class UFONode : Hierarchy
    {

        public UFONode(Azul.Color color)
            : base(color, Name.UFO)
        {
        }

        public override void removeObject()
        {

        }

        public override void accept(Visitor v, CollisionPair pair)
        {
            v.visitUFONode(this, pair);
        }

        public override void visitLeftWall(LeftWall lw, CollisionPair p)
        {
            p.collision(lw, (GameObject)this.child);
        }

        public override void visitRightWall(RightWall rw, CollisionPair p)
        {
            p.collision(rw, (GameObject)this.child);
        }

        public override void visitWallNode(WallNode wn, CollisionPair p)
        {
            p.collision((GameObject)wn.Child, this);
        }

        public override void visitMissileNode(MissileNode mn, CollisionPair p)
        {
            p.collision(mn, (GameObject)this.child);
        }

        public override void visitMissile(Missile v, CollisionPair p)
        {
            p.collision(v, (GameObject)this.child);
        }

        public override void process()
        {
            
        }
    }
}
