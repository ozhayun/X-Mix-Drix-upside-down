using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_01
{
    class GameWithOnePlayer
    {
        Board m_Board;
        Player m_UserPlayer;
        ComputerPlayer m_ComputerPlayer;
        private bool m_IsGameFinished;
        private bool m_IsUserTurn;

        public GameWithOnePlayer(Board gameBoard)
        {
            m_Board = gameBoard;
            m_UserPlayer = new Player();
            m_ComputerPlayer = new ComputerPlayer();
            m_IsGameFinished = false;
            m_IsUserTurn = true;
        }

        public void Run()
        {
            GamePrints gamePrints = new GamePrints();

            while (!m_IsGameFinished)
            {
                gamePrints.PrintBoard(m_Board);

                if (m_IsUserTurn)
                {
                    m_UserPlayer.Move(ref m_Board, ref m_IsGameFinished);
                }
                else
                {
                    m_ComputerPlayer.StupidMove(ref m_Board, ref m_IsGameFinished);
                }

                m_Board.checkIfWin();
                m_Board.checkIfTie();
                m_IsUserTurn = !m_IsUserTurn;
            }
        }

        

    }
}
