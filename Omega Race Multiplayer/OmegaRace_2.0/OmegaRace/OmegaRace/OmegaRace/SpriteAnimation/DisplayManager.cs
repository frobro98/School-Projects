using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OmegaRace;

namespace SpriteAnimation
{
    enum SpriteEnum
    {
        Ship,
        Title,
        Wall,
        Missile,
        Bomb,
        Floor,
        Roof,
        Score,
        FencePost,
        Explosion,
        p1KillsText,
        p1DeathsText,
        p2KillsText,
        p2DeathsText,
        Wins,
        versionNum,
        courseNum,

        box,


        p1Bomb1,
        p1Bomb2,
        p1Bomb3,
        p1Bomb4,
        p1Bomb5,
        
        
        p2Bomb1,
        p2Bomb2,
        p2Bomb3,
        p2Bomb4,
        p2Bomb5,

        fence1,
        fence2,
        fence3,
        fence4,

        fence5,
        fence6,

        fence7,
        fence8,
        fence9,
        fence10,

        fence11,
        fence12,

        fenceCTop,
        fenceCBot,
        fenceCLeft,
        fenceCRight,

        menu
    }


    // Sprite Factory
    class DisplayManager : Manager
    {
        private static DisplayManager instance;



        private DisplayManager()
        {
            createDisplayObjs();
        }

        public static DisplayManager Instance()
        {
            if (instance == null)
                instance = new DisplayManager();
            return instance;
        }

       
        public void addDisplayObj(Enum _type, DisplayObject _obj)
        {
            //_displayObjs.addNode(_type, _obj);
        }
       
        
        public DisplayObject getDisplayObj(SpriteEnum _enum)
        {
            return (DisplayObject)privFind(_enum);
        }

        public void removeDisplayObj(DisplayObject _obj)
        {
            privActiveRemoveNode(_obj, ref this.active);
        }

