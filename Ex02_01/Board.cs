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
        private int m_CounterOfFullCells;

        public Board()
        {
            m_Size = 0;
            m_Board = null;
            m_CounterOfFullCells = 0;
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

        public char[,] BoardMatrix
        {
            set
            {
                m_Board = value;
            }
        }
        public bool IsValidBoardSize(int i_BoardSizeToCheck)
        {
            bool isValidBoardSize = false;
            if (i_BoardSizeToCheck >= 3 && i_BoardSizeToCheck <= 9)
            {
                isValidBoardSize = true;
            }

            return isValidBoardSize;
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

        public bool CheckIfWin(int i_Row, int i_Column, char i_Sign)
        {
            bool winning = false;
            if(WinInRow(i_Sign, i_Row) || WinInColumn(i_Sign, i_Column) || WinInDiagonal(i_Sign, i_Row, i_Column))
            {
                winning = true;
            }
            return winning;
        }

        public bool WinInRow(char i_Sign, int i_Row)
        {
            bool winning = true;
            for(int i = 0; i < m_Size; i++)
            {
                if(m_Board[i_Row, i] != i_Sign)
                {
                    winning = false;
                }
            }
            return winning;
        }

        public bool WinInColumn(char i_Sign, int i_Column)
        {
            bool winning = true;
            for (int i = 0; i < m_Size; i++)
            {
                if (m_Board[i, i_Column] != i_Sign)
                {
                    winning = false;
                }
            }
            return winning;
        }

        public bool WinInDiagonal(char i_Sign, int i_Row, int i_Column)
        {
            bool winning = true;
            
            if (i_Row == i_Column)
            {
                winning =  WinInMainDiagonal(i_Sign);
            }

            if(i_Row + i_Column == m_Size + 1)
            {
                winning = WinInSecondaryDiagonal(i_Sign);
            }

            return winning;
        }

        public bool WinInMainDiagonal(char i_Sign)
        {
            bool winning = true;
            for (int i = 0; i < m_Size; i++)
            {
                if (m_Board[i, i] != i_Sign)
                {
                    winning = false;
                }
            }
            return winning;
        }

        public bool WinInSecondaryDiagonal(char i_Sign)
        {
            bool winning = true;
            for (int i = 0; i < m_Size; i++)
            {
                if (m_Board[i, (m_Size + 1 - i)] != i_Sign)
                {
                    winning = false;
                }
            }
            return winning;
        }

        public void checkIfTie()
        {

        }

        

        public void CheckForWinningAndAskForNewGame(UIDuringTheGame i_UI, char i_PlayerSign, ref bool io_IsPlayerWon)
        {
            if (io_IsPlayerWon)
            {
                i_UI.PrintWinnig(i_PlayerSign);

                if (i_UI.AskUserForNewGame())
                {
                    io_IsPlayerWon = false;
                    ClearBoard();
                }
            }
        }

        public void CheckForTieAndAskForNewGame(UIDuringTheGame i_UI, char i_PlayerSign, ref bool io_IsTie)
        {
            if (IsGameEndWithTie(i_PlayerSign))
            {
                i_UI.PrintTie();

                if (i_UI.AskUserForNewGame())
                {
                    io_IsTie = false;
                    ClearBoard();
                }
                else
                {
                    io_IsTie = true;
                }
            }
        }

        public void CheckForExitAndAskForNewGame(UIDuringTheGame i_UI, ref bool io_IsPlayerWantsToExit)
        {
            if (io_IsPlayerWantsToExit && i_UI.AskUserForNewGame())
            {
                io_IsPlayerWantsToExit = false;
                ClearBoard();
            }
        }

        private bool IsGameEndWithTie(char i_PlayerSign)
        {
            


            return;
        }

        private is
    }
}
