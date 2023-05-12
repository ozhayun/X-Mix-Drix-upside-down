
using System;
namespace Ex02_01
{
	public class ComputerPlayer
	{
		private char    m_Sign;
        private int     m_Score;

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

        public int Score
        {
            get
            {
                return m_Score;
            }
            set
            {
                m_Score = value;
            }
        }

        public ComputerPlayer()
        {
			m_Sign = 'O';
            m_Score = 0;
		}

        public void AIMove(ref Board io_Board, ref int io_Row, ref int io_Coulmn)
        {
            if(!io_Board.IsFoundEmptyCellThatNotClosedSequence(ref io_Row, ref io_Coulmn, Sign))
            {
                io_Board.SetRowAndColumnToBeTheFirstClearCell(ref io_Row, ref io_Coulmn, Sign);
            }

        }
    }
}

