using GameDev_Project_Frederik_Meuldermans.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Frederik_Meuldermans.Content
{
    internal class LevelManager
    {
        public Level level1;
        public List<ILevel> LevelList;
        public LevelManager(GraphicsDevice graphicsDevice) {
            LevelList = new List<ILevel>();
            int[,] gameBoardL1 = new int[,]
            {
                { 1,1,1,1,1,1,1,1 },
                { 0,0,1,1,0,1,1,1 },
                { 1,0,0,0,0,0,0,1 },
                { 1,1,1,1,1,1,0,1 },
                { 1,0,0,0,0,0,0,1 },
                { 1,0,1,1,1,1,1,1 },
                { 1,0,0,0,0,0,0,0 },
                { 1,1,1,1,1,1,1,1 }
            };
            List<IMovable> enemies1 = new List<IMovable>(); 
            String description1 = "While mining down in the Black Forest in Germany, it seems you've delved too deep... Where have I heard that before?.. Doesn't matter! You've dug all the way to Minos' Mines. In Crete.. How?.. Since when did Minos have mines?? Are you sure you're a Dwarf and not some kind of Wizard?";
            level1 = new Level(1, "Minos' Mines", description1, enemies1, new BlockFactory(), gameBoardL1, graphicsDevice);
            level1.CreateBlocks();
    }
        public void DrawLevel(int levelNumber, SpriteBatch _spriteBatch)
        {
            if (levelNumber == 1)
            {
                level1.DrawBlocks(_spriteBatch);
            }
        }
    }
}
