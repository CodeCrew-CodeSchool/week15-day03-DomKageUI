using System;

public class GameBoard
{
    private string[] board;

    public GameBoard()
    {
        board = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    }

    public void DisplayBoard()
    {
        Console.WriteLine("|{0}||{1}||{2}|", board[0], board[1], board[2]);
        Console.WriteLine("|{0}||{1}||{2}|", board[3], board[4], board[5]);
        Console.WriteLine("|{0}||{1}||{2}|", board[6], board[7], board[8]);
    }

    public bool UpdateBoard(int position, string marker)
    {
        if (position >= 1 && position <= 9 && board[position - 1] != "X" && board[position - 1] != "O")
        {
            board[position - 1] = marker;
            return true;
        }
        return false;
    }

    public bool CheckForWinner()
    {
        string[][] winningCombinations = new string[][]
        {
            new string[] { board[0], board[1], board[2] },
            new string[] { board[3], board[4], board[5] },
            new string[] { board[6], board[7], board[8] },
            new string[] { board[0], board[3], board[6] },
            new string[] { board[1], board[4], board[7] },
            new string[] { board[2], board[5], board[8] },
            new string[] { board[0], board[4], board[8] },
            new string[] { board[2], board[4], board[6] }
        };

        foreach (var combo in winningCombinations)
        {
            if (combo[0] == combo[1] && combo[1] == combo[2])
            {
                return true;
            }
        }
        return false;
    }

    public bool IsFull()
    {
        foreach (var spot in board)
        {
            if (spot != "X" && spot != "O")
            {
                return false;
            }
        }
        return true;
    }
}
