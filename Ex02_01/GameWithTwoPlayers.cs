using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_01
{
    public class GameWithTwoPlayers
    {
        private Board m_Board;
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private bool m_IsPlayerWon;
        private bool m_IsTie;
        private bool m_IsPlayerWantsToExit;
        private bool m_IsFirstPlayerMove;
        
        public GameWithTwoPlayers(Board gameBoard)
        {
            m_Board = gameBoard;
            m_FirstPlayer = new Player('X', 0);
            m_SecondPlayer = new Player('O', 0);
            m_IsPlayerWon = false;
            m_IsTie = false;
            m_IsPlayerWantsToExit = false;
            m_IsFirstPlayerMove = true;
        }

        public void Run()
        {
            UIDuringTheGame ui = new UIDuringTheGame();

            while (!m_IsPlayerWon && !m_IsPlayerWantsToExit && !m_IsTie)
            {
                ui.PrintBoard(m_Board);

                if (m_IsFirstPlayerMove)
                {
                    m_FirstPlayer.Move(ui, ref m_Board, ref m_IsPlayerWon, ref m_IsPlayerWantsToExit);
                }
                else
                {
                    m_SecondPlayer.Move(ui, ref m_Board, ref m_IsPlayerWon, ref m_IsPlayerWantsToExit);
                }

                m_Board.CheckGameStatus(GetPlayersSign(), ref m_IsPlayerWon, ref m_IsTie, ref m_IsPlayerWantsToExit, ui);
                m_IsFirstPlayerMove = !m_IsFirstPlayerMove;
            }
        }

        public char GetPlayersSign()
        {
            char resSign;
            if (m_IsFirstPlayerMove)
            {
                resSign = m_FirstPlayer.Sign;
            }
            else
            {
                resSign = m_SecondPlayer.Sign;
            }

            return resSign;
        }

    }
}
