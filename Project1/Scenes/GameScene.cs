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
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Serialization;
using MonoGame.Extended.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using MonoGame.Extended.TextureAtlases;

namespace Project1.Scenes
{
    public class GameScene : GameScreen
    {
        private static GraphicsDeviceManager _graphics;
        private Game1 _myGame;
        private Texture2D background;
        private Rectangle bgRect;


        private const int taillePerso = 100;
        private KeyboardState kb;
        private int vitesse = 5;

        Obstacle obstacle;

        private AnimatedSprite _perso;
        private Vector2 _persoPosition;

        private AnimatedSprite _porte;
        private Vector2 _portePos;

        private int _persoVitesse;
        private Rectangle _persoRect;

        private Texture2D _block;
        private Rectangle _blockRect;

        private Texture2D _panneau;
        private Rectangle _panneauRect;



        private int Gravite = 5;
        bool SAUT;
        private SpriteFont text;
 

        public GameScene(Game1 game) : base(game)
        {
            _myGame = game;
            obstacle = new Obstacle(game);
        }

        public override void LoadContent()
        {
            background = Content.Load<Texture2D>("Texutres/background");
            bgRect = new Rectangle(-1000, 0, data.largeurEcran, data.longueurEcran);
            _block = Content.Load<Texture2D>("Texutres/block");
            _blockRect = new Rectangle(600, 500, 50, 50);
            _panneau = Content.Load<Texture2D>("Texutres/panneau");
            _panneauRect = new Rectangle(-100, 560, 267/2, 279/2);


            SpriteSheet porteSheet = Content.Load<SpriteSheet>("door.sf", new JsonContentLoader());
            _porte = new AnimatedSprite(porteSheet);


            text = Content.Load<SpriteFont>("Font");
            SpriteBatch spriteBatch = new SpriteBatch(GraphicsDevice);


            obstacle.LoadContent(_block);

            


            Song song = Content.Load<Song>("musique");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(song);


            SpriteSheet spriteSheet = Content.Load<SpriteSheet>("perso.sf", new JsonContentLoader());
            var sprite = new AnimatedSprite(spriteSheet);
            

            sprite.Play("idleEast");
            _perso = sprite;

            

            base.LoadContent();
        }

        public override void Initialize()
        {
            _persoVitesse = 0;
            _persoPosition = new Vector2(410, 630);
            _portePos = new Vector2(7000, 640);  
            _persoRect = new Rectangle((int)_persoPosition.X,(int)_persoPosition.Y, 50, 50);
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            obstacle.Update(_persoPosition, _persoRect);

            kb = Keyboard.GetState();          
            _persoPosition.Y = _persoPosition.Y + Gravite;
            SAUT = false;

            _persoRect.X = (int)_persoPosition.X;
            _persoRect.Y = (int)_persoPosition.Y;

            float deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float walkSpeed = deltaSeconds * _persoVitesse;
            var keyboardState = Keyboard.GetState();
            var animation = "idleEast";

            if (keyboardState.IsKeyDown(Keys.Q) || keyboardState.IsKeyDown(Keys.Left))
            {
                animation = "walkWest";
                _persoPosition.X -= walkSpeed;
                bgRect.X = bgRect.X + 5;
                _blockRect.X = _blockRect.X + 5;
                SAUT = true;
                _portePos.X += 5;
                _panneauRect.X = _panneauRect.X+5;

            }

            if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {
                animation = "walkEast";
                bgRect.X = bgRect.X-5;
                _blockRect.X = _blockRect.X - 5;
                _persoPosition.X += walkSpeed;
                SAUT = true;
                _portePos.X -= 5;
                _panneauRect.X = _panneauRect.X - 5;
            }
            if (keyboardState.IsKeyDown(Keys.D) && (keyboardState.IsKeyDown(Keys.Space)  || keyboardState.IsKeyDown(Keys.Right) && (keyboardState.IsKeyDown(Keys.Space))))
            {
                animation = "slideEast";
                _persoPosition.X += walkSpeed;
                bgRect.X = bgRect.X - 10;
                _portePos.X -= 10;
                _blockRect.X = _blockRect.X - 10;
                _persoRect = new Rectangle((int)_persoPosition.X, (int)_persoPosition.Y, 25, 50);
                _panneauRect.X = _panneauRect.X - 10;
                SAUT = true;     
            }
            if (keyboardState.IsKeyDown(Keys.Q) && (keyboardState.IsKeyDown(Keys.Space) || keyboardState.IsKeyDown(Keys.Left) && (keyboardState.IsKeyDown(Keys.Space))))
            {
                animation = "slideWest";
                _persoPosition.X -= walkSpeed;
                _persoRect = new Rectangle((int)_persoPosition.X, (int)_persoPosition.Y, 25, 50);
                bgRect.X = bgRect.X + 10;
                _blockRect.X = _blockRect.X + 10;
                _portePos.X += 10;
                _panneauRect.X = _panneauRect.X + 10;
                SAUT = true;
                
            }

            


         



            if (_portePos.X < _persoPosition.X)
            {
                _persoPosition.X = _portePos.X;
                _porte.Play("porte");
                _porte.Update(gameTime);
              
                _myGame.LoadScreen2();
            }

            if (_panneauRect.X >= _persoPosition.X)
            {
                _persoPosition.X = _panneauRect.X;


            }

            if (_persoPosition.Y > 630)
                _persoPosition.Y = 630;

            _perso.Play(animation);
            _perso.Update(deltaSeconds);

        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Yellow);
            _myGame.SpriteBatch.Begin();
            _myGame.SpriteBatch.Draw(background, bgRect, Color.White);
            _myGame.SpriteBatch.DrawString(text, "Vies Restantes : " + Obstacle.nbVies, new Vector2(50, 50), Color.Black);
            _myGame.SpriteBatch.Draw(_porte, _portePos);
            _myGame.SpriteBatch.Draw(_panneau, _panneauRect, Color.White);
            _myGame.SpriteBatch.Draw(_perso, _persoPosition);
            _myGame.SpriteBatch.End();

            obstacle.Draw(_myGame.SpriteBatch);
        }

    }
}
