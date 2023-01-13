using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;
using Project1.Core.Managers;
using Project1.Scenes;
using System;

namespace Project1.Core
{
    public class Game1 : Game
    {
        private static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private readonly ScreenManager _screenManager;
        public enum Etats { Menu, Setting, play, Exit, gameover, win, GameScene2, end };
        private Etats etat;
        private MenuScene _screenMenu;
        private GameScene _screenPlay;
        private SettingScene _screenSetting;
        private gameover _gameOverScene;
        private win _win;
        private GameScene2 _gameScene2;
        private EndScene _endScene;

        private GameStateManager gsm;

        private const int taillePerso = 100;
        private KeyboardState kb;
        private const int vitesse = 5;

        public SpriteBatch SpriteBatch
        {
            get
            {
                return this._spriteBatch;
            }

            set
            {
                this._spriteBatch = value;
            }
        }

        public Etats Etat
        {
            get
            {
                return this.etat;
            }

            set
            {
                this.etat = value;
            }
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _screenManager = new ScreenManager();
            Components.Add(_screenManager);
            _graphics.ToggleFullScreen();

            Etat = Etats.Menu;

            _screenMenu = new MenuScene(this);
            _screenPlay = new GameScene(this);
            _screenSetting = new SettingScene(this);
            _gameOverScene = new gameover(this);
            _win = new win(this);
            _gameScene2 = new GameScene2(this);
            _endScene = new EndScene(this);
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
            _screenManager.LoadScreen(_screenMenu, new FadeTransition(GraphicsDevice, Color.Black));
            gsm.LoadContent(Content);
 



        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            gsm.Update(gameTime);


            MouseState _mouseState = Mouse.GetState();
            if (_mouseState.LeftButton == ButtonState.Pressed)
            {
               
                if (this.Etat == Etats.Exit)
                    Exit();

                else if (this.Etat == Etats.play)
                    _screenManager.LoadScreen(_screenPlay, new FadeTransition(GraphicsDevice, Color.Black));


                else if (this.Etat == Etats.Setting)
                    _screenManager.LoadScreen(_screenSetting, new FadeTransition(GraphicsDevice, Color.Black));

            }

            if (Keyboard.GetState().IsKeyDown(Keys.Back))
            {
                if (this.Etat == Etats.Menu)
                    _screenManager.LoadScreen(_screenMenu, new FadeTransition(GraphicsDevice, Color.Black));
            }



            kb = Keyboard.GetState();



            if (data.Exit)
                Exit(); 

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            gsm.Draw(_spriteBatch);
            _spriteBatch.End();
            


            base.Draw(gameTime);
        }


        public void LoadScreen0()
        {
            _screenManager.LoadScreen(new gameover(this));
        }
        public void LoadScreen1()
        {
            _screenManager.LoadScreen(new GameScene(this));
        }
        public void LoadScreen2()
        {
            _screenManager.LoadScreen(new win(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen3()
        {
            _screenManager.LoadScreen(new GameScene2(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen4()
        {
            _screenManager.LoadScreen(new EndScene(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
        public void LoadScreen5()
        {
            _screenManager.LoadScreen(new MenuScene(this), new FadeTransition(GraphicsDevice, Color.Black));
        }
    }
}