using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Project;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Project
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Level map;
        Hero heroRight, heroLeft;   
        Texture2D heroRightTexture, heroLeftTexture;
        Texture2D enemy1RightTexture, enemy1LeftTexture;
        Texture2D coinTexture;
        Song backgroundMusic;
        SoundEffect soundEffect;
        Camerda2D camera;
        Viewport viewport;
        Vector2 camPos = new Vector2();
        Enemy enemy1Right, enemy1Left;
        List<Coin> coins = new List<Coin>();
        Random rnd = new Random();
        SpriteFont scoreFont;
        Vector2 scorePos;
        int score = 0;
        float _timer;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            System.Console.WriteLine(graphics.PreferredBackBufferWidth.ToString());

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            camera = new Camerda2D(GraphicsDevice.Viewport);
            map = new Level();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Tile.Content = Content;


            //SOUNDTRACKS
            soundEffect = Content.Load<SoundEffect>("soundTracks/jump");
            backgroundMusic = Content.Load<Song>("soundTracks/background");
            for (int i = 0; i < 100; i++)
            {
                MediaPlayer.Play(backgroundMusic);
            }


            //HERO
            heroRightTexture = Content.Load<Texture2D>("boy/heroRight");
            heroRight = new Hero(heroRightTexture, new Vector2(0, 0), heroLeftTexture, heroRightTexture);
            heroRight._control = new ControlsArrows();

            heroLeftTexture = Content.Load<Texture2D>("boy/heroLeft");
            heroLeft = new Hero(heroLeftTexture, new Vector2(0, 0), heroLeftTexture, heroRightTexture);
            heroLeft._control = new ControlsArrows();


            //ENEMY
            enemy1RightTexture = Content.Load<Texture2D>("enemy/enemy1Right");
            enemy1Right = new Enemy(enemy1RightTexture, new Vector2(0, 0), enemy1LeftTexture, enemy1RightTexture);

            enemy1LeftTexture = Content.Load<Texture2D>("enemy/enemy1left");
            enemy1Left = new Enemy(enemy1LeftTexture, new Vector2(0, 0), enemy1LeftTexture, enemy1RightTexture);

            //COIN
            coinTexture = Content.Load<Texture2D>("coin");

            coins.Add(new Coin(coinTexture, new Vector2(0, 0)));


            coins.Add(new Coin(coinTexture, new Vector2(150, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(180, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(210, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(240, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(270, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(300, 0)));

            coins.Add(new Coin(coinTexture, new Vector2(390, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(420, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(450, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(480, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(510, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(540, 0)));

            //SCORE
            scoreFont = Content.Load<SpriteFont>("fonts/Font1");
            scorePos = new Vector2(35,0);













            map.Generate(new int[,]
            {
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0},
           {1,1,1,1,1,1,1,1,1,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,1,1,2,2,2,2,2,1,1,1,1,1,1,1,1,1},
           {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
           {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
           {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2}
            }, 30);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;


            heroRight.Update(gameTime, soundEffect);
            heroLeft.Update(gameTime, soundEffect);
            enemy1Right.Update(gameTime, soundEffect);
            foreach (Coin coin in coins)
            {
                coin.Update(gameTime);
            }
            foreach (CollisionTiles tile in map.CollisionTiles)
            {
                heroRight.Collision(tile.Rectangle, map.Width, map.Height);
                heroLeft.Collision(tile.Rectangle, map.Width, map.Height);
                enemy1Right.Collision(tile.Rectangle, map.Width, map.Height);
                enemy1Left.Collision(tile.Rectangle, map.Width, map.Height);
                camera.Update(heroRight._position, map.Width, map.Height);
                camera.Update(heroLeft._position, map.Width, map.Height);


                foreach (Coin coin in coins)
                {

                    coin.Collision(tile.Rectangle, map.Width, map.Height);
                    if (heroRight._viewRect.Intersects(coin._rectangle))
                    {
                        coin.isRemoved = true;
                        score++;
                    }

                    
                }
                coins[0]._positie.X = 0;
                coins[0]._positie.Y = 0;
                coins[0].isRemoved = false;

                for (int i = 0; i < coins.Count; i++)
                {
                    if (coins[i].isRemoved)
                    {
                        coins.RemoveAt(i);
                    }
                }




            }

            


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here


            //START
            spriteBatch.Begin(SpriteSortMode.Deferred,
                               BlendState.AlphaBlend,
                               null, null, null, null,
                               camera.Transform);

            //ÉÉN SPRITE LATEN ZIEN
            KeyboardState stateKey = Keyboard.GetState();

            if (stateKey.IsKeyDown(Keys.Left))
            {
                heroLeft.Draw(spriteBatch);
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                heroRight.Draw(spriteBatch);
            }
            map.Draw(spriteBatch);
            // enemy1Right.Draw(spriteBatch);
            // enemy1Left.Draw(spriteBatch);
            foreach (Coin coin in coins)
            {
                coin.Draw(spriteBatch);

            }
            //SCORE LATEN ZIEN
            

            spriteBatch.DrawString(scoreFont,score.ToString(), scorePos, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
