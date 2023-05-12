using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_01
{
    public class Board
    {
        const char          k_BlankChar = ' ';

        private char[,]     m_Board;
        private int         m_CounterOfFullCells;

        public Board()
        {
            m_Board = null;
            m_CounterOfFullCells = 0;
        }

        public int BoardSize
        {
            get
            {
                return m_Board.GetLength(0);
            }
        }

        public char[,] BoardMatrix
        {
            set
            {
                m_Board = value;
                ClearBoard();
            }
        }

        public bool IsFoundEmptyCellThatNotClosedSequence(ref int io_Row, ref int io_Coulmn, char i_PlayerSign)
        {
            bool foundClearCellThatNotClosedSequence = false;
            for (int i = 0; i < BoardSize && !foundClearCellThatNotClosedSequence; i++)
            {
                for (int j = 0; j < BoardSize && !foundClearCellThatNotClosedSequence; j++)
                {
                    if (IsThisCellClear(i, j) && !IsThisCellCloseSequence(i, j, i_PlayerSign))
                    {
                        io_Row = i;
                        io_Coulmn = j;
                        foundClearCellThatNotClosedSequence = true;
                    }
                }
            }
            return foundClearCellThatNotClosedSequence;
        }

        private bool IsThisCellCloseSequence(int i_Row, int i_Column, char i_UserSign)
        {
            bool isThisCellCloseSequence = false;
            AddPlayerSign(i_Row, i_Column, i_UserSign);

            if (IsGameFinishedWithLost(i_UserSign, i_Row, i_Column))
            {
                RemovePlayerSign(i_Row, i_Column);
                isThisCellCloseSequence = true;
            }
            return isThisCellCloseSequence;
        }

        public void SetRowAndColumnToBeTheFirstClearCell(ref int io_Row, ref int io_Coulmn, char i_UserSign)
        {
            bool foundClearCell = false;

            for (int i = 0; i < BoardSize && !foundClearCell; i++)
            {
                for (int j = 0; j < BoardSize && !foundClearCell; j++)
                {
                    if (IsThisCellClear(i, j))
                    {
                        io_Row = i;
                        io_Coulmn = j;
                        AddPlayerSign(io_Row, io_Coulmn, i_UserSign);
                        foundClearCell = true;
                    }
                }
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

        public bool IsRowAndColumnFromUserIsValid(int i_Row, int i_Column)
        {
            return IsRowAndColumnInRange(i_Row,i_Column) && IsThisCellClear(i_Row, i_Column);
        }


        public bool IsRowAndColumnInRange(int i_Row, int i_Column)
        {
            return 0 <= i_Row && i_Row < BoardSize && 0 <= i_Column && i_Column < BoardSize;
        }

        public bool IsThisCellClear(int i_Row, int i_Column)
        {
            return GetCellValueInBoard(i_Row, i_Column) == k_BlankChar;
        }

        public bool IsGameFinishedWithLost(char i_PlayersSign, int i_Row, int i_Column)
        {
            bool isLose = false;
            if (IsThereRowSequence(i_PlayersSign, i_Row) ||
                IsThereColumnSequence(i_PlayersSign, i_Column) ||
                IsThereDiagonalSequence(i_PlayersSign, i_Row, i_Column))
            {
                isLose = true;
            }
            return isLose;
        }

        private bool IsThereRowSequence(char i_PlayersSign, int i_Row) 
        {
            bool isWinning = true;
            for (int i = 0; i < BoardSize; i++)
            {
                if (m_Board[i_Row, i] != i_PlayersSign)
                {
                    isWinning = false;
                }
            }
            return isWinning;
        }

        private bool IsThereColumnSequence(char i_PlayersSign, int i_Column) 
        {
            bool isWinning = true;
            for (int i = 0; i < BoardSize; i++)
            {
                if (m_Board[i, i_Column] != i_PlayersSign)
                {
                    isWinning = false;
                }
            }
            return isWinning;
        }

        private bool IsThereDiagonalSequence(char i_PlayersSign, int i_Row, int i_Column) 
        {
            bool isWinning = false;

            if (i_Row == i_Column)
            {
                isWinning = WinInMainDiagonal(i_PlayersSign);
            }

            if (!isWinning && i_Row + i_Column == BoardSize + 1)
            {
                isWinning = IsThereWinInSecondaryDiagonal(i_PlayersSign);
            }

            return isWinning;
        }

        public bool WinInMainDiagonal(char i_PlayersSign) 
        {
            bool isWinning = true;
            for (int i = 0; i < BoardSize; i++)
            {
                if (m_Board[i, i] != i_PlayersSign)
                {
                    isWinning = false;
                }
            }
            return isWinning;
        }

        public bool IsThereWinInSecondaryDiagonal(char i_PlayersSign) 
        {
            bool isWinning = true;
            for (int i = 0; i < BoardSize; i++)
            {
                if (m_Board[i, (BoardSize - 1 - i)] != i_PlayersSign)
                {
                    isWinning = false;
                }
            }
            return isWinning;
        }

        public bool IsGameFinishedWithTie(UIDuringTheGame ui)
        {
            return m_CounterOfFullCells == BoardSize * BoardSize;
        }

        public char GetCellValueInBoard(int i_Row, int i_Column)
        {
            return m_Board[i_Row, i_Column];
        }

        public void AddPlayerSign(int i_Row, int i_Column, char i_UserSign)
        {
            m_Board[i_Row, i_Column] = i_UserSign;
            m_CounterOfFullCells++;
        }
        private void RemovePlayerSign(int i_Row, int i_Column)
        {
            m_Board[i_Row, i_Column] = k_BlankChar;
            m_CounterOfFullCells--;
        }

        public void ClearBoard()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    m_Board[i, j] = k_BlankChar;
                }
            }
            m_CounterOfFullCells = 0;
        }
    }
}
