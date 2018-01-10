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
        public Texture2D texture;
        public Rectangle rectangle;
<<<<<<< HEAD
        public Rectangle CollisionRectTile;
        public float scale { get; set; }
        public static ContentManager Content { get; set; }
        public Tile(Texture2D texture, Vector2 pos)
=======

        public Rectangle Rectangle
>>>>>>> 4497b0c
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
            Rectangle = newRectangle;
        }
    }

    class CollisionTiles : Tile
    {
        private int number;

       

        public CollisionTiles(Texture2D texture, Vector2 pos, int i, Rectangle newRectangle) : base(texture, pos)
        {
            texture = Content.Load<Texture2D>("grass" + i);
            this.rectangle = newRectangle;
        }
    }
}
