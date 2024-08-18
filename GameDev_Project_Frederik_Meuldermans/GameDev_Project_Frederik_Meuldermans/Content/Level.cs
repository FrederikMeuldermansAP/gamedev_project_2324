using GameDev_Project_Frederik_Meuldermans.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Frederik_Meuldermans.Content
{
    internal class Level : ILevel
    {
        public int LevelId { get; set; }
        public String LevelName { get; set; }
        public String LevelDescription { get; set; }
        public List<IMovable> Enemies { get; set; }
        public BlockFactory blockFactory { get; set; }
        public int[,] gameboard { get; set; }
        private GraphicsDevice graphics;
        public List<Block> blocks { get; set; }
        public Level(int levelId, string levelName, string levelDescription, List<IMovable> enemies, BlockFactory blockFactory, int[,] gameboard, GraphicsDevice graphics )
        {
            LevelId = levelId;
            LevelName = levelName;
            LevelDescription = levelDescription;
            Enemies = enemies;
            this.blockFactory = blockFactory;
            this.gameboard = gameboard;
            this.graphics = graphics;
            blocks = new List<Block> ();
        }

        public void CreateBlocks()
        {
            for (int l = 0; l < gameboard.GetLength(0); l++)
            {
                for (int k = 0; k < gameboard.GetLength(1); k++)
                {
                    if (gameboard[l,k] == 1)
                    {
                        blocks.Add(BlockFactory.CreateBlock("normal",(k*10),(l*10), graphics));
                    }
                }
            }
        }

        public void DrawBlocks(SpriteBatch _spriteBatch)
        {
            foreach (var block in blocks)
            {
                block.Draw(_spriteBatch);
            }
        }
    }
}
