using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Board : IBoard
    {
        public int boardSize { get; set; }
        private ICell[,] cells;
        private Random random = new Random();

        public Board(int size)
        {
            boardSize = size;
            cells = new ICell[boardSize, boardSize];
            InitializeBoard();
            PlaceLandmines();
        }

        private void InitializeBoard()
        {
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    cells[x, y] = new EmptyCell();
                }
            }
        }

        private void PlaceLandmines()
        {
            int totalLandmines = random.Next(1, boardSize * boardSize);

            for (int i = 0; i < totalLandmines; i++)
            {
                int x, y;
                do
                {
                    x = random.Next(boardSize);
                    y = random.Next(boardSize);
                } while (cells[x, y].HasLandmine);

                cells[x, y].HasLandmine = true;
            }
        }
        public bool CheckCell(int x, int y)
        {
            return x >= 0 && x < boardSize && y >= 0 && y < boardSize && cells[x, y].HasLandmine;
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
