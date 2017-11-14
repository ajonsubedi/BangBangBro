using Microsoft.Xna.Framework;
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
        public Texture2D _texture { get; set; }
        public Vector2  Positie { get; set; }
        public Rectangle rectangle;
        public Rectangle CollisionRect;
        public Tile(Texture2D texture, Vector2 pos)
        {
            _texture = texture;
            Positie = pos;
            rectangle = new Rectangle((int)Positie.X, (int)Positie.Y, texture.Width, texture.Height);
            CollisionRect = new Rectangle((int)Positie.X, (int)Positie.Y, 64, 205);
        }
        public void Update(GameTime gameTime)
        {
            CollisionRect.X = (int)Positie.X;
            CollisionRect.Y = (int)Positie.Y;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(_texture, rectangle, Color.White);
        }
        public Rectangle GetCollisionRectangle()
        {
            return CollisionRect;
        }
    }
}
