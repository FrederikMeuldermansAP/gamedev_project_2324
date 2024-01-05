using GameDev_Project_Frederik_Meuldermans.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Frederik_Meuldermans.Input
{
    internal class MovementManager
    {
        public void Move(IMovable movable)
    {
        var direction = movable.InputReader.ReadInput();
        if (movable.InputReader.IsDestinationInput)
        {
            direction -= movable.Position;
            direction.Normalize();
        }

        var afstand = direction * movable.Speed;
        movable.Position += afstand;            
    }

    }
}
