namespace Ex02_01
{
    public class Player
    {
        private char m_Sign;
        private int m_Score;

        public Player(char i_Sign, int i_Score)
        {
            m_Sign = i_Sign;
            m_Score = i_Score;
        }

        public char Sign
        {
            get
            {
                return m_Sign;
            }

            set
            {
                m_Sign = value;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }

        public void ComputerMove(ref Board io_Board, ref int io_Row, ref int io_Column)
        {
            if (!io_Board.IsFoundEmptyCellThatNotClosedSequence(ref io_Row, ref io_Column, Sign))
            {
                io_Board.SetRowAndColumnToBeTheFirstClearCell(ref io_Row, ref io_Column, Sign);
            }
        }

        public void HumanMove(UIDuringTheGame i_UI, ref Board io_Board, ref bool io_IsPlayerWantsToExit, ref int io_Row, ref int io_Column)
        {
            i_UI.GetRowAndColumnFromUserAndCheckQuiting(io_Board, ref io_Row, ref io_Column, ref io_IsPlayerWantsToExit);

            if (!io_IsPlayerWantsToExit)
            {
                io_Board.AddPlayerSign(io_Row, io_Column, m_Sign);
            }
        }
    }
}