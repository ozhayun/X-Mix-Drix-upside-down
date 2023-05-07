using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_01
{
    public class Board
    {
        private int m_Size;
        private char[,] m_Board;

        public Board(int i_boardSize)
        {
            m_Size = i_boardSize;
            m_Board = new char[m_Size, m_Size];
            ClearBoard();
        }

        public int Size
        {
            get
            {
                return m_Size;
            }
            set
            {
                m_Size = value;
            }
        }

        public char getCellValueInBoard(int i_row, int i_column)
        {
            return m_Board[i_row, i_column];
        }

        public void ClearBoard()
        {
            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    m_Board[i, j] = ' ';
                }
            }
        }

        public void checkIfWin()
        {

        }

        public void checkIfTie()
        {

        }
    }
}
