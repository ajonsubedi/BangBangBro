using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Button
    {
        Texture2D _texture;
        Vector2 _position;
        Rectangle _rectangle;

        Color colour = new Color(255, 255, 255, 255);

        public Vector2 size;
        public Button(Texture2D texture, GraphicsDevice graphics)
        {
            _texture = texture;
            size = new Vector2(graphics.Viewport.Width / (int)9.6, graphics.Viewport.Height / (int)5.4);
        }

        bool down;
        public bool isClicked;
        public void Update(MouseState mouse)
        {
            _rectangle = new Rectangle((int)_position.X, (int)_position.Y, (int)size.X, (int)size.Y);
            Rectangle mouseRect = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mouseRect.Intersects(_rectangle))
            {
                if (colour.A == 255) down = false;
                if (colour.A == 0) down = true;
                if (down) colour.A += 3; else colour.A -= 3;
                if (mouse.LeftButton == ButtonState.Pressed) isClicked = true;
            }

            else if(colour.A < 255)
            {
                colour.A += 3;
                isClicked = false;
            }
        }

        public void setPosition(Vector2 newPosition)
        {
            _position = newPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, colour);
        }
    }
}
