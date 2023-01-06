using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project1.Core;

namespace Project1.Scenes
{
    internal class GameScene : Component
    {
        private static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D background;
        private Rectangle bgRect;
        internal override void LoadContent(ContentManager Content)
        {
            background = Content.Load<Texture2D>("Texutres/2");
            bgRect = new Rectangle(0, 0, data.largeurEcran, data.longueurEcran);
        }


        internal override void Update(GameTime gameTime)
        {

        }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, bgRect, Color.White);
            _spriteBatch.End();     
        }
    }
}
