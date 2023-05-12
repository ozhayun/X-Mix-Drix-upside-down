using System;

namespace Ex02_01
{
    public class GameWithTwoPlayers : Game
    {
        private Player      m_FirstPlayer;
        private Player      m_SecondPlayer;
        private bool        m_IsFirstPlayerMove;
        
        public GameWithTwoPlayers(Board gameBoard) : base(gameBoard, false, false, false)
        {
            m_FirstPlayer = new Player('X', 0);
            m_SecondPlayer = new Player('O', 0);
            m_IsFirstPlayerMove = true;
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
                    m_FirstPlayer.Move(ui, ref m_Board, ref m_IsPlayerWantsToQuit, ref row, ref column);
                    CheckGameStatus(ui, row, column, m_FirstPlayer.Sign, m_FirstPlayer.Score, m_SecondPlayer.Sign, m_SecondPlayer.Score);
                }
                else
                {
                    m_SecondPlayer.Move(ui, ref m_Board, ref m_IsPlayerWantsToQuit, ref row, ref column);
                    CheckGameStatus(ui, row, column, m_SecondPlayer.Sign, m_SecondPlayer.Score, m_FirstPlayer.Sign, m_FirstPlayer.Score);
                }

                m_IsFirstPlayerMove = !m_IsFirstPlayerMove;
            }
        }
    }
}
