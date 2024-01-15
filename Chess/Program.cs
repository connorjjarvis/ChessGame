using System;

namespace Chess
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                Game game = new Game();
                game.Start();
            } catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
        }
    }
}
