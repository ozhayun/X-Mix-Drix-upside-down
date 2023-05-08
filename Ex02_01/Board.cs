using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_01
{
    public class Board
    {
        const char k_BlankChar = ' ';

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

        public char getCellValueInBoard(int i_Row, int i_Column)
        {
            return m_Board[i_Row, i_Column];
        }

        public bool isThisCellClear(int i_Row, int i_Column)
        {
            return getCellValueInBoard(i_Row, i_Column) == k_BlankChar;
        }

        public void AddPlayerSign(int i_Row, int i_Column, char i_UserSign)
        {
            m_Board[i_Row, i_Column] = i_UserSign;
        }

        public void ClearBoard()
        {
            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    m_Board[i, j] = k_BlankChar;
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
