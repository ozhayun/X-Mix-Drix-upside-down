using System;

namespace Ex02_01
{
    public class UIDuringTheGame
    {
        public void PrintBoard(Board board)
        {
            int boardSize = board.BoardSize;

            Ex02.ConsoleUtils.Screen.Clear();
            printColumnsNumber(boardSize);
            
            for (int i = 0; i < boardSize; i++)
            {
                printRowOfBoard(board, i);
                printBorderBetweenBoardRows(boardSize);
            }
        }

        private void printColumnsNumber(int i_BoardSize)
        {
            for (int column = 0; column < i_BoardSize; column++)
            {
                Console.Write($"  {column + 1} ");
            }

            Console.WriteLine();
        }

        private void printRowOfBoard(Board board, int i_Row)
        {
            for (int column = 0; column < board.BoardSize; column++)
            {
                if (column == 0)
                {
                    Console.Write($"{i_Row + 1}|");
                }
                Console.Write($" {board.GetCellValueInBoard(i_Row, column)} |");
            }

            Console.WriteLine();
        }

        private void printBorderBetweenBoardRows(int i_BoardSize)
        {
            Console.Write(" ");

            for (int i = 0; i < i_BoardSize; i++)
            {
                Console.Write("====");
            }

            Console.WriteLine("=");
        }

        public void GetRowAndColumnFromUserAndCheckQuiting(Board i_Board, ref int io_Row, ref int io_Column, ref bool io_IsPlayerWantsToQuit)
        {
            Console.WriteLine("Please enter your next move or Q to quit the game");

            getValidMoveFromUser(i_Board, ref io_Row, ref io_Column, ref io_IsPlayerWantsToQuit);
            while(!io_IsPlayerWantsToQuit && !i_Board.IsThisCellClear(io_Row, io_Column))
            {
                Console.WriteLine($"This cell ({io_Row + 1},{io_Column + 1}) is filled, please enter new move");
                getValidMoveFromUser(i_Board, ref io_Row, ref io_Column, ref io_IsPlayerWantsToQuit);
            }
        }

        private void getValidMoveFromUser(Board i_Board, ref int io_Row, ref int io_Column, ref bool io_IsPlayerWantsToQuit)
        {
            string      input;
            string[]    stringNumbers;
            bool        isValid = false;

            while(!isValid && !io_IsPlayerWantsToQuit)
            {
                input = Console.ReadLine();
                stringNumbers = input.Split(' ');

                if (stringNumbers.Length == 2)
                {
                    handleMoveLengthIsTwo(stringNumbers, ref io_Row,ref io_Column, ref io_IsPlayerWantsToQuit, out isValid);
                }
                else if (stringNumbers.Length == 1)
                {
                    handleMoveLengthIsOne(stringNumbers, ref io_Row, ref io_Column, ref io_IsPlayerWantsToQuit, out isValid);
                }

                if (!io_IsPlayerWantsToQuit)
                {
                    checkIfMoveInRange(i_Board, ref isValid, io_Row, io_Column);
                }
            }
        }

        private void handleMoveLengthIsTwo(string[] i_StringNumbers, ref int io_Row, ref int io_Column, ref bool io_IsPlayerWantsToQuit, out bool o_IsValid)
        {
            o_IsValid = false;
            if (castStringToNumberAndCheckQuit(i_StringNumbers[0], out io_Row, ref io_IsPlayerWantsToQuit))
            {
                if (!io_IsPlayerWantsToQuit)
                {
                    if (castStringToNumberAndCheckQuit(i_StringNumbers[1], out io_Column, ref io_IsPlayerWantsToQuit))
                    {
                        o_IsValid = true;
                    }
                }
            }
        }

        private void handleMoveLengthIsOne(string[] i_StringNumbers, ref int io_Row, ref int io_Column, ref bool io_IsPlayerWantsToQuit, out bool o_IsValid)
        {
            o_IsValid = false;

            if (castStringToNumberAndCheckQuit(i_StringNumbers[0], out io_Row, ref io_IsPlayerWantsToQuit))
            {
                if (!io_IsPlayerWantsToQuit)
                {
                    Console.WriteLine("Please enter column");
                    io_Column = getNumberFromUser(ref io_IsPlayerWantsToQuit);
                    o_IsValid = true;
                }
            }
        }

        private void checkIfMoveInRange(Board i_Board, ref bool io_IsValid, int i_Row, int i_Column)
        {
            if (io_IsValid)
            {
                io_IsValid = i_Board.IsRowAndColumnInRange(i_Row, i_Column);
            }
            if (!io_IsValid)
            {
                Console.WriteLine("You entered invalid input, please try again");
            }
        }

        private bool castStringToNumberAndCheckQuit(string i_StringToCast, out int o_Number, ref bool io_IsPlayerWantsToQuit)
        {
            bool isValid;

            if(i_StringToCast.Equals("Q"))
            {
                io_IsPlayerWantsToQuit = true;
            }

            isValid = int.TryParse(i_StringToCast, out o_Number);
            o_Number -= 1;

            return isValid;
        }

        private int getNumberFromUser(ref bool io_IsPlayerWantsToQuit)
        {
            int numberFromUser = -1;
            bool isValid = false;

            while (!isValid)
            {
                string input = Console.ReadLine();
                if (input.Equals('Q'))
                {
                    io_IsPlayerWantsToQuit = true;
                    isValid = true;
                }

                else if (int.TryParse(input, out numberFromUser))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("You entered invalid input, please try again");
                }
            }
            return numberFromUser - 1;
        }
        
        public void PrintLosingMessage(char i_LossingPlayerSign)
        {
            Console.WriteLine($"Player {i_LossingPlayerSign} lost!!!");
        }

        public bool IsUserWantNewGame()
        {
            bool userWantsNewGame = false;
            Console.WriteLine("Please enter Y to start a new game");
            String inputFromUser = Console.ReadLine();
            if (inputFromUser == "Y")
            {
                userWantsNewGame = true;
            }

            return userWantsNewGame;
        }

        public void PrintStartNewGameMessage()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Starting a new game");
        }

        public void PrintTieMessage()
        {
            Console.WriteLine("There is a TIE!!!");
        }

        public void PrintScores(Player i_FirstPlayer, Player i_SecondPlayer)
        {
            Console.WriteLine($"Player: {i_FirstPlayer.Sign}, Score: {i_FirstPlayer.Score}");
            Console.WriteLine($"Player: {i_SecondPlayer.Sign}, Score: {i_SecondPlayer.Score}");
        }
    }
}
