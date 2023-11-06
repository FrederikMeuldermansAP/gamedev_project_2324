using GameDev_Project_Frederik_Meuldermans.Content.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Frederik_Meuldermans.Content.Classes
{
    internal class DwarfHero : IGameObject
    {
        private Texture2D texture;
        private Rectangle deelRectangle;

        private int schuifOp_X = 0;

        public DwarfHero(Texture2D texture)
        {
            this.texture = texture;
            deelRectangle = new Rectangle(schuifOp_X, 32, 64, 32);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(0, 0), deelRectangle, Color.White);
        }

        public void Update()
        {
            schuifOp_X += 64;
            if (schuifOp_X > 512)
            {
                schuifOp_X = 0;
            }
            deelRectangle.X = schuifOp_X;
        }


    }
}
