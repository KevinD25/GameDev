using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GameDevProject
{
    class Hero
    {

        static Texture2D[] heroIdleRight = new Texture2D[8];
        static Texture2D[] heroWalkRight = new Texture2D[6];
        static Texture2D[] heroJumpRight = new Texture2D[4];
        static Texture2D[] heroHurt = new Texture2D[2];
        static Texture2D[] heroCrouchRight = new Texture2D[2];
        static Texture2D[] heroIdleLeft = new Texture2D[8];
        static Texture2D[] heroWalkLeft = new Texture2D[6];
        static Texture2D[] heroJumpLeft = new Texture2D[4];
        static Texture2D[] heroCrouchLeft = new Texture2D[2];

        private Rectangle collisionRectangle;
        public Rectangle collisionRectangleBottom;
        public Rectangle collisionRectangleTop;
        public Rectangle collisionRectangleLeft;
        public Rectangle collisionRectangleRight;

        Collider collider;

        private Boolean right = true;
        private int idling = 0;
        private int walking = 0;
        private int jumping = 0;
        private int crouching = 0;
        private int hurt = 0;

        private LevelBase _level;
        private Delay delay;

        public bool bovenCollision = false;

        public bool collisionTop = false;
        public bool collisionRight = false;
        public bool collisionLeft = false;
        public bool collisionBottom = false;

        public Bediening _bediening { get; set; }

        public Vector2 positie;
        private bool hasJumped;
        private Vector2 velocity;
        public bool onBlock;

        public Hero(ContentManager cnt, LevelBase level)
        {
            LoadTextures(cnt);

            _level = level;
            delay = new Delay(0.15f);

            // hero positie geven op veld
            positie = level.beginPositie;

            //collision detection vierkant aanmaken
            collisionRectangle = new Rectangle((int)positie.X + 22, (int)positie.Y + 23, 30, 25);
            collisionRectangleTop = new Rectangle((int)positie.X + 22, (int)positie.Y, 30, 23);
            collisionRectangleBottom = new Rectangle((int)positie.X + 22, (int)positie.Y + 48, 30, 10);
            collisionRectangleLeft = new Rectangle((int)positie.X + 38, (int)positie.Y + 23, 22, 25);
            collisionRectangleRight = new Rectangle((int)positie.X + 22, (int)positie.Y + 23, 38, 25);

            hasJumped = true;
        }

        public Rectangle CollisionRectangle { get => collisionRectangle; set => collisionRectangle = value; }

        private static void LoadTextures(ContentManager cnt)
        {
            #region Right
            for (int i = 0; i < 8; i++)
            {
                heroIdleRight[i] = cnt.Load<Texture2D>("hero/idle/player-idle-" + (i + 1));
            }

            for (int i = 0; i < 6; i++)
            {
                heroWalkRight[i] = cnt.Load<Texture2D>("hero/run/player-run-" + (i + 1));
            }

            for (int i = 0; i < 4; i++)
            {
                heroJumpRight[i] = cnt.Load<Texture2D>("hero/jump/player-jump-" + (i + 1));
            }

            for (int i = 0; i < 2; i++)
            {
                heroHurt[i] = cnt.Load<Texture2D>("hero/hurt/player-hurt-" + (i + 1));
            }

            for (int i = 0; i < 2; i++)
            {
                heroCrouchRight[i] = cnt.Load<Texture2D>("hero/crouch/player-crouch-" + (i + 1));
            }
            #endregion
            #region Left
            for (int i = 0; i < 8; i++)
            {
                heroIdleLeft[i] = cnt.Load<Texture2D>("hero/idleleft/player-idle-" + (i + 1));
            }

            for (int i = 0; i < 6; i++)
            {
                heroWalkLeft[i] = cnt.Load<Texture2D>("hero/runleft/player-run-" + (i + 1));
            }

            for (int i = 0; i < 4; i++)
            {
                heroJumpLeft[i] = cnt.Load<Texture2D>("hero/jumpleft/player-jump-" + (i + 1));
            }

            for (int i = 0; i < 2; i++)
            {
                heroCrouchLeft[i] = cnt.Load<Texture2D>("hero/crouchleft/player-crouch-" + (i + 1));
            }
            #endregion
        }

        public void Update(float elapsedTime, GameTime gameTime)
        {

            _bediening.Update();

            //controleren op collissions
            collisionTop = _level.CheckCollisionTop(this);
            collisionLeft = _level.CheckCollisionLeft(this);
            collisionRight = _level.CheckCollisionRight(this);
            collisionBottom = _level.CheckCollisionBottom(this);

            positie += velocity;

            //TODO Collision logic in if statements

            if (_bediening.right && !collisionLeft)
            {
                delay.setDelay(0.07f); //Running speed
                if (delay.timerDone(gameTime))
                {
                    positie.X += 6; //Running distance per tick
                    if (walking < 5 && right)
                    {
                        walking++;
                    }
                    else if (right)
                    {
                        walking = 0;
                    }
                }
            } //right
            else if (_bediening.left && !collisionRight)
            {
                delay.setDelay(0.07f);
                if (delay.timerDone(gameTime))
                {
                    positie.X += -6;
                    if (walking < 5 && !right)
                    {
                        walking++;
                    }
                    else if (!right)
                    {
                        walking = 0;
                    }
                }
            } //left
            else if (_bediening.down && !collisionTop)
            {
                delay.setDelay(0.15f);
                if (delay.timerDone(gameTime))
                {

                    if (crouching < 1)
                    {
                        crouching++;
                    }
                    else
                    {
                        crouching = 0;
                    }
                }
            } //crouch
            else
            {
                delay.setDelay(0.15f);
                if (delay.timerDone(gameTime))
                {
                    if (idling < 7)
                    {
                        idling++;
                    }
                    else
                    {
                        idling = 0;
                    }
                }
            } //idle
            if (_bediening.up && hasJumped == false && onBlock)
            {
                // hero laten springen (SOURCE: https://www.youtube.com/watch?v=ZLxIShw-7ac&t=303s)

                positie.Y = positie.Y - 10f; //jump height
                velocity.Y = -8f; //Drop speed
                hasJumped = true;
                collisionTop = false;
                
                /*if (delay.timerDone(gameTime))
                {*/
                /*
                                if (jumping < 3)
                                {
                                    jumping++;
                                }
                                else
                                {
                                    jumping = 0;
                                }*/
                //}
            }

            if (hasJumped)
            {

            }
            if (hasJumped || !collisionTop)
            {
                //Velocity na jump  BUG; Valt door grond

                float i = 1;
                velocity.Y += 0.50f * i;
                onBlock = false;
                delay.setDelay(0.1f);
                if (delay.timerDone(gameTime))
                {
                    if (jumping < 3)
                    {
                        jumping++;
                    }
                    else
                    {
                        jumping = 0;
                    }
                }         
            }         
            if (collisionTop)
            {
                velocity.Y = 0;
                positie.Y = _level.collisionMargin - collisionRectangle.Height - 23f;
                Console.WriteLine(positie.Y + " " + positie.X);
                hasJumped = false;
                onBlock = true;
                bovenCollision = false;
            }

            // controleren op botsing boven
            if (collisionBottom && bovenCollision == false)
            {
                velocity.Y = -velocity.Y;
                bovenCollision = true;
            }


            collisionRectangle.X = (int)positie.X + 22 ;
            collisionRectangle.Y = (int)positie.Y;

            collisionRectangleTop.X = (int)positie.X + 22;
            collisionRectangleTop.Y = (int)positie.Y;

            collisionRectangleBottom.X = (int)positie.X + 22;
            collisionRectangleBottom.Y = (int)positie.Y + 48;

            collisionRectangleLeft.X = (int)positie.X + 47;
            collisionRectangleLeft.Y = (int)positie.Y;

            collisionRectangleRight.X = (int)positie.X + 22 ;
            collisionRectangleRight.Y = (int)positie.Y;
        }




        public void Draw(SpriteBatch spritebatch)
        {
            if (_bediening.left)
            {
                //logic for left run
                spritebatch.Draw(heroWalkLeft[walking], positie, Color.AliceBlue);
                right = false;
            }
            else if (_bediening.right)
            {
                //logic for right run  
                spritebatch.Draw(heroWalkRight[walking], positie, Color.AliceBlue);
                right = true;
            }
            else if (_bediening.up)
            {
                //logic for left and right jump
                if (right)
                {
                    spritebatch.Draw(heroJumpRight[jumping], positie, Color.AliceBlue);
                }
                else
                {
                    spritebatch.Draw(heroJumpLeft[jumping], positie, Color.AliceBlue);
                }
            }
            else if (_bediening.down)
            {
                //logic for left and right crouch
                if (right)
                {
                    spritebatch.Draw(heroCrouchRight[crouching], positie, Color.AliceBlue);
                }
                else
                {
                    spritebatch.Draw(heroCrouchLeft[crouching], positie, Color.AliceBlue);// TODO Mirror sprite
                }

            }
            else
            {
                if (right)
                {
                    spritebatch.Draw(heroIdleRight[idling], positie, Color.AliceBlue);
                }
                else
                {
                    //logic for left idle
                    spritebatch.Draw(heroIdleLeft[idling], positie, Color.AliceBlue);
                }
            }
        }
    }
}
