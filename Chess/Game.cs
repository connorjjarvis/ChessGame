using System;
using Chess;

public class Game
{
    private IBoard board;
    private IMovable player;

    public Game()
    {
        board = new ChessBoard();
        player = new Player(board);
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine($"Player is at ({player.X}, {player.Y}). Landmines hit: {player.LandminesHit}");
            Console.Write("Enter move (U, D, L, R): ");
            char move = Console.ReadKey().KeyChar;

            Console.WriteLine();

            player.Move(move);

            if (board.CheckLandmine(player.X, player.Y))
            {
                player.HitLandmine();
                Console.WriteLine(String.Format("Hit a landmine! Lifes remaining: {0}", player.Lives));
            }

            if (!player.isAlive())
            {
                Console.WriteLine("Hit too many landmines! Game over.");
                break;
            }

            if (player.Y == 7)
            {
                Console.WriteLine("You've reached the top! You win!");
                break;
            }
        }
    }
}
