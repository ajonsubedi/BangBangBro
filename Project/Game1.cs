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
        //ALLE VARIABELEN
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        World map = new World();
        Hero heroRight, heroLeft;   
        Texture2D heroRightTexture, heroLeftTexture;
        Texture2D enemy1RightTexture, enemy1LeftTexture;
        Texture2D coinTexture;
        Texture2D btnPlayTexture, btnInstructionTexture, btnBackTexture, btnPlayAgainTexture;
        Texture2D backgroundTexture;
        Texture2D ladderTexture;
        Texture2D healthBarRedTexture, healthBarGreenTexture;
        Texture2D healthTexture;
        Rectangle healthBarGreenRect, healthBarRedRect;
        Song backgroundMusic;
        SoundEffect soundEffect;
        Camera2D camera;
        Viewport viewport;
        Vector2 camPos = new Vector2();
        List<Coin> coins = new List<Coin>();
        Random rnd = new Random();
        List<Enemy> enemies = new List<Enemy>();
        static Score score;
        static SpriteFont scoreFont;
        static  Vector2 scorePos;
        Button btnPlay, btnInstruction, btnBack, btnPlayAgain;
        Tile tile = new Tile();
        Background background;
        Ladder ladder;
        Map level1 = new Map();

        enum GameState
        {
            MainMenu,
            Instructions,
            Playing, 
            GameOver
        }

        GameState CurrentGameState = GameState.MainMenu;
        
        int screenWidth = 1920, screenHeight = 1050;

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
            camera = new Camera2D(GraphicsDevice.Viewport);

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

            //SCREEN
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();


            //BUTTON
            btnPlayTexture = Content.Load<Texture2D>("buttons/btnPlay");
            btnPlay = new Button(btnPlayTexture, graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(-50,750));

            btnInstructionTexture = Content.Load<Texture2D>("buttons/btnInstructions");
            btnInstruction = new Button(btnInstructionTexture, graphics.GraphicsDevice);
            btnInstruction.setPosition(new Vector2(1300, 750));

            btnBackTexture = Content.Load<Texture2D>("buttons/btnBack");
            btnBack = new Button(btnBackTexture, graphics.GraphicsDevice);
            btnBack.setPosition(new Vector2(-100, 0));
            btnBack._rectangle = new Rectangle(0, 0, 25, 25);

            btnPlayAgainTexture = Content.Load<Texture2D>("buttons/btnPlayAgain");
            btnPlayAgain = new Button(btnPlayAgainTexture, graphics.GraphicsDevice);
            btnPlayAgain.setPosition(new Vector2(960, 525));



            //SOUNDTRACKS
            soundEffect = Content.Load<SoundEffect>("soundTracks/jump");
            backgroundMusic = Content.Load<Song>("soundTracks/background");
            for (int i = 0; i < 100; i++)
            {
                MediaPlayer.Play(backgroundMusic);
            }


            //HEALTHBAR
            healthBarRedTexture = Content.Load<Texture2D>("healthBarRed");
            healthBarGreenTexture = Content.Load<Texture2D>("healthBarGreen");


            //HEALTH
            healthTexture = Content.Load<Texture2D>("health");

            //HERO
            heroRightTexture = Content.Load<Texture2D>("boy/heroRight");
            heroRight = new Hero(heroRightTexture, new Vector2(0, 0), heroLeftTexture, heroRightTexture, 100);
            heroRight._control = new ControlsArrows();

            heroLeftTexture = Content.Load<Texture2D>("boy/heroLeft");
            heroLeft = new Hero(heroLeftTexture, new Vector2(0, 0), heroLeftTexture, heroRightTexture, 100);
            heroLeft._control = new ControlsArrows();


            //ENEMY
            enemy1RightTexture = Content.Load<Texture2D>("enemy/enemyRight");
            enemy1LeftTexture = Content.Load<Texture2D>("enemy/enemyleft");

            enemies.Add(new Enemy(enemy1RightTexture, new Vector2(510, 0)));
            enemies.Add(new Enemy(enemy1RightTexture, new Vector2(1000, 0)));


            //COIN
            coinTexture = Content.Load<Texture2D>("coin");

            //SCORE COIN
            coins.Add(new Coin(coinTexture, new Vector2(0, 0)));


     
            //COINS
            coins.Add(new Coin(coinTexture, new Vector2(360, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(390, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(420, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(450, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(480, 0)));

            coins.Add(new Coin(coinTexture, new Vector2(630, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(660, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(690, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(720, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(750, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(780, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(810, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(840, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(870, 0)));


            coins.Add(new Coin(coinTexture, new Vector2(1140, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(1170, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(1200, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(1230, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(1260, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(1290, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(1320, 0)));








            //SCORE
            scoreFont = Content.Load<SpriteFont>("fonts/scoreFont");
            scorePos = new Vector2(35,0);
            score = new Score(scoreFont, scorePos);






            //BACKGROUND
            backgroundTexture = Content.Load<Texture2D>("background/bgNormal");
            background = new Background(backgroundTexture, new Vector2(0, 0), new Rectangle(GraphicsDevice.Viewport.X,GraphicsDevice.Viewport.Y,GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));


            //LADDER
            ladderTexture = Content.Load<Texture2D>("ladder");
            ladder = new Ladder(ladderTexture, new Vector2(0,0), new Rectangle(475,595,150,150));





            //MAP

            map.Generate(new int[,]
            {

           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
           {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
           {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
           {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
           {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
           {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
           {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
           {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
           {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
           {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
           {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2}

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
            IsMouseVisible = true;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            score._scorePos = scorePos;
            camera.Update(heroRight._position, heroRight._viewRect);
            heroRight.Update(gameTime, soundEffect);
            heroLeft.Update(gameTime, soundEffect);
            healthBarGreenRect = new Rectangle((int)heroRight._position.X + 150, 10, heroRight.health, 10);
            healthBarRedRect = new Rectangle((int)heroRight._position.X + 150, 10, 100, 10);
            UpdateEnemy(gameTime);
            UpdateCoin(gameTime);
            scorePos.X = heroRight._position.X + 35;
            ScoreCounter();
            Collision(gameTime);
            ChangingGameState();
            TurnOffSoundOnLadder();
            enemies[0].MoveEnemyAround(780, 510);
            enemies[1].MoveEnemyAround(1150, 960);




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
            var viewMatrix = camera.GetViewMatrix();
            camera.Position = camPos;

            //START
            spriteBatch.Begin(transformMatrix: viewMatrix);

            //MAIN MENU
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Draw(Content.Load<Texture2D>("background/mainMenu"), new Rectangle(-175,0,screenWidth, screenHeight), Color.White);
                    btnPlay.Draw(spriteBatch);
                    btnInstruction.Draw(spriteBatch);
                    break;
                case GameState.Playing:
                    background.Draw(spriteBatch);

                    //ÉÉN SPRITE LATEN ZIEN
                    KeyboardState stateKey = Keyboard.GetState();
                    map.Draw(spriteBatch);


                    ladder.Draw(spriteBatch);

                    if (stateKey.IsKeyDown(Keys.Left))
                    {
                        heroLeft.Draw(spriteBatch);
                    }
                    if (stateKey.IsKeyUp(Keys.Left))
                    {
                        heroRight.Draw(spriteBatch);
                    }

                    foreach (Coin coin in coins)
                    {
                        coin.Draw(spriteBatch);

                    }

                    foreach (Enemy enemy in enemies)
                    {
                        enemy.Draw(spriteBatch);
                    }
                    coins[0].Draw(spriteBatch);
                    //SCORE LATEN ZIEN


                    // spriteBatch.DrawString(scoreFont,"x " + score.ToString(), scorePos, Color.White);
                    score.Draw(spriteBatch);
                    spriteBatch.Draw(healthBarRedTexture, healthBarRedRect, Color.White);
                    spriteBatch.Draw(healthBarGreenTexture, healthBarGreenRect, Color.White);
                    spriteBatch.Draw(healthTexture, new Rectangle((int)heroRight._position.X + 115, 0, 30, 30), Color.White);


                    break;
                case GameState.Instructions:
                    spriteBatch.Draw(Content.Load<Texture2D>("background/instructionPage"), new Rectangle(-175, 0, screenWidth, screenHeight), Color.White);
                    btnBack.Draw(spriteBatch);


                    break;

                case GameState.GameOver:
                    spriteBatch.Draw(Content.Load<Texture2D>("background/gameOverPage"), new Rectangle(-175, 0, screenWidth, screenHeight), Color.White);
                    btnPlayAgain.Draw(spriteBatch);
                    break;
            }

            
            spriteBatch.End();

            base.Draw(gameTime);
        }













        //FUNCTIES

        public void UpdateEnemy(GameTime gameTime)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Update(gameTime, soundEffect);
                if (heroRight._viewRect.Intersects(enemy._viewRect))
                {
                    heroRight.health--;
                    heroLeft.health--;

                }
            }
        }

        public void UpdateCoin(GameTime gameTime)
        {
            foreach (Coin coin in coins)
            {
                coin.Update(gameTime);
            }
            coins[0]._positie.X = heroRight._position.X;
            coins[0]._positie.Y = 0;
            coins[0].isRemoved = false;
        }

        public void ScoreCounter()
        {
            for (int i = 0; i < coins.Count; i++)
            {
                if (coins[i].isRemoved)
                {
                    coins.RemoveAt(i);
                    score._score++;
                }
            }
        }


        public void Collision(GameTime gameTime)
        {
            foreach (CollisionTiles tile in map.CollisionTiles)
            {
                heroRight.Collision(tile.Rectangle, map.Width, map.Height);
                heroLeft.Collision(tile.Rectangle, map.Width, map.Height);
                foreach (Enemy enemy in enemies)
                {
                    enemy.Collision(gameTime, tile.Rectangle, map.Width, map.Height);
                }



                foreach (Coin coin in coins)
                {

                    coin.Collision(tile.Rectangle, map.Width, map.Height);
                    if (heroRight._viewRect.Intersects(coin._rectangle))
                    {
                        coin.isRemoved = true;
                    }
                    else if (heroLeft._viewRect.Intersects(coin._rectangle))
                        coin.isRemoved = true;


                }
            }
        }

        public void ChangingGameState()
        {
            MouseState mouse = Mouse.GetState();
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    if (btnPlay.isClicked == true) CurrentGameState = GameState.Playing;
                    btnPlay.Update(mouse);

                    if (btnInstruction.isClicked == true) CurrentGameState = GameState.Instructions;
                    btnInstruction.Update(mouse);
                    break;
                case GameState.Playing:
                    if (heroRight.health < 0)
                        CurrentGameState = GameState.GameOver;
                    break;
                case GameState.Instructions:
                    if (btnBack.isClicked == true) CurrentGameState = GameState.MainMenu;
                    btnBack.Update(mouse);
                    break;
                case GameState.GameOver:
                    if (btnPlayAgain.isClicked == true) CurrentGameState = GameState.Playing;
                    btnPlayAgain.Update(mouse);
                    break;
            }
        }

        public void TurnOffSoundOnLadder()
        {
            if (heroRight._viewRect.Intersects(ladder._rectangle))
            {
                SoundEffect.MasterVolume = 0;
            }
            else SoundEffect.MasterVolume = 1;
        }


       
    }
}
