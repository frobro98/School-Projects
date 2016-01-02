using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using OmegaRace;

namespace SpriteAnimation
{
    enum AnimEnum
    {
        dummy
    }


    class AnimManager : Manager
    {
        private static AnimManager instance;

        private AnimManager()
        {
        }

        public static AnimManager Instance()
        {
            if (instance == null)
                instance = new AnimManager();
            return instance;
        }

        public void addAnimation(Animation _anim)
        {
            /*
            if (head == null)
                head = _anim;
            else
            {
                Animation ptr = head;

                while (ptr.next != null)
                {
                    ptr = ptr.next;
                }
                ptr.next = _anim;

            }*/

            this.privActiveAddToFront((ManLink)_anim, ref this.active);
        }

        public Animation getAnimation(AnimEnum _enum)
        {
            return (Animation)privFind(_enum);
        }


        public void clear()
        {
            this.active = null;
            instance = null;
        }

        protected override object privGetNewObj()
        {
            throw new NotImplementedException();
        }
        

    }
}
