using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OmegaRace;

namespace SpriteAnimation
{
    enum ImageEnum
    {
        ship,
        missile,
        bluebomb1,
        bluebomb2,
        greenbomb1,
        greenbomb2,
        box,
        circle,
        fencePost,
        explosion,

        fence1,
        fence2,
        fence3,
        fence4,
        fence5,
        fence6,
        fence7, 

        menu,

        Not_Initialized
    }


    class ImageManager : Manager
    {
        private static ImageManager instance;

        private ImageManager()
        {
            createImages();
        }

        public static ImageManager Instance()
        {
            if (instance == null)
                instance = new ImageManager();
            return instance;
        }

        public Image getImage(ImageEnum _enum)
        {
            return (Image)privFind(_enum);
        }

        private void createImages()
        {
            // Grab Sprite Sheet
            Text Shiptext = TextureManager.Instance().getText(TextEnum.ship);
            Text MissileText = TextureManager.Instance().getText(TextEnum.missile);
            Text BlueBombText = TextureManager.Instance().getText(TextEnum.bluebomb1);
            Text BlueBombText2 = TextureManager.Instance().getText(TextEnum.bluebomb2);
            Text GreenBombText = TextureManager.Instance().getText(TextEnum.greenbomb1);
            Text GreenBombText2 = TextureManager.Instance().getText(TextEnum.greenbomb2);
            Text boxText = TextureManager.Instance().getText(TextEnum.box);
            Text circleText = TextureManager.Instance().getText(TextEnum.circle);
            Text fencePostText = TextureManager.Instance().getText(TextEnum.post);
            Text explosionText = TextureManager.Instance().getText(TextEnum.explosion);
            Text fence1 = TextureManager.Instance().getText(TextEnum.fence1);
            Text fence2 = TextureManager.Instance().getText(TextEnum.fence2);
            Text fence3 = TextureManager.Instance().getText(TextEnum.fence3);
            Text fence4 = TextureManager.Instance().getText(TextEnum.fence4);
            Text fence5 = TextureManager.Instance().getText(TextEnum.fence5);
            Text fence6 = TextureManager.Instance().getText(TextEnum.fence6);
            Text fence7 = TextureManager.Instance().getText(TextEnum.fence7);

            this.privActiveAddToFront((ManLink)(new Image(ImageEnum.ship, 0, 0, 32, 32, Shiptext)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Image(ImageEnum.missile, 0, 0, 24, 6, MissileText)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Image(ImageEnum.bluebomb1, 0, 0, 12, 12, BlueBombText)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Image(ImageEnum.bluebomb2, 0, 0, 12, 12, BlueBombText2)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Image(ImageEnum.greenbomb1, 0, 0, 12, 12, GreenBombText)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Image(ImageEnum.greenbomb2, 0, 0, 12, 12, GreenBombText2)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Image(ImageEnum.box, 0, 0, 16, 16, boxText)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Image(ImageEnum.circle, 0, 0, 64, 64, circleText)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Image(ImageEnum.fencePost, 0, 0, 12, 12, fencePostText)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Image(ImageEnum.explosion, 7, 13, 74, 47, explosionText)), ref this.active);

            this.privActiveAddToFront((ManLink)(new Image(ImageEnum.fence1, 0, 0, 6, 209, fence1)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Image(ImageEnum.fence2, 0, 0, 6, 209, fence2)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Image(ImageEnum.fence3, 0, 0, 6, 209, fence3)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Image(ImageEnum.fence4, 0, 0, 6, 209, fence4)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Image(ImageEnum.fence5, 0, 0, 6, 209, fence5)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Image(ImageEnum.fence6, 0, 0, 6, 209, fence6)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Image(ImageEnum.fence7, 0, 0, 6, 209, fence7)), ref this.active);
        }

        protected override object privGetNewObj()
        {
            object pObj = new Image();
            return pObj;
        }

        public void clear()
        {
            this.active = null;
            instance = null;
        }
    }
}
