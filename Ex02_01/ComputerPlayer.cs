
using System;
namespace Ex02_01
{
	public class ComputerPlayer
	{
		private char m_Sign;
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

        public ComputerPlayer()
        {
			m_Sign = 'O';
		}

        public void StupidMove(ref Board io_Board, ref int i_Row, ref int i_Coulmn)
        {
            GetBlankRandomRowAndCol(io_Board, out i_Row, out i_Coulmn);
            io_Board.AddPlayerSign(i_Row, i_Coulmn, m_Sign);
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

