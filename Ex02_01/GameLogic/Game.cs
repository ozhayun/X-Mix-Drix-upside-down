using System;

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
        private Board m_Board;
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private bool m_IsPlayerLosed;
        private bool m_IsTie;
        private bool m_IsPlayerWantsToQuit;
        private bool m_IsFirstPlayerMove = false;

        public Game(int i_TypeOfGame, ref Board io_Board)
        {
            this.m_TypeOfGame = i_TypeOfGame;
            this.m_Board = io_Board;
            this.m_FirstPlayer = new Player((char)ePlayersSigns.X, 0);
            this.m_SecondPlayer = new Player((char)ePlayersSigns.O, 0);
            this.m_IsPlayerLosed = false;
            this.m_IsTie = false;
            this.m_IsPlayerWantsToQuit = false;
            this.m_IsFirstPlayerMove = true;
        }

        public void Run()
        {
            UIDuringTheGame ui = new UIDuringTheGame();
            int row = -1, column = -1;

            Console.Clear();
            ui.PrintBoard(m_Board);

            while (!m_IsPlayerLosed && !m_IsPlayerWantsToQuit && !m_IsTie)
            {
                if (m_IsFirstPlayerMove)
                {
                    m_FirstPlayer.HumanMove(ui, ref m_Board, ref m_IsPlayerWantsToQuit, ref row, ref column);
                }
                else
                {
                    if (m_TypeOfGame == (int)eGameType.AgainstTheCumputer)
                    {
                        m_SecondPlayer.ComputerMove(ref m_Board, ref row, ref column);
                    }
                    else if (m_TypeOfGame == (int)eGameType.TwoHumanPlayers)
                    {
                        m_SecondPlayer.HumanMove(ui, ref m_Board, ref m_IsPlayerWantsToQuit, ref row, ref column);
                    }
                }

                checkGameStatus(ui, row, column);
                m_IsFirstPlayerMove = !m_IsFirstPlayerMove;
            }
        }

        private void checkGameStatus(UIDuringTheGame i_UI, int i_Row, int i_Column)
        {
            i_UI.PrintBoard(m_Board);

            if (m_IsPlayerWantsToQuit || isGameFinishedWithLost(i_UI, i_Row, i_Column) || isGameFinishedWithTie(i_UI))
            {
                i_UI.PrintScores(m_FirstPlayer, m_SecondPlayer);

                if (i_UI.IsUserWantNewGame())
                {
                    m_IsPlayerLosed = m_IsTie = m_IsPlayerWantsToQuit = false;
                    m_Board.ClearBoard();
                    i_UI.PrintStartNewGameMessage();
                }
            }
        }


        private bool isGameFinishedWithLost(UIDuringTheGame i_UI, int i_Row, int i_Column)
        {
            bool isLost = false;
            if (m_Board.IsGameFinishedWithLost(getCurrentPlayerSign(), i_Row, i_Column))
            {
                addPlayerScore();
                i_UI.PrintLosingMessage(getCurrentPlayerSign());
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

        private bool isGameFinishedWithTie(UIDuringTheGame i_UI)
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
