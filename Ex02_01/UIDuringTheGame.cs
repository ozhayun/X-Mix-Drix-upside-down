using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_01
{
    public class UIDuringTheGame
    {
        public void PrintBoard(Board board)
        {
            for (int i = 0; i < board.BoardSize; i++)
            { 
                Console.Write($"  {i + 1} ");
            }
            Console.WriteLine();
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    if (j == 0)
                    {
                        Console.Write($"{i + 1}|");
                    }
                    Console.Write($" {board.GetCellValueInBoard(i, j)} |");
                }
                Console.WriteLine();
                Console.Write(" ");
                for (int j = 0; j < board.BoardSize; j++)
                {
                    Console.Write("====");
                }
                Console.WriteLine("=");
            }
        }
        public void GetRowAndColumnFromUserAndCheckQuiting(Board i_Board, ref int io_Row, ref int io_Column, ref bool io_IsPlayerWantsToExit)
        {
            GetValidRowAndColumnFromUserAndCheckQuiting(ref io_Row, ref io_Column, ref io_IsPlayerWantsToExit);

            while (!io_IsPlayerWantsToExit && !i_Board.IsRowAndColumnFromUserIsValid(io_Row, io_Column))
            {
                Console.WriteLine("Invalid input");
                GetValidRowAndColumnFromUserAndCheckQuiting(ref io_Row, ref io_Column, ref io_IsPlayerWantsToExit);
            }
        }

        public void GetValidRowAndColumnFromUserAndCheckQuiting(ref int io_Row, ref int io_Column, ref bool io_IsPlayerWantsToExit)
        {
            Console.WriteLine("Please enter your next move: ");
            io_Row = GetNumberFromUser(ref io_IsPlayerWantsToExit) - 1;
            if (!io_IsPlayerWantsToExit)
            {
                io_Column = GetNumberFromUser(ref io_IsPlayerWantsToExit) - 1;
            }
        }

        public int GetNumberFromUser(ref bool io_IsPlayerWantsToExit)
        {
            int numberFromUser = -1;
            bool isValid = false;

            while (!isValid)
            {
                string input = Console.ReadLine();
                if (input.Equals('Q'))
                {
                    io_IsPlayerWantsToExit = true;
                    isValid = true;
                }

                else if (int.TryParse(input, out numberFromUser))
                {
                    isValid = true;
                }
            }
            return numberFromUser;
        }

        public void PrintLosingMessage(char i_LossingPlayerSign)
        {
            Console.WriteLine($"Player {i_LossingPlayerSign} lost!!!");
        }

        public bool IsUserWantNewGame()
        {
            bool userWantsNewGame = false;
            Console.WriteLine("Please enter y for new game");
            String inputFromUser = Console.ReadLine();
            if (inputFromUser == "Y")
            {
                userWantsNewGame = true;
            }

            return userWantsNewGame;
        }

        public void PrintStartNewGameMessage()
        {
            Console.WriteLine("Starting a new game");
        }

        public void PrintTieMessage()
        {
            Console.WriteLine("There is a TIE!!!");
        }

    }
}
