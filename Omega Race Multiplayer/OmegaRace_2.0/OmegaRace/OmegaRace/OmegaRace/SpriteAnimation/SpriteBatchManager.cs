using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OmegaRace;

namespace SpriteAnimation
{

    enum batchEnum
    {
        missiles,
        ships, 
        boxs,
        bomb,
        explosions,
        displayText,
        None
    }


    class SpriteBatchManager : Manager
    {
        private static SpriteBatchManager instance;
        


        private SpriteBatchManager()
        {
            createSpriteBatches();
        }

        public static SpriteBatchManager Instance()
        {
            if(instance == null)
                instance = new SpriteBatchManager();
            return instance;
        }
        

        public SBNode getBatch(batchEnum batch)
        {
            return (SBNode)privFind(batch);
        }

        public void process()
        {
            ManLink ptr = this.active;

            while (ptr != null)
            {
                ((SBNode)ptr).Draw();

                ptr = ptr.next;
            }
        }

        private void createSpriteBatches()
        {


            this.privActiveAddToFront((ManLink)(new SBNode(batchEnum.boxs, SpriteSortMode.Immediate, BlendState.Additive)), ref this.active);
            this.privActiveAddToFront((ManLink)(new SBNode(batchEnum.missiles, SpriteSortMode.Immediate, BlendState.Additive)), ref this.active);
            this.privActiveAddToFront((ManLink)(new SBNode(batchEnum.ships, SpriteSortMode.Immediate, BlendState.Additive)), ref this.active);
            this.privActiveAddToFront((ManLink)(new SBNode(batchEnum.bomb, SpriteSortMode.Immediate, BlendState.Additive)), ref this.active);
            this.privActiveAddToFront((ManLink)(new SBNode(batchEnum.explosions, SpriteSortMode.Immediate, BlendState.Additive)), ref this.active);
            this.privActiveAddToFront((ManLink)(new SBNode(batchEnum.displayText, SpriteSortMode.Immediate, BlendState.Additive)), ref this.active);
        }

        public void clear()
        {
            this.active = null;
            instance = null;
        }

        protected override object privGetNewObj()
        {
            throw new NotImplementedException();
        }
    }
}
