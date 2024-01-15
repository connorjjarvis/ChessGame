using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ChessBoard : IBoard
    {
        private const int boardSize = 8;
        private bool[,] landmines;
        private Random random = new Random();

        public ChessBoard()
        {
            InititalizeLandMines();
        }

        private void InititalizeLandMines()
        {
            // A random number of squares are ‘landmines’
            landmines = new bool[boardSize, boardSize];
            int totalSquares = boardSize * boardSize;
            int totalLandmines = random.Next(totalSquares);
            // Game could be unbeatable and spawning square may be instant death.
            // Add in checks to ensure player can actually win

            for (int i = 0; i < totalLandmines; i++)
            {
                int x = random.Next(boardSize);
                int y = random.Next(boardSize);
                landmines[x, y] = true;
            }
        }

        public bool CheckLandmine(int x, int y)
        {
            return landmines[x, y];
        }

        /// <summary>
        /// Ensure player is making a legitimate move to the board size
        /// </summary>
        /// <param name="newX">New X position on the move</param>
        /// <param name="newY">New Y position on the move</param>
        /// <returns></returns>
        public bool IsLegalMove(int newX, int newY)
        {
            return newX >= 0 && newX < boardSize && newY >= 0 && newY < boardSize;
        }
    }
}
