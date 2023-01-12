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
        private Texture2D _gagne;
        private Rectangle _gagneRect;
        private Texture2D background;
        private Rectangle bgRect;

        public win(Game1 game) : base(game)
        {
            _myGame = game;


        }
        public override void LoadContent()
        {
            _gagne = Content.Load<Texture2D>("Texutres/GAGNE");
            _gagneRect = new Rectangle(300, 200, 631, 387);
            background = Content.Load<Texture2D>("Texutres/background");
            bgRect = new Rectangle(-1000, 0, data.largeurEcran, data.longueurEcran);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                _myGame.LoadScreen3();
            }
        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Beige);
            _myGame.SpriteBatch.Begin();
            _myGame.SpriteBatch.Draw(background, bgRect, Color.White);
            _myGame.SpriteBatch.Draw(_gagne, _gagneRect, Color.White);
            _myGame.SpriteBatch.End();
        }
    }
}
