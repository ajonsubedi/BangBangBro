using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Tile
    {
        protected Texture2D texture;
        private Rectangle rectangle;

        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }
        private static ContentManager content;
        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }

    }
    class CollisionTiles : Tile
    {
        public CollisionTiles(int i, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>("tileSheet/tile" + i);
            this.Rectangle = newRectangle;
        }
    }
}
