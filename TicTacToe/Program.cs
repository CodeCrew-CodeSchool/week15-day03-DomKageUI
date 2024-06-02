using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Tic-Tac-Toe!");

        Console.Write("Enter name for Player 1: ");
        string player1Name = Console.ReadLine();
        Player player1 = new Player(player1Name, "X");

        Console.Write("Enter name for Player 2: ");
        string player2Name = Console.ReadLine();
        Player player2 = new Player(player2Name, "O");

        Game game = new Game(player1, player2);
        game.Play();

        Console.WriteLine("Thanks for playing!");
    }
}
