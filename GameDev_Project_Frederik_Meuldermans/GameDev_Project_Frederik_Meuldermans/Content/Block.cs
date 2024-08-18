using GameDev_Project_Frederik_Meuldermans.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project_Frederik_Meuldermans.Content
{
    class Block : IGameObject
    {
        public Rectangle BoundingBox { get; set; }
        public bool Passable { get; set; }
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }
        public CollideWithEvent CollideWithEvent { get; set; }

        public Block(int x, int y, GraphicsDevice graphics)
        {
            BoundingBox = new Rectangle(x, y, 10, 10);
            Passable = false;
            Color = Color.Green;
            Texture = new Texture2D(graphics, 1, 1);
            CollideWithEvent = new NoEvent();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(Texture, BoundingBox, Color);
        }
        public virtual void IsCollidedWithEvent
        (IMovable collider)
        {
            CollideWithEvent.Execute();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        private class NoEvent : CollideWithEvent
        {
        }
    }
}
