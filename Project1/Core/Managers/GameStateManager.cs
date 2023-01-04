using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Core;
using Project1.Scenes;

namespace Project1.Core.Managers
{
    internal partial class GameStateManager : Component
    {
        private MenuScene ms = new MenuScene(); 
        private GameScene gs = new GameScene();

        internal override void LoadContent(ContentManager Content)
        {       
            ms.LoadContent(Content);
            gs.LoadContent(Content);    
        }

        internal override void Update(GameTime gameTime)
        {          
            switch(data.CurrentState)
            {
                case data.Scenes.Menu:
                    ms.Update(gameTime);
                    break;
                case data.Scenes.Game:
                    gs.Update(gameTime);
                    break;
                case data.Scenes.Setting:
                    break;
            }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            switch (data.CurrentState)
            {
                case data.Scenes.Menu:
                    ms.Draw(spriteBatch);   
                    break;
                case data.Scenes.Game:
                    gs.Draw(spriteBatch);
                    break;
                case data.Scenes.Setting:
                    break;
            }
        }
    }
}
