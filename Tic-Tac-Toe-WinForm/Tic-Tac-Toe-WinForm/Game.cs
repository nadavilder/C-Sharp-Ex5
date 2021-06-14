using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex02_Shahar_311359566_Nadav_312173776
{
    class Game
    {
        public static Move GetPlayerMove(out bool o_ContinueGame)
        {
            Move playerMove = null;
            o_ContinueGame = true;
            bool checking = true;
            while (checking)
            {
              //  Console.WriteLine("Please enter your row number and column number seprated by a space");
             //   Console.WriteLine("If you like to Quit enter just Q");
                string moveString = Console.ReadLine();
                string[] inputs = moveString.Split(' ');
                int[] parsedInts = new int[2];
                if (moveString.Equals("Q"))
                {
                    o_ContinueGame = !CheckForGameQuit();
                    if (o_ContinueGame)
                    {
                        continue;
                    }
                    else
                    {
                        checking = false;
                    }
                }

                if (o_ContinueGame)
                {
                    if (!IsValidInputs(inputs, out parsedInts))
                    {
                        Console.WriteLine("Invalid input.");
                        continue;
                    }

                    checking = false;
                    playerMove = new Move(parsedInts[0] - 1, parsedInts[1] - 1);
                }
            }

            return playerMove;
        }

        public static int GetBoardSizeFromPlayer()
        {
            Console.WriteLine("Please enter the size of board (3 to 9)");
            string boardSizeString = Console.ReadLine();
            bool validInput = int.TryParse(boardSizeString, out int boardSize);

            while (!validInput || (boardSize < 3 || boardSize > 9))
            {
                Console.WriteLine("Invalid size, please enter the size of board (3 to 9)");
                boardSizeString = Console.ReadLine();
                validInput = int.TryParse(boardSizeString, out boardSize);
            }

            return boardSize;
        }


        public static bool CheckForNewGame()
        {
            bool newGame = false;
            bool checking = true;
            while (checking)
            {
           //     Console.WriteLine("Would you like you play another game? (Y/N)");
                string answer = Console.ReadLine();
                if (answer == "Y")
                {
                    newGame = true;
                    checking = false;
                    Ex02.ConsoleUtils.Screen.Clear();
                }
                else if (answer == "N")
                {
      //              Console.WriteLine("Thank you for playing");
                    checking = false;
                }
                else
                {
       //             Console.WriteLine("Invalid Input.");
                }
            }

            return newGame;
        }

        private static bool CheckForGameQuit()
        {
            bool gameQuit = false;
            bool checking = true;
            while (checking)
            {
     //           Console.WriteLine("Are you sure you want to quit? (Y/N)");
                string answer = Console.ReadLine();
                if (answer == "Y")
                {
       //             Console.WriteLine("Thank you for playing");
                    gameQuit = true;
                    checking = false;
                }
                else if (answer == "N")
                {
                    checking = false;
                }
                else
                {
       //             Console.WriteLine("Invalid Input.");
                }
            }

            return gameQuit;
        }


        public static bool CheckIfMultiplayer()
        {
            Console.WriteLine("Please choose number of human players (1/2)");
            string numOfPlayersString = Console.ReadLine();
            bool multiplayer = false;
            bool validInput = int.TryParse(numOfPlayersString, out int numOfPlayers);
            while (!validInput || (numOfPlayers < 0 || numOfPlayers > 2))
            {
                Console.WriteLine("Invalid number of players, please choose number of human players (1/2)");
                numOfPlayersString = Console.ReadLine();
                validInput = int.TryParse(numOfPlayersString, out numOfPlayers);
            }

            if (numOfPlayers == 2)
            {
                multiplayer = true;
            }

            return multiplayer;
        }


        private static bool IsValidInputs(string[] i_Inputs, out int[] o_parsedInts)
        {
            bool valid = true;

            if (i_Inputs.Length != 2)
            {
                valid = false;
            }

            int[] parsedInts = new int[2];

            if (valid)
            {
                for (int i = 0; i < i_Inputs.Length; i++)
                {
                    if (!int.TryParse(i_Inputs[i].ToString(), out parsedInts[i]))
                    {
                        valid = false;
                    }
                }
            }

            o_parsedInts = parsedInts;

            return valid;
        }
    }
}
