using System;

namespace SpaceInvaders
{
    class BombNode : Hierarchy
    {

        public BombNode(Azul.Color color)
            : base(color, Name.Bombs)
        {
        }

        public override void accept(Visitor v, CollisionPair pair)
        {
            v.visitBombNode(this, pair);
        }

        public override void visitPlayerNode(PlayerNode p, CollisionPair pair)
        {
            pair.collision((GameObject)p.Child, this);
        }

        public override void visitPlayer(PlayerShip v, CollisionPair p)
        {
            p.collision(v, (GameObject)this.child);
        }

        public override void visitWallNode(WallNode wn, CollisionPair p)
        {
            p.collision((GameObject)wn.Child, this);
        }

        public override void visitBottomWall(BottomWall bw, CollisionPair p)
        {
            p.collision(bw, (GameObject)this.child);
        }

        public override void visitMissileNode(MissileNode mn, CollisionPair p)
        {
            p.collision((GameObject)mn.Child, this);
        }

        public override void visitMissile(Missile v, CollisionPair p)
        {
            p.collision(v, (GameObject)this.child);
        }

        public override void visitShieldNode(ShieldNode sb, CollisionPair p)
        {
            p.collision(sb, (GameObject)this.child);
        }

        public override void visitShield(ShieldBlock v, CollisionPair p)
        {
            p.collision(v, (GameObject)this.child);
        }

        public override void removeObject()
        {
            
        }

        public override void process()
        {
            
        }
    }
}
