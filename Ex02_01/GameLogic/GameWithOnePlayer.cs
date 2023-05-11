﻿using System;

namespace Ex02_01
{
    public class GameWithOnePlayer : Game
    {
        private Player          m_UserPlayer;
        private ComputerPlayer  m_ComputerPlayer;
        private bool            m_IsComputerPlayerTurn;


        public GameWithOnePlayer(Board gameBoard) : base(gameBoard, false, false, false)
        {
            m_UserPlayer = new Player('X', 0);
            m_ComputerPlayer = new ComputerPlayer();
            m_IsComputerPlayerTurn = false;
        }


        public void Run()
        {
            UIDuringTheGame ui = new UIDuringTheGame();
            int row = -1, column = -1;
            char currentPlayerSign;

            while (!m_IsPlayerLosed && !m_IsPlayerWantsToQuit && !m_IsTie)
            {
                Console.Clear();
                ui.PrintBoard(m_Board);

                if (m_IsComputerPlayerTurn)
                {
                    m_ComputerPlayer.StupidMove(ref m_Board, ref row, ref column);
                    currentPlayerSign = m_ComputerPlayer.Sign;
                }
                else
                {
                    m_UserPlayer.Move(ui, ref m_Board, ref m_IsPlayerWantsToQuit, ref row, ref column);
                    currentPlayerSign = m_UserPlayer.Sign;
                }

                if (!m_IsPlayerWantsToQuit)
                {
                    CheckGameStatus(ui, row, column, currentPlayerSign);
                }

                m_IsComputerPlayerTurn = !m_IsComputerPlayerTurn;
            }
        }
    }
}

