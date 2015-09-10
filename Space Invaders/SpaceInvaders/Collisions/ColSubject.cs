using System;

namespace SpaceInvaders
{
    class ColSubject
    {
        private GameObject obj1;
        private GameObject obj2;
        private Observer observerList;

        public ColSubject()
        {

        }

        public void notifyObservers(GameObject obj1, GameObject obj2)
        {
            this.obj1 = obj1;
            this.obj2 = obj2;

            Observer currObv = observerList;
            while (currObv != null)
            {
                currObv.notify();

                currObv = currObv.Next;
            }
        }

        public void attach(Observer obser)
        {
            obser.setSubject(this);
            obser.Next = observerList;
            observerList = obser;

        }

        public GameObject GameObj1
        {
            get
            {
                return obj1;
            }
        }

        public GameObject GameObj2
        {
            get
            {
                return obj2;
            }
        }
    }
}
