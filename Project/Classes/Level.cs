using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Level
    {
        public Texture2D _grassTexture, _dirtTexture, _grassLeftTexture, _grassRightTexture, _grassUpTexture;
        public Vector2 positie;


        public short[,] titleArray = new short[,]
        {
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, 
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, 
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}, 
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,3,1,1,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {1,1,1,1,1,1,2,2,2,2,1,1,4,0,0,0,3,1,1,1,1,1,1,1,1,1,1},
           {2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,1,2,2,2,2,2,2,2,2,2,2,2},
           {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
           {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2}
        };
        private Tile[,] grassArray = new Tile[20, 27];
        private Tile[,] grassLeftArray = new Tile[20, 27];
        private Tile[,] grassRightArray = new Tile[20, 27];
        private Tile[,] grassUpArray = new Tile[20, 27];
        private Tile[,] dirtArray = new Tile[20, 27];



        public void CreateWorld()
        {
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 27; y++)
                {
                    if (titleArray[x, y] == 1) 
                    {
                        grassArray[x, y] = new Tile(_grassTexture, new Vector2(y*30  , x*24 ));
                    }
                     else if(titleArray[x,y] == 2)
                    {
                        dirtArray[x, y] = new Tile(_dirtTexture, new Vector2(y * 30, x * 24));
                    }
                    else if (titleArray[x, y] == 3)
                    {
                        grassLeftArray[x, y] = new Tile(_grassLeftTexture, new Vector2(y * 30, x * 24));
                    }
                    else if (titleArray[x, y] == 4)
                    {
                        grassRightArray[x, y] = new Tile(_grassRightTexture, new Vector2(y * 30, x * 24));
                    }
                    else if (titleArray[x, y] == 5)
                    {
                        grassUpArray[x, y] = new Tile(_grassUpTexture, new Vector2(y * 30, x * 24));
                    }
                }
            }
        }
     
        public void DrawWorld(SpriteBatch spriteBatch)
        {
            
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 27; y++)
                {

                    if (grassArray[x,y] != null)
                    {
                       grassArray[x, y].Draw(spriteBatch);
                    }
                    else if(dirtArray[x,y] != null)
                    {
                        dirtArray[x, y].Draw(spriteBatch);
                    }
                    else if (grassLeftArray[x, y] != null)
                    {
                        grassLeftArray[x, y].Draw(spriteBatch);
                    }
                    else if (grassRightArray[x, y] != null)
                    {
                        grassRightArray[x, y].Draw(spriteBatch);
                    }
                    else if (grassUpArray[x, y] != null)
                    {
                        grassUpArray[x, y].Draw(spriteBatch);
                    }
                }
            }
        }
    }
}
