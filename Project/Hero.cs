using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{

    class Hero : ICollide
    {

        
        Matrix m;
        public Vector2 _positie;
        public Texture2D _texture { get; set; }
        private Texture2D left;
        private Texture2D right;
        private Texture2D jump;
        private Keys GoRight;
        private Keys GoLeft;
        private Rectangle _viewRect;
        public Rectangle CollisionRect;
        public bool hasJumped;
        private Animation _animation;

        //private Animation _animation
        public Vector2 veloCityX = new Vector2(10, 0);
        public Vector2 veloCityY = new Vector2(0, 10);
        public Controls _control { get; set; }

        public bool isMoving = false;
        public Hero(Texture2D texture, Vector2 positie, Texture2D AILeft, Texture2D AIRight, Keys GoRightIn, Keys GoLeftIn)
        {
            m = new Matrix();
            _texture = texture;
            _positie = positie; //new Vector2(0, 300);
            _viewRect = new Rectangle(0, 0, 48, 56);
            CollisionRect = new Rectangle((int)_positie.X, (int)_positie.Y, 64, 205);
            left = AILeft;
            right = AIRight;
            GoLeft = GoLeftIn;  
            GoRight = GoRightIn;
            hasJumped = true;

            _animation = new Animation();
            _animation.AddFrame(new Rectangle(0, 0, 48, 56));
            _animation.AddFrame(new Rectangle(48, 0, 48, 56));
            _animation.AddFrame(new Rectangle(96, 0, 48, 56));
            _animation.aantalBewegingenPerSec = 8;

            // mannetje = leftRight;
        }
        public void Update(GameTime gameTime, SoundEffect soundEffect)
        {
            _control.Update();
            _positie += veloCityY;
            //LEFT AND RIGHT
            if (_control.left || _control.right)
            {
                _viewRect.X += 48;
                _animation.Update(gameTime);
                if (_viewRect.X > 140)
                {
                    _viewRect.X = 0;
                }
                isMoving = true;
            }
            else
                isMoving = false;
            if (_control.left)
            {
                veloCityX.X = 3f;
                _texture = left;
                _positie -= veloCityX;
            }
            if (_control.right)
            {
                veloCityX.X = 3f;
                _texture = right;
                _positie += veloCityX;
            }
            else veloCityX.X = 0f;

            //JUMP   (https://www.youtube.com/watch?v=ZLxIShw-7ac)
            if (_control.jump && hasJumped == false)
            {
                _positie.Y -= 60f;//SPEED & HEIGHT
                veloCityY.Y = 10f;//SPEED
                hasJumped = true;
                _positie -= veloCityY;
                soundEffect.Play();
            }

            if(hasJumped == false)
            {
                veloCityY.Y = 0f;
            }
            if(_positie.Y + _texture.Height >= 366.5/*STARTPOSITIE!!!!*/)
            {
                hasJumped = false;
            }

            
            CollisionRect.X = (int)_positie.X;
            CollisionRect.Y = (int)_positie.Y;
        }
        Rectangle _viewRectangle = new Rectangle(0, 0, 95, 295);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _positie, _animation.currentFrame.SourceRectangle, Color.White);
        }

        public Rectangle GetCollisionRectangle()
        {
            return CollisionRect;
        }
    }

}
