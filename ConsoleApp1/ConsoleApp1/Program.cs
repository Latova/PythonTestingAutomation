using System;

namespace TicTacToeGame
{
    public class TicTacToe
    {
        private char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        private char currentPlayer = 'X';

        public char CurrentPlayer => currentPlayer;

        public bool MakeMove(int position)
        {
            if (position < 1 || position > 9 || board[position] != ' ')
            {
                return false;
            }

            board[position] = currentPlayer;
            return true;
        }

        public bool CheckWin()
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

        public bool IsBoardFull()
        {
            for (int i = 1; i < board.Length; i++)
            {
                if (board[i] == ' ')
                    return false;
            }
            return true;
        }

        public void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }

        public char GetBoardValue(int position)
        {
            return board[position];
        }

        public void ResetGame()
        {
            Array.Fill(board, ' ');
            currentPlayer = 'X';
        }

        public void DisplayBoard()
        {
            Console.WriteLine(" {0} | {1} | {2} ", board[1], board[2], board[3]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[4], board[5], board[6]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[7], board[8], board[9]);
        }
    }

    class Program
    {
        static void Main()
        {
            var game = new TicTacToe();
            int choice;

            do
            {
                Console.Clear();
                game.DisplayBoard();
                Console.WriteLine($"Player {game.CurrentPlayer}, choose your position (1-9): ");
                choice = int.Parse(Console.ReadLine());

                if (!game.MakeMove(choice))
                {
                    Console.WriteLine("Invalid choice, try again.");
                    Console.ReadLine();
                    continue;
                }

                if (game.CheckWin())
                {
                    Console.Clear();
                    game.DisplayBoard();
                    Console.WriteLine($"Player {game.CurrentPlayer} wins!");
                    break;
                }

                if (game.IsBoardFull())
                {
                    Console.Clear();
                    game.DisplayBoard();
                    Console.WriteLine("It's a draw!");
                    break;
                }

                game.SwitchPlayer();

            } while (true);
        }
    }
}
