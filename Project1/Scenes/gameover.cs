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

namespace Project1.Scenes
{
    public class gameover : GameScreen
    {
        private static GraphicsDeviceManager _graphics;
        private Game1 _myGame;
        private Texture2D background;
        private Rectangle bgRect;
        private Texture2D _gameOver;
        private Rectangle _gameOverRect;

        public gameover(Game1 game) : base(game)
        {
            _myGame = game;


        }
        public override void LoadContent()
        {
            background = Content.Load<Texture2D>("Texutres/background");
            bgRect = new Rectangle(-1000, 0, data.largeurEcran, data.longueurEcran);
            _gameOver = Content.Load<Texture2D>("Texutres/game_over");
            _gameOverRect = new Rectangle(0, 0,871 , 160);

            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                _myGame.LoadScreen1();
            }
        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Orange);
            _myGame.SpriteBatch.Begin();
            _myGame.SpriteBatch.Draw(background, bgRect, Color.White);
            _myGame.SpriteBatch.Draw(_gameOver,_gameOverRect,Color.White);
          
            _myGame.SpriteBatch.End();
        }
    }
}
