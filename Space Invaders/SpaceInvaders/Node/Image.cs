using System;

namespace SpaceInvaders
{
    class Image : ManNode
    {
        #region Data Members

        private Texture tex;
        private Azul.Rect texCoords;
        private Index index;
        private ImageEnum name;

        #endregion

        public Image()
            : base()
        {
            tex = null;
            texCoords = null;
            index = Index.Index_Null;
            name = ImageEnum.Not_Initialized;
        }

        public void setImage(ImageEnum iName, TexEnum tName, float x, float y, float width, float height)
        {
            name = iName;
            tex = TextureManager.find(tName);
            texCoords = new Azul.Rect(x, y, width, height);
        }

        override public Enum getName()
        {
            return name;
        }

        public override Index getIndex()
        {
            return index;
        }

        public Azul.Texture getTexture()
        {
            return this.tex.Tex;
        }

        public Azul.Rect TexCoords
        {
            get
            {
                return texCoords;
            }
        }

    }
}
