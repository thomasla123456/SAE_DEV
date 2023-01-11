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


        private AnimatedSprite _perso;
        private Vector2 _persoPosition;
        private int _persoVitesse;
        private Rectangle _persoRect;
        private Texture2D _block;
        private Rectangle _blockRect;
        private SoundEffect music;
        private int Gravite = 5;
        private Song song;
        bool SAUT;
        public GameScene(Game1 game) : base(game)
        {
            _myGame = game;
        }

        public override void LoadContent()
        {
            background = Content.Load<Texture2D>("Texutres/background");
            bgRect = new Rectangle(0, 0, data.largeurEcran, data.longueurEcran);
            _block = Content.Load<Texture2D>("Texutres/block");
            _blockRect = new Rectangle(200, 400, 100, 100);          

            /*Song song = Content.Load<Song>("music");
            MediaPlayer.Play(song);*/       

            SpriteSheet spriteSheet = Content.Load<SpriteSheet>("perso.sf", new JsonContentLoader());
            var sprite = new AnimatedSprite(spriteSheet);
            

            sprite.Play("idleEast");
            _perso = sprite;
            base.LoadContent();
        }

        public override void Initialize()
        {
            _persoVitesse = 250;
            _persoPosition = new Vector2(210, 630);
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            kb = Keyboard.GetState();          
            _persoPosition.Y = _persoPosition.Y + Gravite;
            SAUT = false;

            float deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float walkSpeed = deltaSeconds * _persoVitesse;
            var keyboardState = Keyboard.GetState();
            var animation = "idleEast";

            if (keyboardState.IsKeyDown(Keys.Q) || keyboardState.IsKeyDown(Keys.Left))
            {
                animation = "walkWest";
                _persoPosition.X -= walkSpeed;
                SAUT = true;
            }

            if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {
                animation = "walkEast";
                _persoPosition.X += walkSpeed;
                SAUT = true;
            }
            if (keyboardState.IsKeyDown(Keys.D) && (keyboardState.IsKeyDown(Keys.Space)  || keyboardState.IsKeyDown(Keys.Right) && (keyboardState.IsKeyDown(Keys.Space))))
            {
                animation = "jumpEast";
                _persoPosition.X += walkSpeed;
                _persoPosition.Y = _persoPosition.Y - 6f;
                SAUT = true;
            }
            if (keyboardState.IsKeyDown(Keys.Q) && (keyboardState.IsKeyDown(Keys.Space) || keyboardState.IsKeyDown(Keys.Left) && (keyboardState.IsKeyDown(Keys.Space))))
            {
                animation = "jumpWest";
                _persoPosition.X -= walkSpeed;
                _persoPosition.Y = _persoPosition.Y - 6f;
                SAUT = true;
            }

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                _persoPosition.Y = _persoPosition.Y - 12f;
                SAUT = true;
            }



            if (_blockRect.Intersects(_persoRect))
            {
                _persoRect.X = 0;
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
            _myGame.SpriteBatch.Draw(_perso, _persoPosition);
            _myGame.SpriteBatch.Draw(_block, _blockRect, Color.White);
            _myGame.SpriteBatch.End();
        }
    }
}
