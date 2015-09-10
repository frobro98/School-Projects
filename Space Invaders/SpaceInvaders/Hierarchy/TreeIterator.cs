using System;

namespace SpaceInvaders
{
    class TreeIterator : Iterator
    {
        private GameObject treeRoot;
        private GameObject current;

        public TreeIterator(GameObject root)
        {
            this.treeRoot = root;
            this.current = this.treeRoot;
        }

        public GameObject first()
        {
            this.current = this.treeRoot;

            return this.current;
        }

        // Tells user if iterator is at the end of a subtree's leaves
        public bool atEnd()
        {
            return current == null;
        }

        public void moveNext()
        {
            this.current = getNext(current);
        }

        private GameObject getNext(TreeNode node, bool willUseChild = true)
        {
            TreeNode toRet = null;

            if (current.Child != null)
            {
                toRet = node.Child;
            }
            else if (node.Sibling != null)
            {
                toRet = node.Sibling;
            }
            else if (node.Parent != null && node.Parent != this.treeRoot)
            {
                toRet = getNext(node.Parent, false);
            }

            return (GameObject)toRet;

        }

        public GameObject getCurrent()
        {
            return (GameObject)current;
        }
        
    }
}
