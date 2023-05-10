
namespace Ex02_01
{
    class GameWithOnePlayer : Game
    {
        Player m_UserPlayer;
        ComputerPlayer m_ComputerPlayer;
        private bool m_IsComputerPlayerTurn;

        public GameWithOnePlayer(Board gameBoard) : base(gameBoard, false, false, false)
        {
            m_UserPlayer = new Player('X', 0);
            m_ComputerPlayer = new ComputerPlayer();
            m_IsComputerPlayerTurn = false;
        }

        public void Run()
        {
            UIDuringTheGame ui = new UIDuringTheGame();
            int row = -1, column = -1;
            char currentPlayerSign;

            while (!m_IsPlayerLosed && !m_IsPlayerWantsToExit && !m_IsTie)
            {
                ui.PrintBoard(m_Board);

                if (m_IsComputerPlayerTurn)
                {
                    m_ComputerPlayer.StupidMove(ref m_Board, ref row, ref column);
                    currentPlayerSign = m_ComputerPlayer.Sign;
                }
                else
                {
                    m_UserPlayer.Move(ui, ref m_Board, ref m_IsPlayerWantsToExit, ref row, ref column);
                    currentPlayerSign = m_UserPlayer.Sign;
                }

                CheckGameStatus(ui, row, column, currentPlayerSign);
                m_IsComputerPlayerTurn = !m_IsComputerPlayerTurn;
            }
        }
    }
}

