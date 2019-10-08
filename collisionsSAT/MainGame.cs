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

        Texture2D obj1Texture;
        Texture2D obj2Texture;
        Texture2D projTexture;

        PolygonHitBox obj1 = new PolygonHitBox(new List<Vector2> { new Vector2(50, 100),
            new Vector2(92, 240), new Vector2(121, 200) });

        PolygonHitBox obj2 = new PolygonHitBox(new List<Vector2> { new Vector2(120, 180),
            new Vector2(310, 240), new Vector2(321, 200) });


        Rectangle obj1Xprojection;
        Rectangle obj1Yprojection;
        Rectangle obj1Qprojection;



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

            //obj1Xprojection = new Rectangle((int)obj1A.X, 0, (int)obj1B.X - (int)obj1A.X, 4);
            //obj1Yprojection = new Rectangle(0, (int)obj1A.Y, 4, (int)obj1B.Y - (int)obj1A.Y);
            //obj1Qprojection = new Rectangle(Tools.BaseProjectionVertexSurX(obj1A, obj1B), 0
            //    , Tools.BaseProjectionVertexSurX(obj1B, obj1A) - Tools.BaseProjectionVertexSurX(obj1A, obj1B)
            //    , 4);


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


            spriteBatch.Draw(obj1Texture, obj1Xprojection, Color.White * 0.5f);
            spriteBatch.Draw(obj1Texture, obj1Yprojection, Color.White * 0.5f);
            spriteBatch.Draw(projTexture, obj1Qprojection, Color.White * 0.5f);


#if DEBUG
            spriteBatch.DrawString(Fonts.Instance.kenPixel16, mouseText ?? "", mouseTextPos, Color.Yellow);
            //mainGame.spriteBatch.DrawString(Fonts.Instance.kenPixel16, cursorCarthPos.ToString(), Vector2.Zero, Color.Yellow);

#endif

            spriteBatch.End();

            base.Draw(gameTime);
        }



        //public getAngleAlpha 



        //public bool CheckCollision(PolygonHitBox poly1, PolygonHitBox poly2)
        //{
        //    bool collision = false;

        //    foreach (var item in collection)
        //    {

        //    }




        //    return collision;
        //}


    }
}
