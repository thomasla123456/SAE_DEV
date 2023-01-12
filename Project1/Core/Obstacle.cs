using System;
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

        private Game1 _myGame;


        int largeur = 100;
        Random random = new Random();

        public Obstacle(Game1 game)
        {
            _blockRect = new Rectangle[40];
            _myGame = game;

        }

        public void LoadContent(Texture2D _block2)
        {
            _block = _block2;

            for(int i = 0; i < 10; i++)
            {


                _blockRect[i] = new Rectangle(largeur , 500, 50, 50);
                largeur += 200;

            }
            
        }
        public void Update(Vector2 _persoPosition, Rectangle _persoRect)
        {
            var keyboardState = Keyboard.GetState();
            

            for (int i = 0; i < 10; i++)
            {
                if (keyboardState.IsKeyDown(Keys.Q) || keyboardState.IsKeyDown(Keys.Left))
                {

                    _blockRect[i].X = _blockRect[i].X + 5;
                }

                if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
                {

                    _blockRect[i].X = _blockRect[i].X - 5;

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
            }

            
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            for (int i = 0; i < 10; i++)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(_block, _blockRect[i], Color.White);
                spriteBatch.End();
            }
        }
    }
}
