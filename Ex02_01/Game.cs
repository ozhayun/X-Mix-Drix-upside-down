namespace Ex02_01
{
    public class Game
    {
        protected Board     m_Board;
        protected bool      m_IsPlayerLosed;
        protected bool      m_IsTie;
        protected bool      m_IsPlayerWantsToExit;

        public Game(Board i_Board, bool i_IsPlayerLosed, bool i_IsTie, bool i_IsPlayerWantsToExit)
        {
            this.m_Board = i_Board;
            this.m_IsPlayerLosed = i_IsPlayerLosed;
            this.m_IsTie = i_IsTie;
            this.m_IsPlayerWantsToExit = i_IsPlayerWantsToExit;
        }

        
    public void CheckGameStatus(UIDuringTheGame i_UI, int i_Row, int i_Column, char i_CurrentPlayerSign)
        {
            if (IsGameFinishedWithLost(i_UI, i_Row, i_Column, i_CurrentPlayerSign) || IsGameFinishedWithTie(i_UI) || m_IsPlayerWantsToExit)
            {
                if (i_UI.IsUserWantNewGame())
                {
                    m_IsPlayerLosed = m_IsTie = m_IsPlayerWantsToExit = false;
                    m_Board.ClearBoard();
                    i_UI.PrintStartNewGameMessage();
                }
            }
        }


        public bool IsGameFinishedWithLost(UIDuringTheGame i_UI, int i_Row, int i_Column, char i_CurrentPlayerSign)
        {
            bool isLost = false;
            if (m_Board.IsGameFinishedWithLost(i_UI, i_CurrentPlayerSign, i_Row, i_Column))
            {
                i_UI.PrintLosingMessage(i_CurrentPlayerSign);
                ; m_IsPlayerLosed = true;
                isLost = true;
            }
            return isLost;
        }


        public bool IsGameFinishedWithTie(UIDuringTheGame i_UI)
        {
            bool isTie = false;
            if (m_Board.IsGameFinishedWithTie(i_UI))
            {
                i_UI.PrintTieMessage();
                m_IsTie = true;
                isTie = true;
            }
            return isTie;
        }
    }
}
