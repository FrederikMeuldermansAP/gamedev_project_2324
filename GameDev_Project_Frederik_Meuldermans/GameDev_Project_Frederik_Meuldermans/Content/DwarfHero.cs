using GameDev_Project_Frederik_Meuldermans.Animation;
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
    internal class DwarfHero : IGameObject
    {
        private Texture2D texture;

        private Animatie animatie;
        private Vector2 snelheid;
        private Vector2 positie;
        private Vector2 versnelling;
        private Vector2 mouseVector;

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
            positie = new Vector2(0, 0);
            snelheid = new Vector2(1, 1);
            versnelling = new Vector2(0.1f, 0.1f);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, positie, animatie.CurrentFrame.SourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            var direction = Vector2.Zero;
            KeyboardState kybrdState = Keyboard.GetState();

            if (kybrdState.IsKeyDown(Keys.Left))
            {
                direction = new Vector2(-1, 0);
            } else if (kybrdState.IsKeyDown(Keys.Right))
            {
                direction = new Vector2(1, 0);
            }

            direction *= 4;
            positie += direction;
            //Move(GetMouseState());
            //Move();
            animatie.Update(gameTime);
        }

        //GetMouseState optioneel - te verwijderen in Move
        private Vector2 GetMouseState()
        {
            MouseState state = Mouse.GetState();
            mouseVector = new Vector2(state.X, state.Y);
            return mouseVector;
        }

        private void Move()
        {
            //var direction = Vector2.Add(mouse, -positie);

            //snelheid += direction;

            snelheid+=versnelling;
            snelheid = Limit(snelheid, 3);

            positie += snelheid;

            if (positie.X > 600 || positie.X < 0)
            {
                snelheid.X *= -1;
                versnelling.X *= -1;
            }

            if (positie.Y > 400 || positie.Y < 0)
            {
                snelheid.Y *= -1;
                versnelling.Y *= -1;
            }
        }

        private Vector2 Limit(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }


    }
}
