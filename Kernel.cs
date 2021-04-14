using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System;
using System.Windows;

/// <summary>
/// This engine is a slightly re-written engine from my teammate last year, Niall Mathews.  
/// Some sections have been re-written/slightly edited to better suit my game this year, instead of last year's Pong.
/// As of production milestone, has been heavily modified.
/// </summary>
namespace UpdatedEngine2 
{
    /// <summary>
    /// Core Kernel class, handles the game loop and core engine functions
    /// </summary>
    public class Kernel : Game
    {
        #region Enum and game loop
        // Create an enum to determine game state
        public enum States
        {
            Credits,
            TitleScreen,
            CharacterSelect,
            Paused,
            CHOutside,
            Museum,
            Chapel
        }

        // Create a State to store game state, call it 'gameState'
        States gameState;

        // Create a bool to check if main game loop is running, call it 'loopRunning'
        private bool loopRunning;
        #endregion

        #region Graphics, SpriteBatch, Player, Lister
        private GraphicsDeviceManager graphics;
        private SpriteBatch _spriteBatch;

        // List of IEntities
        private List<IEntity> lister;

        // Create reference to player, call it 'player'
        private Player player;

        // Create two Texture2D to store player textures, for displaying in character selection screen, call them 'boy and girl'
        private Texture2D boy;
        private Texture2D girl;
        #endregion

        #region Managers
        private AIComponentManager aI = new AIComponentManager();
        private EntityManager entityManager;
        private SceneManager sceneManager;
        private CollisionManager collisionManager;
        private InputManager inputManager;
        #endregion

        #region Artefacts
        // Create reference to Artefact for the Jar object, call it 'artefact_Jar'
        private Artefact artefact_Jar;

        // Create reference to Artefact for Junkers Bottle object, call it 'Artefact_JunkersBottle'
        private Artefact artefact_JunkersBottle;
        #endregion

        #region Backgrounds
        // Create Texture2D to store credits screen, call it 'credits'
        private Texture2D credits;

        // Create Texture2D to store Title Screen texture, call it 'titleScreen'
        private Texture2D titleScreen;

        // Create Texture2D to store Character Select screen backgrund, call it 'characterSelectBG'
        private Texture2D characterSelectBG;

        // Create a Texture2D to store Character select light, call it 'selectionLight'
        private Texture2D selectionLight;
        // Create Vector 2 to store position of light, call it 'lightPos'
        private Vector2 lightPos;

        // Create Texture2D to store Pause Screen, call it 'pauseScreen'
        private Texture2D pauseScreen;

        // Create Texture2D to store texture for Charles Hasting Outside, call it 'chOutside'
        private Texture2D chOutside;

        // Texture for Museum
        private Texture2D museum;

        // Create Texture2D to store texture for Chapel, call it 'chapel'
        private Texture2D chapel;
        #endregion

        #region AI
        // Create reference to AIComponent for a groundsKeeper object, call it 'groundsKeeper'
        private AIComponent groundsKeeper;

        // Create Curator
        private AIComponent curator;
        #endregion

        #region SpriteFonts
        // Create SpriteFont to store the text that will display when various events occur
        private SpriteFont artefactText;
        private SpriteFont gkConvoText;
        private SpriteFont playerConvoText;
        private SpriteFont inventoryText;
        #endregion

        #region Audio
        private SoundEffect bgAudio;
        #endregion

        #region Misc
        // Keyboard state for various events
        private KeyboardState keyboardState;

        // Bools for handling sprite font displaying
        private bool displayed = false;
        private bool playerPressedC = false;
        #endregion


        /// <summary>
        /// Entry point for game, initialise core values
        /// </summary>
        public Kernel()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Keep mouse pointer visible over game screen
            this.IsMouseVisible = true;
            
            // Set loop to false at first
            loopRunning = false;
        }

        /// <summary>
        /// Initalise members, callses objects and some values
        /// </summary>
        protected override void Initialize()
        {
            // Set first state to title screen
            gameState = States.TitleScreen;

            // Set starting position of character selection light
            lightPos = new Vector2(140, 45);

            // Initialise graphics settings
            InitialiseGraphics();

            // Initialise Managers
            InitialiseManagers();

            // Initialise Objects
            InitialiseObjects();

            // Initialise SpriteFonts
            InitialisespriteFonts();

            base.Initialize();
        }

        /// <summary>
        /// Load textures into memory, from Content folder
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Set boy and girl to respective textures
            boy = Content.Load<Texture2D>("PlayerToken");
            girl = Content.Load<Texture2D>("Player\\Girl_Front");

