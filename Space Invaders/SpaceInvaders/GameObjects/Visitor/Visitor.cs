using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class Visitor
    {
        abstract public void accept(Visitor v, CollisionPair pair);

        public virtual void visitShieldNode(ShieldNode sb, CollisionPair p)
        {
            Debug.Assert(false, "Shouldn't have been called");
        }
        public virtual void visitShield(ShieldBlock v, CollisionPair p)
        {
            Debug.Assert(false, "Shouldn't have been called");
        }
        public virtual void visitMissile(Missile v, CollisionPair p)
        {
            Debug.Assert(false, "Shouldn't have been called");
        }
        public virtual void visitMissileNode(MissileNode mn, CollisionPair p)
        {
            Debug.Assert(false, "Shouldn't have been called");
        }

        public virtual void visitPlayerNode(PlayerNode p, CollisionPair pair)
        {
            Debug.Assert(false, "Shouldn't have been called");
        }
        public virtual void visitPlayer(PlayerShip v, CollisionPair p)
        {
            Debug.Assert(false, "Shouldn't have been called");
        }

        public virtual void visitBombNode(BombNode bn, CollisionPair p)
        {
            Debug.Assert(false, "Shouldn't have been called");
        }

        public virtual void visitBomb(Bomb v, CollisionPair p)
        {
            Debug.Assert(false, "Shouldn't have been called");
        }
        public virtual void visitAlien(Alien a, CollisionPair p)
        {
            Debug.Assert(false, "Shouldn't have been called");
        }
        public virtual void visitUFONode(UFONode u, CollisionPair p)
        {
            Debug.Assert(false, "Shouldn't have been called");
        }
        public virtual void visitUFO(UFO v, CollisionPair p)
        {
            Debug.Assert(false, "Shouldn't have been called");
        }

        public virtual void visitGridNode(GridNode gn, CollisionPair p)
        {
            Debug.Assert(false, "Shouldn't have been called");
        }
        public virtual void visitWallNode(WallNode wn, CollisionPair p)
        {
            Debug.Assert(false, "Shouldn't have been called");
        }

        // Boundaries
        public virtual void visitRightWall(RightWall rw, CollisionPair p)
        {
            Debug.Assert(false, "Shouldn't have been called");
        }
        public virtual void visitLeftWall(LeftWall lw, CollisionPair p)
        {
            Debug.Assert(false, "Shouldn't have been called");
        }
        public virtual void visitTopWall(TopWall tw, CollisionPair p)
        {
            Debug.Assert(false, "Shouldn't have been called");
        }
        public virtual void visitBottomWall(BottomWall bw, CollisionPair p)
        {
            Debug.Assert(false, "Shouldn't have been called");
        }


    }
}
