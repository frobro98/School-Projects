using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ImageManager : Manager
    {
        #region Data Members

        // instance reference for the ImageManager
        private static ImageManager iImgMan;

        
        #endregion

        private ImageManager(int toCreate, int willCreate)
            : base(toCreate, willCreate)
        {
            
        }

        public static void initialize(int toCreate, int willCreate)
        {
            Debug.Assert(toCreate > 0);
            Debug.Assert(willCreate > 0);

            if(iImgMan == null)
            {
                iImgMan = new ImageManager(toCreate, willCreate);
            }
        }

        // Returns the only instance of the Image Manager
        private static ImageManager Instance
        {
            get
            {
                return iImgMan;
            }
        }

        public static void destroy()
        {
            Instance.baseDestroy();
        }

        public override ManNode getManObject()
        {
            object ret = new Image();

            return (ManNode)ret;
        }

        public static void add(ImageEnum imgName, TexEnum tex, float x, float y, float width, float height)
        {
            
            Image toAdd = (Image)Instance.baseAdd();

            toAdd.setImage(imgName, tex, x, y, width, height);

        }

        public static void remove(ImageEnum imgName)
        {
            Instance.baseRemove(imgName);
        }

        public static Image find(ImageEnum imgName)
        {
            return (Image)Instance.baseFind(imgName);
        }

        public static void print(string obj)
        {
            Instance.PrintStats(obj);
        }
       
    }
}
