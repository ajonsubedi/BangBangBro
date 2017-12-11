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
        public bool isMoving = true;

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

        public void Update(GameTime gameTime, SoundEffect soundEffect)
        {
            _position += _velocity;
            if(_position.X > _viewRect.Width / 3)
            _position.X++;
           
            _viewRect = new Rectangle((int)_position.X, (int)_position.Y, 48, 56);
            if (_velocity.Y < 10)
                _velocity.Y += 0.4f;


            _animation.Update(gameTime);



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
                _position.X--;
            }
            if (_viewRect.TouchRightOf(newRectangle))
            {
                _position.X++;
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

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, _animation.currentFrame.SourceRectangle, Color.White);
        }
    }
}
