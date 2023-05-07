using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_01
{
    class GamePlay
    {
        private enum eGameType
        {
           OnePlayer,
           TwoPlayers
        }
        public void Play()
        {
            Menu menu = new Menu();
            menu.PrintStartMenu();
            Board gameBoard = new Board(menu.GetBoardSizeFromUser());
            int typeOfGame = menu.GetTypeOfGameFromUser();

            if (typeOfGame == (int)eGameType.OnePlayer)
            {
                GameWithOnePlayer onePlayer = new GameWithOnePlayer(gameBoard);
                onePlayer.Run();
            }

            else if (typeOfGame == (int)eGameType.TwoPlayers)
            {
                GameWithTwoPlayers twoPlayers = new GameWithTwoPlayers(gameBoard);
                twoPlayers.Run();
            }

            else
            {
                //menu.PrintEndMenu();
            }
        }
    }
}
