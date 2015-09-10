using System;

namespace SpaceInvaders
{
    abstract class TreeNode : Visitor
    {
        protected TreeNode parent;
        protected TreeNode child;
        protected TreeNode sibling;
        protected TreeNode reverse;

        protected TreeNode()
        {
            this.parent = null;
            this.child = null;
            this.sibling = null;
            this.reverse = null;
        }

        abstract public Enum getName();
        abstract public Index getIndex();

        public TreeNode Parent
        {
            get
            {
                return this.parent;
            }
            set
            {
                this.parent = value;
            }
        }
        public TreeNode Child
        {
            get
            {
                return this.child;
            }
            set
            {
                this.child = value;
            }
        }
        public TreeNode Sibling
        {
            get
            {
                return this.sibling;
            }
            set
            {
                this.sibling = value;
            }
        }
        public TreeNode Reverse
        {
            get
            {
                return reverse;
            }
            set
            {
                reverse = value;
            }
        }

    }
}
