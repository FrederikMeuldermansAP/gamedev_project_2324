using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Frederik_Meuldermans.Animation
{
    public class Animatie
    {
        public AnimationFrame currentFrame { get; set; }
        
        private List<AnimationFrame> frames;

        private int counter;

        public Animatie() { 
            frames = new List<AnimationFrame>();
        }

        public void AddFrame(AnimationFrame animationFrame)
        {
            frames.Add(animationFrame);
            currentFrame = frames[0];
        }

        public void Update()
        {
            currentFrame = frames[counter];
            counter++;

            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }

    }
}
