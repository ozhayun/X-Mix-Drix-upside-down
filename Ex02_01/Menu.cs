using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_01
{
    public class Menu
    {

        public void PrintStartMenu()
        {
            Console.WriteLine("Welcome to X & O");
        }

        public int GetBoardSizeFromUser()
        {
            int boardSize = 0; 
            bool isValid = false;
            Console.WriteLine("Please enter a number between 3 and 9 for board size (or 'Q' for exit): ");
            while (!isValid) {
                string input = Console.ReadLine();
                if (int.TryParse(input, out boardSize))
                { 
                    if (boardSize >= 3 && boardSize <= 9) { 
                        isValid = true;
                    }
                    else {
                        Console.WriteLine("Invalid input. Please enter a number between 3 and 9.");
                    }
                }
                else 
                {
                    if(input.Equals('Q'))
                    {
                        boardSize = -1;
                        isValid = true;
                    }
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


       
    }
}
