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
        private bool m_IsPlayerLosed;
        private bool m_IsTie;
        private bool m_IsPlayerWantsToExit;
        private bool m_IsFirstPlayerMove;
        
        public GameWithTwoPlayers(Board gameBoard)
        {
            m_Board = gameBoard;
            m_FirstPlayer = new Player('X', 0);
            m_SecondPlayer = new Player('O', 0);
            m_IsPlayerLosed = false;
            m_IsTie = false;
            m_IsPlayerWantsToExit = false;
            m_IsFirstPlayerMove = true;
        }

        public void Run()
        {
            UIDuringTheGame ui = new UIDuringTheGame();

            while (!m_IsPlayerLosed && !m_IsPlayerWantsToExit && !m_IsTie)
            {
                ui.PrintBoard(m_Board);

                if (m_IsFirstPlayerMove)
                {
                    m_FirstPlayer.Move(ui, ref m_Board, ref m_IsPlayerWantsToExit);
                }
                else
                {
                    m_SecondPlayer.Move(ui, ref m_Board, ref m_IsPlayerWantsToExit);
                }

                CheckGameStatus(GetPlayersSign(), ref m_IsPlayerLosed, ref m_IsTie, ref m_IsPlayerWantsToExit, ui);
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

        public void CheckGameStatus(char i_PlayerSign, ref bool io_IsPlayerLosed, ref bool io_IsTie, ref bool io_IsPlayerWantsToExit, UIDuringTheGame ui)
        {
           if(m_Board.CheckForLosing(ui, GetPlayersSign(), ref io_IsPlayerLosed) || m_Board.CheckForTieAnd(ui) || m_IsPlayerWantsToExit)
            {
                if (ui.IsUserWantNewGame())
                {
                    m_IsPlayerLosed = m_IsTie = m_IsPlayerWantsToExit = false;
                    m_Board.ClearBoard();
                }
            }
        }
    }
}
