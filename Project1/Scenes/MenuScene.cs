using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;
using Project1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Scenes
{
    internal class MenuScene : Component
    {
        private const int MAX_BTNS = 3;
        private Texture2D[] btns = new Texture2D[MAX_BTNS];
        private Rectangle[] btnRect = new Rectangle[MAX_BTNS]; 
        internal override void LoadContent(ContentManager Content)
        {
            const int INCREMENT = 125;
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i] = Content.Load<Texture2D>($"BTN{i}");
                btnRect[i] = new Rectangle(0, 0 +( INCREMENT*i), btns[i].Width/2, btns[i].Height/2);
            }
             
        }

        internal override void Update(GameTime gameTime)
        {
           }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < btns.Length; i++)
                spriteBatch.Draw(btnRect[i], btns[i], Color.White);
        }
    }
}
