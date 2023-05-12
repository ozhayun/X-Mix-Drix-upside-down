
using System;
namespace Ex02_01
{
	public class ComputerPlayer
	{
		private char    m_Sign;

        public char     Sign
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

        public ComputerPlayer()
        {
			m_Sign = 'O';
		}

        public void AIMove(ref Board io_Board, ref int io_Row, ref int io_Coulmn)
        {
            if(io_Board.IsFoundEmptyCellThatNotClosedSequence(io_Row, io_Coulmn, Sign))
            {
                io_Board.SetRowAndColumnToBeTheFirstClearCell(io_Row, io_Coulmn);
            }
        }
    }
}

