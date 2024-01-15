using System;
using Chess;

public class Game
{
    private IBoard board;
    private ICharacter player;

    public Game()
    {
        board = new Board(8);
        player = new Player(board);
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine($"Player is at ({player.X}, {player.Y}). Landmines hit: {player.LandminesHit}");
            Console.WriteLine("Enter move (U, D, L, R): ");
            char move = Console.ReadKey().KeyChar;

            Console.WriteLine();

            player.Move(move);

            if (CheckForLandmine())
            {
                Console.WriteLine($"Hit a landmine! Lives remaining: {player.Lives}");
            }

            if (CheckGameOver())
            {
                Console.WriteLine("Hit too many landmines! Game over.");
                break;
            }

            if (CheckWinCondition())
            {
                Console.WriteLine("You've reached the top! You win!");
                break;
            }
        }
    }

    private bool CheckForLandmine()
    {
        if (board.CheckCell(player.X, player.Y))
        {
            player.HitLandmine();
            return true;
        }
        return false;
    }

    private bool CheckGameOver() => !player.isAlive();

    private bool CheckWinCondition() => player.Y == 7; 
}
