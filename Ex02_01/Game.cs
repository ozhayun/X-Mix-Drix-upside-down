using System;


namespace Ex02_01
{
    public class Game
    {
        protected Board m_Board;
        protected bool m_IsPlayerLosed;
        protected bool m_IsTie;
        protected bool m_IsPlayerWantsToExit;

        public Game(Board i_Board, bool i_IsPlayerLosed, bool i_IsTie, bool i_IsPlayerWantsToExit)
        {
            this.m_Board = i_Board;
            this.m_IsPlayerLosed = i_IsPlayerLosed;
            this.m_IsTie = i_IsTie;
            this.m_IsPlayerWantsToExit = i_IsPlayerWantsToExit;
        }


        

    public void CheckGameStatus(UIDuringTheGame ui, int i_Row, int i_Column, char i_CurrentPlayerSign)
        {
            if (IsGameFinishedWithLost(ui, i_Row, i_Column, i_CurrentPlayerSign) || IsGameFinishedWithTie(ui) || m_IsPlayerWantsToExit)
            {
                if (ui.IsUserWantNewGame())
                {
                    m_IsPlayerLosed = m_IsTie = m_IsPlayerWantsToExit = false;
                    m_Board.ClearBoard();
                    ui.PrintStartNewGameMessage();
                }
            }
        }

        public bool IsGameFinishedWithLost(UIDuringTheGame ui, int i_Row, int i_Column, char i_CurrentPlayerSign)
        {
            bool lost = false;
            if (m_Board.IsGameFinishedWithLost(ui, i_CurrentPlayerSign, i_Row, i_Column))
            {
                ui.PrintLosingMessage(i_CurrentPlayerSign);
                ; m_IsPlayerLosed = true;
                lost = true;
            }
            return lost;
        }
        public bool IsGameFinishedWithTie(UIDuringTheGame ui)
        {
            bool tie = false;
            if (m_Board.IsGameFinishedWithTie(ui))
            {
                ui.PrintTieMessage();
                m_IsTie = true;
                tie = true;
            }
            return tie;
        }
    }
}
