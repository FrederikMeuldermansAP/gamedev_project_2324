using GameDev_Project_Frederik_Meuldermans.Animation;
using GameDev_Project_Frederik_Meuldermans.Input;
using GameDev_Project_Frederik_Meuldermans.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Frederik_Meuldermans.Content.Classes
{
    internal class DwarfHero : IGameObject, IMovable
    {
        private Texture2D texture;

        private Animatie animatie;
        private Vector2 versnelling;
        private Vector2 mouseVector;

        private MovementManager movementManager;

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public IInputReader InputReader { get; set; }

        public DwarfHero(Texture2D texture, IInputReader reader)
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
            Position = new Vector2(0, 430);
            Speed = new Vector2(1, 1);
            versnelling = new Vector2(0.1f, 0.1f);
            movementManager = new MovementManager();

            this.InputReader = reader;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, animatie.CurrentFrame.SourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            animatie.Update(gameTime);
        }


        private void Move()
        {
            movementManager.Move(this);

        }

        public void ChangeInput(IInputReader inputReader)
        {
            this.InputReader = inputReader;
        }
    }
}
