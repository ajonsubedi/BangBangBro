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
    class Enemy : Hero
    {
        public Enemy(Texture2D texture, Vector2 positie, Texture2D heroLeft, Texture2D heroRight) : base(texture, positie, heroLeft, heroRight)
        {
            _animation = new Animation();
            _animation.AddFrame(new Rectangle(0, 0, 75, 55));
            _animation.AddFrame(new Rectangle(75, 0, 75, 55));
            _animation.AddFrame(new Rectangle(150, 0, 75, 55));
            _animation.AddFrame(new Rectangle(225, 0, 75, 55));
            _animation.aantalBewegingenPerSec = 8;
        }

        public void Update(GameTime gameTime, SoundEffect soundEffect)
        {
            _position.Y++;
            _viewRect.X += 75 ;
            _animation.Update(gameTime);
            if (_viewRect.X > 300)
            {
                _viewRect.X = 0;
            }
            _position.X++;
        }
        


    }
}
