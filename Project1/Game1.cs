using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D background;
        private Rectangle bgRect;

        private int hauteurFenetre = 900;
        private int longueurFenetre = 1600;

        private Vector2 textPos;
        private SpriteFont textFont;
        private const string textMsg =" dans le jeu";

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
            _graphics.PreferredBackBufferHeight = hauteurFenetre;
            _graphics.PreferredBackBufferWidth = longueurFenetre;
           _graphics.ApplyChanges();    
            Window.AllowUserResizing = false;
            Window.AllowAltF4 = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
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

           kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.Z))
                playerRect.Y -= vitesse;
            else if (kb.IsKeyDown(Keys.S))
                playerRect.Y += vitesse;

            if (kb.IsKeyDown(Keys.D))
                playerRect.X += vitesse;
            else if (kb.IsKeyDown(Keys.Q))
                playerRect.X -= vitesse;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(background,bgRect,Color.White);
            _spriteBatch.Draw(playerText,playerRect,Color.White);
            _spriteBatch.DrawString(textFont, textMsg, textPos, Color.Black);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}