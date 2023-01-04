using System;

namespace Project1.Core
{
    public static class Program
    {
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}


