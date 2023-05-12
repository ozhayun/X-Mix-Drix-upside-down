using System;

namespace Ex02_01
{
    public class GameWithOnePlayer : Game
    {
        private Player          m_UserPlayer;
        private ComputerPlayer  m_ComputerPlayer;
        private bool            m_IsComputerPlayerTurn;


        public GameWithOnePlayer(Board gameBoard) : base(gameBoard, false, false, false)
        {
            m_UserPlayer =              new Player('X', 0);
            m_ComputerPlayer =          new ComputerPlayer();
            m_IsComputerPlayerTurn =    false;
        }


        public void Run()
        {
            UIDuringTheGame   ui = new UIDuringTheGame();
            int               row = -1;
            int               column = -1;

            ui.PrintBoard(m_Board);

            while (!m_IsPlayerLosed && !m_IsPlayerWantsToQuit && !m_IsTie)
            {
                if (m_IsComputerPlayerTurn)
                {
                    m_ComputerPlayer.AIMove(ref m_Board, ref row, ref column);
                    CheckGameStatus(ui, row, column, m_ComputerPlayer.Sign, m_ComputerPlayer.Score, m_UserPlayer.Sign, m_UserPlayer.Score);

                }
                else
                {
                    m_UserPlayer.Move(ui, ref m_Board, ref m_IsPlayerWantsToQuit, ref row, ref column);
                    CheckGameStatus(ui, row, column, m_UserPlayer.Sign, m_UserPlayer.Score, m_ComputerPlayer.Sign, m_ComputerPlayer.Score);
                }
                m_IsComputerPlayerTurn = !m_IsComputerPlayerTurn;
            }
        }
    }
}

