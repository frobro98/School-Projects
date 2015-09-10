using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ProxyCollisionSprite : BaseSprite
    {
        private CollisionSprite colSprite;
        private Azul.Rect grid;
        private Azul.Color gridColor;

        public ProxyCollisionSprite(Azul.Color color, SpriteEnum name, Index index)
            : base()
        {
            Debug.Assert(color != null);
            //Debug.Assert(name.Equals(SpriteEnum.Collision));
            //Debug.Assert(index.Equals(Index.Index_Null));

            setBase(name, index, 0.0f, 0.0f);
            colSprite = CollisionSpriteManager.find(SpriteEnum.Collision, Index.Index_Null);
            grid = new Azul.Rect();
            gridColor = color;
        }

        public override void update()
        {
            colSprite.Rect = grid;
            colSprite.Color = this.gridColor;
        }

        public override void draw()
        {
            colSprite.draw();
        }

        public Azul.Rect Rect
        {
            get
            {
                return grid;
            }
            set
            {
                grid = value;
            }
        }
    }
}
