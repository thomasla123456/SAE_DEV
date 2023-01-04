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
        private Texture2D playerText;
        private Rectangle playerRect;
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
            playerText = Content.Load<Texture2D>("Texutres/perso");
            playerRect = new Rectangle(500,500,playerText.Width,playerText.Height);
           

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            gsm.Update(gameTime);

           kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.Z))
                playerRect.Y -= vitesse;
            else if (kb.IsKeyDown(Keys.S))
                playerRect.Y += vitesse;

            if (kb.IsKeyDown(Keys.D))
                playerRect.X += vitesse;
            else if (kb.IsKeyDown(Keys.Q))
                playerRect.X -= vitesse;

            if (playerRect.X > longueurEcran)
                playerRect.X =  0;

            if (playerRect.X < 0)
                playerRect.X = longueurEcran;

            
            if (textPos.X > longueurEcran)
                textPos.X = 0;
            textPos.X += vitesse;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            gsm.Draw(_spriteBatch);
            _spriteBatch.Draw(background,bgRect,Color.White);
            _spriteBatch.Draw(playerText,playerRect,Color.White);
            _spriteBatch.DrawString(textFont, textMsg, textPos, Color.Black);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}