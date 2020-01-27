using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject
{
    public class Enemy : Sprite
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

        public List<Sprite> ants = new List<Sprite>();
        public List<Sprite> acorns = new List<Sprite>();

        

        public Enemy(ContentManager cnt, LevelBase level) : base()
        {
            _level = level;
            delay = new Delay(0.15f);

        }

        public void createEnemies(ContentManager cnt)
        {
            CreateAnts(cnt);
            CreateAcorns(cnt);
        }

        private void CreateAcorns(ContentManager cnt)
        {
            acorns.Clear();
            foreach (Vector2 position in _level.beginPositieAcorns)
            {
                Acorn acorn = new Acorn(cnt, _level, position);
                acorns.Add(acorn);
            }
        }

        private void CreateAnts(ContentManager cnt)
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
            foreach (Acorn acorn in acorns) {
                acorn.UpdateAcorn(elapsedTime, gameTime);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {         
            foreach (Ant ant in ants)
            {
                ant.DrawAnt(spriteBatch);
            }
            foreach(Acorn acorn in acorns)
            {
                acorn.DrawAcorn(spriteBatch);
            }
        }
    }

    class Acorn : Enemy
    {
        static Texture2D[] acorn = new Texture2D[3];
        private bool collected = false;
        private int collectable = 0;
        private bool firsthit = true;
        SoundEffectInstance soundEffectCollect;
        SoundEffect seCollect;

        public Acorn(ContentManager cnt, LevelBase level, Vector2 beginPositie) : base(cnt, level)
        {
            positie = beginPositie;
            startPositie = beginPositie;
        
            collisionRectangle = new Rectangle((int)positie.X, (int)positie.Y, 16, 14);
            collisionRectangleTop = collisionRectangle;
            collisionRectangleBottom = collisionRectangle;
            collisionRectangleLeft = collisionRectangle;
            collisionRectangleRight = collisionRectangle;

            seCollect = cnt.Load<SoundEffect>("effects/Pickup_Coin");
            soundEffectCollect = seCollect.CreateInstance();
            soundEffectCollect.Volume = 0.5f;

            LoadTextures(cnt);
        }

        public Rectangle CollisionRectangle { get => collisionRectangle; set => collisionRectangle = value; }

        public override void LoadTextures(ContentManager cnt)
        {
            for (int i = 0; i < 3; i++)
            {
                acorn[i] = cnt.Load<Texture2D>("acorn/acorn-" + (i + 1));
            }
        }

        public void UpdateAcorn(float elapsedTime, GameTime gameTime)
        {
            
            if (CheckCollisions() && !collected)
            {
                collected = true;
                if (firsthit && collected)
                {
                    _level.Hero.collectedAcorns++;  //Acorns collected
                    soundEffectCollect.Play();
                }
                firsthit = false;
                Console.WriteLine(_level.Hero.collectedAcorns);
                //Console.WriteLine("COLLECTED");
            }

            if (!collected)
            {
                delay.setDelay(0.2f);
                if (delay.timerDone(gameTime))
                {
                    if (collectable < 2)
                    {
                        collectable++;
                    }
                    else
                    {
                        collectable = 0;
                    }
                }
            }

            UpdateCollisionRectangle();
        }

        public void DrawAcorn(SpriteBatch spriteBatch)
        {
            if (!collected)
            {
                spriteBatch.Draw(acorn[collectable], positie, Color.AliceBlue);
            }
        }

        private bool CheckCollisions()
        {

            //controleren of sprite geraakt wordt door player
            List<Sprite> sprites = new List<Sprite>();
            sprites.Add(_level.Hero);
            collisionSpriteLeft = _level.CheckCollisionLeftSprites(this, sprites);
            collisionSpriteRight = _level.CheckCollisionRightSprites(this, sprites);
            collisionSpriteTop = _level.CheckCollisionTopSprites(this, sprites);
            collisionSpriteBottom = _level.CheckCollisionBottomSprites(this, sprites);
            // CHECKING COLLISION
            return collisionSpriteLeft || collisionSpriteRight || collisionSpriteTop || collisionSpriteBottom;
        }

        private void UpdateCollisionRectangle()
        {
            collisionRectangle.X = (int)positie.X;
            collisionRectangle.Y = (int)positie.Y;
        }
    }



    class Ant : Enemy
    {
        static Texture2D[] antRight = new Texture2D[8];
        static Texture2D[] antLeft = new Texture2D[8];

        private int walking = 0;
        private bool right = true;
        private int dying = 0;
        private float YPositie;

        static Texture2D custom;

        SoundEffectInstance soundEffectPop;
        Song sePop;

        public Ant(ContentManager cnt, LevelBase level, Vector2 beginPositie) : base(cnt, level)
        {
            positie = beginPositie;
            startPositie = beginPositie;
            YPositie = startPositie.Y + 16;     

            //collision detection vierkant aanmaken
            collisionRectangle = new Rectangle((int)positie.X, (int)positie.Y + 23, 37, 31);
            collisionRectangleTop = new Rectangle((int)positie.X, (int)positie.Y - 5, 37, 5);
            collisionRectangleBottom = new Rectangle((int)positie.X, (int)positie.Y + 48, 37, 5);
            collisionRectangleLeft = new Rectangle((int)positie.X + 37, (int)positie.Y + 31, 5, 31);
            collisionRectangleRight = new Rectangle((int)positie.X, (int)positie.Y + 31, 5, 31);

            sePop = cnt.Load<Song>("effects/pop3");
           /* soundEffectPop = sePop.CreateInstance();
            soundEffectPop.Volume = 0.6f;*/


            LoadTextures(cnt);
        }

        public Rectangle CollisionRectangle { get => collisionRectangle; set => collisionRectangle = value; }

        public override void LoadTextures(ContentManager cnt)
        {
            custom = cnt.Load<Texture2D>("tijdelijk/custom");

            for (int i = 0; i < 8; i++)
            {
                antRight[i] = cnt.Load<Texture2D>("ant/right/ant-" + (i + 1));
            }

            for (int i = 0; i < 8; i++)
            {
                antLeft[i] = cnt.Load<Texture2D>("ant/left/ant-" + (i + 1));
            }
            for (int i = 0; i < 4; i++)
            {
                enemyDying[i] = cnt.Load<Texture2D>("enemydeath/enemy-death-" + (i + 1));
            }

        }

        public void UpdateAnt(float elapsedTime, GameTime gameTime)
        {
            CheckCollisions();

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
                if (collisionSpriteTop)
                {
                    alive = false;
                    positie.Y = YPositie;
                    MediaPlayer.Volume = 0.8f;
                    MediaPlayer.Play(sePop);
                   /* delay.setDelay(0.1f);
                    if (dying < 4)
                    {
                        dying++;
                    }*/
                }   

                if (collisionTop)
                {                
                    positie.Y = _level.collisionMargin - collisionRectangle.Height - 1;
                    bovenCollision = false;
                }
                if (!collisionTop)
                {                   
                    float i = 1;
                    velocity.Y += 0.50f * i; ;
                }
            }

            if (!alive && dying < 4)
            {
                delay.setDelay(0.2f);
                if (delay.timerDone(gameTime))
                {
                    if (dying < 4)
                    {
                        dying++;
                    }
                }
            }

            UpdateCollisionRectangle();
        }

        private void UpdateCollisionRectangle()
        {
            collisionRectangle.X = (int)positie.X;
            collisionRectangle.Y = (int)positie.Y;

            collisionRectangleTop.X = (int)positie.X;
            collisionRectangleTop.Y = (int)positie.Y - 5;

            collisionRectangleBottom.X = (int)positie.X;
            collisionRectangleBottom.Y = (int)positie.Y + 31;

            collisionRectangleLeft.X = (int)positie.X + 37;
            collisionRectangleLeft.Y = (int)positie.Y;

            collisionRectangleRight.X = (int)positie.X;
            collisionRectangleRight.Y = (int)positie.Y;
        }

        private void CheckCollisions()
        {
            //controleren op collissions
            collisionTop = _level.CheckCollisionTop(this);
            collisionLeft = _level.CheckCollisionLeft(this);
            collisionRight = _level.CheckCollisionRight(this);
            collisionBottom = _level.CheckCollisionBottom(this);

            //controleren of sprite geraakt wordt door player
            List<Sprite> sprites = new List<Sprite>();
            sprites.Add(_level.Hero);
            collisionSpriteLeft = _level.CheckCollisionLeftSprites(this, sprites);
            collisionSpriteRight = _level.CheckCollisionRightSprites(this, sprites);
            collisionSpriteTop = _level.CheckCollisionTopSprites(this, sprites);
            if (!collisionSpriteLeft && !collisionSpriteRight && !collisionSpriteTop)
            {
                collisionSpriteBottom = _level.CheckCollisionBottomSprites(this, sprites);
            }
        }

        public void DrawAnt(SpriteBatch spriteBatch)
        {

            Vector2 rectPos = new Vector2(collisionRectangle.X, collisionRectangle.Y);
           /* spriteBatch.Draw(custom, collisionRectangle, Color.Red);
            spriteBatch.Draw(custom, collisionRectangleLeft, Color.Red);
            spriteBatch.Draw(custom, collisionRectangleRight, Color.Red);
            spriteBatch.Draw(custom, collisionRectangleTop, Color.Red);
            spriteBatch.Draw(custom, collisionRectangleBottom, Color.Red);*/
            //Drawing hitboxes


            if (right && alive) spriteBatch.Draw(antRight[walking], positie, Color.AliceBlue);
            if (!right && alive)
            {
                spriteBatch.Draw(antLeft[walking], positie, Color.AliceBlue);
            }
            if (!alive && dying < 4)
            {
                if (dying < 4)
                {
                    spriteBatch.Draw(enemyDying[dying], new Vector2(positie.X, YPositie), Color.AliceBlue); 
                    //spriteBatch.Draw(enemyDying[dying], positie, Color.AliceBlue);
                }
            }
        }
    }
}
