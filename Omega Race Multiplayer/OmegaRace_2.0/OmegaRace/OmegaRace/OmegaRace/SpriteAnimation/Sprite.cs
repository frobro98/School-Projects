using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CollisionManager;
using Box2D.XNA;
using OmegaRace;

namespace SpriteAnimation
{
    class Sprite : DisplayObject
    {
        public float height;
        public float width;
        public bool alpha;
        public int depth;
        public bool isLine;

        public Image image;

        public SpriteEnum spriteName;

        public Sprite(SpriteEnum _name, float _screenX, float _screenY, float _width, float _height, bool _alpha, int _depth, Image _image, bool _isLine)
        {
            width = _width;
            height = _height;
            alpha = _alpha;
            image = _image;
            depth = _depth;
            isLine = _isLine;
            spriteName = _name;
        }

        public void changeImage(Image _image)
        {
            image = _image;
        }

        public override Enum getName()
        {
            return this.spriteName;
        }


    }

    class Sprite_Proxy : DisplayObject
    {
        public Sprite sprite;

        public Color color;
        public float scale;
        public float rotation;
        public Vector2 center;

        public Vector2 pos;
        


        public Sprite_Proxy(Sprite _ref, float _screenX, float _screenY, float _scale, Color _color)
        {
            sprite = _ref;
            pos = new Vector2(_screenX, _screenY);
            color = _color;
            scale = _scale;
            center = new Vector2((sprite.image.sourceRec.Width) / 2.0f, (sprite.image.sourceRec.Height) / 2.0f);
        }


        // For fence Drawing, used to stretch the object
        public Rectangle getDes()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, (int)sprite.width, (int)sprite.height);
        }


        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch batch)
        {
            // for all Objects except fences
            if (!sprite.isLine)
                batch.Draw(((XNA_Text2D)sprite.image.texture.texture).src, new Vector2(pos.X, pos.Y), sprite.image.sourceRec, color, rotation, center, scale, SpriteEffects.None, sprite.depth);

            // For drawing fences
            else
            {
                batch.Draw(((XNA_Text2D)sprite.image.texture.texture).src, getDes(), sprite.image.sourceRec, color, rotation, center, SpriteEffects.None, sprite.depth);
            }
        }

        public override Enum getName()
        {
            return sprite.spriteName;
        }
       
    }
}
