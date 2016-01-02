using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CollisionManager;

namespace SpriteAnimation
{
    class TextSprite : DisplayObject
    {

        private SpriteFont refFont;
        public string message;
        private Vector2 pos;
        private Color color;
        private float scale;

        Random rnd = new Random();
        Vector2 spriteSpeed;
        Vector2 size;

        public SpriteEnum spriteName;

        public TextSprite(SpriteEnum _name, SpriteFont _refFont, string _mes, Vector2 _pos, Color _color, float _scale)
        {
            refFont = _refFont;
            message = _mes;
            pos = _pos;
            color = _color;
            scale = _scale;

            spriteSpeed = new Vector2((rnd.Next(0, 2) * 2) - 1, (rnd.Next(0, 2) * 2) - 1);
            size = refFont.MeasureString(message);

            spriteName = _name;
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.DrawString(refFont, message, pos, color, 0, new Vector2(0, 0), scale, SpriteEffects.None, 0);
        }

        public string getMessage()
        {
            return message;
        }

        public override Enum getName()
        {
            return this.spriteName;
        }
    }
}
