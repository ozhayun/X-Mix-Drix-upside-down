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
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    Console.WriteLine(board.getCellValueInBoard(i, j));
                }
            }
        }

        public void GetRowAnColumnFromUserAndCheckQ(ref int io_Row, ref int io_Column, ref bool io_IsPlayerWantsToExit)
        {
            Console.WriteLine("Please enter your next move: ");
            io_Row = GetNumberFromUser(ref io_IsPlayerWantsToExit);
            if (!io_IsPlayerWantsToExit)
            {
                io_Column = GetNumberFromUser(ref io_IsPlayerWantsToExit);
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
    }
}
