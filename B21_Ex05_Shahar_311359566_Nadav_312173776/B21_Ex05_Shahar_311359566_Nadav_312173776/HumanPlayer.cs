using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex05_Shahar_311359566_Nadav_312173776
{
    class HumanPlayer
    {

        public static bool PlayMultiplayer(Board io_Board)
        {
            UI.BoardPrinter(io_Board);
            bool gameTied = false;
            bool continueGame = true;
            while (!gameTied)
            {
                Console.WriteLine($"It is now {Move.GetTurn()} turn");
                Move cur_move = Game.GetPlayerMove(out continueGame);
                if (!continueGame)
                {
                    break;
                }

                while (!io_Board.UpdateBoard(cur_move))
                {
                    Console.WriteLine("Ilegal Move, please enter a new move");
                    cur_move = Game.GetPlayerMove(out continueGame);
                    if (!continueGame)
                    {
                        break;
                    }
                }

                UI.BoardPrinter(io_Board);
                if (io_Board.CheckLose())
                {
                    Move.eTurn winner = Move.eTurn.X;
                    if (Move.GetTurn() == Move.eTurn.X)
                    {
                        winner = Move.eTurn.O;
                    }

                    Console.WriteLine($"You lost! {winner} Wins!");
                    break;
                }

                gameTied = io_Board.CheckTie();
                Program.TurnNum++;
            }

            if (gameTied)
            {
                Console.WriteLine("The game is tied, nobody wins");
            }

            if (continueGame)
            {
                continueGame = Game.CheckForNewGame();
            }

            return continueGame;
        }
    }
}
