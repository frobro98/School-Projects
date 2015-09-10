using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GridNode : Hierarchy
    {

        private float deltaX;
        private float deltaY;
        bool moveVert;

        public GridNode(Azul.Color colColor, GameObject.Name name, Index index = Index.Index_Null)
            : base(colColor, name, index)
        {
            this.deltaX = 10.0f;
            this.deltaY = -30.0f;
            moveVert = false;
        }

        #region Visitor methods

        public override void visitWallNode(WallNode wn, CollisionPair p)
        {
            p.collision((GameObject)this.Child, (GameObject)wn.Child);
        }

        public override void visitLeftWall(LeftWall lw, CollisionPair p)
        {
            p.collision((GameObject)this.Child, lw);
        }

        public override void visitRightWall(RightWall rw, CollisionPair p)
        {
            p.collision((GameObject)this.Child, rw);
        }

        public override void visitShieldNode(ShieldNode sb, CollisionPair p)
        {
            p.collision((GameObject)sb.Child, (GameObject)this.child);
        }

        public override void visitMissile(Missile m, CollisionPair p)
        {
            p.collision((GameObject)this.Child, m);
        }

        public override void visitPlayer(PlayerShip v, CollisionPair p)
        {
            base.visitPlayer(v, p);
        }

        public override void accept(Visitor v, CollisionPair pair)
        {
            v.visitGridNode(this, pair);
        }

        #endregion

        public override void removeObject()
        {
            BatchGroup batch = colObj.Spr.getBatch();
            batch.detach(colObj.Spr);
            GameObjectManager.removeNode(GameObject.Name.Grid, this);
            
        }

        public override void process()
        {
            if (moveVert)
            {
                deltaX *= -1.0f;
            }
            processTree(this);
            moveVert = false;
        }

        private void processTree(GameObject treeNode)
        {
            TreeNode child = null;

            if (!moveVert)
            {
                float x = treeNode.getX() + deltaX;
                treeNode.setX(x);
            }
            else
            {
                float y = treeNode.getY() + this.deltaY;
                treeNode.setY(y);
            }

            if (treeNode.Child != null)
            {
                child = treeNode.Child;

                while (child != null)
                {
                    processTree((GameObject)child);

                    child = child.Sibling;
                }
                
            }
        }

        public float DeltaX
        {
            get
            {
                return deltaX;
            }
            set
            {
                deltaX = value;
            }
        }

        public bool MoveVert
        {
            get
            {
                return moveVert;
            }
            set
            {
                moveVert = value;
            }
        }
    }
}
