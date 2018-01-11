﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Bullet
    {
        public Texture2D _texture;
        public Vector2 _position, _velocity, origin;
        public bool isVisible;
        public Rectangle _rectangle;
        public int speed;
        public Bullet(Texture2D texture)
        {
            _position = new Vector2(0, 0);
            _rectangle = new Rectangle((int)_position.X, (int)_position.Y, 25, 25);
            _texture = texture;
            speed = 10;
            isVisible = false;
        }

        public void Update()
        {
            _rectangle = new Rectangle((int)_position.X, (int)_position.Y, 25, 25);
            _rectangle.X += 25;
            if (_rectangle.X > 25)
                _rectangle.X = 0;
            _position.X++;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture,_position,null, Color.White, 0f, origin, 1f, SpriteEffects.None, 0);
        }
    }
}
