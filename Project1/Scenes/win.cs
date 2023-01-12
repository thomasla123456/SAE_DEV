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
    public class win : GameScreen
    {
        private static GraphicsDeviceManager _graphics;
        private Game1 _myGame;

        public win(Game1 game) : base(game)
        {
            _myGame = game;


        }
        public override void LoadContent()
        {

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
            GraphicsDevice.Clear(Color.Beige);
            _myGame.SpriteBatch.Begin();

            _myGame.SpriteBatch.End();
        }
    }
}
