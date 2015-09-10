using System;

namespace SpaceInvaders
{
    class MissileNode : Hierarchy
    {

        public enum MissileName
        {
            Missile
        }

        public MissileNode(Azul.Color color)
            : base(color, Name.Missiles)
        {
        }

        public override void removeObject()
        {

        }

        public override void accept(Visitor v, CollisionPair pair)
        {
            v.visitMissileNode(this, pair);
        }

        public override void visitGridNode(GridNode gn, CollisionPair p)
        {
            p.collision((GameObject)this.child, gn);
        }

        public override void visitUFONode(UFONode u, CollisionPair p)
        {
            p.collision(u, (GameObject)this.child);
        }

        public override void visitUFO(UFO v, CollisionPair p)
        {
            p.collision(v, (GameObject)this.child);
        }

        public override void visitWallNode(WallNode wn, CollisionPair p)
        {
            p.collision((GameObject)this.Child, wn);
        }

        public override void visitTopWall(TopWall tw, CollisionPair p)
        {
            p.collision((GameObject)this.Child, tw);
        }

        public override void visitShieldNode(ShieldNode sb, CollisionPair p)
        {
            p.collision(sb, (GameObject)this.child);
        }

        public override void visitShield(ShieldBlock v, CollisionPair p)
        {
            p.collision(v, (GameObject)this.child);
        }

        public override void process()
        {
            
        }

    }
}
