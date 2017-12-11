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
        Vector2 position;

        public int ScreenWidth { get { return GraphicsDeviceManager.DefaultBackBufferWidth; } }
        public int ScreenHeight { get { return GraphicsDeviceManager.DefaultBackBufferHeight;} }
        public Matrix Transform { get; set; }
       public readonly Viewport _viewport;
        public Vector2 centre;
        public Vector2 coinPos = new Vector2(0, 0);

        

        public void Update(Vector2 heroPositie)
        {

            position.X = heroPositie.X - (ScreenWidth / 2);

            if (position.X < 0)
                position.X = 0;
        

            Transform = Matrix.CreateTranslation(new Vector3(-position, 0));
        }

       

    }
}
