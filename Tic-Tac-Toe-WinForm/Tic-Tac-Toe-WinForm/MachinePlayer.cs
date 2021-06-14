using System;
using System.Collections.Generic;
using System.Text;


namespace B21_Ex02_Shahar_311359566_Nadav_312173776
{
    class MachinePlayer
    {
       
        public static bool PlayVsMachine(Board io_Board)
        {
            UI.BoardPrinter(io_Board);
            bool gameTied = false;
            bool continueGame = true;
            while (!gameTied)
            {
                if (Move.GetTurn() == Move.eTurn.X)
                {
                    Console.WriteLine("It is now your turn");
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
                }
                else
                {
                    io_Board.MakeMachineMove();
                }

                UI.BoardPrinter(io_Board);
                if (io_Board.CheckLose())
                {
                    if (Move.GetTurn() == Move.eTurn.X)
                    {
                        Console.WriteLine($"You lost! the Machine Wins!");
                    }
                    else
                    {
                        Console.WriteLine($"You Won!");
                    }

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
