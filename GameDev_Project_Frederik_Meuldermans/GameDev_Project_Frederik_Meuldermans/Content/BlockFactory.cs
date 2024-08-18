using GameDev_Project_Frederik_Meuldermans.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Frederik_Meuldermans.Content
{
    class BlockFactory
    {
        public static Block CreateBlock(
        string type, int x, int y, GraphicsDevice graphics)
        {
            Block newBlock = null;
            type = type.ToUpper();
            if (type == "NORMAL")
            {
                newBlock = new Block(x, y, graphics);
            }
            return newBlock;
        }
    }
}
