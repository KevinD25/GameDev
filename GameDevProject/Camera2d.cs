using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject
{
    public class Camera2d
    {
        public Matrix Transform { get; private set; }

        public void Follow(Hero target)
        {
            var position = Matrix.CreateTranslation(
                -target.positie.X - (target.collisionRectangle.Width / 2),
                -target.positie.Y - (target.collisionRectangle.Height / 2),
                0);

            var offset = Matrix.CreateTranslation(
                    Game1.screenWidth / 3,
                    Game1.screenHeight / 2f,
                    0);
            Transform =  position * offset;
        }
    }
}