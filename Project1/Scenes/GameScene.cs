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


        private AnimatedSprite _perso;
        private Vector2 _persoPosition;
        private int _persoVitesse;
        private Rectangle _persoRect;

        private Texture2D _block;
        private Rectangle _blockRect;


        private int Gravite = 5;
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
            _blockRect = new Rectangle(400, 500, 100, 100);


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
            _persoRect = new Rectangle((int)_persoPosition.X,(int)_persoPosition.Y, 50, 50);
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
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
            }

            if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {
                animation = "walkEast";
                bgRect.X = bgRect.X-5;
                _blockRect.X = _blockRect.X - 5;
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
                _myGame.Etat = Game1.Etats.gameover;
            }


            if ((_persoPosition.X < _blockRect.X + _blockRect.Width) &&
            (_persoPosition.X  > _blockRect.X) &&
            (_persoPosition.Y < _blockRect.Y + _block.Height) &&
            (_persoPosition.Y + _persoRect.Height > _blockRect.Y))
            {
                _persoPosition.X = 0;
              
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
