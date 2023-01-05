using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private MouseState ms, oldMs;
        private Rectangle msRect;
        internal override void LoadContent(ContentManager Content)
        {
            const int INCREMENT = 175;
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i] = Content.Load<Texture2D>($"Texutres/btn{i}");
                btnRect[i] = new Rectangle(580, 0 +( INCREMENT*i), btns[i].Width/2, btns[i].Height/2);
            }
             
        }

        internal override void Update(GameTime gameTime)
        {
            oldMs = ms;
            ms = Mouse.GetState(); 
            msRect = new Rectangle (ms.X,ms.Y,1,1);

            if (ms.LeftButton == ButtonState.Pressed && msRect.Intersects(btnRect[0]))
                data.CurrentState = data.Scenes.Game;
            else if (ms.LeftButton == ButtonState.Pressed && msRect.Intersects(btnRect[1]))
                data.CurrentState = data.Scenes.Setting;
            else if (ms.LeftButton == ButtonState.Pressed && msRect.Intersects(btnRect[2]))
                data.Exit = true;

        }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < btns.Length; i++)
            {
                spriteBatch.Draw(btns[i], btnRect[i], Color.White);

                if (msRect.Intersects(btnRect[i]))
                {
                    spriteBatch.Draw(btns[i], btnRect[i], Color.Gray);
                }
            }
        }
    }
}
