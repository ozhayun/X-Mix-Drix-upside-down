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

        public void Move(ref Board io_board, out bool o_IsGameFinished)
        {
            int row, column;
            GetNextMove(io_board, out row, out column);
            io_board.ApplyMove(row, column);

            
        }

        public void GetNextMove(Board i_Board, out int i_Row, out int i_Column)
        {
            getRowAngColumnFromUser(i_Board, out i_Row, out i_Column);
            i_Board.isValidMove(i_Row, i_Column);
        }
    }
}
