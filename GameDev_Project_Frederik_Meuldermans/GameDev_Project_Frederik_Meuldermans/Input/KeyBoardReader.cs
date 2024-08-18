using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Frederik_Meuldermans.Input
{
    internal class KeyBoardReader : IInputReader
    {
        public bool IsDestinationInput => false;
        KeyboardState oldKybrdState;
        public Vector2 ReadInput()
        {
            var direction = Vector2.Zero;
            KeyboardState kybrdState = Keyboard.GetState();

            if (kybrdState.IsKeyDown(Keys.Left))
            {
                direction = new Vector2(-1, 0);
            }
            else if (kybrdState.IsKeyDown(Keys.Right))
            {
                direction = new Vector2(1, 0);
            } else if (kybrdState.IsKeyUp(Keys.Space) && oldKybrdState.IsKeyDown(Keys.Space))
            {
                direction = new Vector2(0, -1);
            }
            oldKybrdState = kybrdState;
            return direction;

        }
    }
}
