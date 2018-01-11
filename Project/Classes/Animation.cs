using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Animation
    {
        private List<AnimationFrame> frames;
        public AnimationFrame currentFrame { get; set; }
        public int aantalBewegingenPerSec { get; set; }
        private int counter = 0;

        private double x = 0;
        public double offset { get; set; }
        private int _totalWidth = 0;

        public Animation()
        {
            frames = new List<AnimationFrame>();
            aantalBewegingenPerSec = 1;
        }
        public void AddFrame(Rectangle rectangle)
        {
            AnimationFrame newFrame = new AnimationFrame()
            {
                SourceRectangle = rectangle,
            };
            
            
            frames.Add(newFrame);
            currentFrame = frames[0];
            offset = currentFrame.SourceRectangle.Width;
            foreach(AnimationFrame f in frames)
            {
                _totalWidth += f.SourceRectangle.Width;
            }
        }

        public void Update(GameTime gameTime)
        {
            double temp = currentFrame.SourceRectangle.Width * ((double)gameTime.ElapsedGameTime.Milliseconds / 1000);

            x += temp;
            if(x >= currentFrame.SourceRectangle.Width / aantalBewegingenPerSec)
            {
                //Console.WriteLine(x);
                x = 0;
                counter++;
                if(counter >= frames.Count)
                {
                    counter = 0;
                }
                currentFrame = frames[counter];
                offset += currentFrame.SourceRectangle.Width;
            }
            if(offset >= _totalWidth)
            {
                offset = 0;
            }
        }
    }
}

