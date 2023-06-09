﻿using System;

namespace Ex02_01
{
    internal struct Player
    {
        private char m_Sign;
        private int m_Score;

        internal Player(char i_Sign, int i_Score)
        {
            m_Sign = i_Sign;
            m_Score = i_Score;
        }

        internal char Sign
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

        internal int Score
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

        internal void SmarterComputerMove(ref Board io_Board, ref int io_Row, ref int io_Column)
        {
            int i = 0;

            GetBlankRandomRowAndCol(io_Board, out io_Row, out io_Column);

            while(i < 3 && io_Board.IsThisCellCloseSequence(io_Row, io_Column, m_Sign))
            {
                GetBlankRandomRowAndCol(io_Board, out io_Row, out io_Column);
                i++;
            }

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
            o_Row = i_Random.Next(0, i_BoardSize);
            o_Column = i_Random.Next(0, i_BoardSize);
        }

        internal void HumanMove(UIDuringTheGame i_UI, ref Board io_Board, ref bool io_IsPlayerWantsToExit, ref int io_Row, ref int io_Column)
        {
            i_UI.GetRowAndColumnFromUserAndCheckQuiting(io_Board, ref io_Row, ref io_Column, ref io_IsPlayerWantsToExit);

            if (!io_IsPlayerWantsToExit)
            {
                io_Board.AddPlayerSign(io_Row, io_Column, m_Sign);
            }
        }
    }
}