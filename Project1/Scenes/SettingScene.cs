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
    internal class SettingScene : Component

    {
        private static GraphicsDeviceManager _graphics;
        private Game1 _setting;
        private Texture2D background;
        private Rectangle bgRect;


        private const int taillePerso = 100;
        private Texture2D player1Text;
        private Rectangle player1Rect;
        private Texture2D player2Text;
        private Rectangle player2Rect;
        private KeyboardState kb;
        private const int vitesse = 5;

        public SettingScene(Game1 game) : base(game)
        {
            _setting = game;


        }
        public override void LoadContent(ContentManager content)
        {
            background = Content.Load<Texture2D>("Texutres/bg");
            bgRect = new Rectangle(0, 0, data.largeurEcran, data.longueurEcran);
            player1Text = Content.Load<Texture2D>("Texutres/perso");
            player1Rect = new Rectangle(500, 500, player1Text.Width, player1Text.Height);
            player2Text = Content.Load<Texture2D>("Texutres/2");
            player2Rect = new Rectangle(500, 500, player2Text.Width / 2, player2Text.Height / 2);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.Z))
                player1Rect.Y -= vitesse;
            else if (kb.IsKeyDown(Keys.S))
                player1Rect.Y += vitesse;

            if (kb.IsKeyDown(Keys.D))
                player1Rect.X += vitesse;

            else if (kb.IsKeyDown(Keys.Q))
                player1Rect.X -= vitesse;

            if (player1Rect.X > data.longueurEcran)
                player1Rect.X = 0;

            if (player1Rect.X < 0)
                player1Rect.X = data.longueurEcran;

            if (player1Rect.Y > data.largeurEcran)
                player1Rect.Y = 0;

            if (player1Rect.Y < 0)
                player1Rect.Y = data.largeurEcran;



            if (kb.IsKeyDown(Keys.Up))
                player2Rect.Y -= vitesse;
            else if (kb.IsKeyDown(Keys.Down))
                player2Rect.Y += vitesse;

            if (kb.IsKeyDown(Keys.Right))
                player2Rect.X += vitesse;
            else if (kb.IsKeyDown(Keys.Left))
                player2Rect.X -= vitesse;

            if (player2Rect.X > data.longueurEcran)
                player2Rect.X = 0;

            if (player2Rect.X < 0)
                player2Rect.X = data.longueurEcran;

            if (player2Rect.Y > data.largeurEcran)
                player2Rect.Y = 0;

            if (player2Rect.Y < 0)
                player2Rect.Y = data.largeurEcran;



        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            GraphicsDevice.Clear(Color.Yellow);
            _setting.SpriteBatch.Begin();
            _setting.SpriteBatch.Draw(background, bgRect, Color.White);
            _setting.SpriteBatch.Draw(player2Text, player2Rect, Color.White);
            _setting.SpriteBatch.Draw(player1Text, player1Rect, Color.White);
            _setting.SpriteBatch.End();


        }
    }
}
