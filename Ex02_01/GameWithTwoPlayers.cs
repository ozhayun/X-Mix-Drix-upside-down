using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_01
{
    public class GameWithTwoPlayers : Game
    {
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private bool m_IsFirstPlayerMove;
        
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
<<<<<<< HEAD

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
                //ui.PrintLosing();
;               m_IsPlayerLosed = true;
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
=======
>>>>>>> 7e0a4fbe6d94d1e6483a8daa843bffdf694350ee
    }
}