            // Set GroundsKeeper token to GroundsKeeperToken file
            groundsKeeper.Texture = Content.Load<Texture2D>("GroundsKeeperToken");

            // Set Curator texture to Curator file
            curator.Texture = Content.Load<Texture2D>("AI\\Curator");

            //animatedSprite = new AnimatedSprite(boy_Idle, 1, 5);

            // TODO: REPLACE WITH OWN AUDIO - PROOF OF CONCEPT
            bgAudio = Content.Load<SoundEffect>("Audio\\Audio_CHBG");
            bgAudio.Play();

            #region Artefacts
            // Set first artefact token to Artefact_Jar file
            artefact_Jar.Texture = Content.Load<Texture2D>("Artefact_Jar");

            // Set second artefact token to Artefact_JunkersBottle file
            artefact_JunkersBottle.Texture = Content.Load<Texture2D>("Artefact_JunkersBottle");
            #endregion

            #region Backgrounds
            // Set credits screen to Game_Credits file
            credits = Content.Load<Texture2D>("Backgrounds\\Game_Credits");

            // Set titleScreen to TitleScreen file
            titleScreen = Content.Load<Texture2D>("Backgrounds\\TitleScreen");

            // Set characterSelectBG to CharacterSelectBG file
            characterSelectBG = Content.Load<Texture2D>("Backgrounds\\CharacterSelectBG");

            // Set selectionLight to SelectionLight file
            selectionLight = Content.Load<Texture2D>("Backgrounds\\SelectionLight");

            // Set pauseScreen to PauseScreen file
            pauseScreen = Content.Load<Texture2D>("Backgrounds\\PauseScreen");

            // Set background image to CHOutside file
            chOutside = Content.Load<Texture2D>("Backgrounds\\CHOutside");

            // Set museum to Museum file
            museum = Content.Load<Texture2D>("Backgrounds\\Museum");

