using System;

namespace SpaceInvaders
{
    abstract class Hierarchy : GameObject
    {

        public enum Grid
        {
            Grid
        }

        public enum Column
        {
            Column
        }

        public enum Shields
        {
            Shields
        }

        public enum ShieldCol
        {
            Column
        }

        public enum Missiles
        {
            Missiles
        }

        public enum Bombs
        {
            Bombs
        }

        public enum UFOs
        {
            UFO
        }

        public enum Walls
        {
            Walls
        }

        public enum Players
        {
            Player
        }

        private GameObject.Name type;

        abstract public void process();

        protected Hierarchy(Azul.Color colColor, GameObject.Name typeName, Index index = Index.Index_Null)
            : base(typeName, SpriteEnum.Null, index, new Azul.Color(0f, 0f, 0f), colColor, 0.0f, 0.0f)
        {
            this.type = typeName;
            this.index = index;
            this.sprite = new ProxySprite(SpriteEnum.Null, index, 0.0f, 0.0f);
        }

        public override Enum getName()
        {
            return type;
        }

        public override Index getIndex()
        {
            return index;
        }

        public override void update()
        {
            if (this.Child != null)
            {
                GameObject node = (GameObject)this.Child;
                Azul.Rect rectNode = node.ColObj.Bounds;

                while (node != null)
                {
                    rectNode = CollisionObject.union(rectNode, node.ColObj.Bounds);

                    node = (GameObject)node.Sibling;
                }

                this.colObj.setRect(rectNode);
                this.colObj.update();
            }
            else
            {
                this.colObj.setRect(0.0f, 0.0f, 0.0f, 0.0f);
            }
        }
        public override void draw()
        {
            
        }
    }
}
