using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace WindowsGame2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>  
    public class Game1 : Microsoft.Xna.Framework.Game
    {

 
        /// ///// Set Screen Proportion Units////////
        float x_unit = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 100;
        float y_unit = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 100;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D EggrikaSpriteSheet;
        private EggrikaAnimation eggrikaanimation;
        static Color background_color = Color.PeachPuff;

        public int eggrika_mode;
        public int eggrika_x = 50;
        public int eggrika_xvelocity;
        public int eggrika_y = 0;
        public int eggrika_yvelocity;
        public int eggrika_gravity;




        float thumbstick_position;
       
    


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; 
            ///////Full Screen///////
            this.graphics.IsFullScreen = true;
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        /// 




        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

          
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /// 




        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            EggrikaSpriteSheet = Content.Load<Texture2D>("EggrikaSpriteSheet");
            eggrikaanimation = new EggrikaAnimation(EggrikaSpriteSheet, 8, 4);

      

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        /// 




        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 




        protected override void Update(GameTime gameTime)
        {   
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (GamePad.GetState(PlayerIndex.Two).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            GamePadState player1_controller = GamePad.GetState(PlayerIndex.One);
            GamePadState player2_controller = GamePad.GetState(PlayerIndex.Two);

            if (player1_controller.Buttons.Back == ButtonState.Pressed)
            {
                this.graphics.IsFullScreen = true;
            }

            ///////////Eggrika Controller//////////////////////////////////////////////////////////

            thumbstick_position = player1_controller.ThumbSticks.Left.X;//return value from -1 to 1\

           //default

            if (thumbstick_position < -.3)
            {
                eggrika_mode = 1;
                eggrika_xvelocity = -1;
            }

            else if (thumbstick_position > .3)
            {
                eggrika_mode = 2;
                eggrika_xvelocity = 1;
            }
            else
            {
                eggrika_mode = 0;
                eggrika_xvelocity = 0;
            }



            ////////Update Eggrika position/////////
            eggrika_x += eggrika_xvelocity;





            eggrikaanimation.Update(eggrika_mode);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 




        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(background_color);
       
            // TODO: Add your drawing code here
            eggrikaanimation.Draw(spriteBatch, new Vector2(eggrika_x*x_unit, 40*y_unit));

           
        }
    }
}
