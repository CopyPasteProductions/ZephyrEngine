﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine.Graphics.ContentManager;
using HordeGame.Graphics.ContentManager;
using Engine.Graphics;
using Engine.Graphics.Renderer;
using Engine.StateManagement.GameStateManagement;
using HordeGame.StateManagement;
using Engine.StateManagement.EntityManagement;
using Engine.StateManagement.EntityManagement.Entity;
using Engine.Physics;
using Engine.Physics.Collision;
using Engine.Physics.Action;
using HordeGame.Physics.Action;
namespace HordeGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite guySprite;
        private IGameStateManager gameManager;
        private EntityManager entityManager;

        Sprite[] sprites;

        Texture2D guy;
        private GenericContentManager<Texture2D> textureContentManager;
        private GraphicsRenderer renderer;
        public static GraphicsDeviceManager Graphics
        {
            get
            {
                return graphics;
            }

            set
            {
                graphics = value;
            }
        }

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            var cont = Content;
            gameManager = new ConcreteGameStateManager("test");
            entityManager = new GameElementEntityManager();
            EngineMonoGameSingleTon.init(ref cont);
            Content = cont;
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
            renderer = new GraphicsQueueRenderer();
            TestGameState gameState = new TestGameState(entityManager, renderer);
            gameManager.addGameState(gameState);
            gameManager.init();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            var content = Content;
            textureContentManager = ContentMangerSingleton.Textures;
            new HordeGameContentLoader(ref textureContentManager).load();
            Content = content;
            guy = textureContentManager.getContentById("player");
       
            sprites = new Sprite[] { new Sprite("player"), new Sprite("player"), new Sprite("player"), new Sprite("player")};
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Engine.Graphics.SpriteBatchSingleton.setSpriteBatch(spriteBatch);

            foreach (Sprite s in sprites)
            {
                SimpleCollisionBody body = new SimpleCollisionBody(new Rectangle(10, 10, 64, 64), true);
                var oc = new Physics.OnCollisionScreenEdge();
                var m = new ComplexMovement();
                m.addAction(new MoveRandomDirectionAction());
                GameWorldObject o = new GameWorldObject(body, oc, m );



               entityManager.addEntity(new ConcreteEntity(s, null, o));
            }
            var width = graphics.GraphicsDevice.Viewport.Width;
            var height = graphics.GraphicsDevice.Viewport.Height;
            System.Console.WriteLine(width +" , "+ height);
            entityManager.addEntity(new ConcreteEntity(null, null, new GameWorldObject(new SimpleCollisionBody(new Rectangle(0, 0, width, 1), true), null, new ComplexMovement())));
            entityManager.addEntity(new ConcreteEntity(null, null, new GameWorldObject(new SimpleCollisionBody(new Rectangle(0, height, width , 1), true), null, new ComplexMovement())));
            entityManager.addEntity(new ConcreteEntity(null, null, new GameWorldObject(new SimpleCollisionBody(new Rectangle(width, 0, 1, height), true), null, new ComplexMovement())));
            entityManager.addEntity(new ConcreteEntity(null, null, new GameWorldObject(new SimpleCollisionBody(new Rectangle(0, 0, 1, height), true), null, new ComplexMovement())));
            //// TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        double lastGameTime = 0;
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
          
         
                gameManager.updateActiveGameState(gameTime);
              
        

            
            base.Update(gameTime);
        }
        double lastDrawGameTime = 0.0;
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            gameManager.drawGameStateComponents(gameTime);
                
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
