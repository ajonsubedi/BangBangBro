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
    class Hero
    {
        public Vector2 _position = new Vector2(64, 200), _velocity;
        Rectangle _rectangle;
        Texture2D _texture;
        private Texture2D left;
        private Texture2D right;
        private Texture2D jump;
        public bool hasJumped = false;
        public Controls _control { get; set; }
        public Animation _animation;
        public bool isMoving = false;
        Matrix m;








        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Hero(Texture2D texture, Vector2 positie, Texture2D heroLeft, Texture2D heroRight)
        {
            m = new Matrix();
            _texture = texture;
            _position = positie;
            _rectangle = new Rectangle(0, 0, 48, 56);
            left = heroLeft;
            right = heroRight;
            hasJumped = true;
            _animation = new Animation();
            _animation.AddFrame(new Rectangle(0, 0, 48, 56));
            _animation.AddFrame(new Rectangle(48, 0, 48, 56));
            _animation.AddFrame(new Rectangle(96, 0, 48, 56));
            _animation.aantalBewegingenPerSec = 8;
        }

        public void Load(ContentManager Content)
        {
            _texture = Content.Load<Texture2D>("heroRight");
        }

        public void Update(GameTime gameTime, SoundEffect soundEffect)
        {
            _position += _velocity;
            Input(gameTime, soundEffect);

            _rectangle = new Rectangle((int)_position.X, (int)_position.Y, 48, 56);
            if (_velocity.Y < 10)
                _velocity.Y += 0.4f;
        }


        private void Input(GameTime gameTime, SoundEffect soundEffect)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;

            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                _velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            else _velocity.X = 0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && hasJumped == false)
            {
                _position.Y -= 5f;
                _velocity.Y = -9f;
                hasJumped = true;
                soundEffect.Play();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _rectangle.X += 48;
                _animation.Update(gameTime);
                if (_rectangle.X > 140)
                {
                    _rectangle.X = 0;
                }
                isMoving = true;
            }

        }

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (_rectangle.TouchTopOf(newRectangle))
            {
                _rectangle.Y = newRectangle.Y - _rectangle.Height;
                _velocity.Y = 0f;
                hasJumped = false;
            }
            if (_rectangle.TouchLeftOf(newRectangle))
            {
                _position.X = newRectangle.X - _rectangle.Width;
            }
            if (_rectangle.TouchRightOf(newRectangle))
            {
                _position.X = newRectangle.X + 17;
            }
            if (_rectangle.TouchBottomOf(newRectangle))
            {
                _velocity.Y = 1f;
            }

            if (_position.X < 0) _position.X = 0;
            if (_position.X > xOffset - _rectangle.Width) _position.X = xOffset - _rectangle.Width;
            if (_position.Y < 0) _velocity.Y = 1f;
            if (_position.Y > yOffset - _rectangle.Height) _position.Y = yOffset - _rectangle.Height;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, _animation.currentFrame.SourceRectangle, Color.White);
        }

    }
}
