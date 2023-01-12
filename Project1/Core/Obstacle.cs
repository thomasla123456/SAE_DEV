﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project1.Core;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using MonoGame.Extended.TextureAtlases;
using System.Reflection.Metadata;

namespace Project1.Core
{
    public class Obstacle
    {
        private Texture2D _block;

        private Rectangle[] _blockRect;
        private int[] _lastPos;

        private Game1 _myGame;


        int largeur = 500;

        public Obstacle(Game1 game)
        {
            _blockRect = new Rectangle[40];
            _lastPos = new int[40];
            _myGame = game;

        }

        public void LoadContent(Texture2D _block2)
        {
            _block = _block2;

            for(int i = 0; i < 21; i++)
            {
                int rd = new Random().Next(430, 440);
         
             
                    
                    _blockRect[i] = new Rectangle(largeur , rd, 50, 50);
                largeur += 300;

            }
            
        }
        public void Update(Vector2 _persoPosition, Rectangle _persoRect)
        {
            var keyboardState = Keyboard.GetState();

            



            for (int i = 0; i < 21; i++)
            {
                if (keyboardState.IsKeyDown(Keys.Q) || keyboardState.IsKeyDown(Keys.Left))
                {

                    _blockRect[i].X = _blockRect[i].X + 5;
                }

                if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
                {

                    _blockRect[i].X = _blockRect[i].X - 5;

                }

                    if (_blockRect[i].Y <= 430)
                        _lastPos[i] = 1;

                    if (_blockRect[i].Y >= 440)
                        _lastPos[i] = 0;

                    if (_lastPos[i]==1 )
                    {
                        _blockRect[i].Y = _blockRect[i].Y + 5;
                    }
                    else if ( _lastPos[i]==0 )
                    {
                        _blockRect[i].Y = _blockRect[i].Y - 5;
                    }
                    else
                    {
                        _blockRect[i].Y = _blockRect[i].Y + 5;
                    }

                
                


                if ((_persoPosition.X < _blockRect[i].X + _blockRect[i].Width) &&
                (_persoPosition.X > _blockRect[i].X) &&
                (_persoPosition.Y < _blockRect[i].Y + _block.Height) &&
                (_persoPosition.Y + _persoRect.Height > _blockRect[i].Y))
                {
                    /*_persoPosition.X = 100;
                    bgRect.X = -1000;
                    bgRect.Y = 0;
                    _blockRect.X = 600;
                    _blockRect.Y = 500;
                    */

                    _myGame.LoadScreen0();
                }

                if (keyboardState.IsKeyDown(Keys.D) && (keyboardState.IsKeyDown(Keys.Space) || keyboardState.IsKeyDown(Keys.Right) && (keyboardState.IsKeyDown(Keys.Space))))
                {


                    _blockRect[i].X = _blockRect[i].X - 10;
                    _persoRect = new Rectangle((int)_persoPosition.X, (int)_persoPosition.Y, 25, 50);
                   

                }
                if (keyboardState.IsKeyDown(Keys.Q) && (keyboardState.IsKeyDown(Keys.Space) || keyboardState.IsKeyDown(Keys.Left) && (keyboardState.IsKeyDown(Keys.Space))))
                {
                   
                    _persoRect = new Rectangle((int)_persoPosition.X, (int)_persoPosition.Y, 25, 50);
                  
                    _blockRect[i].X = _blockRect[i].X + 10;
                    

                }


            }

            
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            for (int i = 0; i < 21; i++)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(_block, _blockRect[i], Color.White);
                spriteBatch.End();
            }
        }
    }

}