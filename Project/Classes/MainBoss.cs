using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    class MainBoss
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
        public bool isVisible = false;

        public MainBoss(Texture2D texture, Vector2 newposition)
        {
            _texture = texture;
            _position = newposition;
            _animation = new Animation();
            _animation.AddFrame(new Rectangle(0, 0, 66, 100));
            _animation.AddFrame(new Rectangle(66, 0, 66, 100));
            _animation.AddFrame(new Rectangle(132, 0, 66, 100));
            _animation.AddFrame(new Rectangle(198, 0, 66, 100));
            _animation.AddFrame(new Rectangle(264, 0, 66, 100));
            _animation.AddFrame(new Rectangle(330, 0, 66, 100));
            _animation.AddFrame(new Rectangle(396, 0, 66, 100));
            _animation.AddFrame(new Rectangle(462, 0, 66, 100));
            _animation.AddFrame(new Rectangle(528, 0, 66, 100));

            
            _animation.aantalBewegingenPerSec = 9;
            flip = SpriteEffects.None;
            isVisible = false;
        }

        public virtual void Update(GameTime gameTime, SoundEffect soundEffect)
        {
            _position += _velocity;
            if (_position.X > _viewRect.Width / 3)
                _position.X++;




            _viewRect = new Rectangle((int)_position.X, (int)_position.Y, 66, 100);
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
