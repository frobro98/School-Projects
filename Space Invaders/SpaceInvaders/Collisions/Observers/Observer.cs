using System;

namespace SpaceInvaders
{
    abstract class Observer
    {
        protected Observer next;
        protected ColSubject subj;

        public Observer()
        {
            next = null;
            subj = null;
        }

        public void setSubject(ColSubject subject)
        {
            subj = subject;
        }

        abstract public void notify();

        public Observer Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }
    }
}
