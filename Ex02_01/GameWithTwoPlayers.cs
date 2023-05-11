using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            while (!m_IsPlayerLosed && !m_IsPlayerWantsToExit && !m_IsTie)
            {
                ui.PrintBoard(m_Board);

                if (m_IsFirstPlayerMove)
                {
                    m_FirstPlayer.Move(ui, ref m_Board, ref m_IsPlayerWantsToExit, ref row, ref column);
                    currentPlayerSign = m_FirstPlayer.Sign;
                }
                else
                {
                    m_SecondPlayer.Move(ui, ref m_Board, ref m_IsPlayerWantsToExit, ref row, ref column);
                    currentPlayerSign = m_SecondPlayer.Sign;
                }

                CheckGameStatus(ui, row, column, currentPlayerSign);
                m_IsFirstPlayerMove = !m_IsFirstPlayerMove;
            }
        }
    }
}
