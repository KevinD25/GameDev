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
    class Enemy : Sprite
    {


        protected bool moving = true;
        protected bool alive = true;


        protected LevelBase _level;
        protected Delay delay;

        protected bool bovenCollision = false;

        protected bool collisionTop = false;
        protected bool collisionRight = false;
        protected bool collisionLeft = false;
        protected bool collisionBottom = false;

        protected bool collisionSpriteTop = false;
        protected bool collisionSpriteRight = false;
        protected bool collisionSpriteLeft = false;
        protected bool collisionSpriteBottom = false;

        protected Vector2 positie;
        protected Vector2 velocity;
        protected Vector2 startPositie;

        protected Texture2D[] enemyDying = new Texture2D[4];

        public List<Ant> ants = new List<Ant>();


        public Enemy(ContentManager cnt, LevelBase level)
        {
            _level = level;
            delay = new Delay(0.15f);

        }

        public void createEnemies(ContentManager cnt)
        {
            ants.Clear();
            foreach (Vector2 position in _level.beginPositieAnts)
            {
                Ant ant = new Ant(cnt, _level, position);
                ants.Add(ant);
            }
        }
        public override void Update(float elapsedTime, GameTime gameTime)
        {
            foreach (Ant ant in ants)
            {
                ant.UpdateAnt(elapsedTime, gameTime);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Ant ant in ants)
            {
                ant.DrawAnt(spriteBatch);
            }
        }
    }

    class Ant : Enemy
    {
        static Texture2D[] antRight = new Texture2D[8];
        static Texture2D[] antLeft = new Texture2D[8];

        private int walking = 0;
        private bool right = true;
        private int dying = 0;




        public Ant(ContentManager cnt, LevelBase level, Vector2 beginPositie) : base(cnt, level)
        {
            positie = beginPositie;
            startPositie = beginPositie;
            //collision detection vierkant aanmaken
            collisionRectangle = new Rectangle((int)positie.X, (int)positie.Y + 23, 37, 31);
            collisionRectangleTop = new Rectangle((int)positie.X, (int)positie.Y, 37, 5);
            collisionRectangleBottom = new Rectangle((int)positie.X, (int)positie.Y + 48, 37, 5);
            collisionRectangleLeft = new Rectangle((int)positie.X + 37, (int)positie.Y + 31, 5, 31);
            collisionRectangleRight = new Rectangle((int)positie.X, (int)positie.Y + 31, 5, 31);

            LoadTextures(cnt);
        }

        public Rectangle CollisionRectangle { get => collisionRectangle; set => collisionRectangle = value; }

        public override void LoadTextures(ContentManager cnt)
        {
            for (int i = 0; i < 8; i++)
            {
                antRight[i] = cnt.Load<Texture2D>("ant/right/ant-" + (i + 1));
            }

            for (int i = 0; i < 8; i++)
            {
                antLeft[i] = cnt.Load<Texture2D>("ant/left/ant-" + (i + 1));
            }
            for(int i = 0; i < 4; i++)
            {
                enemyDying[i] = cnt.Load<Texture2D>("enemyDeath/enemy-death-" + (i + 1));
            }
        
        }

        public void UpdateAnt(float elapsedTime, GameTime gameTime)
        {
            //controleren op collissions
            collisionTop = _level.CheckCollisionTop(this);
            collisionLeft = _level.CheckCollisionLeft(this);
            collisionRight = _level.CheckCollisionRight(this);
            collisionBottom = _level.CheckCollisionBottom(this);

            //controleren of sprite geraakt wordt door player
            List<Sprite> sprites = new List<Sprite>();
            sprites.Add(_level.Hero);
            collisionSpriteTop = _level.CheckCollisionTopSprites(this, sprites);
            collisionSpriteLeft = _level.CheckCollisionLeftSprites(this, sprites);
            collisionSpriteRight = _level.CheckCollisionRightSprites(this, sprites);
            collisionSpriteBottom = _level.CheckCollisionBottomSprites(this, sprites);

            positie += velocity;

            if (moving && alive)
            {
                if (startPositie.X - positie.X < -20 || collisionLeft) right = false;
                if (startPositie.X - positie.X > 20 || collisionRight) right = true;

                delay.setDelay(0.07f);

                if (right)
                {
                    if (delay.timerDone(gameTime))
                    {
                        positie.X += 3;
                        if (walking < 7)
                        {
                            walking++;
                        }
                        else
                        {
                            walking = 0;
                        }
                    }
                }
                else
                {

                    if (delay.timerDone(gameTime))
                    {
                        positie.X -= 3;
                        if (walking < 7)
                        {
                            walking++;
                        }
                        else
                        {
                            walking = 0;
                        }
                    }
                }

                if (!alive)
                {
                    delay.setDelay(0.07f);
                    if (delay.timerDone(gameTime))
                    {
                        if(dying < 4)
                        {
                            dying++;
                        }                        
                    }
                }

                if (collisionTop)
                {
                    positie.Y = _level.collisionMargin - collisionRectangle.Height - 1;
                    Console.WriteLine(positie.Y + " " + positie.X);
                    bovenCollision = false;
                }
                if (!collisionTop)
                {
                    float i = 1;
                    velocity.Y += 0.50f * i; ;
                }


                if (collisionSpriteTop)
                {
                    alive = false;
                }
            }

            collisionRectangle.X = (int)positie.X;
            collisionRectangle.Y = (int)positie.Y;

            collisionRectangleTop.X = (int)positie.X;
            collisionRectangleTop.Y = (int)positie.Y;

            collisionRectangleBottom.X = (int)positie.X;
            collisionRectangleBottom.Y = (int)positie.Y + 31;

            collisionRectangleLeft.X = (int)positie.X + 37;
            collisionRectangleLeft.Y = (int)positie.Y;

            collisionRectangleRight.X = (int)positie.X;
            collisionRectangleRight.Y = (int)positie.Y;
        }

        public void DrawAnt(SpriteBatch spriteBatch)
        {
            if (right && alive) spriteBatch.Draw(antRight[walking], positie, Color.AliceBlue);
            if (!right && alive) spriteBatch.Draw(antLeft[walking], positie, Color.AliceBlue);
            if (!alive)
            {
                if(dying < 3)
                {
                    spriteBatch.Draw(enemyDying[dying], positie, Color.AliceBlue);
                }
            }
        }
    }
}
