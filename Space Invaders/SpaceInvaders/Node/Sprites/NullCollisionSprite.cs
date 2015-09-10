using System;


namespace SpaceInvaders
{
    class NullCollisionSprite : CollisionSprite
    {
        public NullCollisionSprite(SpriteEnum name = SpriteEnum.Null, Index index = Index.Index_Null)
            : base()
        {
            this.Rect = new Azul.Rect();
        }

        public override void draw()
        {
            // NullSprite does nothing
        }

    }
}
