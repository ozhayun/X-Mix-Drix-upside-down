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
            SetBoardFromUser(ref board);
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
            Console.WriteLine("Welcome to X Mix Drix Upside Down ame");
        }


        public void SetBoardFromUser(ref Board io_Board)
        {
            int     boardSize = 0;
            bool    isValid = false;

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


        public int GetTypeOfGameFromUser()
        {
            int     gameType = 0;
            bool    isValid = false;

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


        public void PrintEndMenu()
        {

        }
    }
}
