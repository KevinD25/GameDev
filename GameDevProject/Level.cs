﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevProject
{
    class Level : LevelBase
    {
        public Texture2D TijdelijkeTexture;

        // wereld tekenen
        public byte[,] tileArray;

        // array maken van blokken
        public Blok[,] blokArray;

        // level initialiseren
        public Level(ContentManager content)

        {
            // textures die voor alle levels hetzelfde zijn inladen
            TijdelijkeTexture = content.Load<Texture2D>("tijdelijk/Tile2");
        
        }

        public override void CreateWorld()
        {
            blokArray = new Blok[tileArray.GetLength(0), tileArray.GetLength(1)];
            for (int x = 0; x < tileArray.GetLength(0); x++)
            {
                for (int y = 0; y < tileArray.GetLength(1); y++)
                {
                    switch (tileArray[x, y])
                    {
                        //logica voor de verschillende textures toevoegen
                        case 1:
                            blokArray[x, y] = new Blok(TijdelijkeTexture, new Vector2(y * 70, x * 70));
                            break;
                        default:
                            break;

                    }

                }
            }
        }

        public override void DrawWorld(SpriteBatch spritebatch)
        {
            for (int x = 0; x < tileArray.GetLength(0); x++)
            {
                for (int y = 0; y < tileArray.GetLength(1); y++)
                {
                    if (blokArray[x, y] != null)
                    {
                        blokArray[x, y].Draw(spritebatch);
                    }
                }
            }
        }
    }
}
