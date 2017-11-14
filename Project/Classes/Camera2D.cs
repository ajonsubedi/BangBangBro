using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Camerda2D
    {
        private readonly Viewport _viewport;
        public Camerda2D(Viewport viewport)
        {
            _viewport = viewport;
            Origin = new Vector2(viewport.Width / 4f, viewport.Height / 4f);
            Positie = Vector2.Zero;
        }

        public Vector2 ViewportCenter
        {
            get
            {
                return new Vector2(_viewport.Width * -0.5f, _viewport.Height * -0.5f);
            }
        }

        public Vector2 Positie { get; set; }
        public Vector2 Origin { get; set; }

        public Matrix GetViewMatrix()
        {
            Matrix m = Matrix.CreateTranslation(new Vector3(-Positie, 0));
            return m;
        }
    }
}
