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
            char currentPlayerSign;

            Console.Clear();
            ui.PrintBoard(m_Board);

            while (!m_IsPlayerLosed && !m_IsPlayerWantsToQuit && !m_IsTie)
            {
                if (m_IsFirstPlayerMove)
                {
                    m_FirstPlayer.Move(ui, ref m_Board, ref m_IsPlayerWantsToQuit, ref row, ref column);
                    currentPlayerSign = m_FirstPlayer.Sign;
                }
                else
                {
                    m_SecondPlayer.Move(ui, ref m_Board, ref m_IsPlayerWantsToQuit, ref row, ref column);
                    currentPlayerSign = m_SecondPlayer.Sign;
                }

                if(!m_IsPlayerWantsToQuit)
                {
                    Console.Clear();
                    ui.PrintBoard(m_Board);
                    CheckGameStatus(ui, row, column, currentPlayerSign);
                }

                m_IsFirstPlayerMove = !m_IsFirstPlayerMove;
            }
        }
    }
}
