namespace Ex02_01
{
    public class Game
    {
        private enum eGameType
        {
            AgainstTheCumputer,
            TwoHumanPlayers
        }

        private enum ePlayersSigns
        {
            X = 'X',
            O = 'O'
        }

        private int m_TypeOfGame;
        private bool m_IsPlayerLosed;
        private bool m_IsTie;
        private bool m_IsPlayerWantsToQuit;
        private bool m_IsFirstPlayerMove;
        private Board m_Board = null;
        private Player m_FirstPlayer = null;
        private Player m_SecondPlayer = null;
        private UIDuringTheGame m_UIDuringTheGame = null;

        public Game(int i_TypeOfGame, ref Board io_Board)
        {
            this.m_TypeOfGame = i_TypeOfGame;
            this.m_IsPlayerLosed = false;
            this.m_IsTie = false;
            this.m_IsPlayerWantsToQuit = false;
            this.m_IsFirstPlayerMove = true;
            this.m_Board = io_Board;
            this.m_FirstPlayer = new Player((char)ePlayersSigns.X, 0);
            this.m_SecondPlayer = new Player((char)ePlayersSigns.O, 0);
            this.m_UIDuringTheGame = new UIDuringTheGame();
        }

        public void Run()
        {
            int row = -1, column = -1;

            Ex02.ConsoleUtils.Screen.Clear();
            m_UIDuringTheGame.PrintBoard(m_Board);

            while (!m_IsPlayerLosed && !m_IsPlayerWantsToQuit && !m_IsTie)
            {
                if (m_IsFirstPlayerMove)
                {
                    m_FirstPlayer.HumanMove(m_UIDuringTheGame, ref m_Board, ref m_IsPlayerWantsToQuit, ref row, ref column);
                }
                else
                {
                    if (m_TypeOfGame == (int)eGameType.AgainstTheCumputer)
                    {
                        m_SecondPlayer.ComputerMove(ref m_Board, ref row, ref column);
                    }
                    else if (m_TypeOfGame == (int)eGameType.TwoHumanPlayers)
                    {
                        m_SecondPlayer.HumanMove(m_UIDuringTheGame, ref m_Board, ref m_IsPlayerWantsToQuit, ref row, ref column);
                    }
                }

                checkGameStatus(row, column);
                m_IsFirstPlayerMove = !m_IsFirstPlayerMove;
            }
        }

        private void checkGameStatus(int i_Row, int i_Column)
        {
            m_UIDuringTheGame.PrintBoard(m_Board);

            if (m_IsPlayerWantsToQuit || isGameFinishedWithLost(i_Row, i_Column) || isGameFinishedWithTie())
            {
                m_UIDuringTheGame.PrintScores(m_FirstPlayer, m_SecondPlayer);

                if (m_UIDuringTheGame.IsUserWantNewGame())
                {
                    m_IsPlayerLosed = m_IsTie = m_IsPlayerWantsToQuit = false;
                    m_Board.ClearBoard();
                    m_UIDuringTheGame.PrintStartNewGameMessage();
                }
            }
        }

        private bool isGameFinishedWithLost(int i_Row, int i_Column)
        {
            bool isLost = false;
            if (m_Board.IsGameFinishedWithLost(getCurrentPlayerSign(), i_Row, i_Column))
            {
                addPlayerScore();
                m_UIDuringTheGame.PrintLosingMessage(getCurrentPlayerSign());
                m_IsPlayerLosed = true;
                isLost = true;
            }

            return isLost;
        }

        private void addPlayerScore()
        {
            if (m_IsFirstPlayerMove)
            {
                m_SecondPlayer.Score++;
            }
            else
            {
                m_FirstPlayer.Score++;
            }
        }

        private char getCurrentPlayerSign()
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

        private bool isGameFinishedWithTie()
        {
            bool isTie = false;
            if (m_Board.IsGameFinishedWithTie())
            {
                m_UIDuringTheGame.PrintTieMessage();
                m_IsTie = true;
                isTie = true;
            }

            return isTie;
        }
    }
}
