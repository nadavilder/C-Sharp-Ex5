using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace B21_Ex05_Shahar_311359566_Nadav_312173776
{
    public class Board
    {
        private readonly Move.eTurn[,] r_BoardMatrix;
        private readonly int r_BoardSize;
        private Random m_rand;

        public Board(int i_BoardSize)
        {
            r_BoardSize = i_BoardSize;
            r_BoardMatrix = new Move.eTurn[i_BoardSize, i_BoardSize];
            m_rand = new Random();
        }

        public bool UpdateBoard(Move i_Move)
        {
            bool movesuccessful = false;
            if (CheckLegalMove(i_Move))
            {
                if (r_BoardMatrix[i_Move.Row, i_Move.Column].Equals(Move.eTurn.EMPTY))
                {
                    r_BoardMatrix[i_Move.Row, i_Move.Column] = i_Move.Turn;
                    movesuccessful = true;
                }
            }

            return movesuccessful;
        }

        private bool CheckLegalMove(Move i_Move)
        {
            bool legalMove = true;

            if (i_Move.Row < 0 || i_Move.Row >= r_BoardSize || i_Move.Column < 0 || i_Move.Column >= r_BoardSize)
            {
                legalMove = false;
            }

            return legalMove;
        }

        public bool CheckLose()
        {
            return CheckRowsLose() || CheckColsLose() || CheckDiagLose();
        }

        private bool CheckRowsLose()
        {
            bool gameLost = false;
            for (int i = 0; i < r_BoardSize; i++)
            {
                Move.eTurn[] row = new Move.eTurn[r_BoardSize];

                for (int j = 0; j < r_BoardSize; j++)
                {
                    row[j] = r_BoardMatrix[i, j];
                }

                if (CheckSeriesLose(row))
                {
                    gameLost = true;
                }
            }

            return gameLost;
        }

        private bool CheckColsLose()
        {
            bool gameLost = false;
            for (int i = 0; i < r_BoardSize; i++)
            {
                Move.eTurn[] col = new Move.eTurn[r_BoardSize];

                for (int j = 0; j < r_BoardSize; j++)
                {
                    col[j] = r_BoardMatrix[j, i];
                }

                if (CheckSeriesLose(col))
                {
                    gameLost = true;
                }
            }

            return gameLost;
        }

        private bool CheckDiagLose()
        {
            bool gameLost = false;
            Move.eTurn[] diag1 = new Move.eTurn[r_BoardSize];

            for (int i = 0; i < r_BoardSize; i++)
            {
                diag1[i] = r_BoardMatrix[i, i];
            }

            if (CheckSeriesLose(diag1))
            {
                gameLost = true;
            }

            Move.eTurn[] diag2 = new Move.eTurn[r_BoardSize];
            for (int i = 0; i < r_BoardSize; i++)
            {
                diag2[i] = r_BoardMatrix[i, r_BoardSize - i - 1];
            }

            if (CheckSeriesLose(diag2))
            {
                gameLost = true;
            }

            return gameLost;
        }

        private bool CheckSeriesLose(Move.eTurn[] i_Series)
        {
            bool gameLost = true;
            Move.eTurn firstEntry = i_Series[0];

            if(firstEntry == Move.eTurn.EMPTY)
            {
                gameLost = false;
            }

            foreach (Move.eTurn entry in i_Series)
            {
                if (!entry.Equals(firstEntry))
                {
                    gameLost = false;
                }
            }

            return gameLost;
        }

        public bool CheckTie()
        {
            double turns = Math.Pow(r_BoardSize, 2) - 1;
            return Game.TurnNum == (int)turns;
        }

        public List<Move> GetAvailableMoves()
        {
            List<Move> availableMoves = new List<Move>();
            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    if (r_BoardMatrix[i, j] == Move.eTurn.EMPTY)
                    {
                        Move possibleMove = new Move(i, j);
                        availableMoves.Add(possibleMove);
                    }
                }
            }

            return availableMoves;
        }

        public Move MakeMachineMove()
        {
            List<Move> availableMoves = this.GetAvailableMoves();
            Move chosenMove = availableMoves[m_rand.Next(availableMoves.Count)];
            this.UpdateBoard(chosenMove);
            return chosenMove;
        }

        // Properties
        public Move.eTurn[,] BoardMatrix
        {
            get { return r_BoardMatrix; }
        }

        public int BoardSize
        {
            get { return r_BoardSize; }
        }
    }
}
