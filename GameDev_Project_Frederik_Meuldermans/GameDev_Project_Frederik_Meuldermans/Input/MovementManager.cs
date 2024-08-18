using GameDev_Project_Frederik_Meuldermans.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameDev_Project_Frederik_Meuldermans.Input
{
    internal class MovementManager
    {
        public void Move(IMovable movable)
        {
            Vector2 tempDirection = new Vector2(0,0);
            var direction = movable.InputReader.ReadInput();
            if (movable.InputReader.IsDestinationInput)
            {
                tempDirection = direction;
                direction -= movable.Position;
                direction.Normalize();
            }

            var afstand = direction * movable.Speed;
            var toekomstigePositie = movable.Position + afstand;

            if (toekomstigePositie.Y < movable.Position.Y)
            {
                movable.Jumping = true;
            } else
            {
                movable.Jumping = false;
            }

            if (movable.Jumping && !movable.OnGround)
            {
                toekomstigePositie = movable.Position;
                movable.Falling = true;
            }

            if (toekomstigePositie.X < movable.Position.X)
            {
                if (movable.mover != 1)
                {
                    movable.walkingLeftAnimation();
                }
               
            } else if (toekomstigePositie.X > movable.Position.X)
            {
                if (movable.mover != 1)
                {
                    movable.walkingRightAnimation();
                }
            } else if (toekomstigePositie.X == movable.Position.X)
            {
                movable.standingAnimation();
            }

            if (movable.Position.Y >= 430)
            {
                movable.OnGround = true;
            }
            else
            {
                movable.OnGround = false;
            }

            if (movable.Position.Y < 430 && toekomstigePositie.Y < 430 && !movable.Jumping)
            {
                toekomstigePositie.Y = movable.Position.Y + movable.Gravity.Y; 
            }

            if (movable.Position.Y > 429)
            {
                movable.Falling = false;
            }

            if ((toekomstigePositie.X < (800-64) && toekomstigePositie.X >= 0) && (toekomstigePositie.Y < (480) && toekomstigePositie.Y > 0))
            {
                if(movable.Jumping && !movable.Falling)
                {
                    for (int i = 0; i<75;i++)
                    {
                        toekomstigePositie.Y = movable.Position.Y - 1f;
                        movable.Position = toekomstigePositie;
                    }
                } else
                {
                    movable.Position = toekomstigePositie;
                }
            } else
            {
                movable.standingAnimation();
            }
        }

    }
}
