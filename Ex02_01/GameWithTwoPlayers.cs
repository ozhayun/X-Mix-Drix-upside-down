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
        private bool m_IsGameFinished;
        private bool m_IsFirstPlayerMove;

        public GameWithTwoPlayers(Board gameBoard)
        {
            m_Board = gameBoard;
            m_FirstPlayer = new Player();
            m_SecondPlayer = new Player();
            m_IsGameFinished = false;
            m_IsFirstPlayerMove = true;
        }

        public void Run()
        {
            GamePrints gamePrints = new GamePrints();

            while (!m_IsGameFinished)
            {
                gamePrints.PrintBoard(m_Board);

                if (m_IsFirstPlayerMove)
                {
                    m_FirstPlayer.Move(ref m_Board, out m_IsGameFinished);
                }
                else
                {
                    m_SecondPlayer.Move(ref m_Board, out m_IsGameFinished);
                }
                m_Board.checkIfWin();
                m_Board.checkIfTie();
                m_IsFirstPlayerMove = !m_IsFirstPlayerMove;
            }
        }
    }
}
