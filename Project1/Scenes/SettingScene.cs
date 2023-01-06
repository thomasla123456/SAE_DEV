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
    public class SettingScene : GameScreen
    {
        private static GraphicsDeviceManager _graphics;
        private Game1 _myGame;
        private Texture2D background;
        private Rectangle bgRect;


        public SettingScene(Game1 game) : base(game)
        {
            _myGame = game;


        }
        public override void LoadContent()
        {
            background = Content.Load<Texture2D>("Texutres/bg");
            bgRect = new Rectangle(0, 0, data.largeurEcran, data.longueurEcran);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            
        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Yellow);
            _myGame.SpriteBatch.Begin();
            /*_myGame.SpriteBatch.Draw(background, bgRect, Color.White);*/
            _myGame.SpriteBatch.End();


        }
    }
}
