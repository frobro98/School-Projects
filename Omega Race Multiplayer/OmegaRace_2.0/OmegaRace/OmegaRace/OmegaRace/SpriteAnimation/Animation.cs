using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OmegaRace;

namespace SpriteAnimation
{
    class Animation : ManLink
    {
        // Head of the Image List
        ImageLink head;
        ImageLink current;

        int numImages;
        int curImage;

        Sprite sprite;

        public Animation(Sprite _sprite)
        {
            sprite = _sprite;
            numImages = 0;
            curImage = 0;
            head = new ImageLink(sprite.image);
            current = head;
        }

        public void addImage(Image _image)
        {
            
            if (head == null)
                head.image = _image;
            else
            {
                ImageLink newLink = new ImageLink(_image);

                ImageLink ptr = head;

                while (ptr.next != null)
                {
                    ptr = ptr.next;
                }

                ptr.next = newLink;
            }

            numImages++;
        }


        public void flipImage()
        {
            if (sprite != null)
            {

                if (curImage >= numImages - 1)
                {
                    current = head;
                    sprite.changeImage(current.image);
                    curImage = 0;
                }
                else
                {
                    current = current.next;
                    sprite.changeImage(current.image);
                    curImage++;
                }
            }
            else { }
        }

        public void changeSprite(Sprite _sprite)
        {
            sprite = _sprite;
        }

        public override Enum getName()
        {
            throw new NotImplementedException();
        }
    }
}
