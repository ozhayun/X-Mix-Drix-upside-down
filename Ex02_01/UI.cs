using System;

namespace Ex02_01
{
    class UI
    {
        private enum eGameType
        {
           OnePlayer,
           TwoPlayers
        }

        public void Play()
        {
            Board board = new Board();

            PrintStartMenu();
            GetBoardSizeFromUser(board);
            int typeOfGame = GetTypeOfGameFromUser();

            if (typeOfGame == (int)eGameType.OnePlayer)
            {
                GameWithOnePlayer onePlayer = new GameWithOnePlayer(board);
                onePlayer.Run();
            }
            else if (typeOfGame == (int)eGameType.TwoPlayers)
            {
                GameWithTwoPlayers twoPlayers = new GameWithTwoPlayers(board);
                twoPlayers.Run();
            }
            else
            {
                PrintEndMenu();
            }
        }

        public void PrintStartMenu()
        {
            Console.WriteLine("Welcome to X & O");
        }

        public int GetBoardSizeFromUser(Board i_Board)
        {
            int boardSize = 0;
            bool isValid = false;
            Console.WriteLine("Please enter a number between 3 and 9 for board size (or 'Q' for exit): ");
            while (!isValid)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out boardSize))
                {
                    if (i_Board.IsValidBoardSize(boardSize))
                    {
                        i_Board.BoardMatrix = new char[boardSize, boardSize];
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
            return boardSize;
        }

        public int GetTypeOfGameFromUser()
        {
            int gameType = 0;
            bool isValid = false;
            Console.WriteLine("Please enter 0 for playing against comuter or 1 for two players: ");
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
                    if (input.Equals('Q'))
                    {
                        gameType = -1;
                        isValid = true;
                    }
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            return gameType;
        }

        public void PrintEndMenu()
        {
        }
    }
}
