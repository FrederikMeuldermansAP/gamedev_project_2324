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

        public bool OnGround { get; set; }

        private MovementManager movementManager;

        public SpriteEffects effect { get; set; }

        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public Vector2 Gravity { get; set; }
        public bool Jumping { get; set; }
        public bool Falling { get; set; }
        public IInputReader InputReader { get; set; }
        public int mover { get; set; }
        public Rectangle BoundingBox { get; set; } 

        public DwarfHero(Texture2D texture, IInputReader reader)
        {
            this.texture = texture;

            this.effect = new SpriteEffects();

            this.animatie = new Animatie();
            
            this.standingAnimation();
            Position = new Vector2(0, 400);
            Speed = new Vector2(1, 1);
            versnelling = new Vector2(0.1f, 0.1f);
            Gravity = new Vector2(0, 0.8f);
            this.OnGround = true;
            movementManager = new MovementManager();

            this.InputReader = reader;

            this.BoundingBox = new Rectangle(0,0,64,64);
            
        }

        public void walkingLeftAnimation()
        {
            this.animatie.RemoveFrames();
            for (int i = 0; i < 448; i += 64)
            {
                this.mover = 1;
                this.animatie.AddFrame(new AnimationFrame(new Rectangle(i, 32, 64, 32)));
            }
            this.effect = SpriteEffects.FlipHorizontally;
        }

        public void walkingRightAnimation()
        {
            this.animatie.RemoveFrames();
            for (int i = 0; i < 448; i += 64)
            {
                this.mover = 1;
                this.animatie.AddFrame(new AnimationFrame(new Rectangle(i, 32, 64, 32)));
            }
            this.effect = SpriteEffects.None;
        }

        public void standingAnimation()
        {
            this.animatie.RemoveFrames();
            for (int i = 0; i < 448; i += 64)
            {
                this.mover = 0;
                this.animatie.AddFrame(new AnimationFrame(new Rectangle(i, 0, 64, 32)));
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture: texture, position: Position, sourceRectangle: animatie.CurrentFrame.SourceRectangle, color: Color.White, rotation: 0, origin: Vector2.Zero, scale: 1, effects: effect, layerDepth: 0);
        }

        public void Update(GameTime gameTime)
        {
            UpdateBoundingBox(this.BoundingBox);
            Move();
            animatie.Update(gameTime);
        }

        private void UpdateBoundingBox(Rectangle boundingBox)
        {
            boundingBox.X = (int)this.Position.X;
            boundingBox.Y = (int)this.Position.Y;
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
