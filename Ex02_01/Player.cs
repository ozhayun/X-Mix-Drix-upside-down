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

        public Player(char i_Sign, int i_Score)
        {
            m_Sign = i_Sign;
            m_Score = i_Score;
        }

        public char Sign
        {
            get
            {
                return m_Sign;
            }
            set
            {
                m_Sign = value;
            }
        }

        public void Move(ref Board io_Board, ref bool m_IsPlayerWon, ref bool io_IsPlayerWantsToExit)
        {
            int row = -1, column = -1;

            GetRowAndColumnFromUser(io_Board.Size, ref row, ref column, ref io_IsPlayerWantsToExit);

            while(!io_IsPlayerWantsToExit && !io_Board.isThisCellClear(row, column))
            {
                GetRowAndColumnFromUser(io_Board.Size, ref row, ref column, ref io_IsPlayerWantsToExit);
            }

            io_Board.AddPlayerSign(row, column, m_Sign);

            if(io_Board.CheckIfWin(row, column, m_Sign))
            {
                m_IsPlayerWon = true;
                m_Score++;
            }

        }

        public void GetRowAndColumnFromUser(int i_BoardSize, ref int io_Row, ref int io_Column, ref bool io_IsPlayerWantsToExit)
        {
            Console.WriteLine("Please enter your next move: ");
            io_Row = GetNumberThatFitBoardSize(i_BoardSize, ref io_IsPlayerWantsToExit);
            if (!io_IsPlayerWantsToExit)
            {
                io_Column = GetNumberThatFitBoardSize(i_BoardSize, ref io_IsPlayerWantsToExit);
            }
        }

        public int GetNumberThatFitBoardSize(int i_BoardSize, ref bool io_IsPlayerWantsToExit)
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
