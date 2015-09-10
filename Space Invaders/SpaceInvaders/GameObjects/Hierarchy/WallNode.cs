using System;

namespace SpaceInvaders
{
    class WallNode : Hierarchy
    {


        public WallNode(Azul.Color colColor, GameObject.Name name, Index index = Index.Index_Null)
            : base(colColor, name, index)
        {
        }

        public override void removeObject()
        {

        }

        public override void visitUFO(UFO u, CollisionPair p)
        {
            p.collision(u, (GameObject)this.Child);
        }

        public override void visitUFONode(UFONode u, CollisionPair p)
        {
            p.collision((GameObject)this.child, u);
        }

        public override void visitPlayerNode(PlayerNode p, CollisionPair pair)
        {
            pair.collision(p, (GameObject)this.Child);
        }

        public override void visitBombNode(BombNode bn, CollisionPair p)
        {
            p.collision((GameObject)this.Child, bn);
        }

        public override void visitGridNode(GridNode gn, CollisionPair p)
        {
            p.collision((GameObject)gn, (GameObject)this.Child);
        }

        public override void visitMissileNode(MissileNode mn, CollisionPair p)
        {
            p.collision((GameObject)mn.Child, this);
        }

        public override void visitMissile(Missile v, CollisionPair p)
        {
            p.collision(v, (GameObject)this.Child);
        }

        public override void accept(Visitor v, CollisionPair pair)
        {
            v.visitWallNode(this, pair);
        }

        public override void process()
        {
            
        }
    }
}
