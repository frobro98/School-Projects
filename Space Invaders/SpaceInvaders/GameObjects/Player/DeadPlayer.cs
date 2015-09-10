using System;

namespace SpaceInvaders
{
    class DeadPlayer : GameObject
    {

        public enum Dead
        {
            Dead
        }

        public DeadPlayer(float x, float y)
            : base(Name.Player, SpriteEnum.PlayerExplosion, Index.Index_Null, new Azul.Color(0f, 1f, 0f), new Azul.Color(0f, 0f, 0f), x, y)
        {
            this.colObj = new CollisionObject(SpriteEnum.Null, Index.Index_Null, new Azul.Color(0f, 0f, 0f));
            this.sprite = new ProxySprite(SpriteEnum.PlayerExplosion, Index.Index_Null, x, y);
        }

        public override void removeObject()
        {
            GameObjectManager.removeNode(this.name, this);

            BatchGroup group = this.sprite.getBatch();
            BatchGroup colGroup = this.colObj.getSpriteBatch();
            group.detach(this.sprite);

        }

        public override void accept(Visitor v, CollisionPair pair)
        {
            
        }

        public override void update()
        {
            this.sprite.Color = this.goColor;
            this.sprite.update();
        }

        public override void draw()
        {
            
        }
    }
}
