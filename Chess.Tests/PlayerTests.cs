using NUnit.Framework;
using Chess;

namespace Chess.PlayerTests
{
    [TestFixture]
    public class PlayerTests
    {
        private IBoard board;
        private IMovable player;

        [SetUp]
        public void Setup()
        {
            board = new ChessBoard();
            player = new Player(board);
        }

        [Test]
        public void Move_WithValidMove_ChangesPosition()
        {
            player.Move('R');
            Assert.AreEqual(1, player.X);
            Assert.AreEqual(0, player.Y);
        }

        [Test]
        public void Move_WithInvalidMove_PositionUnchanged()
        {
            player.Move('D');
            Assert.AreEqual(0, player.X);
            Assert.AreEqual(0, player.Y);
        }

        [Test]
        public void HitLandmine_DecreasesLives()
        {
            int initialLives = player.Lives;
            player.HitLandmine();
            Assert.AreEqual(initialLives - 1, player.Lives, "Hitting a landmine should decrease lives by 1.");
        }
        [Test]
        public void IsPlayerAlive_WithLives_ReturnsTrue()
        {
            player.Lives = 3; // Set a specific number of lives
            Assert.IsTrue(player.isAlive(), "Player should be alive when lives are greater than 0.");
        }

        [Test]
        public void IsPlayerAlive_WithZeroLives_ReturnsFalse()
        {
            player.Lives = 0;
            Assert.IsFalse(player.isAlive(), "Player should not be alive when lives are 0.");
        }

        [Test]
        public void HitLandmine_MultipleTimes_CheckLivesAndAliveStatus()
        {
            player.Lives = 3;
            player.HitLandmine(); // Lives = 2
            Assert.AreEqual(2, player.Lives, "Lives should be decreased to 2.");
            Assert.IsTrue(player.isAlive(), "Player should still be alive.");

            player.HitLandmine(); // Lives = 1
            Assert.AreEqual(1, player.Lives, "Lives should be decreased to 1.");
            Assert.IsTrue(player.isAlive(), "Player should still be alive.");

            player.HitLandmine(); // Lives = 0
            Assert.AreEqual(0, player.Lives, "Lives should be decreased to 0.");
            Assert.IsFalse(player.isAlive(), "Player should not be alive with 0 lives.");
        }
    }

}
