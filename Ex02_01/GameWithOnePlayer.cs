using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_01
{
    class GameWithOnePlayer
    {
        Board m_Board;
        Player m_UserPlayer;
        Player m_ComputerPlayer;

        public GameWithOnePlayer(Board gameBoard)
        {
            m_Board = gameBoard;
            m_UserPlayer = new Player();
        }

        public void Run()
        {

        }

    }
}
