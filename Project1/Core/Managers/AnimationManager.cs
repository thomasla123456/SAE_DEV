﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Core.Managers
{
    public class AnimationManager
    {
        private Animation _animation;

        private float _timer;

        public Vector2 Position { get; set; }

        public AnimationManager(Animation animation)
        {
            _animation = animation;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void Play(Animation animation)
        {

        }

        public void Stop()
        {

        }

        public void Update(GameTime gameTime)
        { 
        }
    }
}