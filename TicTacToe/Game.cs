using System;

public class Game
{
    private GameBoard gameBoard;
    private Player player1;
    private Player player2;
    private Player currentPlayer;

    public Game(Player player1, Player player2)
    {
        gameBoard = new GameBoard();
        this.player1 = player1;
        this.player2 = player2;
        currentPlayer = player1;
    }

    public void Play()
    {
        while (true)
        {
            Console.Clear();
            gameBoard.DisplayBoard();
            Console.WriteLine($"{currentPlayer.Name}'s ({currentPlayer.Marker}) turn. Choose your position: ");
            int position;
            while (!int.TryParse(Console.ReadLine(), out position) || position < 1 || position > 9 || !gameBoard.UpdateBoard(position, currentPlayer.Marker))
            {
                Console.WriteLine("Invalid input, please choose an empty position between 1 and 9: ");
            }

            if (gameBoard.CheckForWinner())
            {
                Console.Clear();
                gameBoard.DisplayBoard();
                Console.WriteLine($"{currentPlayer.Name} wins!");
                break;
            }

            if (gameBoard.IsFull())
            {
                Console.Clear();
                gameBoard.DisplayBoard();
                Console.WriteLine("It's a draw!");
                break;
            }

            currentPlayer = currentPlayer == player1 ? player2 : player1;
        }
    }
}

