using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OmegaRace
{
    public class Camera
    {

        //The viewport we want the camera to use (holds dimensions and so on)
        public Viewport View
        {
            get;
            private set;
        }

        //Where to point the center of the camera (0x0 will be the center of the viewport)
        public Vector2 Position
        {
            get;
            private set;
        }



        //The zoom scalar (1.0f = 100% zoom level)
 

        //Amount to rotate the camera
        public float Rotation
        {
            get;
            private set;
        }

        //Our camera's transform matrix
        private Matrix transform;

        public Vector2 focusPoint;
        public float zoom;

        //Used to matching the rotation of the object, or any value you wish
        public float SourceRotationOffset
        {
            get;
            private set;
        }

        /// <summary>
        /// Initialize a new Camera object
        /// </summary>
        /// <param name="view">The viewport we want the camera to use (holds dimensions and so on)</param>
        /// <param name="position">Where to point the center of the camera (0x0 will be the center of the viewport)</param>
        public Camera(Viewport _view, Vector2 _position)
        {
            View = _view;
            Position = _position;
            zoom = 1.1f;
            Rotation = 0;
            //focusPoint = new Vector2(_view.Width / 2, _view.Height / 2);
            focusPoint = new Vector2(0, 0);
            transform = Matrix.CreateTranslation(new Vector3(0, 0, 0)) *
                  Matrix.CreateScale(new Vector3((float)Math.Pow(zoom, 10), (float)Math.Pow(zoom, 10), 0)) *
                  Matrix.CreateRotationZ(0) *
                  Matrix.CreateTranslation(new Vector3(0, 0, 0));
        }

        /// <summary>
        /// Initialize a new Camera object
        /// </summary>
        /// <param name="view">The viewport we want the camera to use (holds dimensions and so on)</param>
        /// <param name="position">Where to position our camera relative to the focus point</param>
        /// <param name="focus">Where to point the center of the camera (0x0 will be the center of the viewport)</param>
        /// <param name="zoom">How much we want the camera zoomed by default</param>
        /// <param name="rotation">How much we want the camera to be rotated by default</param>
        public Camera(Viewport view, Vector2 _position, Vector2 _focus, float _zoom, float _rotation)
        {
            View = view;
            Position = _position;
            zoom = _zoom;
            Rotation = _rotation;
            focusPoint = _focus;
        }

        public void Update(GameTime gametime)
        {

            /* Create a transform matrix through position, scale, rotation, and translation to the focus point
             * We use Math.Pow on the zoom to speed up or slow down the zoom.  Both X and Y will have the same zoom levels
             * so there will be no stretching.
             * */
            //Vector2 objectPosition = Source != null ? Source.Position : Position;
            //float objectRotation = Source != null ? Source.Rotation : Rotation;
            //float deltaRotation = Source != null ? SourceRotationOffset : 0.0f;

            transform = Matrix.CreateTranslation(new Vector3(0, 0, 0)) *
                  Matrix.CreateScale(new Vector3((float)Math.Pow(zoom, 10), (float)Math.Pow(zoom, 10), 0)) *
                  Matrix.CreateRotationZ(0) *
                  Matrix.CreateTranslation(new Vector3(focusPoint.X, focusPoint.Y, 0));
            
        }

        public Matrix getTransform()
        {
            return transform;
        }
    }
}