            // Load Chapel Texture
            chapel = Content.Load<Texture2D>("Backgrounds\\Chapel");
            #endregion
        }

        /// <summary>
        /// Dispose of unused textures 
        /// </summary>
        /// <param name="texture"></param>
        protected void UnloadContent(Texture2D texture)
        {
            // Dispose of passed in asset to free up memory, from assets no longer being used
            texture.Dispose();
        }

        /// <summary>
        /// Set initial window size - to that of title screen texture
        /// </summary>
        private void InitialiseGraphics()
        {
            // Set game window to max size and keep close button visible
            graphics.PreferredBackBufferWidth = 485;
            graphics.PreferredBackBufferHeight = 275;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Initialise objects - use engine classes to create them and store them
        /// </summary>
        private void InitialiseObjects()
        {
            // Instantiate new Player
            player = (Player)entityManager.CreatePlayer();
            // Store entity in entity list in  SceneManager
            sceneManager.StoreEntity(player);

            // Instantiate new Jar Artefact
            artefact_Jar = (Artefact)entityManager.CreateArtefact();
            // Set start positin of jar
            artefact_Jar.SetPos(270, 10);
            // Store entity in entity list in  SceneManager
            sceneManager.StoreEntity(artefact_Jar);

            // Instatntiate new Junkers Bottle Artefact
            artefact_JunkersBottle = (Artefact)entityManager.CreateArtefact();
            // Set start position of Junkers Bottle
            artefact_JunkersBottle.SetPos(300, 10);
            // Store entity in entity list in  SceneManager
            sceneManager.StoreEntity(artefact_JunkersBottle);

            // Instantiate GroundsKeeper
            groundsKeeper = new AIComponent();
            // Set start position of GroundsKeeper
            groundsKeeper.SetPos(250, 250);
            // Store entity in entity list in  SceneManager
            sceneManager.StoreEntity(groundsKeeper);

            // Instantiate Curator
            curator = new AIComponent();
            // Set start pos of curator
            curator.SetPos(250, 250);
            // Store entity in list
            sceneManager.StoreEntity(curator);

            // Get lister from SceneManager, which contains above entities
            lister = sceneManager.List();
        }

        /// <summary>
        /// Initialise engine component managers
        /// </summary>
        private void InitialiseManagers()
        {
            // Create Entity Manager
            entityManager = new EntityManager();

            // Create Scene Manager
            sceneManager = new SceneManager();

            // Create Collisions Manager
            collisionManager = new CollisionManager();

            // Create Input Manager
            inputManager = new InputManager();
        }

        /// <summary>
        /// Initialise spritefonts used in some events
        /// </summary>
        private void InitialisespriteFonts()
        {
            // Instantiate artefactText
            artefactText = Content.Load<SpriteFont>("CollectArtefactText");

            // Instantiate gk text
            gkConvoText = Content.Load<SpriteFont>("GKConvoText");

            // Instantiate Player convo text
            playerConvoText = Content.Load<SpriteFont>("PlayerConvoText");

            // Instantiate Inventory text
            inventoryText = Content.Load<SpriteFont>("InventoryText");
        }

        /// <summary>
        /// Miscellaneous event handling - hacky workarounds
        /// </summary>
        private void Extras()
        {
            keyboardState = Keyboard.GetState();

            if (player.gender == Player.Gender.Male)
            {
                // Change player texture to face correct way, done in Kernel as I can't use Content outside of Kernel
                if (keyboardState.IsKeyDown(Keys.W))
                {
                    player.Texture = Content.Load<Texture2D>("PlayerToken_Back");
                }

                if (keyboardState.IsKeyDown(Keys.A))
                {
                    player.Texture = Content.Load<Texture2D>("PlayerToken_SideLeft");
                }

                if (keyboardState.IsKeyDown(Keys.S))
                {
                    player.Texture = Content.Load<Texture2D>("PlayerToken");
                }

                if (keyboardState.IsKeyDown(Keys.D))
                {
                    player.Texture = Content.Load<Texture2D>("PlayerToken_SideRight");
                }
            }
            else if (player.gender == Player.Gender.Female)
            {
                // Change player texture to face correct way, done in Kernel as I can't use Content outside of Kernel
                if (keyboardState.IsKeyDown(Keys.W))
                {
                    player.Texture = Content.Load<Texture2D>("Player\\Girl_Back");
                }

                if (keyboardState.IsKeyDown(Keys.A))
                {
                    player.Texture = Content.Load<Texture2D>("Player\\Girl_SideLeft");
                }

                if (keyboardState.IsKeyDown(Keys.S))
                {
                    player.Texture = Content.Load<Texture2D>("Player\\Girl_Front");
                }

                if (keyboardState.IsKeyDown(Keys.D))
                {
                    player.Texture = Content.Load<Texture2D>("Player\\Girl_SideRight");
                }
            }


            if (Keyboard.GetState().IsKeyDown(Keys.C) && !playerPressedC)
            {
                playerPressedC = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.C) && playerPressedC)
            {
                playerPressedC = false;
            }

            // Because ESC is used to pause the game
            if (Keyboard.GetState().IsKeyDown(Keys.RightShift))
            {
                Exit();
            }
        }

        /// <summary>
        /// Update each engine component manager each frame, to make everything work
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            if (loopRunning)
            {
                // Call Update in SceneManager
                sceneManager.Update();

                // Call Manager in CollisionManager and pass through lister
                collisionManager.Manager(lister);

                //call Update in InputManager and pass through lister
                inputManager.Update(lister);

                // Update animated sprite
                //animatedSprite.Update();

                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    gameState = States.Paused;
                }

                Console.WriteLine("X: " + player.HitBox.X);
                Console.WriteLine("Y: " + player.HitBox.Y);
            }

            // Set Player Texture to selected file  
            if (player.gender == Player.Gender.Male)
            {
                player.Texture = Content.Load<Texture2D>("PlayerToken");
            }
            else if (player.gender == Player.Gender.Female)
            {
                player.Texture = Content.Load<Texture2D>("Player\\Girl_Front");
            }

            CheckStates();

            base.Update(gameTime);
        }

        /// <summary>
        /// Check states of the game and run logic accordingly
        /// </summary>
        private void CheckStates()
        {
            if (gameState == States.Credits)
            {
                loopRunning = false;

                ChangeGraphics(750, 750);

                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    gameState = States.Paused;
                }
            }

            if (gameState == States.TitleScreen)
            {
                loopRunning = false;
       
                if (Keyboard.GetState().GetPressedKeys().Length > 0)
                {
                    // Set game state to Character Select
                    gameState = States.CharacterSelect;
                }
            }

            if (gameState == States.CharacterSelect)
            {
                // Unload title screen assets to free up memory
                UnloadContent(titleScreen);

                ChangeGraphics(486, 273);

                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    lightPos = new Vector2(230, 45);
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    lightPos = new Vector2(140, 45);
                }

                // If light is over boy
                if (Keyboard.GetState().IsKeyDown(Keys.Enter) && lightPos.X == 140)
                {
                    player.gender = Player.Gender.Male;
                    gameState = States.CHOutside;
                }
                // If light is over girl
                else if (Keyboard.GetState().IsKeyDown(Keys.Enter) && lightPos.X == 230)
                {
                    player.gender = Player.Gender.Female;
                    gameState = States.CHOutside;
                }
            }

            if (gameState == States.Paused)
            {
                loopRunning = false;

                ChangeGraphics(1585, 985);

                // TODO: Change the absurdly Adhoc way of unpausing
                if (Keyboard.GetState().IsKeyDown(Keys.P))
                {
                    gameState = States.CHOutside;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.C))
                {
                    gameState = States.Credits;
                }
            }

            if (gameState == States.CHOutside)
            {
                // Dispose of unused assets
                UnloadContent(characterSelectBG);
                UnloadContent(selectionLight);

                if (player.gender == Player.Gender.Male)
                {
                    UnloadContent(girl);
                }
                else
                {
                    UnloadContent(boy);
                }

                loopRunning = true;

                // Set window size to fit background
                ChangeGraphics(1920, 1080);

                // Call Update in AIComponentManager
                groundsKeeper.Update();

                Extras();
            }
        }

        /// <summary>
        /// Change window size to fit caller's texture size
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void ChangeGraphics(int x, int y)
        {
            graphics.PreferredBackBufferWidth = x;
            graphics.PreferredBackBufferHeight = y;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Draw assets to the screen
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            sceneManager.Draw(_spriteBatch);

            // Only draw Title Screen if game state is title screen
            if (gameState == States.TitleScreen)
            {
                _spriteBatch.Draw(titleScreen, new Vector2(0, 0), Color.White);
            }
            // Only draw Character Selection assets if game state is CharacterSelect
            if (gameState == States.CharacterSelect)
            {
                // First drawn background
                _spriteBatch.Draw(characterSelectBG, new Vector2(0, 0), Color.White);
                // Then characters so they are 'in' the light
                _spriteBatch.Draw(boy, new Vector2(145, 65), Color.White);
                _spriteBatch.Draw(girl, new Vector2(270, 135), Color.White);
                // Then lights on top of characters
                _spriteBatch.Draw(selectionLight, lightPos, Color.White);
            }
            // Only draw CHOutside if game state is CHOutside
            else if (gameState == States.CHOutside)
            {
                _spriteBatch.Draw(chOutside, new Vector2(0, 0), Color.White);

                _spriteBatch.Draw(groundsKeeper.Texture, groundsKeeper.Pos, Color.White);

                #region Jar
                // Only draw Jar if it hasn't been collected
                if (!artefact_Jar.isCollected)
                {
                    _spriteBatch.Draw(artefact_Jar.Texture, artefact_Jar.pos, null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
                }
                else if (artefact_Jar.isCollected && !displayed)
                {
                    _spriteBatch.DrawString(artefactText, "Jar collected! View it in your Journal by pressing 'P'", new Vector2(250, 50), Color.White);

                    displayed = true;
                }
                #endregion

                if (playerPressedC)
                {
                    _spriteBatch.DrawString(playerConvoText, "Hi, I don't suppose you have a map of the grounds please?", new Vector2(player.Pos.X - 150, player.Pos.Y + 150), Color.White);
                    _spriteBatch.DrawString(gkConvoText, "Hey there kid, can I help ye?", new Vector2(groundsKeeper.Pos.X, groundsKeeper.Pos.Y - 5), Color.Black);
                }

            }
            // Only draw Pause Screen if game states is Paused
            else if (gameState == States.Paused)
            {
                _spriteBatch.Draw(pauseScreen, new Vector2(0, 0), Color.White);
            }
            // Only draw credits screen if game state is Credits
            else if (gameState == States.Credits)
            {
                _spriteBatch.Draw(credits, new Vector2(0, 0), Color.White);
            }
            // Only draw museum and curator if game state is museum
            else if (gameState == States.Museum)
            {
                _spriteBatch.Draw(museum, new Vector2(0, 0), Color.White);
                _spriteBatch.Draw(curator.Texture, curator.Pos, Color.White);
            }

            if (loopRunning)
            {
                // Draw player after everything else so they appear on top of everything else
                _spriteBatch.Draw(player.Texture, player.Pos, Color.White);

                // This is the line of code that allows for the animation to run
                //animatedSprite.Draw(_spriteBatch, player.Pos);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
