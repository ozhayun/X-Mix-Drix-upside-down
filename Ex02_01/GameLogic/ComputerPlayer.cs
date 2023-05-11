
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

        public void StupidMove(ref Board io_Board, ref int io_Row, ref int io_Column)
        {
            GetBlankRandomRowAndCol(io_Board, out io_Row, out io_Column);
            io_Board.AddPlayerSign(io_Row, io_Column, m_Sign);
        }

        private void GetBlankRandomRowAndCol(Board i_Board, out int o_Row, out int o_Column)
        {
            Random random = new Random();
            GetRowAndCol(random, i_Board.BoardSize, out o_Row, out o_Column);
            while (!i_Board.IsThisCellClear(o_Row, o_Column))
            {
                GetRowAndCol(random, i_Board.BoardSize, out o_Row, out o_Column);
            }
        }

        private void GetRowAndCol(Random i_Random, int i_BoardSize, out int o_Row, out int o_Column)
        {
            o_Row = i_Random.Next(1, i_BoardSize);
            o_Column = i_Random.Next(1, i_BoardSize);
        }
    }
}

