using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ReverseTreeIterator : Iterator
    {
        private GameObject treeRoot;
        private GameObject current;

        public ReverseTreeIterator(TreeNode root)
        {
            Debug.Assert(root != null);
            treeRoot = (GameObject)root;
            current = (GameObject)root;

            GameObject go = treeRoot;
            GameObject node = go;

            while (go != null)
            {
                node = go;
                go = this.next();

                if (go != null)
                {
                    go.Reverse = node;
                }
                
            }

            this.treeRoot = node;
            this.current = node;

        }

        public GameObject first()
        {
            this.current = this.treeRoot;

            return (GameObject)this.current;
        }

        public GameObject getCurrent()
        {
            return current;
        }

        public void moveNext()
        {
            this.current = (GameObject)this.current.Reverse;
        }

        private GameObject next()
        {
            this.current = getNext(this.current);

            return this.current;
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

        public bool atEnd()
        {
            return current == null;
        }
    }
}
