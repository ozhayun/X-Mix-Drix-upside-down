using System;

namespace Ex02_01
{
    internal class UI
    {
        internal void Play()
        {
            Board board = new Board(null, 0);

            printStartMenu();
            setBoardFromUser(ref board);
            Game game = new Game(getTypeOfGameFromUser(), ref board);
            game.Run();
            printEndMenu();
        }

        private void printStartMenu()
        {
            Console.WriteLine("Welcome to X Mix Drix Upside Down game");
        }

        private void setBoardFromUser(ref Board io_Board)
        {
            int boardSize = 0;
            bool isValid = false;

            Console.WriteLine("Please enter a number between 3 and 9 for board size");

            while (!isValid)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out boardSize))
                {
                    if (io_Board.IsValidBoardSize(boardSize))
                    {
                        io_Board.BoardMatrix = new char[boardSize, boardSize];
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 3 and 9.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        private int getTypeOfGameFromUser()
        {
            int gameType = 0;
            bool isValid = false;

            Console.WriteLine("Please enter 0 for playing against computer or 1 for two players");

            while (!isValid)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out gameType))
                {
                    if (gameType == 0 || gameType == 1)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a 0 or 1.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            return gameType;
        }

        private void printEndMenu()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Goodbye!");
            Console.ReadLine();
        }
    }
}
