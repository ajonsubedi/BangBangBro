using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Background
    {
        public Texture2D texture;
        public Rectangle rect;
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, Color.White);
        }
    }

    class Scroll : Background
    {
        public Scroll(Texture2D textureIn, Rectangle rectIn)
        {
            texture = textureIn;
            rect = rectIn;
        }
        public void Update()
        {
            rect.X -= 3;

        }
    }

    class FarBuilding : Background
    {
        public FarBuilding(Texture2D textureIn, Rectangle rectIn)
        {
            texture = textureIn;
            rect = rectIn;
        }
        public void Update()
        {
            rect.X -= 10;

        }
    }

    class Building : Background
    {
        public Building(Texture2D textureIn, Rectangle rectIn)
        {
            texture = textureIn;
            rect = rectIn;
        }
        public void Update()
        {
            rect.X -= 2;

        }
    }

    class ForeBuilding : Background
    {
        public ForeBuilding(Texture2D textureIn, Rectangle rectIn)
        {
            texture = textureIn;
            rect = rectIn;
        }
        public void Update()
        {
            rect.X -= 2;

        }
    }
}
