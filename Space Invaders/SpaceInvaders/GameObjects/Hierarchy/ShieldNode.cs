using System;

namespace SpaceInvaders
{
    class ShieldNode : Hierarchy
    {



        public ShieldNode(Azul.Color color)
            : base(color, Name.Shields)
        {
        }

        public override void accept(Visitor v, CollisionPair pair)
        {
            v.visitShieldNode(this, pair);
        }

        public override void visitMissileNode(MissileNode mn, CollisionPair p)
        {
            p.collision(this, (GameObject)mn.Child);
        }

        public override void visitMissile(Missile v, CollisionPair p)
        {
            p.collision((GameObject)this.child, v);
        }

        public override void visitBombNode(BombNode bn, CollisionPair p)
        {
            p.collision(this, (GameObject)bn.Child);
        }

        public override void visitBomb(Bomb v, CollisionPair p)
        {
            p.collision((GameObject)this.child, v);
        }

        public override void visitGridNode(GridNode gn, CollisionPair p)
        {
            p.collision((GameObject)gn.Child, (GameObject)this.child);
        }

        public override void visitAlien(Alien a, CollisionPair p)
        {
            p.collision((GameObject)this.child, a);
        }

        public override void removeObject()
        {
            BatchGroup batch = colObj.Spr.getBatch();
            batch.detach(colObj.Spr);
            GameObjectManager.removeNode(GameObject.Name.Shields, this);
        }

        public override void process()
        {
            
        }
    }
}
