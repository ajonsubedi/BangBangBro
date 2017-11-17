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
        public Texture2D _grassTexture, _dirtTexture;
        public Vector2 positie;
        List<CollisionTiles> collisionTiles = new List<CollisionTiles>();

        private int width, height;
        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }
        

        /*public void Generate(int[,] map, int size)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];
                    if(number > 0)
                     collisionTiles.Add(new CollisionTiles(_grassTexture, positie, number, new Rectangle(x * size, y * size, size, size)));
                    
                    width = (x + 1) * size;
                    height = (y + 1) * size;
                }
            }
        }*/
        public int[,] map = new int[,]
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
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
           {0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        };
        private Tile[,] grassArray = new Tile[20, 27];
        private Tile[,] dirtArray = new Tile[20, 27];



        public void CreateWorld(int size)
        {
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 27; y++)
                {
                    if (map[x, y] == 1) 
                    {
                        int number = map[y, x];
                        if (number > 0)
                            collisionTiles.Add(new CollisionTiles(_grassTexture, positie, number, new Rectangle(x * size, y * size, size, size)));

                        width = (x + 1) * size;
                        height = (y + 1) * size;
                        grassArray[x, y] = new Tile(_grassTexture, new Vector2(y*30  , x*24 ));
                    }
                     else if(map[x,y] == 2)
                    {
                        int number = map[y, x];
                        if (number > 0)
                            collisionTiles.Add(new CollisionTiles(_grassTexture, positie, number, new Rectangle(x * size, y * size, size, size)));

                        width = (x + 1) * size;
                        height = (y + 1) * size;
                        dirtArray[x, y] = new Tile(_dirtTexture, new Vector2(y * 30, x * 24));
                    }
                }
            }
        }
     
        public void DrawWorld(SpriteBatch spriteBatch)
        {
            foreach(CollisionTiles tile in collisionTiles)
            {
                tile.Draw(spriteBatch);
            }
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
                }
            }
        }
    }
}
