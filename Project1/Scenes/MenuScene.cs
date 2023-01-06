using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private MouseState ms, oldMs;
        private Rectangle msRect;

        public MenuScene(Game1 game) : base(game)
        {
            _myGame = game;
            lesBoutons = new Rectangle[3];
            lesBoutons[0] = new Rectangle(75, 110, 640, 160);
            lesBoutons[1] = new Rectangle(75, 320, 640, 160);
            lesBoutons[2] = new Rectangle(75, 528, 640, 160);

        }

        public override void LoadContent()
        {
            _textBoutons = Content.Load<Texture2D>($"Texutres/boutons");
            base.LoadContent();
        }
   

        public override void Update(GameTime gameTime)
        {
            MouseState _mouseState = Mouse.GetState();
            if (_mouseState.LeftButton == ButtonState.Pressed)
            {
                for (int i = 0; i < lesBoutons.Length; i++)
                {
                    // si le clic correspond à un des 3 boutons
                    if (lesBoutons[i].Contains(Mouse.GetState().X, Mouse.GetState().Y))
                    {
                        // on change l'état défini dans Game1 en fonction du bouton cliqué
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
            _myGame.SpriteBatch.Draw(_textBoutons, new Vector2(0, 0), Color.White);
            _myGame.SpriteBatch.End();
        }
    }
}
