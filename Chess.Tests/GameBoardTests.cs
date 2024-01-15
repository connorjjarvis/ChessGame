using NUnit.Framework;
using Chess;

namespace Chess.BoardTests
{
    public class Tests
    {
        private ChessBoard board;

        [SetUp]
        public void Setup()
        {
            board = new ChessBoard();
        }

        [Test]
        public void IsLegalMove_InsideBounds_ReturnsTrue()
        {
            Assert.IsTrue(board.IsLegalMove(0, 0));
            Assert.IsTrue(board.IsLegalMove(7, 7));
        }

        [Test]
        public void IsLegalMove_OutsideBounds_ReturnsFalse()
        {
            Assert.IsFalse(board.IsLegalMove(-1, 0));
            Assert.IsFalse(board.IsLegalMove(0, 8));
        }
    }
}