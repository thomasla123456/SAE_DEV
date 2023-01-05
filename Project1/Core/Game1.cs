using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;
using Project1.Core.Managers;

namespace Project1.Core
{
    public class Game1 : Game
    {
        private static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D background;
        private Rectangle bgRect;
        private GameStateManager gsm;

        private int largeurEcran = 900;
        private int longueurEcran = 1440;

        private Vector2 textPos;
        private SpriteFont textFont;
        private const string textMsg ="Pessi game";

        private const int taillePerso = 100;
        private Texture2D player1Text;
        private Rectangle player1Rect;
        private Texture2D player2Text;
        private Rectangle player2Rect;
        private KeyboardState kb;
        private const int vitesse = 5;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.ToggleFullScreen();
        }

        protected override void Initialize()
        {
            Window.Title = "Game";
            _graphics.PreferredBackBufferHeight = data.longueurEcran;
            _graphics.PreferredBackBufferWidth = data.largeurEcran;
           _graphics.ApplyChanges();    
            Window.AllowUserResizing = false;
            Window.AllowAltF4 = true;
            gsm = new GameStateManager();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            gsm.LoadContent(Content);
            background = Content.Load<Texture2D>("Texutres/bg");
            textFont = Content.Load<SpriteFont>("Fonts/TextFont");
            bgRect = new Rectangle(0, 0, _graphics.GraphicsDevice.Viewport.Width , _graphics.GraphicsDevice.Viewport.Height);
            textPos = new Vector2(0,10);
            player1Text = Content.Load<Texture2D>("Texutres/1");
            player1Rect = new Rectangle(500,500,player1Text.Width,player1Text.Height);
            player2Text = Content.Load<Texture2D>("Texutres/2");
            player2Rect = new Rectangle(500, 500, player2Text.Width / 2, player2Text.Height / 2);


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            gsm.Update(gameTime);

           kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.Z))
                player1Rect.Y -= vitesse;
            else if (kb.IsKeyDown(Keys.S))
                player1Rect.Y += vitesse;

            if (kb.IsKeyDown(Keys.D))
                player1Rect.X += vitesse;
            else if (kb.IsKeyDown(Keys.Q))
                player1Rect.X -= vitesse;

            if (player1Rect.X > longueurEcran)
                player1Rect.X =  0;

            if (player1Rect.X < 0)
                player1Rect.X = longueurEcran;



            if (kb.IsKeyDown(Keys.Up))
                player2Rect.Y -= vitesse;
            else if (kb.IsKeyDown(Keys.Down))
                player2Rect.Y += vitesse;

            if (kb.IsKeyDown(Keys.Right))
                player2Rect.X += vitesse;
            else if (kb.IsKeyDown(Keys.Left))
                player2Rect.X -= vitesse;

            if (player2Rect.X > longueurEcran)
                player2Rect.X = 0;

            if (player2Rect.X < 0)
                player2Rect.X = longueurEcran;



            if (textPos.X > longueurEcran)
                textPos.X = 0;
            textPos.X += vitesse;

            if (data.Exit)
                Exit(); 

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, bgRect, Color.White);
            gsm.Draw(_spriteBatch);
            _spriteBatch.Draw(player2Text, player2Rect, Color.White);
            _spriteBatch.Draw(player1Text,player1Rect,Color.White);
            _spriteBatch.DrawString(textFont, textMsg, textPos, Color.Black);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}