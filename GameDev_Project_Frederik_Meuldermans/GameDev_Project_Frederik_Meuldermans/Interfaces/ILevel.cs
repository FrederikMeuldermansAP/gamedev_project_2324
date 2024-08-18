using GameDev_Project_Frederik_Meuldermans.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Frederik_Meuldermans.Interfaces
{
    internal interface ILevel
    {
        public int LevelId { get; }
        public String LevelName { get; }
        public String LevelDescription { get; }
        public List<IMovable> Enemies { get; }
        public BlockFactory blockFactory { get; }
        public int[,] gameboard {  get; } 
        public List<Block> blocks { get; }
    }
}
