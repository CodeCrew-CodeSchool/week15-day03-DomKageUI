

public class Board
{
    private string[] positions;

    // Constructor to initialize the board positions
    public Board()
    {
        positions = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    }

    // Method to display the board
    public void ShowBoard()
    {
        // Print the board in a 3x3 grid
        Console.WriteLine("|{0}||{1}||{2}|", positions[0], positions[1], positions[2]);
        Console.WriteLine("|{0}||{1}||{2}|", positions[3], positions[4], positions[5]);
        Console.WriteLine("|{0}||{1}||{2}|", positions[6], positions[7], positions[8]);
    }

    // Method to update the board with a player's move
    public bool MakeMove(int pos, string mark)
    {
        // Check if the position is valid and not already taken
        if (pos >= 1 && pos <= 9 && positions[pos - 1] != "X" && positions[pos - 1] != "O")
        {
            positions[pos - 1] = mark;
            return true;
        }
        return false;
    }

    // Method to check if there's a winner
    public bool HasWinner()
    {
        // Possible winning combinations
        string[][] wins = new string[][]
        {
            new string[] { positions[0], positions[1], positions[2] },
            new string[] { positions[3], positions[4], positions[5] },
            new string[] { positions[6], positions[7], positions[8] },
            new string[] { positions[0], positions[3], positions[6] },
            new string[] { positions[1], positions[4], positions[7] },
            new string[] { positions[2], positions[5], positions[8] },
            new string[] { positions[0], positions[4], positions[8] },
            new string[] { positions[2], positions[4], positions[6] }
        };

        // Check each combination to see if they match
        foreach (var combo in wins)
        {
            if (combo[0] == combo[1] && combo[1] == combo[2])
            {
                return true;
            }
        }
        return false;
    }

    // Method to check if the board is full
    public bool IsBoardFull()
    {
        // Check if all positions are filled with "X" or "O"
        foreach (var spot in positions)
        {
            if (spot != "X" && spot != "O")
            {
                return false;
            }
        }
        return true;
    }
}

public class Participant
{
    public string Username { get; set; }
    public string Symbol { get; set; }

    // Constructor to initialize player with a name and symbol
    public Participant(string username, string symbol)
    {
        Username = username;
        Symbol = symbol;
    }
}

public class TicTacToeGame
{
    private Board board;
    private Participant playerOne;
    private Participant playerTwo;
    private Participant currentPlayer;

    // Constructor to initialize the game with two players
    public TicTacToeGame(Participant p1, Participant p2)
    {
        board = new Board();
        playerOne = p1;
        playerTwo = p2;
        currentPlayer = p1;
    }

    // Method to start and manage the game play
    public void StartGame()
    {
        while (true)
        {
            // Clear the console and display the current board
            Console.Clear();
            board.ShowBoard();

            // Prompt the current player to make a move
            Console.WriteLine($"{currentPlayer.Username}'s ({currentPlayer.Symbol}) turn. Choose your position: ");
            int chosenPos;
            while (!int.TryParse(Console.ReadLine(), out chosenPos) || chosenPos < 1 || chosenPos > 9 || !board.MakeMove(chosenPos, currentPlayer.Symbol))
            {
                // Invalid input, ask the player to choose again
                Console.WriteLine("Invalid input, please choose an empty position between 1 and 9: ");
            }

            // Check if there's a winner
            if (board.HasWinner())
            {
                Console.Clear();
                board.ShowBoard();
                Console.WriteLine($"{currentPlayer.Username} wins!");
                break;
            }

            // Check if the board is full (draw)
            if (board.IsBoardFull())
            {
                Console.Clear();
                board.ShowBoard();
                Console.WriteLine("It's a draw!");
                break;
            }

            // Switch to the other player
            currentPlayer = currentPlayer == playerOne ? playerTwo : playerOne;
        }
    }
}

class GameStart
{
    static void Main()
    {
        Console.WriteLine("Welcome to Tic-Tac-Toe!");

        // Get player 1's name and create player 1
        Console.Write("Enter name for Player 1: ");
        string playerOneName = Console.ReadLine();
        Participant playerOne = new Participant(playerOneName, "X");

        // Get player 2's name and create player 2
        Console.Write("Enter name for Player 2: ");
        string playerTwoName = Console.ReadLine();
        Participant playerTwo = new Participant(playerTwoName, "O");

        // Create a new game with both players
        TicTacToeGame game = new TicTacToeGame(playerOne, playerTwo);

        // Start the game
        game.StartGame();

        Console.WriteLine("Thanks for playing!");
    }
}
