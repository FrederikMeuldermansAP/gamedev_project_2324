using GameDev_Project_Frederik_Meuldermans.Animation;
using GameDev_Project_Frederik_Meuldermans.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Frederik_Meuldermans.Interfaces
{
    interface IMovable
    {
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public IInputReader InputReader { get; set; }
        public SpriteEffects effect { get; set;}
        public Vector2 Gravity { get; set; }
        public bool OnGround {  get; set; }
        public int mover { get; set; }
        public bool Jumping {  get; set; }
        public bool Falling { get; set; }

        void walkingLeftAnimation();
        void walkingRightAnimation();
        void standingAnimation();
    }

}
