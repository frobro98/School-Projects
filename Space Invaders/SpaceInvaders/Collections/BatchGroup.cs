using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BatchGroup : Collection
    {
        public enum BatchType
        {
            Aliens,
            Collisions,
            Player,
            UFO,
            HUD,
            Missiles,
            Bombs,
            Shields,
            Explosions,
            Null
        }

        private BatchType name;
        private Index index;
        private bool willDraw;

        public BatchGroup(int toCreate, int willCreate)
            : base(toCreate, willCreate)
        {
            name = BatchType.Null;
            index = Index.Index_Null;
            willDraw = true;
        }

        // Prevents use of default constructor
        private BatchGroup()
            :base(0, 0)
        {
        }

        public void set(BatchType name, Index index, bool draw = true)
        {
            this.name = name;
            this.index = index;
            this.willDraw = draw;
        }

        public override CollectionNode getCollectionObj()
        {
            CollectionNode node = new SpriteBatchNode();
            return node;
        }

        public void attach(BaseSprite spr)
        {
            SpriteBatchNode toAdd = (SpriteBatchNode)this.Add();
            toAdd.set(spr);
            spr.setBatch(this);
        }

        public SpriteBatchNode find(SpriteEnum sName, Index index = Index.Index_Null)
        {
            return (SpriteBatchNode)this.Find(sName, index);
        }

        public void detach(BaseSprite sprite)
        {
            //this.Remove(sName, index);
            SpriteBatchNode curr = (SpriteBatchNode)this.activeHead;

            while (curr != null)
            {
                if (curr.getSprite() == sprite)
                {
                    break;
                }

                curr = (SpriteBatchNode)curr.next;
            }

            if (this.activeHead == curr && curr != null)
            {
                activeHead = activeHead.next;
                if (activeHead != null)
                {
                    activeHead.prev = null;
                }
            }
            else if(curr != null)
            {
                curr.prev.next = curr.next;

                if (curr.next != null)
                {
                    curr.next.prev = curr.prev;
                }
            }
        }

        public void draw()
        {
            if (Azul.Input.GetKeyState(Azul.AZUL_KEYS.KEY_F1) && 
                this.name.Equals(BatchType.Collisions))
            {
                if (willDraw)
                {
                    willDraw = false;
                }
                else
                {
                    willDraw = true;
                }
            }

            if (willDraw)
            {
                SpriteBatchNode node = (SpriteBatchNode)this.activeHead;
                while (node != null)
                {
                    node.draw();

                    node = (SpriteBatchNode)node.next;
                }
            }
        }

        public override Enum getName()
        {
            return name;
        }

        public override Index getIndex()
        {
            return index;
        }
    }
}
