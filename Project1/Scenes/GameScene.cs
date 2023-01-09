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
    public class GameScene : GameScreen
    {
        private static GraphicsDeviceManager _graphics;
        private Game1 _myGame;
        private Texture2D background;
        private Rectangle bgRect;


        private const int taillePerso = 100;
        private Texture2D player1Text;
        private Rectangle player1Rect;
        private KeyboardState kb;
        private const int vitesse = 5;
        private Texture2D obstacle;
        private Rectangle obstacleRect;
        public GameScene(Game1 game) : base(game)
        {
            _myGame = game;
        }
        public override void LoadContent()
        {
            background = Content.Load<Texture2D>("Texutres/bg");
            bgRect = new Rectangle(0, 0, data.largeurEcran, data.longueurEcran);
            player1Text = Content.Load<Texture2D>("Texutres/perso");
            player1Rect = new Rectangle(500, 500, player1Text.Width, player1Text.Height);
            obstacle = Content.Load<Texture2D>("Texutres/block");
            obstacleRect = new Rectangle(800, 500, 100, 100);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.Z))
            {
                player1Rect.Y -= vitesse;
            }
            else if (kb.IsKeyDown(Keys.S))
                player1Rect.Y += vitesse;

            if (kb.IsKeyDown(Keys.D))
            {
                bgRect.X -= vitesse;
                obstacleRect.X -= vitesse;
            }

            else if (kb.IsKeyDown(Keys.Q))
            {
                bgRect.X += vitesse;
                obstacleRect.X += vitesse;
            }


            if (player1Rect.Y >= 1440)
                player1Rect.Y = 1440;

            if (player1Rect.Y < 0)
                player1Rect.Y = 0;

           /* if (player1Rect.X+taillePerso >= obstacleRect.X)
                player1Rect.X = obstacleRect.X-taillePerso;

            else if (player1Rect.X + taillePerso >= obstacleRect.X && player1Rect.Y + taillePerso <= obstacleRect.Y)
                player1Rect.X += player1Rect.X+100;*/
        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Yellow);
            _myGame.SpriteBatch.Begin();
            _myGame.SpriteBatch.Draw(background, bgRect, Color.White);
            _myGame.SpriteBatch.Draw(obstacle,obstacleRect, Color.White);
            _myGame.SpriteBatch.Draw(player1Text, player1Rect, Color.White);
            _myGame.SpriteBatch.End();


        }
    }
}
