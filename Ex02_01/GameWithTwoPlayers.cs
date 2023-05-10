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
            int row = -1, column = -1;

            while (!m_IsPlayerLosed && !m_IsPlayerWantsToExit && !m_IsTie)
            {
                ui.PrintBoard(m_Board);

                if (m_IsFirstPlayerMove)
                {
                    m_FirstPlayer.Move(ui, ref m_Board, ref m_IsPlayerWantsToExit, ref row, ref column);
                }
                else
                {
                    m_SecondPlayer.Move(ui, ref m_Board, ref m_IsPlayerWantsToExit, ref row, ref column);
                }

                CheckGameStatus(ui, row, column);
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

        public void CheckGameStatus(UIDuringTheGame ui, int i_Row, int i_Column)
        {
           if(IsGameFinishedWithLost(ui, i_Row, i_Column) || IsGameFinishedWithTie(ui) || m_IsPlayerWantsToExit)
            {
                if (ui.IsUserWantNewGame())
                {
                    m_IsPlayerLosed = m_IsTie = m_IsPlayerWantsToExit = false;
                    m_Board.ClearBoard();
                }
            }
        }

        public bool IsGameFinishedWithLost(UIDuringTheGame ui, int i_Row, int i_Column)
        {
            bool lost = false;
            if (m_Board.IsGameFinishedWithLost(ui, GetPlayersSign(), i_Row, i_Column))
            {
                m_IsPlayerLosed = true;
                lost = true;
            }
            return lost;
        }
        public bool IsGameFinishedWithTie(UIDuringTheGame ui)
        {
            bool tie = false;
            if (m_Board.IsGameFinishedWithTie(ui))
            {
                m_IsTie = true;
                tie = true;
            }
            return tie;
        }
    }
}
