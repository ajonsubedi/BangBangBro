using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public abstract class Controls
    {
        public bool left { get; set; }
        public bool right { get; set; }
        public bool jump { get; set; }
        public abstract void Update();
    }
    public class ControlsArrows : Controls
    {
        public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();
            if (stateKey.IsKeyDown(Keys.Left))
            {
                
                left = true;
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                left = false;
            }
            if (stateKey.IsKeyDown(Keys.Right))
            {
                right = true;
            }
            if (stateKey.IsKeyUp(Keys.Right))
            {
                right = false;
            }
            if (stateKey.IsKeyDown(Keys.Up))
            {
                jump = true;
            }
            if (stateKey.IsKeyUp(Keys.Up))
            {
                jump = false;
            }
        }
    }

    public class ControlsKeys : Controls
    {
        public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();
            if (stateKey.IsKeyDown(Keys.Q))
            {

                left = true;
            }
            if (stateKey.IsKeyUp(Keys.Q))
            {
                left = false;
            }
            if (stateKey.IsKeyDown(Keys.D))
            {
                right = true;
            }
            if (stateKey.IsKeyUp(Keys.D))
            {
                right = false;
            }
            if (stateKey.IsKeyDown(Keys.Z))
            {
                jump = true;
            }
            if (stateKey.IsKeyUp(Keys.Z))
            {
                jump = false;
            }
        }
    }
}