using System;
using System.Diagnostics;

namespace SpaceInvaders
{

    // A manager will create and manage the textures needed in the game
    class TextureManager : Manager
    {
        #region Data Members
        // Texture Manager instance making it a singleton
        private static TextureManager iTexMan;

        #endregion

        // private constructor so that only one texture 
        // manager can exist
        private TextureManager(int toCreate, int willCreate)
            : base(toCreate, willCreate)
        {
        }

        public static void initialize(int toCreate, int willCreate)
        {
            Debug.Assert(toCreate > 0);
            Debug.Assert(willCreate > 0);

            if (iTexMan == null)
            {
                iTexMan = new TextureManager(toCreate, willCreate);
            }
        }

        public static void destroy()
        {
            Instance.baseDestroy();
        }

        public override ManNode getManObject()
        {
            ManNode ret = new Texture();
            return ret;
        }
       
        // returns the instance of the Texture Manager
        // so that public static methods can use it
        private static TextureManager Instance
        {
            get
            {
                return iTexMan;
            }
        }

        public void setTexture(TexEnum tName, string filename)
        {

        }

        // Adds a texture to the list. Create calls this method
        // with the newly created texture
        public static void add(TexEnum texName, string fileName)
        {
            Texture tex = (Texture)Instance.baseAdd();
            tex.Tex = new Azul.Texture(fileName);
            tex.setName(texName);
        }

        // public method remove that calls the private method pRemove
        public static void remove(TexEnum tName)
        {
            Instance.baseRemove(tName);
        }

        public static Texture find(TexEnum tName)
        {
            return (Texture)Instance.baseFind(tName);
        }

        public static void print(string obj)
        {
            Instance.PrintStats(obj);
        }

    }
}
