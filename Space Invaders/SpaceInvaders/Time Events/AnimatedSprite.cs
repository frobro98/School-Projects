using System;


namespace SpaceInvaders
{
    class AnimatedSprite : Command
    {
        private SpriteEnum name;
        private Index index;
        private Image imgToSwap;
        private GameSprite sprite;

        public AnimatedSprite()
        {
            name = SpriteEnum.Not_Initialized;
            index = Index.Index_Null;
            sprite = null;
            imgToSwap = null;
        }

        public AnimatedSprite(SpriteEnum sName, ImageEnum iName, Index index = Index.Index_Null)
        {
            this.name = sName;
            this.index = index;
            sprite = GameSpriteManager.find(sName, index);
            imgToSwap = ImageManager.find(iName);
        }

        public void set(SpriteEnum sName, ImageEnum iName, Index index = Index.Index_Null)
        {
            this.name = sName;
            this.index = index;
            sprite = GameSpriteManager.find(sName, index);
            imgToSwap = ImageManager.find(iName);
        }

        // Swaps image of GameSprite ref
        public override void execute(float time)
        {
            Image newImg = sprite.Img;
            sprite.Img = imgToSwap;
            imgToSwap = newImg;
            TimeEventManager.add(GameManager.MoveFrameTime, this, TimeEvent.EventType.Animation, this.index);
        }

        public SpriteEnum getName()
        {
            return name;
        }
    }
}
