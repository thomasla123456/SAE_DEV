﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Core
{
    public static class data
    {
        public static int largeurEcran { get; set; } = 1440;
        public static int longueurEcran { get; set; } = 900;
        public static bool Exit { get; set; } = false;

        public enum Scenes { Menu, Game, Setting }
        public static Scenes CurrentState { get; set; } = Scenes.Menu;
    }
}
