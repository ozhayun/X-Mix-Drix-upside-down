
using System;
namespace Ex02_01
{
	public class ComputerPlayer
	{
		char m_Sign;

		public ComputerPlayer()
		{
			m_Sign = 'O';
		}

		public void StupidMove(ref Board io_Board, ref bool io_IsGameFinished)
		{
			int row, column;
			GetBlankRandomRowAndCol(io_Board, out row, out column);			
			io_Board.AddPlayerSign(row, column, m_Sign);

            // Check Win
        }

        private void GetBlankRandomRowAndCol(Board i_Board, out int o_Row, out int o_Column)
		{
			Random random = new Random();
			GetRowAndCol(random, i_Board.Size, out o_Row, out o_Column);
			while(!i_Board.isThisCellClear(o_Row, o_Column))
			{
                GetRowAndCol(random, i_Board.Size, out o_Row, out o_Column);
            }

        }

		private void GetRowAndCol(Random i_Random, int i_BoardSize, out int o_Row, out int o_Column)
		{
            o_Row = i_Random.Next(1, i_BoardSize);
            o_Column = i_Random.Next(1, i_BoardSize);
        }

	}
}

