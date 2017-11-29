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
        public Vector2 _position = new Vector2(64, 200), _velocity;
        Rectangle _viewRect;
        Texture2D _texture;
        private Texture2D left;
        private Texture2D right;
        public Animation _animation;
        public bool isMoving = false;

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Enemy(Texture2D texture, Vector2 positie, Texture2D heroLeft, Texture2D heroRight)
        {
            _texture = texture;
            _position = positie;
            _viewRect = new Rectangle(0, 0, 43, 70);
            left = heroLeft;
            right = heroRight;
            _animation = new Animation();
            _animation.AddFrame(new Rectangle(0, 0, 43, 70));
            _animation.AddFrame(new Rectangle(43, 0, 43, 70));
            _animation.AddFrame(new Rectangle(86, 0, 43, 70));
            _animation.AddFrame(new Rectangle(129, 0, 43, 70));
            _animation.AddFrame(new Rectangle(172, 0, 43, 70));
            _animation.AddFrame(new Rectangle(215, 0, 43, 70));
            _animation.AddFrame(new Rectangle(258, 0, 43, 70));
            _animation.aantalBewegingenPerSec = 8;
        }

        

        public void Update(GameTime gameTime, SoundEffect soundEffect)
        {
            _position += _velocity;
            _viewRect = new Rectangle((int)_position.X, (int)_position.Y, 48, 56);


            _viewRect.X += 10;
            _animation.Update(gameTime);
            if (_viewRect.X > 100)
                _viewRect.X = 0;
            isMoving = true;


            _position.X += 1;

            if (_velocity.Y < 10)
                _velocity.Y += 0.4f;


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
                _position.X -= -1;
            }
            if (_viewRect.TouchRightOf(newRectangle))
            {
                _position.X  += 1;
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
