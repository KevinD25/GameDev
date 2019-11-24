using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject
{
    class Level : LevelBase
    {
        public Texture2D TijdelijkeTexture;

        // wereld tekenen
        public byte[,] tileArray;

        // array maken van blokken
        public Blok[,] blokArray;

        //collider aanmaken
        Collider collider;

        // level initialiseren
        public Level(ContentManager content)

        {
            // textures die voor alle levels hetzelfde zijn inladen
            TijdelijkeTexture = content.Load<Texture2D>("tijdelijk/Tile2");
            collider = new Collider();
        }

        public override void CreateWorld()
        {
            blokArray = new Blok[tileArray.GetLength(0), tileArray.GetLength(1)];
            for (int x = 0; x < tileArray.GetLength(0); x++)
            {
                for (int y = 0; y < tileArray.GetLength(1); y++)
                {
                    switch (tileArray[x, y])
                    {
                        //logica voor de verschillende textures toevoegen
                        case 1:
                            blokArray[x, y] = new Blok(TijdelijkeTexture, new Vector2(y*70, x*70));
                            blokArray[x, y].collision = true;
                            break;
                        default:
                            break;

                    }

                }
            }
        }

        public override void DrawWorld(SpriteBatch spritebatch)
        {
            for (int x = 0; x < tileArray.GetLength(0); x++)
            {
                for (int y = 0; y < tileArray.GetLength(1); y++)
                {
                    if (blokArray[x, y] != null)
                    {     
                        blokArray[x, y].Draw(spritebatch);                     
                    }
                }
            }
        }
        
        public override bool CheckCollisionTop(Hero hero)
        {
            bool hit = false;

            foreach (Blok blok in blokArray)
            {
                if (blok is Blok && blok.collision)
                {
                    if (hero.collisionRectangleBottom.Intersects(blok.CollisionRectangle))
                    {
                        hit = true;
                        collisionMargin = Convert.ToInt32(blok.positie.Y);
                    }
                }
            }


            return hit;
        }

        public override bool CheckCollisionLeft(Hero hero)
        {
            bool hit = false;

            foreach (Blok blok in blokArray)
            {
                if (blok is Blok && blok.collision)
                {
                    if (hero.collisionRectangleLeft.Intersects(blok.CollisionRectangle))
                    {
                        hit = true;
                    }
                }
            }


            return hit;
        }

        public override bool CheckCollisionRight(Hero hero)
        {
            bool hit = false;

            foreach (Blok blok in blokArray)
            {
                if (blok is Blok && blok.collision)
                {
                    if (hero.collisionRectangleRight.Intersects(blok.CollisionRectangle))
                    {
                        hit = true;
                    }
                }
            }


            return hit;
        }

        public override bool CheckCollisionBottom(Hero hero)
        {
            bool hit = false;

            foreach (Blok blok in blokArray)
            {
                if (blok is Blok && blok.collision)
                {
                    if (hero.collisionRectangleTop.Intersects(blok.CollisionRectangle))
                    {
                        hit = true;
                    }
                }
            }


            return hit;
        }
        /*
        public override bool CheckCollisionTop(Hero hero)
        {
            bool hit = false;

            foreach(Blok blok in blokArray)
            {
                if(blok is Blok && blok.collision)
                {
                    collider.setPlayer(hero.CollisionRectangle);
                    collider.setTarget(blok.CollisionRectangle);
                    if (collider.IsTouchingTop()){
                        hit = true;
                        collisionMargin = Convert.ToInt32(blok.positie.Y);
                        Console.WriteLine("TOUCHING TOP");
                    }
                }
            }
            return hit;
        }

        public override bool CheckCollisionLeft(Hero hero)
        {
            bool hit = false;

            foreach (Blok blok in blokArray)
            {
                if (blok is Blok && blok.collision)
                {
                    collider.setPlayer(hero.CollisionRectangle);
                    collider.setTarget(blok.CollisionRectangle);
                    if (collider.IsTouchingLeft())
                    {
                        hit = true;
                        Console.WriteLine("TOUCHING LEFT");
                    }
                }
            }


            return hit;
        }

        public override bool CheckCollisionRight(Hero hero)
        {
            bool hit = false;

            foreach (Blok blok in blokArray)
            {
                if (blok is Blok && blok.collision)
                {
                    collider.setPlayer(hero.CollisionRectangle);
                    collider.setTarget(blok.CollisionRectangle);
                    if (collider.IsTouchingRight())
                    {
                        hit = true;
                        Console.WriteLine("TOUCHING RIGHT");
                    }
                }
            }


            return hit;
        }

        public override bool CheckCollisionBottom(Hero hero)
        {
            bool hit = false;

            foreach (Blok blok in blokArray)
            {
                if (blok is Blok && blok.collision)
                {
                    collider.setPlayer(hero.CollisionRectangle);
                    collider.setTarget(blok.CollisionRectangle);
                    if (collider.IsTouchingBottom())
                    {
                        hit = true;
                       Console.WriteLine("TOUCHING BOTTOM");
                    }
                }
            }


            return hit;
        }
        */
    }
}
