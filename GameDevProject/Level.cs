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
    public class Level : LevelBase
    {
        public Texture2D TijdelijkeTexture;

        // wereld tekenen
        public byte[,] tileArray;

        // array maken van blokken
        public Blok[,] blokArray;

        //Textures
        protected Texture2D[] levelTextures = new Texture2D[64];

        // level initialiseren
        public Level(ContentManager content)
        {
            // textures die voor alle levels hetzelfde zijn inladen
            //TijdelijkeTexture = content.Load<Texture2D>("tijdelijk/Tile2");

            LoadTextures(content);

            
        }

        private void LoadTextures(ContentManager content)
        {
            for(int i = 0; i < 63; i++)
            {
                levelTextures[i] = content.Load<Texture2D>("level/" + i);
            }
        }

        public override void CreateWorld()
        {
            
            blokArray = new Blok[tileArray.GetLength(0), tileArray.GetLength(1)];
            for (int x = 0; x < tileArray.GetLength(0); x++)
            {
                for (int y = 0; y < tileArray.GetLength(1); y++)
                {
                    if (tileArray[x, y] == 99)
                    {
                        blokArray[x, y] = new Blok(levelTextures[tileArray[x, y]], new Vector2(y * 70, x * 70));
                        blokArray[x, y].collision = true;
                    }
                    /*
                        switch (tileArray[x, y])
                        {
                        //logica voor de verschillende textures toevoegen
                        

                        case 1:
                            blokArray[x, y] = new Blok(TijdelijkeTexture, new Vector2(y * 70, x * 70));
                            blokArray[x, y].collision = true;
                            break;

                            default:
                                break;
                        }    */                                  
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
        
        public override bool CheckCollisionTop(Sprite sprite)
        {
            bool hit = false;

            foreach (Blok blok in blokArray)
            {
                if (blok is Blok && blok.collision)
                {
                    if (sprite.collisionRectangleBottom.Intersects(blok.CollisionRectangle))
                    {
                        hit = true;
                        collisionMargin = Convert.ToInt32(blok.positie.Y);
                    }
                }
            }
            return hit;
        }

        public override bool CheckCollisionLeft(Sprite sprite)
        {
            bool hit = false;

            foreach (Blok blok in blokArray)
            {
                if (blok is Blok && blok.collision)
                {
                    if (sprite.collisionRectangleLeft.Intersects(blok.CollisionRectangle))
                    {
                        hit = true;
                    }
                }
            }
            return hit;
        }

        public override bool CheckCollisionRight(Sprite sprite)
        {
            bool hit = false;

            foreach (Blok blok in blokArray)
            {
                if (blok is Blok && blok.collision)
                {
                    if (sprite.collisionRectangleRight.Intersects(blok.CollisionRectangle))
                    {
                        hit = true;
                    }
                }
            }
            return hit;
        }

        public override bool CheckCollisionBottom(Sprite sprite)
        {
            bool hit = false;

            foreach (Blok blok in blokArray)
            {
                if (blok is Blok && blok.collision)
                {
                    if (sprite.collisionRectangleTop.Intersects(blok.CollisionRectangle))
                    {
                        hit = true;
                    }
                }
            }
            return hit;
        }

        public override bool CheckCollisionTopSprites(Sprite player, List<Sprite> target)
        {
            bool hit = false;

            //collider.setPlayer(player.collisionRectangle);

            foreach (Sprite enemy in target)
            {
                if (player.collisionRectangleTop.Intersects(enemy.collisionRectangle))
                {
                    hit = true;
                    collisionMargin = 2;
                    //Console.WriteLine("Hit sprite Top");
                }
                /*
                collider.setTarget(enemy.collisionRectangle);
                if (collider.IsTouchingTop())
                {
                    hit = true;
                    collisionMargin = 2;
                }*/

            }
            return hit;

        }

        public override bool CheckCollisionLeftSprites(Sprite player, List<Sprite> target)
        {
            bool hit = false;

            //collider.setPlayer(player.collisionRectangle);
            foreach (Sprite enemy in target)
            {

                if (player.collisionRectangleLeft.Intersects(enemy.collisionRectangle))
                {
                    hit = true;
                    //Console.WriteLine("Hit sprite left");
                }
                /*
                collider.setTarget(enemy.collisionRectangle);
                if (collider.IsTouchingLeft())
                {
                    hit = true;
                    collisionMargin = 2;

                }*/

            }
            return hit;
        }

        public override bool CheckCollisionRightSprites(Sprite player, List<Sprite> target)
        {
            bool hit = false;

            //collider.setPlayer(player.collisionRectangle);
            foreach (Sprite enemy in target)
            {
                if (player.collisionRectangleRight.Intersects(enemy.collisionRectangle))
                {
                    hit = true;
                    //Console.WriteLine("Hit sprite right");
                }

/*
                collider.setTarget(enemy.collisionRectangle);
                if (collider.IsTouchingRight())
                {
                    hit = true;
                    collisionMargin = 2;

                }*/

            }
            return hit;
        }

        public override bool CheckCollisionBottomSprites(Sprite player, List<Sprite> target)
        {
            bool hit = false;

            //collider.setPlayer(player.collisionRectangle);
            foreach (Sprite enemy in target)
            {

                if (player.collisionRectangleBottom.Intersects(enemy.collisionRectangle))
                {
                    hit = true;
                    //Console.WriteLine("Hit sprite Bottom");
                }
                /*
                collider.setTarget(enemy.collisionRectangle);
                if (collider.IsTouchingBottom())
                {
                    hit = true;
                    collisionMargin = 2;

                }*/

            }
            return hit;
        }
        /*
        public override bool CheckCollisionLeft(Sprite sprite)
        {
            bool hit = false;

            foreach (Blok blok in blokArray)
            {
                if (blok is Blok && blok.collision)
                {
                    collider.setPlayer(sprite.collisionRectangleLeft);
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

        public override bool CheckCollisionRight(Sprite sprite)
        {
            bool hit = false;

            foreach (Blok blok in blokArray)
            {
                if (blok is Blok && blok.collision)
                {
                    collider.setPlayer(sprite.collisionRectangleRight);
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

        public override bool CheckCollisionBottom(Sprite sprite)
        {
            bool hit = false;

            foreach (Blok blok in blokArray)
            {
                if (blok is Blok && blok.collision)
                {
                    collider.setPlayer(sprite.collisionRectangleTop);
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
