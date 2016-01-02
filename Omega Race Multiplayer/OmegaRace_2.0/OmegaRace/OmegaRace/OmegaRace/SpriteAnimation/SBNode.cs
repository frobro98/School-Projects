using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CollisionManager;
using OmegaRace;
using System.Diagnostics;

namespace SpriteAnimation
{
    // SpriteBatch Node
    class SBNode : Container
    {
        public batchEnum batchName;
      //  public DisplayObject displayHead;

        public SpriteSortMode sort;
        public BlendState blend;

        public SpriteNode spriteListHead;


        private SpriteBatch spriteBatch;

        public SBNode(batchEnum _name, SpriteSortMode _sort, BlendState _blend)
        {
            spriteBatch = new SpriteBatch(Game1.GameInstance.GraphicsDevice);

            batchName = _name;

            sort = _sort;
            blend = _blend;

            spriteListHead = null;
        }

        public void Draw()
        {

            SpriteNode ptr = spriteListHead;

            //spriteBatch.Begin(sort, blend);


            spriteBatch.Begin(sort, blend, null, null, null, null, Game1.Camera.getTransform());

            while (ptr != null)
            {
                ((DisplayObject)ptr.sprite).Draw(spriteBatch);

                ptr = ptr.next;
            }

            spriteBatch.End();
        }

        public void addDisplayObject(DisplayObject _sprite)
        {
            Debug.Assert(_sprite != null);

            SpriteNode node = new SpriteNode(_sprite);

            if (spriteListHead == null)
            {
                spriteListHead = node;
                node.next = null;
                node.prev = null;
            }
            else
            {
                node.next = spriteListHead;
                spriteListHead.prev = node;
                spriteListHead = node;
            }

        }

        public void removeDisplayObject(DisplayObject _sprite)
        {
            SpriteNode node = findSpriteNode(_sprite);


            if (node.prev != null)
            {	// middle or last node
                node.prev.next = node.next;
            }
            else
            {  // first
                spriteListHead = node.next;
            }

            if (node.next != null)
            {	// middle node
                node.next.prev = node.prev;
            }
        }

        public SpriteNode findSpriteNode(DisplayObject _obj)
        {
            SpriteNode ptr = spriteListHead;

            while (ptr != null)
            {
                if (ptr.sprite.Equals(_obj))
                    break;
                ptr = ptr.next;
            }
            return ptr;
        }

        protected override object privGetNewObj()
        {
            throw new NotImplementedException();
        }

        public override Enum getName()
        {
            return batchName;
        }
    }
}
