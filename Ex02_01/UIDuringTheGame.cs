﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_01
{
    public class UIDuringTheGame
    {
        public void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    Console.WriteLine(board.getCellValueInBoard(i, j));
                }
            }
        }
    }
}