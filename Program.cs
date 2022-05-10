using System;
using v1;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = Game.getGame();
            game.Start();        
        }
    }
}
