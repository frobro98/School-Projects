using System;


namespace SpaceInvaders
{
    class NullGameSprite : GameSprite
    {
        public NullGameSprite(SpriteEnum name = SpriteEnum.Null, Index index = Index.Index_Null)
            : base(name, index)
        {

        }

        public override void update()
        {
            
        }
        
        public override void draw()
        {
            // NullSprite does nothing
        }

    }
}
