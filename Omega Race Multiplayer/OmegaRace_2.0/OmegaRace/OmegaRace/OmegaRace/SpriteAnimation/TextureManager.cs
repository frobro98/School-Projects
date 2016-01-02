using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using CollisionManager;
using OmegaRace;

namespace SpriteAnimation
{

    enum TextEnum
    {
        // Alien Sprite Sheet
        ship,
        missile,
        bluebomb1,
        bluebomb2,
        greenbomb1,
        greenbomb2,
        post,
        box, 
        circle,
        explosion,
        font,

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

    enum Type
    {
        Text_Font,
        Text_Sprite,
        Text_Box,

        Not_Initialized
    }



    class TextureManager : Manager
    {
        private static TextureManager instance;



        private TextureManager()
        {
            createTexts();
        }

        public static TextureManager Instance()
        {
            if(instance == null)
                instance = new TextureManager();
            return instance;
        }


        public void Unload()
        {
            Game1.GameInstance.Content.Unload();
        }

        public Text getText(TextEnum _enum)
        {
            return (Text)privFind(_enum);
        }

        private void createTexts()
        {
            this.privActiveAddToFront((ManLink)(new Text("PlayerShip", TextEnum.ship, 1024, 32, 32, true, Type.Text_Sprite)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Text("Laser", TextEnum.missile, 144, 6, 24, true, Type.Text_Sprite)), ref this.active);
            this.privActiveAddToFront((ManLink)(new Text("BlueMine", TextEnum.bluebomb1, 144, 12, 12, true, Type.Text_Sprite)), ref this.active );

            this.privActiveAddToFront((ManLink)(new Text("BlueMine2", TextEnum.bluebomb2, 144, 12, 12, true, Type.Text_Sprite)), ref this.active );
            this.privActiveAddToFront((ManLink)(new Text("GreenMine", TextEnum.greenbomb1, 144, 12, 12, true, Type.Text_Sprite)), ref this.active );
            this.privActiveAddToFront((ManLink)(new Text("GreenMine2", TextEnum.greenbomb2, 144, 12, 12, true, Type.Text_Sprite)), ref this.active );
            this.privActiveAddToFront((ManLink)(new Text("Box", TextEnum.box, 0, 1, 1, true, Type.Text_Box)), ref this.active );
            this.privActiveAddToFront((ManLink)(new Text("Circle", TextEnum.circle, 0, 64, 64, false, Type.Text_Sprite)), ref this.active );
            this.privActiveAddToFront((ManLink)(new Text("FencePost", TextEnum.post, 0, 12, 12, true, Type.Text_Sprite)), ref this.active );
            this.privActiveAddToFront((ManLink)(new Text("explosion", TextEnum.explosion, 0, 70, 86, true, Type.Text_Sprite)), ref this.active );
            this.privActiveAddToFront((ManLink)(new Text("SpriteFont1", TextEnum.font, 0, 70, 86, true, Type.Text_Font)), ref this.active); 

            // Fences
            this.privActiveAddToFront((ManLink)(new Text("FenceTall1", TextEnum.fence1, 0, 209, 6, true, Type.Text_Sprite)), ref this.active );
            this.privActiveAddToFront((ManLink)(new Text("FenceTall2", TextEnum.fence2, 0, 209, 6, true, Type.Text_Sprite)), ref this.active );
            this.privActiveAddToFront((ManLink)(new Text("FenceTall3", TextEnum.fence3, 0, 209, 6, true, Type.Text_Sprite)), ref this.active );
            this.privActiveAddToFront((ManLink)(new Text("FenceTall4", TextEnum.fence4, 0, 209, 6, true, Type.Text_Sprite)), ref this.active );
            this.privActiveAddToFront((ManLink)(new Text("FenceTall5", TextEnum.fence5, 0, 209, 6, true, Type.Text_Sprite)), ref this.active );
            this.privActiveAddToFront((ManLink)(new Text("FenceTall6", TextEnum.fence6, 0, 209, 6, true, Type.Text_Sprite)), ref this.active );
            this.privActiveAddToFront((ManLink)(new Text("FenceTall7", TextEnum.fence7, 0, 209, 6, true, Type.Text_Sprite)), ref this.active );
                                            
            
        }

        protected override object privGetNewObj()
        {
            object pObj = new Text();
            return pObj;
        }

        public void clear()
        {
            this.active = null;
            instance = null;
        }
        
    }
}
