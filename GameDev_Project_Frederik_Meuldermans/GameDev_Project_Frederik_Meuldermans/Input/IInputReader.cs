using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Frederik_Meuldermans.Input
{
    public interface IInputReader
    {
        Vector2 ReadInput();
        public bool IsDestinationInput { get; }
    }
}