        private void createDisplayObjs()
        {
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.Ship, 0, 0, 30, 30, true, 0,
                             ImageManager.Instance().getImage(ImageEnum.ship), false)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.Ship, 0, 0, 30, 30, true, 0,
                            ImageManager.Instance().getImage(ImageEnum.ship), false)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.Missile, 0, 0, 25, 10, true, 0,
                             ImageManager.Instance().getImage(ImageEnum.missile), false)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.Wall, 0, 0, 10, 10, true, 0,
                            ImageManager.Instance().getImage(ImageEnum.box), false)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.FencePost, 0, 0, 10, 10, true, 0,
                            ImageManager.Instance().getImage(ImageEnum.fencePost), false)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.Explosion, 0, 0, 10, 10, true, 0,
                ImageManager.Instance().getImage(ImageEnum.explosion), false)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.box, 0, 0, 10, 10, true, 0,
                ImageManager.Instance().getImage(ImageEnum.box), false)), ref this.active);

            this.privActiveAddToFront((ManLink)(new TextSprite(SpriteEnum.p1KillsText, ((XNA_Font)(TextureManager.Instance().getText(TextEnum.font).texture)).src,
                "", new Vector2(110, 100), Color.White, 0.3f)), ref this.active);

            this.privActiveAddToFront((ManLink)(new TextSprite(SpriteEnum.p1DeathsText, ((XNA_Font)(TextureManager.Instance().getText(TextEnum.font).texture)).src,
                "", new Vector2(103, 105), Color.White, 0.3f)), ref this.active);

            this.privActiveAddToFront((ManLink)(new TextSprite(SpriteEnum.p2KillsText, ((XNA_Font)(TextureManager.Instance().getText(TextEnum.font).texture)).src,
                "", new Vector2(168, 100), Color.White, 0.3f)), ref this.active);

            this.privActiveAddToFront((ManLink)(new TextSprite(SpriteEnum.p2DeathsText, ((XNA_Font)(TextureManager.Instance().getText(TextEnum.font).texture)).src,
                "", new Vector2(168, 105), Color.White, 0.3f)), ref this.active);

            this.privActiveAddToFront((ManLink)(new TextSprite(SpriteEnum.p2DeathsText, ((XNA_Font)(TextureManager.Instance().getText(TextEnum.font).texture)).src,
                "", new Vector2(168, 105), Color.White, 0.3f)), ref this.active);

            this.privActiveAddToFront((ManLink)(new TextSprite(SpriteEnum.Wins, ((XNA_Font)(TextureManager.Instance().getText(TextEnum.font).texture)).src,
                "", new Vector2(137, 80), Color.White, 0.8f)), ref this.active);

            this.privActiveAddToFront((ManLink)(new TextSprite(SpriteEnum.versionNum, ((XNA_Font)(TextureManager.Instance().getText(TextEnum.font).texture)).src,
                "", new Vector2(208, 111), Color.White, 0.3f)), ref this.active);

            this.privActiveAddToFront((ManLink)(new TextSprite(SpriteEnum.courseNum, ((XNA_Font)(TextureManager.Instance().getText(TextEnum.font).texture)).src,
                "", new Vector2(78, 111), Color.White, 0.3f)), ref this.active) ;

            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.p1Bomb1, 0, 0, 50, 50, true, 0,
                            ImageManager.Instance().getImage(ImageEnum.bluebomb1), false)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.p1Bomb2, 0, 0, 50, 50, true, 0,
                            ImageManager.Instance().getImage(ImageEnum.bluebomb1), false)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.p1Bomb3, 0, 0, 50, 50, true, 0,
                            ImageManager.Instance().getImage(ImageEnum.bluebomb1), false)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.p1Bomb4, 0, 0, 50, 50, true, 0,
                            ImageManager.Instance().getImage(ImageEnum.bluebomb1), false)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.p1Bomb5, 0, 0, 50, 50, true, 0,
                            ImageManager.Instance().getImage(ImageEnum.bluebomb1), false)), ref this.active);

            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.p2Bomb1, 0, 0, 50, 50, true, 0,
                            ImageManager.Instance().getImage(ImageEnum.greenbomb1), false)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.p2Bomb2, 0, 0, 50, 50, true, 0,
                            ImageManager.Instance().getImage(ImageEnum.greenbomb1), false)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.p2Bomb3, 0, 0, 50, 50, true, 0,
                            ImageManager.Instance().getImage(ImageEnum.greenbomb1), false)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.p2Bomb4, 0, 0, 50, 50, true, 0,
                            ImageManager.Instance().getImage(ImageEnum.greenbomb1), false)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.p2Bomb5, 0, 0, 50, 50, true, 0,
                            ImageManager.Instance().getImage(ImageEnum.greenbomb1), false)), ref this.active);


            // Top Walls
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.fence1, 0, 0, 2, 75, true, 0,
                ImageManager.Instance().getImage(ImageEnum.fence1), true)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.fence2, 0, 0, 2, 75, true, 0,
                ImageManager.Instance().getImage(ImageEnum.fence1), true)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.fence3, 0, 0, 2, 75, true, 0,
                ImageManager.Instance().getImage(ImageEnum.fence1), true)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.fence4, 0, 0, 2, 75, true, 0,
                ImageManager.Instance().getImage(ImageEnum.fence1), true)), ref this.active);

            // Right Wall
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.fence5, 0, 0, 2, 95, true, 0,
                ImageManager.Instance().getImage(ImageEnum.fence1), true)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.fence6, 0, 0, 2, 95, true, 0,
                ImageManager.Instance().getImage(ImageEnum.fence1), true)), ref this.active);

            // Left Wall
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.fence7, 0, 0, 2, 95, true, 0,
                ImageManager.Instance().getImage(ImageEnum.fence1), true)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.fence8, 0, 0, 2, 95, true, 0,
                ImageManager.Instance().getImage(ImageEnum.fence1), true)), ref this.active);

            // Bottom Wall
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.fence9, 0, 0, 2, 75, true, 0,
                ImageManager.Instance().getImage(ImageEnum.fence1), true)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.fence10, 0, 0, 2, 75, true, 0,
                ImageManager.Instance().getImage(ImageEnum.fence1), true)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.fence11, 0, 0, 2, 75, true, 0,
                ImageManager.Instance().getImage(ImageEnum.fence1), true)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.fence12, 0, 0, 2, 75, true, 0,
                ImageManager.Instance().getImage(ImageEnum.fence1), true)), ref this.active);

            // Center
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.fenceCTop, 0, 0, 2, 150, true, 0,
                ImageManager.Instance().getImage(ImageEnum.fence1), true)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.fenceCBot, 0, 0, 2, 150, true, 0,
                ImageManager.Instance().getImage(ImageEnum.fence1), true)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.fenceCLeft, 0, 0, 2, 50, true, 0,
                ImageManager.Instance().getImage(ImageEnum.fence1), true)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Sprite(SpriteEnum.fenceCRight, 0, 0, 2, 50, true, 0,
                ImageManager.Instance().getImage(ImageEnum.fence1), true)), ref this.active);

        }

        protected override object privGetNewObj()
        {
            return null;
        }

        public void clear()
        {
            this.active = null;
            instance = null;

        }
    }
}
