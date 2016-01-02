using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpriteAnimation
{
    // This is not used for Manager Links
    // these ImageLinks are used for Animations

    class ImageLink
    {
        public ImageLink next;
        public ImageLink prev;

        public Image image;

        public ImageLink(Image _image)
        {
            this.Initialize();
            image = _image;
        }


        protected virtual void Initialize()
        {
            this.next = null;
            this.prev = null;
        }
    }
}
