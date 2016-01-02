using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CollisionManager;
using OmegaRace;

namespace SpriteAnimation
{
    class Text : ManLink
    {
        public string assetName;
        public TextEnum textName;
        public int size;
        public int height;
        public int width;
        public Type textType;
        public bool alpha;

        public XNA_Texture texture;

        public Text(String _assetName, TextEnum _textName, int _size, int _height,
            int _width, bool _alpha, Type _textType)
        {
            assetName = _assetName;
            textName = _textName;
            size = _size;
            height = _height;
            width = _width;
            alpha = _alpha;
            textType = _textType;

            

            if (_textType == Type.Text_Sprite)
            {
                texture = new XNA_Text2D();

                ((XNA_Text2D)texture).src = Game1.GameInstance.Content.Load<Texture2D>(assetName);
            }
            else if (_textType == Type.Text_Font)
            {
                texture = new XNA_Font();

                ((XNA_Font)texture).src = Game1.GameInstance.Content.Load<SpriteFont>(assetName);
            }

            else if (_textType == Type.Text_Box)
            {
                texture = new XNA_Text2D();

                ((XNA_Text2D)texture).src = new Texture2D(Game1.GameInstance.GraphicsDevice, 1, 1);
                ((XNA_Text2D)texture).src.SetData(new[] { Color.White });
            }
            else { }
        }

        public Text()
        {
            assetName = null;
            textName = TextEnum.Not_Initialized;
            size = 0;
            height = 0;
            width = 0;
            alpha = false;
            textType = Type.Not_Initialized;
        }

        public override Enum getName()
        {
            return this.textName;
        }

    }

   
}
