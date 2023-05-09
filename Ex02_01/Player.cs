using System;

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

        public void Move(UIDuringTheGame ui, ref Board io_Board, ref bool io_IsPlayerWantsToExit)
        {
            int row = -1, column = -1;
            GetRowAnColumnFromUserAndCheckQ(ui, ref row, ref column, ref io_IsPlayerWantsToExit);
            io_Board.AddPlayerSign(row, column, m_Sign);
        }

        public void GetRowAnColumnFromUserAndCheckQ(UIDuringTheGame ui, ref int io_Row, ref int io_Column, ref bool io_IsPlayerWantsToExit)
        {
            ui.GetRowAnColumnFromUserAndCheckQ(ref io_Row, ref io_Column, ref io_IsPlayerWantsToExit);

            while (!io_IsPlayerWantsToExit && !io_Board.CheckIfRowAndColumnFromUserIsValid(io_Row, io_Column))
            {
                ui.GetRowAnColumnFromUserAndCheckQ(ref io_Row, ref io_Column, ref io_IsPlayerWantsToExit);
            }
        }
    }
}

