using Microsoft.Xna.Framework;

namespace GameDevProject
{
    class Camera2d
    {
        // code van Ovyou: https://www.youtube.com/watch?v=ceBCDKU_mNw

        public Matrix transform { get; private set; }

        public void Follow(Hero target)
        {
           /* var position = Matrix.CreateTranslation(-target.positie.X - (target.viewRechtangle.Width / 2), -target.positie.Y - (target.viewRechtangle.Height / 2), 0);

            var offset = Matrix.CreateTranslation(Game1.screenWidth / 2, Game1.screenHeight / 2, 0);

            transform = position * offset;*/
        }
    }
}