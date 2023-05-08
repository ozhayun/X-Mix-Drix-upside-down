using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_01
{
    public class Player
    {
        private char m_Sign;
        private int m_Score;

        public void Move(ref Board io_board, ref bool o_IsGameFinished)
        {
            int row = -1, column = -1;

            GetRowAndColumnFromUser(io_board.Size, ref row, ref column, ref o_IsGameFinished);

            while(!o_IsGameFinished && !io_board.isThisCellClear(row, column))
            {
                GetRowAndColumnFromUser(io_board.Size, ref row, ref column, ref o_IsGameFinished);
            }

            io_board.AddPlayerSign(row, column, m_Sign);
            
        }

        public void GetRowAndColumnFromUser(int i_BoardSize, ref int io_Row, ref int io_Column, ref bool io_IsGameFinished)
        {
            Console.WriteLine("Please enter your next move: ");
            io_Row = GetNumberThatFitBoardSize(i_BoardSize, ref io_IsGameFinished);
            if (!io_IsGameFinished)
            {
                io_Column = GetNumberThatFitBoardSize(i_BoardSize, ref io_IsGameFinished);
            }
        }

        public int GetNumberThatFitBoardSize(int i_BoardSize, ref bool io_IsGameFinished)
        {
            int numberFromUser = -1;
            bool isValid = false;

            while (!isValid)
            {
                string input = Console.ReadLine();
                if (input.Equals('Q'))
                {
                    io_IsGameFinished = true;
                    isValid = true;
                }

                else if (int.TryParse(input, out numberFromUser))
                {
                    if (numberFromUser > 0 && numberFromUser <= i_BoardSize)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
            }
            return numberFromUser;
        }

    }
}
}
