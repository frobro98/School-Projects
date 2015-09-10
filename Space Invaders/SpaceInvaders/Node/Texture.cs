using System;


namespace SpaceInvaders
{
   

    class Texture : ManNode
    {
        #region Data Members

        private Azul.Texture tex;
        private Index index;
        private TexEnum name;

        #endregion

        public Texture()
            : base()
        {
            
        }

        public Texture(TexEnum name, string texFile) : base()
        {
            this.name = name;
            this.index = Index.Index_Null;
            tex = new Azul.Texture(texFile);
        }

        public override Index getIndex()
        {
            return index;
        }

        override public Enum getName()
        {
            return name;
        }

        public void setName(TexEnum s)
        {
            name = s;
        }

        public Azul.Texture Tex 
        {
            get
            {
                return tex;
            }
            set
            {
                tex = value;
            }
        }
    }
}
