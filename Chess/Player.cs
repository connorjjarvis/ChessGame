using System;

namespace Chess
{
    public class Player : IMovable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int LandminesHit { get; set; }
        public int Lives { get; set; }

        private IBoard board;

        public Player(IBoard board)
        {
            this.board = board;
            // Start player in bottom left square
            X = 0;
            Y = 0;
            Lives = 3;
        }

        public bool Move(char dir)
        {
            int newX = X, newY = Y;
            // Assume lower case version matches upper case due to the game accepting 4 inputs.

            char direction = Char.ToUpper(dir);
            switch (direction)
            {
                case 'U': newY++; break;
                case 'D': newY--; break;
                case 'L': newX--; break;
                case 'R': newX++; break;
            }

            if (board.IsLegalMove(newX, newY))
            {
                X = newX;
                Y = newY;
                return true;
            } else {
                Console.WriteLine("Invalid move - please pick again");
                return false;
            }
        }

        public void HitLandmine()
        {
            LandminesHit++;
            Lives--;
        }

        public bool isAlive()
        {
            if (Lives == 0)
            {
                return false;
            }
            return true;
        }
    }
}
