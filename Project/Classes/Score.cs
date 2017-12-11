using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{ 
    class Score
    {
        public static SpriteFont _scoreFont { get; set; }
        public  Vector2 _scorePos { get; set; }
        public int _score = 0;
        public Rectangle rectangle = new Rectangle(0, 0, 30, 15);
        Matrix m;
        public Score(SpriteFont scoreFont, Vector2 scorePos )
        {
            m = new Matrix();
            _scoreFont = scoreFont;
            _scorePos = scorePos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_scoreFont, "x" +  _score.ToString(), _scorePos, Color.White);
        }
    }
}

