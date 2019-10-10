using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace collisionsSAT
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Game
    {
        //____Affichage de la position de la souris____
        private MouseState mouse;
        public String mouseText;
        public Vector2 mouseTextPos;
        //_____________________________________________

        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public MouseState oldMouseState;


        Texture2D obj1Texture;
        Texture2D obj2Texture;
        Texture2D projTexture;

        PolygonHitBox obj1 = new PolygonHitBox(new List<Vector2> { new Vector2(50, 100),
            new Vector2(92, 240), new Vector2(121, 200) });

        PolygonHitBox obj2 = new PolygonHitBox(new List<Vector2> { new Vector2(120, 180),
            new Vector2(310, 240), new Vector2(321, 200) });



        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1900;
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

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            Fonts.Instance.Load(this);
            IsMouseVisible = true;

            spriteBatch = new SpriteBatch(GraphicsDevice);

            obj1Texture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            obj1Texture.SetData(new[] { Color.Red });

            obj2Texture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            obj2Texture.SetData(new[] { Color.Blue });

            projTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            projTexture.SetData(new[] { Color.Green });

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

            MouseState newMouseState = Mouse.GetState();

            if ((newMouseState.LeftButton == ButtonState.Pressed) && newMouseState != oldMouseState)
            {
                //clic
                obj1.Update(newMouseState.Position);
                obj2.Update(newMouseState.Position);
            }

            oldMouseState = newMouseState;



#if DEBUG
            mouse = Mouse.GetState();
            mouseText = mouse.Position.X  + ":" + mouse.Position.Y ;
            mouseTextPos = new Vector2(graphics.PreferredBackBufferWidth- Fonts.Instance.kenPixel16.MeasureString(mouseText).X, 0);

#endif

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            obj1.Draw(spriteBatch, obj1Texture);
            obj2.Draw(spriteBatch, obj2Texture);


#if DEBUG
            spriteBatch.DrawString(Fonts.Instance.kenPixel16, mouseText ?? "", mouseTextPos, Color.Yellow);
#endif

            spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
