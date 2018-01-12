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
        private SpriteEffects flip;
        public bool right;
        public float distance;
        public float oldDistance;
        public bool isMoving = true;
        public bool isVisible = true;

        public Enemy(Texture2D texture, Vector2 newposition)
        {
            _texture = texture;
            _position = newposition;
            _animation = new Animation();
            _animation.AddFrame(new Rectangle(0, 0, 75, 55));
            _animation.AddFrame(new Rectangle(75, 0, 75, 55));
            _animation.AddFrame(new Rectangle(150, 0, 75, 55));
            _animation.AddFrame(new Rectangle(225, 0, 75, 55));
            _animation.aantalBewegingenPerSec = 4;
            flip = SpriteEffects.None;
            isVisible = true;
        }

        public void Update(GameTime gameTime, SoundEffect soundEffect)
        {
            _position += _velocity;
            if(_position.X > _viewRect.Width / 3)
            _position.X++;

            


            _viewRect = new Rectangle((int)_position.X, (int)_position.Y, 75, 55);
            if (_velocity.Y < 10)
                _velocity.Y += 0.4f;


            _animation.Update(gameTime);
           



        }


        
       


        public void Collision(GameTime gameTime, Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (_viewRect.TouchTopOf(newRectangle))
            {
                _viewRect.Y = newRectangle.Y - _viewRect.Height;
                _velocity.Y = 0f;
            }
            if (_viewRect.TouchLeftOf(newRectangle))
            {
            }
            if (_viewRect.TouchRightOf(newRectangle))
            {
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


        public void MoveEnemyAround(int leftCollision, int rightCollision)
        {
            
                if (_position.X == leftCollision)
            {
                _velocity.X--;
                flip = SpriteEffects.FlipHorizontally;
            }
            else if (_position.X == rightCollision)
            {
                _velocity.X++;
                flip = SpriteEffects.None;
            }

        }

        public void Draw(SpriteBatch spriteBatch, SpriteEffects spriteEffects)
        {
            Rectangle destinationRect = new Rectangle((int)_position.X, (int)_position.Y, _animation.currentFrame.SourceRectangle.Width, _animation.currentFrame.SourceRectangle.Height);
            if (isVisible == true)
                spriteBatch.Draw(texture: _texture, destinationRectangle: destinationRect, sourceRectangle: _animation.currentFrame.SourceRectangle, color: Color.White, rotation: 0f, origin: new Vector2(0, 0), effects: flip, layerDepth: 0f);
           
        }

        public void GetDamage(Rectangle bRect)
        {
            if (_viewRect.Intersects(bRect))
            {
                isVisible = false;
                Console.WriteLine("enemy is dood");
            }
        }

        public void GiveDamage(Rectangle heroRect, int heroRightHealth)
        {
            if (heroRect.Intersects(_viewRect))
            {
                heroRightHealth--;
            }
        }
    }
}
