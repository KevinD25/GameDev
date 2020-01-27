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
                    /*if (tileArray[x, y] != 99)
                    {
                        Console.WriteLine(tileArray.GetLength(0) + " ----- " + tileArray.GetLength(1));
                        
                        blokArray[x, y] = new Blok(levelTextures[tileArray[x, y]], new Vector2(y * 15, x * 15));
                        Console.WriteLine("TESTING" + blokArray[x, y].CollisionRectangle);
                        blokArray[x, y].collision = true;
                    }*/
                    
                    #region switchStatement
                    
                    switch (tileArray[x, y])
                        {
                        //logica voor de verschillende textures toevoegen

                        case 0:
                            blokArray[x, y] = new Blok(levelTextures[0], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 01:
                            blokArray[x, y] = new Blok(levelTextures[1], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 02:
                            blokArray[x, y] = new Blok(levelTextures[2], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 03:
                            blokArray[x, y] = new Blok(levelTextures[3], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 04:
                            blokArray[x, y] = new Blok(levelTextures[4], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 05:
                            blokArray[x, y] = new Blok(levelTextures[5], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 06:
                            blokArray[x, y] = new Blok(levelTextures[6], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 07:
                            blokArray[x, y] = new Blok(levelTextures[7], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 08:
                            blokArray[x, y] = new Blok(levelTextures[8], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 09:
                            blokArray[x, y] = new Blok(levelTextures[9], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 10:
                            blokArray[x, y] = new Blok(levelTextures[10], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;

                        case 11:
                            blokArray[x, y] = new Blok(levelTextures[11], new Vector2(y*15 , x*15));
                            blokArray[x, y].collision = true;
                            break;
                        case 12:
                            blokArray[x, y] = new Blok(levelTextures[12], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 13:
                            blokArray[x, y] = new Blok(levelTextures[13], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 14:
                            blokArray[x, y] = new Blok(levelTextures[14], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 15:
                            blokArray[x, y] = new Blok(levelTextures[15], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 16:
                            blokArray[x, y] = new Blok(levelTextures[16], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 17:
                            blokArray[x, y] = new Blok(levelTextures[17], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 18:
                            blokArray[x, y] = new Blok(levelTextures[18], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 19:
                            blokArray[x, y] = new Blok(levelTextures[19], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 20:
                            blokArray[x, y] = new Blok(levelTextures[20], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 21:
                            blokArray[x, y] = new Blok(levelTextures[21], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 22:
                            blokArray[x, y] = new Blok(levelTextures[22], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;

                        case 23:
                            blokArray[x, y] = new Blok(levelTextures[23], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 24:
                            blokArray[x, y] = new Blok(levelTextures[24], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 25:
                            blokArray[x, y] = new Blok(levelTextures[25], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 26:
                            blokArray[x, y] = new Blok(levelTextures[26], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 27:
                            blokArray[x, y] = new Blok(levelTextures[27], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 28:
                            blokArray[x, y] = new Blok(levelTextures[28], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 29:
                            blokArray[x, y] = new Blok(levelTextures[29], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 30:
                            blokArray[x, y] = new Blok(levelTextures[30], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 31:
                            blokArray[x, y] = new Blok(levelTextures[31], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 32:
                            blokArray[x, y] = new Blok(levelTextures[32], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 33:
                            blokArray[x, y] = new Blok(levelTextures[33], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 34:
                            blokArray[x, y] = new Blok(levelTextures[34], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;

                        case 35:
                            blokArray[x, y] = new Blok(levelTextures[35], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 36:
                            blokArray[x, y] = new Blok(levelTextures[36], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 37:
                            blokArray[x, y] = new Blok(levelTextures[37], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 38:
                            blokArray[x, y] = new Blok(levelTextures[38], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 39:
                            blokArray[x, y] = new Blok(levelTextures[39], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 40:
                            blokArray[x, y] = new Blok(levelTextures[40], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 41:
                            blokArray[x, y] = new Blok(levelTextures[41], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            break;
                        case 42:
                            blokArray[x, y] = new Blok(levelTextures[42], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;
                        case 43:
                            blokArray[x, y] = new Blok(levelTextures[43], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;
                        case 44:
                            blokArray[x, y] = new Blok(levelTextures[44], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;
                        case 45:
                            blokArray[x, y] = new Blok(levelTextures[45], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;
                        case 46:
                            blokArray[x, y] = new Blok(levelTextures[46], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;

                        case 47:
                            blokArray[x, y] = new Blok(levelTextures[47], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;

                        case 48:
                            blokArray[x, y] = new Blok(levelTextures[48], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;
                        case 49:
                            blokArray[x, y] = new Blok(levelTextures[49], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;
                        case 50:
                            blokArray[x, y] = new Blok(levelTextures[50], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;
                        case 51:
                            blokArray[x, y] = new Blok(levelTextures[51], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;
                        case 52:
                            blokArray[x, y] = new Blok(levelTextures[52], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;
                        case 53:
                            blokArray[x, y] = new Blok(levelTextures[53], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;
                        case 54:
                            blokArray[x, y] = new Blok(levelTextures[54], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;
                        case 55:
                            blokArray[x, y] = new Blok(levelTextures[55], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;
                        case 56:
                            blokArray[x, y] = new Blok(levelTextures[56], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;
                        case 57:
                            blokArray[x, y] = new Blok(levelTextures[57], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;
                        case 58:
                            blokArray[x, y] = new Blok(levelTextures[58], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;

                        case 59:
                            blokArray[x, y] = new Blok(levelTextures[59], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;
                        case 60:
                            blokArray[x, y] = new Blok(levelTextures[60], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;
                        case 61:
                            blokArray[x, y] = new Blok(levelTextures[61], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;
                        case 62:
                            blokArray[x, y] = new Blok(levelTextures[62], new Vector2(y * 15, x * 15));
                            blokArray[x, y].collision = true;
                            blokArray[x, y].endPoint = true;
                            break;
                       // case 63:
                          //  blokArray[x, y] = new Blok(levelTextures[63], new Vector2(y * 15, x * 15));
                          //  blokArray[x, y].collision = true;
                          //  break;

                        default:
                                break;
                        }
                    #endregion
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

        public override bool CheckEndpoint(Hero hero)
        {
            bool hit = false;

            foreach (Blok blok in blokArray)
            {
                if (blok is Blok && blok.endPoint)
                {
                    if (hero.collisionRectangle.Intersects(blok.CollisionRectangle))
                    {
                        hit = true;
                        Console.WriteLine("endpoint");
                    }
                }
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
