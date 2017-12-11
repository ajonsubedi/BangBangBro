using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Enemy 
    {
        public Texture2D _texture;
        public Vector2 _position;
        public Vector2 _velocity;
        public Rectangle _viewRect;
        public Animation _animation;
        public Vector2 origin;
        public float rotation = 0f;
        public bool right;
        public float distance;
        public float oldDistance;

        public Enemy(Texture2D texture, Vector2 newposition, float newDistance)
        {
            _texture = texture;
            _position = newposition;
            distance = newDistance;
            oldDistance = distance;
            _animation = new Animation();
            _animation.AddFrame(new Rectangle(0, 0, 75, 55));
            _animation.AddFrame(new Rectangle(75, 0, 75, 55));
            _animation.AddFrame(new Rectangle(150, 0, 75, 55));
            _animation.AddFrame(new Rectangle(225, 0, 75, 55));
            _animation.aantalBewegingenPerSec = 8;
        }

        float mouseDistance;
        public void Update(GameTime gameTime)
        {
            _position += _velocity;
            origin = new Vector2(_texture.Width / 2, _texture.Height / 2);

            if(distance <= 0)
            {
                right = true;
                _velocity.X = 1f;
            }
            else if(distance <= oldDistance)
            {
                right = false;
                _velocity.X = -1f;
            }

            if (right) distance += 1; else distance -= 1;
            MouseState mouse = Mouse.GetState();
            mouseDistance = mouse.X - _position.X;

            if(mouseDistance >= -200 && mouseDistance <= 200)
            {
                if (mouseDistance < -1)
                    _velocity.X = -1f;
                else if (mouseDistance > 1)
                    _velocity.X = 1f;
                else if(mouseDistance == 0)
                    _velocity.X = 0f;
            }
          

            _viewRect.X += 75;
            _animation.Update(gameTime);
            if (_viewRect.X > 1000)
                _viewRect.X = 0;
            if (_velocity.Y < 30)
                _velocity.Y += 0.4f;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if(_velocity.X > 0)
                spriteBatch.Draw(_texture, _position,null, Color.White, rotation, origin, 1f, SpriteEffects.FlipHorizontally, 0f);
            else
                spriteBatch.Draw(_texture, _position, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);

        }


        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (_viewRect.TouchTopOf(newRectangle))
            {
                _viewRect.Y = newRectangle.Y - _viewRect.Height;
                _velocity.Y = 0f;
            }
            if (_viewRect.TouchLeftOf(newRectangle))
            {
                _position.X = newRectangle.X - _viewRect.Width;
            }
            if (_viewRect.TouchRightOf(newRectangle))
            {
                _position.X = newRectangle.X + 17;
            }
            if (_viewRect.TouchBottomOf(newRectangle))
            {
                _velocity.Y = 1f;
            }

            if (_position.X < 0) _position.X = 0;
            if (_position.X > xOffset - _viewRect.Width) _position.X = xOffset - _viewRect.Width;
            if (_position.Y < 0) _velocity.Y = 1f;
            if (_position.Y > yOffset - _viewRect.Height) _position.Y = yOffset - _viewRect.Height;

        }
    }
}
