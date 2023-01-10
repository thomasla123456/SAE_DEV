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
        private Sprite _block;
        private Vector2 _blockPos;
        private SoundEffect music;

        public GameScene(Game1 game) : base(game)
        {
            _myGame = game;
        }

        public override void LoadContent()
        {
            background = Content.Load<Texture2D>("Texutres/background");
            bgRect = new Rectangle(0, 0, data.largeurEcran, data.longueurEcran);
            music = Content.Load<SoundEffect>("music");
            
            /*_block = Content.Load<Sprite>("Texutres/2");*/
            _blockPos = new Vector2 (500, 500);

            SpriteSheet spriteSheet = Content.Load<SpriteSheet>("perso.sf", new JsonContentLoader());
            var sprite = new AnimatedSprite(spriteSheet);

            sprite.Play("idleEast");
            _perso = sprite;

            base.LoadContent();
        }

        public override void Initialize()
        {
            _persoVitesse = 100;
            _persoPosition = new Vector2(200, 660);
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            kb = Keyboard.GetState();

            float deltaSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float walkSpeed = deltaSeconds * _persoVitesse;
            var keyboardState = Keyboard.GetState();
            var animation = "idleEast";

            if (keyboardState.IsKeyDown(Keys.Q) || keyboardState.IsKeyDown(Keys.Left))
            {
                animation = "walkWest";
                _persoPosition.X -= walkSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
            {
                animation = "walkEast";
                _persoPosition.X += walkSpeed;
            }

            if (_persoPosition.Y > 660)
                _persoPosition.Y = 660;

            _perso.Play(animation);
            _perso.Update(deltaSeconds);


        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Yellow);
            _myGame.SpriteBatch.Begin();
            _myGame.SpriteBatch.Draw(background, bgRect, Color.White);
            _myGame.SpriteBatch.Draw(_perso, _persoPosition);
            _myGame.SpriteBatch.End();


        }


    }
}
