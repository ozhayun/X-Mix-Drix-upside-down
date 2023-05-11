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
            int boardSize = board.BoardSize;

            PrintColumnsNumber(boardSize);
            
            for (int i = 0; i < boardSize; i++)
            {
                PrintRowOfBoard(board, i);
                PrintBorderBetweenBoardRows(boardSize);
            }
        }

        private void PrintColumnsNumber(int i_BoardSize)
        {
            for (int column = 0; column < i_BoardSize; column++)
            {
                Console.Write($"  {column + 1} ");
            }

            Console.WriteLine();
        }

        private void PrintRowOfBoard(Board board, int i_Row)
        {
            for (int column = 0; column < board.BoardSize; column++)
            {
                if (column == 0)
                {
                    Console.Write($"{i_Row + 1}|");
                }
                Console.Write($" {board.GetCellValueInBoard(i_Row, column)} |");
            }

            Console.WriteLine();
        }

        private void PrintBorderBetweenBoardRows(int i_BoardSize)
        {
            Console.Write(" ");

            for (int i = 0; i < i_BoardSize; i++)
            {
                Console.Write("====");
            }

            Console.WriteLine("=");
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
