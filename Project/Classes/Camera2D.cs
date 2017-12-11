using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Camera2D
    {
        public Vector2 Position { get; set; }
        public Matrix Transform { get; set; }
        public Viewport _viewport;
        public Vector2 centre;
        public Vector2 Origin { get; set; }

        public Camera2D(Viewport newView)
        {
            _viewport = newView;
            Origin = new Vector2(newView.Width / 2f, newView.Height / 2f);
            Position = Vector2.Zero;
        }


        public Vector2 ViewportCenter
        {
            get
            {
                return new Vector2(_viewport.Width * 0.5f, _viewport.Height * 0.5f);
            }
        }
         
        public void Update(Vector2 objPos, Rectangle objRect)
        {
            centre = new Vector2(objPos.X + (objRect.Width / 2) - 200, 0);

        }

        public Matrix GetViewMatrix()
        {
            Matrix m = Matrix.CreateScale(new Vector3(1,1,0)) * Matrix.CreateTranslation(new Vector3(-centre.X, centre.Y, 0));
            return m;
        }

        

        /*public void UpdateScore(GameTime gameTime, Score score)
        {
            centre = new Vector2(score._scorePos.X + (score.rectangle.Width / 2) - 200, 0);
            Transform = Matrix.CreateScale(new Vector3(1, 1, 0)) * Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0));

        }*/



    }
}
