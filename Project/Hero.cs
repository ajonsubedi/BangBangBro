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
        public Rectangle _viewRect;
        public bool hasJumped;
        public Animation _animation;
        public float scale { get; set; }

        //variabelen voor collision detection
        public Rectangle CollisionRectHero;

        //private Animation _animation
        public Vector2 veloCityX = new Vector2(10, 0);
        public Vector2 veloCityY = new Vector2(0, 10);
        public Controls _control { get; set; }

        public bool isMoving = false;
        public Hero(Texture2D texture, Vector2 positie, Texture2D heroLeft, Texture2D heroRight, Keys GoRightIn, Keys GoLeftIn)
        {
            m = new Matrix();
            _texture = texture;
            _positie = positie; //new Vector2(0, 300);
            _viewRect = new Rectangle(0, 0, 48, 56);
            CollisionRectHero = new Rectangle((int)_positie.X, (int)_positie.Y, 48, 56);
            left = heroLeft;
            right = heroRight;
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

            if (hasJumped == false)
            {
                veloCityY.Y = 0f;
            }
            if (_positie.Y + _texture.Height >= 366.5/*STARTPOSITIE!!!!*/)
            {
                hasJumped = false;
            }


            CollisionRectHero.X = (int)_positie.X;
            CollisionRectHero.Y = (int)_positie.Y;
        }
        Rectangle _viewRectangle = new Rectangle(0, 0, 48, 56);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _positie, _animation.currentFrame.SourceRectangle, Color.White);
        }

        public Rectangle GetCollisionRectangle()
        {
            return CollisionRectHero;
        }
       /* public bool RectangleCollision(Tile otherSprite)
        {
            if (this._viewRect.X + this._texture.Width * this.scale * hitboxScale / 2 < otherSprite.rectangle.X - otherSprite._texture.Width * otherSprite.scale / 2) return false;
            if (this._viewRect.Y + this._texture.Height * this.scale * hitboxScale / 2 < otherSprite.rectangle.Y - otherSprite._texture.Height * otherSprite.scale / 2) return false;
            if (this._viewRect.X - this._texture.Width * this.scale * hitboxScale / 2 > otherSprite.rectangle.X + otherSprite._texture.Width * otherSprite.scale / 2) return false;
            if (this._viewRect.Y - this._texture.Height * this.scale * hitboxScale / 2 > otherSprite.rectangle.Y + otherSprite._texture.Height * otherSprite.scale / 2) return false;
            return true;
        }*/
    }
}
