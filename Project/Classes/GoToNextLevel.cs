using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class GoToNextLevel
    {

        public Texture2D _texture;
        public Vector2 _position;
        public Rectangle _rectangle;

        public GoToNextLevel(Texture2D texture, Vector2 position)
        {
            _position = position;
            _rectangle = new Rectangle((int)_position.X, (int)_position.Y, 30, 30);
            _texture = texture;
        }


        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}


