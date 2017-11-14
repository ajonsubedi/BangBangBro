using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace Project
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D herotextureRight, heroTextureLeft/*, backgroundTexture, farBuildingTexture, buildingTexture, foreBuildingTexture*/;
        Hero _mannetjeLeft, _mannetjeRight, _mannetje2Left, _mannetje2Right;
        List<ICollide> collideObjecten;
        Level level;
        Tile grass, dirt, grassLeft, grassRight, grassUp;
        Song backgroundMusic;
        SoundEffect soundEffect;

        /*
        Point boyFrameSize = new Point(48, 56);
        Point tileFrameSize = new Point(30, 30);
        int boyCollisionRectOffset = 10;
        int tileCollisionRectOffset = 10;

        protected bool Collide()
        {
            Rectangle boyRect = new Rectangle((int)boyRect)
        }*/
        //Camerda2D camera;
        //Viewport viewport;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
          //  graphics.IsFullScreen = true;
            System.Console.WriteLine(graphics.PreferredBackBufferWidth.ToString());
            Content.RootDirectory = "Content";
            TargetElapsedTime = TimeSpan.FromSeconds(1/20.0);
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
            //camera = new Camerda2D(GraphicsDevice.Viewport);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        ///             
        /// 
        public int vector = 0;
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //SOUNDTRACKS
            soundEffect = Content.Load<SoundEffect>("soundTracks/jump");
            backgroundMusic = Content.Load<Song>("soundTracks/background");
            MediaPlayer.Play(backgroundMusic);

            //MANNETJES
            heroTextureLeft = Content.Load<Texture2D>("boy/weirdLeft");
            herotextureRight = Content.Load<Texture2D>("boy/weirdRight");

            _mannetjeLeft = new Hero(heroTextureLeft, new Vector2(0, 0), heroTextureLeft, herotextureRight, Keys.Right, Keys.Left);
            _mannetjeLeft._control = new ControlsArrows();

            _mannetjeRight = new Hero(herotextureRight, new Vector2(0, 0),heroTextureLeft, herotextureRight, Keys.Right, Keys.Left);
            _mannetjeRight._control = new ControlsArrows();

            //TEST
            _mannetje2Left = new Hero(heroTextureLeft, new Vector2(0, 0), heroTextureLeft, herotextureRight, Keys.Right, Keys.Left);
            _mannetje2Left._control = new ControlsKeys();

            _mannetje2Right = new Hero(herotextureRight, new Vector2(0, 0), heroTextureLeft, herotextureRight, Keys.Right, Keys.Left);
            _mannetje2Right._control = new ControlsKeys();

            //BLOKJE
            Texture2D grassTexture = Content.Load<Texture2D>("tileSheet/grass");
            Texture2D dirtTexture = Content.Load<Texture2D>("tileSheet/dirt");
            Texture2D grassLeftTexture = Content.Load<Texture2D>("tileSheet/grassLeft");
            Texture2D grassRightTexture = Content.Load<Texture2D>("tileSheet/grassRight");
            Texture2D grassUpTexture = Content.Load<Texture2D>("tileSheet/grassUp");

            grass = new Tile(grassTexture, new Vector2(0, 0));


           collideObjecten = new List<ICollide>();
            collideObjecten.Add(_mannetje2Left);
            collideObjecten.Add(_mannetjeLeft);
            collideObjecten.Add(_mannetje2Right);
            collideObjecten.Add(_mannetjeRight);


            //LEVELS
            level = new Level();
            level._grassTexture = grassTexture;
            level._dirtTexture = dirtTexture;
            level._grassLeftTexture = grassLeftTexture;
            level._grassRightTexture = grassRightTexture;
            level._grassUpTexture = grassUpTexture;
            level.CreateWorld();
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
        private bool CheckCollision()
        {
            return false;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

           /* if (_mannetjeRight.CollisionRect.isOnTopOf(grass.rectangle))
            {
                _mannetjeRight.veloCityY.Y = 0f;
                _mannetjeRight.hasJumped = false;
            }*/
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (_mannetjeRight.CollisionRect.Intersects(_mannetje2Right.CollisionRect) && _mannetjeLeft.CollisionRect.Intersects(_mannetje2Left.CollisionRect))
            {
                System.Console.WriteLine("AAAA");
            }
            if (_mannetjeRight.isMoving)
            {
                camPos += _mannetjeRight.veloCityX;
            }
            /* if (_mannetjeLeft.isMoving)
             {
                 camPos -= _mannetjeLeft.veloCityX;
             }*/

            _mannetjeRight.Update(gameTime, soundEffect);
            _mannetjeLeft.Update(gameTime, soundEffect);
            _mannetje2Left.Update(gameTime, soundEffect);
            _mannetje2Right.Update(gameTime, soundEffect);
            base.Update(gameTime);
        }
        Vector2 camPos = new Vector2();
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
           /* var viewMatrix = camera.GetViewMatrix();
            camera.Positie = camPos;*/


            //START
            spriteBatch.Begin(/*transformMatrix: viewMatrix*/);

            //HERO
            KeyboardState stateKey = Keyboard.GetState();
            if (stateKey.IsKeyDown(Keys.Left)){
                _mannetjeLeft.Draw(spriteBatch);
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                _mannetjeRight.Draw(spriteBatch);
            }

            if (stateKey.IsKeyDown(Keys.Q))
            {
                _mannetje2Left.Draw(spriteBatch);
            }
            if (stateKey.IsKeyUp(Keys.Q))
            {
                _mannetje2Right.Draw(spriteBatch);
            }
            level.DrawWorld(spriteBatch);
            spriteBatch.End();
            //END


            base.Draw(gameTime);
        }
    }
}
static class RectangleHelper
{
    const int penetrationMargin = 5;
    public static bool isOnTopOf(this Rectangle r1, Rectangle r2)
    {
        return (r1.Bottom >= r2.Top - penetrationMargin && r1.Bottom <= r2.Top + 1 && r1.Right >= r2.Left + 5 && r1.Left <= r2.Right - 5);
    }
}