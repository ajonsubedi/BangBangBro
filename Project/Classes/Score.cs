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
        public static Vector2 _scorePos { get; set; }
        public static int _score { get; set; }
        public Score(SpriteFont scoreFont, Vector2 score )
        {
            _scoreFont = scoreFont;
            _scorePos = _scorePos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_scoreFont, _score.ToString(), _scorePos, Color.White);
        }
    }
}

