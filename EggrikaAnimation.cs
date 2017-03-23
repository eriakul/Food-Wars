using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WindowsGame2
{
    public class EggrikaAnimation
   
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private int character_size = 7; //higher number = smaller

     
        
        int[] eggrika_left_walk_list = new int[] {0, 1, 2, 3, 4, 5, 6, 7 };
        int[] eggrika_right_walk_list = new int[] {23, 22, 21, 20, 19, 18, 17, 16 };

        private int left_walk_step = 0;
        private int right_walk_step = 0;
    
        private int counter = 0;

        /// //////////////////////////////////////////////////////////////////////////


        public EggrikaAnimation(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;

        }
    
        /// //////////////////////////////////////////////////////////////////////////


        public void Update(int eggrika_mode)
        {counter++;
            if (counter > 5)
            {   if (eggrika_mode == 1){

                    if (left_walk_step == 7){
                        left_walk_step = 0; }

                   left_walk_step++;

                   currentFrame = eggrika_left_walk_list[left_walk_step];

                  if (eggrika_mode == 2)
                   {
                       if (right_walk_step == 7)
                       {
                           right_walk_step = 0;}

                       right_walk_step++;

                   currentFrame = eggrika_right_walk_list[right_walk_step];
                   }
                       }

            }
         
                

               

                }


                
               


         
      

        /// //////////////////////////////////////////////////////////////////////////


        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            /////// set sprite size/////////////////
            int width = (Texture.Width) / Columns;
            int height = (Texture.Height) / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, new Rectangle((int)location.X, (int)location.Y, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width/character_size
          , GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height/character_size), sourceRectangle, Color.White);
            spriteBatch.End();
          
        }
         
        

    }
}