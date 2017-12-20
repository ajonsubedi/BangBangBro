using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Coin
    {
        Texture2D _texture;
        public Rectangle _rectangle;
        public Vector2 _positie, _velocity;
        public Animation _animation;
        public bool isRemoved = false;

        public Coin(Texture2D texture, Vector2 positie)
        {
            _texture = texture;
            _positie = positie;
            _animation = new Animation();
            _animation.AddFrame(new Rectangle(0, 0, 30, 30));
            _animation.AddFrame(new Rectangle(30, 0, 30, 30));
            _animation.AddFrame(new Rectangle(60, 0, 30, 30));
            _animation.AddFrame(new Rectangle(90, 0, 30, 30));
            _animation.AddFrame(new Rectangle(120, 0, 30, 30));
            _animation.AddFrame(new Rectangle(150, 0, 30, 30));
            _animation.AddFrame(new Rectangle(180, 0, 30, 30));
            _animation.AddFrame(new Rectangle(210, 0, 30, 30));
            _animation.AddFrame(new Rectangle(240, 0, 30, 30));
            _animation.AddFrame(new Rectangle(270, 0, 30, 30));
            _animation.aantalBewegingenPerSec = 8;
        }

        public void Update(GameTime gameTime)
        {
            //coin een gravity geven
            _positie += _velocity;
            _rectangle = new Rectangle((int)_positie.X, (int)_positie.Y, 48, 56);


            //Coin laten draaien
            _animation.Update(gameTime);
            _rectangle.X += 30;
                 if (_rectangle.X > 1000000000000000)
                  _rectangle.X = 0;
            if (_velocity.Y < 30)
                _velocity.Y += 0.4f;
        }

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (_rectangle.TouchTopOf(newRectangle))
            {
                _rectangle.Y = newRectangle.Y - _rectangle.Height;
                _velocity.Y = 0f;
            }
            if (_rectangle.TouchLeftOf(newRectangle))
            {
                _positie.X = newRectangle.X - _rectangle.Width;
            }
            if (_rectangle.TouchRightOf(newRectangle))
            {
                _positie.X = newRectangle.X + 17;
            }
            if (_rectangle.TouchBottomOf(newRectangle))
            {
                _velocity.Y = 1f;
            }

            /*if (_positie.X < 0) _positie.X = 0;
            if (_positie.X > xOffset - _rectangle.Width) _positie.X = xOffset - _rectangle.Width;
            if (_positie.Y < 0) _velocity.Y = 1f;
            if (_positie.Y > yOffset - _rectangle.Height) _positie.Y = yOffset - _rectangle.Height;*/

        }

      

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _positie, _animation.currentFrame.SourceRectangle, Color.White);
        }
    }

    
}
