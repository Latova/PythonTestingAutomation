using System;

class TicTacToe
{
    static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
    static char currentPlayer = 'X';

    static void Main()
    {
        int choice;
        do
        {
            Console.Clear();
            Console.WriteLine("Current Board:");
            DisplayBoard();
            Console.WriteLine($"Player {currentPlayer}, choose your position (1-9): ");
            choice = int.Parse(Console.ReadLine());

            if (choice < 1 || choice > 9 || board[choice] != ' ')
            {
                Console.WriteLine("Invalid choice, try again.");
                Console.ReadLine();
                continue;
            }

            board[choice] = currentPlayer;
            if (CheckWin())
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine($"Player {currentPlayer} wins!");
                break;
            }

            if (IsBoardFull())
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine("It's a draw!");
                break;
            }

            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';

        } while (true);
    }

    static void DisplayBoard()
    {
        Console.WriteLine(" {0} | {1} | {2} ", board[1], board[2], board[3]);
        Console.WriteLine("---|---|---");
        Console.WriteLine(" {0} | {1} | {2} ", board[4], board[5], board[6]);
        Console.WriteLine("---|---|---");
        Console.WriteLine(" {0} | {1} | {2} ", board[7], board[8], board[9]);
    }

    static bool CheckWin()
    {
        return (board[1] == currentPlayer && board[2] == currentPlayer && board[3] == currentPlayer) ||
               (board[4] == currentPlayer && board[5] == currentPlayer && board[6] == currentPlayer) ||
               (board[7] == currentPlayer && board[8] == currentPlayer && board[9] == currentPlayer) ||
               (board[1] == currentPlayer && board[4] == currentPlayer && board[7] == currentPlayer) ||
               (board[2] == currentPlayer && board[5] == currentPlayer && board[8] == currentPlayer) ||
               (board[3] == currentPlayer && board[6] == currentPlayer && board[9] == currentPlayer) ||
               (board[1] == currentPlayer && board[5] == currentPlayer && board[9] == currentPlayer) ||
               (board[3] == currentPlayer && board[5] == currentPlayer && board[7] == currentPlayer);
    }

    static bool IsBoardFull()
    {
        for (int i = 1; i < board.Length; i++)
        {
            if (board[i] == ' ')
                return false;
        }
        return true;
    }
}
