using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Project;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Project
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //ALLE VARIABELEN

        //Hier komen alle textures
        Texture2D heroRightTexture, heroLeftTexture; //Hero textures
        Texture2D enemy1RightTexture, mainBossTexture; //Enemy textures
        Texture2D coinTexture, bulletTexture, ladderTexture, goToNextLevelTexture, keyTexture, doorTexture; //Other textures
        Texture2D btnPlayTexture, btnInstructionTexture, btnBackTexture, btnPlayAgainTexture; //Button textures
        Texture2D backgroundTexture; //Background textures
        Texture2D healthBarRedTexture, healthBarGreenTexture, healthTexture; //HealthTextures

        //Hier komen alle objecten
        World map = new World();
        Hero heroRight, heroLeft;
        Camera2D camera;
        Song backgroundMusic;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SoundEffect soundEffect;
        Viewport viewport;
        List<Coin> coins = new List<Coin>();
        Button btnPlay, btnInstruction, btnBack, btnPlayAgain;
        List<Bullet> bullets = new List<Bullet>();
        Tile tile = new Tile();
        Background background;
        Ladder ladder;
        List<Enemy> enemiesLevel1 = new List<Enemy>();
        List<Enemy> enemiesLevel2 = new List<Enemy>();
        Sprite goToLevel2, key, restoreHealth; //extra sprites
        Door door;
        MainBoss mainBoss;

        //Hier komen alle variabelen
        static Score score, finalScore;
        static SpriteFont scoreFont, finalScoreFont;
        static Vector2 scorePos, finalScorePos;
        int screenWidth = 1920, screenHeight = 1050;
        int keyValue = 0;



        //Hier komen alle rectangles
        Rectangle healthBarGreenRect, healthBarRedRect;

        //Hier komen alle vectoren
        Vector2 camPos = new Vector2();




        enum GameState //De gamestate word bepaald.
        {
            MainMenu,
            Instructions,
            Playing,
            GameOver
        }

        GameState CurrentGameState = GameState.MainMenu;


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

            camera.Position = camPos;
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
            btnPlay.setPosition(new Vector2(-50, 750));

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

            enemiesLevel1.Add(new Enemy(enemy1RightTexture, new Vector2(510, 0)));
            enemiesLevel1.Add(new Enemy(enemy1RightTexture, new Vector2(1130, 0)));


            //COIN
            coinTexture = Content.Load<Texture2D>("coin");

            //SCORE COIN
            coins.Add(new Coin(coinTexture, new Vector2(0, 0)));


            //MAINBOSS
            mainBossTexture = Content.Load<Texture2D>("enemy/mainboss");
            mainBoss = new MainBoss(mainBossTexture, new Vector2(1600, 0));





            //COIN
            AddCoinsLevel1();


            //Go to next level
            goToNextLevelTexture = Content.Load<Texture2D>("gotonextlevel");
            goToLevel2 = new Sprite(goToNextLevelTexture, new Vector2(1800, 697));



            //SCORE
            scoreFont = Content.Load<SpriteFont>("fonts/scoreFont");
            scorePos = new Vector2(35, 0);
            score = new Score(scoreFont, scorePos);

            finalScoreFont = Content.Load<SpriteFont>("fonts/finalScore");
            finalScorePos = new Vector2(200, 200);
            finalScore = new Score(finalScoreFont, finalScorePos);






            //BACKGROUND
            backgroundTexture = Content.Load<Texture2D>("background/bgLevel2");
            background = new Background(backgroundTexture, new Vector2(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y
                ), new Rectangle(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));


            //LADDER
            ladderTexture = Content.Load<Texture2D>("ladder");
            ladder = new Ladder(ladderTexture, new Vector2(0, 0), new Rectangle(475, 595, 150, 150));





            //MAP
            map.DrawLevel1();

            //BULLET
            bulletTexture = Content.Load<Texture2D>("bullet");
            bullets.Add(new Bullet(bulletTexture));

            //KEY
            keyTexture = Content.Load<Texture2D>("key");
            key = new Sprite(keyTexture, new Vector2(0, 1500));

            //RESTORE HEALTH
            restoreHealth = new Sprite(healthTexture, new Vector2(0, 1500));

            //DOOR
            doorTexture = Content.Load<Texture2D>("door");
            door = new Door(doorTexture, new Vector2(0, 1500));

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
            finalScore._scorePos = scorePos;
            camera.Update(heroRight._position, heroRight._viewRect);
            heroRight.Update(gameTime, soundEffect);
            heroLeft.Update(gameTime, soundEffect);
            healthBarGreenRect = new Rectangle((int)heroRight._position.X + 150, 10, heroRight.health, 10);
            healthBarRedRect = new Rectangle((int)heroRight._position.X + 150, 10, 100, 10);
            UpdateEnemy(gameTime);
            mainBoss.Update(gameTime, soundEffect);
            foreach (Coin coin in coins) //coin laten draaien
            {
                coin.Update(gameTime);
            }
            coins[0]._positie.X = heroRight._position.X; //1 coin aan de top laten zien voor score
            coins[0]._positie.Y = 0;
            coins[0].isRemoved = false;

            scorePos.X = heroRight._position.X + 35;
            ScoreCounter();
            Collision(gameTime);
            ChangingGameState();
            TurnOffSoundOnLadder();
            enemiesLevel1[0].MoveEnemyAround(780, 510);
            enemiesLevel1[1].MoveEnemyAround(1330, 1130);
            ShootRight();
            foreach (Bullet bullet in bullets) //update voor bullet
            {
                enemiesLevel1[0].GetDamage(bullet._rectangle);
                bullet.Update(graphics);
            }

            for (int i = 0; i < bullets.Count; i++) //Verwijder bullet uit lijst als bullet.isVisible = false;
            {
                if (!bullets[i].isVisible)
                {
                    bullets.RemoveAt(i);
                    i--;
                }
            }
           // key.hasDisapeard = true;
            if (heroRight._viewRect.Intersects(goToLevel2._rectangle))
            {
                GoToLevel2();
                mainBoss.isVisible = true;
                
            }
            GetKey();
            GetHealth();
            EndGame();
            mainBoss.isVisible = false;
            
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

            //START
            spriteBatch.Begin(transformMatrix: viewMatrix);

            //MAIN MENU
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Draw(Content.Load<Texture2D>("background/mainMenu"), new Rectangle(-175, 0, screenWidth, screenHeight), Color.White);
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

                    foreach (Enemy enemy in enemiesLevel1)
                    {
                        enemy.Draw(spriteBatch, SpriteEffects.FlipHorizontally);
                    }
                    foreach (Bullet bullet in bullets)
                    {
                        bullet.Draw(spriteBatch);
                    }
                    coins[0].Draw(spriteBatch);
                    //SCORE LATEN ZIEN


                    // spriteBatch.DrawString(scoreFont,"x " + score.ToString(), scorePos, Color.White);
                    score.Draw(spriteBatch);
                    spriteBatch.Draw(healthBarRedTexture, healthBarRedRect, Color.White);
                    spriteBatch.Draw(healthBarGreenTexture, healthBarGreenRect, Color.White);
                    spriteBatch.Draw(healthTexture, new Rectangle((int)heroRight._position.X + 115, 0, 30, 30), Color.White);
                    goToLevel2.Draw(spriteBatch);
                    key.Draw(spriteBatch);
                    restoreHealth.Draw(spriteBatch);
                    door.Draw(spriteBatch);
                    mainBoss.Draw(spriteBatch, SpriteEffects.FlipHorizontally);
                    break;
                case GameState.Instructions:
                    spriteBatch.Draw(Content.Load<Texture2D>("background/instructionPage"), new Rectangle(-175, 0, screenWidth, screenHeight), Color.White);
                    btnBack.Draw(spriteBatch);


                    break;

                case GameState.GameOver:
                    spriteBatch.Draw(Content.Load<Texture2D>("background/gameOverPage"), new Rectangle(-175, 0, screenWidth, screenHeight), Color.White);
                    btnPlayAgain.Draw(spriteBatch);
                    finalScore.Draw(spriteBatch);

                    break;
            }


            spriteBatch.End();

            base.Draw(gameTime);
        }













        //FUNCTIES

        public void UpdateEnemy(GameTime gameTime)   //Hiermee wordt de enemy geupdate, en de health van de hero daalt als er een collision is met de enemy
        {
            foreach (Enemy enemy in enemiesLevel1)
            {
                enemy.Update(gameTime, soundEffect);
                if (heroRight._viewRect.Intersects(enemy._viewRect))
                {
                    heroRight.health--;

                }
            }
        }

        public void GoToLevel2()
        {
            Console.WriteLine("volgende level begiint");
            heroRight._position = Vector2.Zero;
            heroLeft._position = Vector2.Zero;
            map.ClearMap();
            map.DrawLevel2();
            ClearCoins();
            AddCoinsLevel2();
            ladder.isVisible = false;
            key = new Sprite(keyTexture, new Vector2(685, 95));
            restoreHealth = new Sprite(healthTexture, new Vector2(750, 95));
            enemiesLevel1.Clear();
            enemiesLevel1.Add(new Enemy(enemy1RightTexture, new Vector2(510, 0)));
            enemiesLevel1.Add(new Enemy(enemy1RightTexture, new Vector2(1130, 0)));
            enemiesLevel1[0].isVisible = false;
            enemiesLevel1[1].isVisible = false;
            enemiesLevel2.Add(new Enemy(enemy1RightTexture, new Vector2(510, 0)));
            enemiesLevel2[0].MoveEnemyAround(780, 510);
            door = new Door(doorTexture, new Vector2(1770, 600));
            mainBoss = new MainBoss(mainBossTexture, new Vector2(1600, 0));
            mainBoss.isVisible = true;





        }

        public void Reset() //Alles wordt terug gereset
        {
            heroRight.health = 100;
            score._score = 0;
            heroRight._position = Vector2.Zero;
            heroLeft._position = Vector2.Zero;
            key.hasDisapeard = true;
            restoreHealth.hasDisapeard = true;
            enemiesLevel1[0]._position.Y = 0;
            enemiesLevel1[1]._position.Y = 0;
            door.hasDisapeard = true;
            ladder.isVisible = true;
            enemiesLevel1[0].isVisible = true;
            enemiesLevel1[1].isVisible = true;

        }



        public void ScoreCounter() //hiermee wordt de score opgeteld en de coin verwijderd uit de lijst
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


        public void Collision(GameTime gameTime) //Collision met tiles
        {
            foreach (CollisionTiles tile in map.CollisionTiles)
            {
                heroRight.Collision(tile.Rectangle, map.Width, map.Height);
                heroLeft.Collision(tile.Rectangle, map.Width, map.Height);
                foreach (Enemy enemy in enemiesLevel1)
                {
                    enemy.Collision(gameTime, tile.Rectangle, map.Width, map.Height);
                }
                mainBoss.Collision(gameTime, tile.Rectangle, map.Width, map.Height);



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

        public void ChangingGameState() //Van state veranderen, bv. Menu, Game Over, Instructions en Playing
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
                    {
                        CurrentGameState = GameState.GameOver;
                        ClearCoins();
                       // AddCoinsLevel1();
                        map.ClearMap();
                        map.DrawLevel1();
                    }
                    break;
                case GameState.Instructions:
                    if (btnBack.isClicked == true) CurrentGameState = GameState.MainMenu;
                    btnBack.Update(mouse);
                    break;
                case GameState.GameOver:
                    if (btnPlayAgain.isClicked == true)
                    {
                        CurrentGameState = GameState.Playing;
                        map.ClearMap();
                        map.DrawLevel1();
                    }
                    Reset();
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




        //BULLET FUNCTIONS
        public void ShootBullet()
        {
            Bullet nBullet = new Bullet(Content.Load<Texture2D>("bullet"));
            nBullet._position.X = heroRight._position.X;
            nBullet._position.Y = heroRight._position.Y + heroRight._texture.Height / 4;
            nBullet._velocity.X += 10f;
            nBullet.isVisible = true;

            if (bullets.Count < 2)
                bullets.Add(nBullet);
        }



        public void ShootRight()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                ShootBullet();

            }
        }

        public void AddCoinsLevel1()
        {
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

            coins.Add(new Coin(coinTexture, new Vector2(1470, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(1500, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(1530, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(1560, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(1590, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(1620, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(1650, 0)));
        }

        public void AddCoinsLevel2()
        {
            coins.Add(new Coin(coinTexture, new Vector2(200, 0)));//coin voor score


            coins.Add(new Coin(coinTexture, new Vector2(420, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(450, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(480, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(510, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(540, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(570, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(600, 0)));

            coins.Add(new Coin(coinTexture, new Vector2(930, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(960, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(990, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(1020, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(1050, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(1080, 0)));
            coins.Add(new Coin(coinTexture, new Vector2(1110, 0)));





        }

        public void ClearCoins()
        {
            coins.Clear();
        }

        public void GetKey()
        {
            if (heroRight._viewRect.Intersects(key._rectangle))
            {
                Console.WriteLine("hero raakt key");
                key.hasDisapeard = true;
                keyValue = 1;
            }       
        }

        public void GetHealth()
        {
            if (heroRight._viewRect.Intersects(restoreHealth._rectangle))
            {
                Console.WriteLine("hero raakt extra health");
                restoreHealth.hasDisapeard = true;
                heroRight.health = 100;
            }
        }

        public void EndGame()
        {
            if (heroRight._viewRect.Intersects(door._rectangle))
            {
                Console.WriteLine("hero raakt de deur");
                if(keyValue == 1)
                {
                    Console.WriteLine("Gefeliciteerd, je hebt het gehaald!");
                    CurrentGameState = GameState.GameOver;
                    ClearCoins();
                    AddCoinsLevel1();
                }
            }
        }
    }
}


