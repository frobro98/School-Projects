using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    class SpriteBatchNode : CollectionNode
    {

        private SpriteEnum name;
        private Index index;
        private BaseSprite sprite;

        public SpriteBatchNode()
            : base()
        {
            this.name = SpriteEnum.Not_Initialized;
            this.index = Index.Index_Null;
        }

        public void set(BaseSprite spr)
        {
            this.sprite = spr;
            Debug.Assert(sprite != null);
            this.name = (SpriteEnum)spr.getName();
            this.index = spr.getIndex();
        }

        public void draw()
        {
            sprite.update();
            sprite.draw();
        }

        public override Enum getName()
        {
            return name;
        }

        public override Index getIndex()
        {
            return index;
        }

        public BaseSprite getSprite()
        {
            return sprite;
        }
    }
}
