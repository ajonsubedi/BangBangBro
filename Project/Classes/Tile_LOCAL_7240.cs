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
    class Tile:ICollide
    {
        public Texture2D _texture { get; set; }
        public Vector2  Positie { get; set; }
        public Rectangle rectangle;
        public Rectangle CollisionRectTile;
        public float scale { get; set; }
        public static ContentManager Content { get; set; }
        public Tile(Texture2D texture, Vector2 pos)
        {
            _texture = texture;
            Positie = pos;
            rectangle = new Rectangle((int)Positie.X, (int)Positie.Y, 30, 30);
            CollisionRectTile = new Rectangle((int)Positie.X, (int)Positie.Y, 30, 30);
        }
        public void Update(GameTime gameTime)
        {
            CollisionRectTile.X = (int)Positie.X;
            CollisionRectTile.Y = (int)Positie.Y;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(_texture, rectangle, Color.White);
        }
        public Rectangle GetCollisionRectangle()
        {
            return CollisionRectTile;
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
