using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject
{
    public class Collider
    {

        protected Rectangle player;
        protected Rectangle target;

        public Vector2 Position;
        public Vector2 Velocity;
        public float Speed;

        

        public Collider() 
        {
            player = new Rectangle();
            target = new Rectangle();
        }

        public void setPlayer(Rectangle player)
        {
            this.player = player;
        }

        public void setTarget(Rectangle target)
        {
            this.target = target;
        }


       /* public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Colour);
        }*/

        #region Colloision
        public bool IsTouchingLeft()
        {
            return player.Right + this.Velocity.X > target.Left &&
              player.Left < target.Left &&
              player.Bottom > target.Top &&
              player.Top < target.Bottom;
        }

        public bool IsTouchingRight()
        {
            return player.Left + this.Velocity.X < target.Right &&
              player.Right > target.Right &&
              player.Bottom > target.Top &&
              player.Top < target.Bottom;
        }

        public bool IsTouchingTop()
        {
            return player.Bottom + this.Velocity.Y > target.Top &&
              player.Top < target.Top &&
              player.Right > target.Left &&
              player.Left < target.Right;
        }

        public bool IsTouchingBottom()
        {
            return player.Top + this.Velocity.Y < target.Bottom &&
              player.Bottom > target.Bottom &&
              player.Right > target.Left &&
              player.Left < target.Right;
        }

        #endregion
    }
}
