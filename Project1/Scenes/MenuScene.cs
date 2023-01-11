using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;
using Project1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class MenuScene : GameScreen
    {
        private Game1 _myGame;
        private Texture2D _textBoutons;
        private Rectangle[] lesBoutons;
        private Texture2D background;
        private Rectangle bgRect;

        public MenuScene(Game1 game) : base(game)
        {
            _myGame = game;
            lesBoutons = new Rectangle[3];
            lesBoutons[0] = new Rectangle(375, 110, 640, 160);
            lesBoutons[1] = new Rectangle(375, 320, 640, 160);
            lesBoutons[2] = new Rectangle(375, 528, 640, 160);

        }

        public override void LoadContent()
        {
            _textBoutons = Content.Load<Texture2D>($"Texutres/boutons");
            background = Content.Load<Texture2D>("Texutres/background");
            bgRect = new Rectangle(0, 0, data.largeurEcran, data.longueurEcran);

            Song song = Content.Load<Song>("musique");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(song);
            base.LoadContent();
        }
   

        public override void Update(GameTime gameTime)
        {
            MouseState _mouseState = Mouse.GetState();
            if (_mouseState.LeftButton == ButtonState.Pressed)
            {
                for (int i = 0; i < lesBoutons.Length; i++)
                {
                    if (lesBoutons[i].Contains(Mouse.GetState().X, Mouse.GetState().Y))
                    {

                        if (i == 0)
                            _myGame.Etat = Game1.Etats.Setting;
                        else if (i == 1)
                            _myGame.Etat = Game1.Etats.play;
                        else
                            _myGame.Etat = Game1.Etats.Exit;
                        break;
                    }

                }
            }

        }
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _myGame.SpriteBatch.Begin();
            _myGame.SpriteBatch.Draw(background, bgRect, Color.White);
            _myGame.SpriteBatch.Draw(_textBoutons, new Vector2(300, 0), Color.White);
            _myGame.SpriteBatch.End();
        }
    }
}
