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
    internal class SettingScene : Component

    {

        private static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Vector2 textPos;
        private SpriteFont textFont;
        private const string textMsg = "PARAMETRES";

        internal override void LoadContent(ContentManager Content)
        {
            textFont = Content.Load<SpriteFont>("Fonts/TextFont");
            textPos = new Vector2(40, 40);
        }

        internal override void Update(GameTime gameTime)
        {
         
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            _spriteBatch.Begin();   
            _spriteBatch.DrawString(textFont, textMsg, textPos, Color.Orange);
            _spriteBatch.End();
        }
    }
}
