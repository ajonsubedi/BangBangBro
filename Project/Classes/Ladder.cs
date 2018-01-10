using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Ladder
    {
        public Texture2D _texture;
        public Rectangle _rectangle;
        public Vector2 _position;
        public Ladder(Texture2D texture, Vector2 position, Rectangle rectangle)
        {
            _texture = texture;
            _position = position;
            _rectangle = rectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, Color.White);
        }
    }
}
