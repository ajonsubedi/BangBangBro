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
        public Matrix Transform { get; set; }
        private readonly Viewport _viewport;
        public Vector2 centre;
        public Camerda2D(Viewport viewport)
        {
            _viewport = viewport;

        }

        public void Update(Vector2 positie, int xOffset, int yOffset)
        {
            if (positie.X < _viewport.Width / 2)
                centre.X = _viewport.Width / 2;
            else if (positie.X > xOffset - (_viewport.Width / 2))
                centre.X = xOffset - (_viewport.Width / 2);
            else centre.X = positie.X;

            if (positie.Y < _viewport.Height / 2)
                centre.Y = _viewport.Height / 2;
            else if (positie.Y > yOffset - (_viewport.Height / 2))
                centre.Y = yOffset - (_viewport.Height / 2);
            else centre.Y = positie.Y;

            Transform = Matrix.CreateTranslation(new Vector3(-centre.X + (_viewport.Width / 2),
                                                            -centre.Y + (_viewport.Height / 2), 0));
        }

    }
}
