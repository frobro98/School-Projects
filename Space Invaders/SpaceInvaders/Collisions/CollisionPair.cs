using System;

namespace SpaceInvaders
{
    class CollisionPair : ManNode
    {
        public enum Type
        {
            AlienMissile,
            AlienPlayer,
            AlienShield,
            AlienSide,
            MissileBomb,
            MissileUFO,
            MissileTop,
            MissileShield,
            ShieldBomb,
            BombPlayer,
            BombBottom,
            PlayerSide,
            UFOSide
        }

        private GameObject treeA;
        private GameObject treeB;
        private ColSubject subject;
        bool collided;

        private Type type;

        public CollisionPair()
            : base()
        {
        }

        public void set(Type t, GameObject.Name tA, GameObject.Name tB)
        {
            this.treeA = GameObjectManager.find(tA);
            this.treeB = GameObjectManager.find(tB);
            this.type = t;
            this.subject = new ColSubject();
            collided = false;
        }

        public void attach(Observer newObserv)
        {
            subject.attach(newObserv);
        }

        public void collision(GameObject nodeA, GameObject nodeB)
        {
            GameObject currA = nodeA;
            GameObject currB = nodeB;

            while (currA != null)
            {
                currB = nodeB;
                while (currB != null)
                {
                    if (intersect(currA, currB))
                    {
                        currA.accept(currB, this);
                        return;
                    }

                    currB = (GameObject)currB.Sibling;
                }

                currA = (GameObject)currA.Sibling;
            }
            collided = false;
        }

        public void testCollision()
        {
            this.collision(this.treeA, this.treeB);    
        }

        public void notify(GameObject go1, GameObject go2)
        {
            if (!collided)
            {
                subject.notifyObservers(go1, go2);
            }
            collided = true;
        }

        private bool intersect(GameObject elem1, GameObject elem2)
        {
            Azul.Rect c1 = elem1.ColObj.Bounds;
            Azul.Rect c2 = elem2.ColObj.Bounds;

            float minX1 = c1.x;
            float minY1 = c1.y - c1.h;
            float maxX1 = c1.x + c1.w;
            float maxY1 = c1.y;

            float minX2 = c2.x;
            float minY2 = c2.y - c2.h;
            float maxX2 = c2.x + c2.w;
            float maxY2 = c2.y;
            bool result = false;

            if (minX1 < maxX2 && maxX1 > minX2 &&
                minY1 < maxY2 && maxY1 > minY2)
            {
                result = true;
            }

            return result;
            
        }

        public override Enum getName()
        {
            return type;
        }

        public override Index getIndex()
        {
            return Index.Index_Null;
        }
    }
}
