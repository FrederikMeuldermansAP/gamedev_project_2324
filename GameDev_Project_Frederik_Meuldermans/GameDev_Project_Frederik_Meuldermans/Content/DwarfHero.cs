using GameDev_Project_Frederik_Meuldermans.Animation;
using GameDev_Project_Frederik_Meuldermans.Interfaces;
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

        Animatie animatie;

        public DwarfHero(Texture2D texture)
        {
            this.texture = texture;

            this.animatie = new Animatie();
            this.animatie.AddFrame(new AnimationFrame(new Rectangle(0, 32, 64, 32)));
            this.animatie.AddFrame(new AnimationFrame(new Rectangle(64, 32, 64, 32)));
            this.animatie.AddFrame(new AnimationFrame(new Rectangle(128, 32, 64, 32)));
            this.animatie.AddFrame(new AnimationFrame(new Rectangle(192, 32, 64, 32)));
            this.animatie.AddFrame(new AnimationFrame(new Rectangle(256, 32, 64, 32)));
            this.animatie.AddFrame(new AnimationFrame(new Rectangle(320, 32, 64, 32)));
            this.animatie.AddFrame(new AnimationFrame(new Rectangle(384, 32, 64, 32)));
            this.animatie.AddFrame(new AnimationFrame(new Rectangle(448, 32, 64, 32)));
            this.animatie.AddFrame(new AnimationFrame(new Rectangle(512, 32, 64, 32)));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(0, 0), animatie.currentFrame.SourceRectangle, Color.White);
        }

        public void Update()
        {
            animatie.Update();
        }


    }
}
