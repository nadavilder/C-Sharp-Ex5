using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex05_Shahar_311359566_Nadav_312173776
{
    public class Move
    {
        private readonly int r_Row;
        private readonly int r_Column;
        private eTurn m_Turn;

        public Move(int i_row, int i_column)
        {
            r_Row = i_row;
            r_Column = i_column;
            m_Turn = GetTurn();
        }

        public static eTurn GetTurn()
        {
            eTurn symbol = eTurn.X;
            if (Game.TurnNum % 2 == 1)
            {
                symbol = eTurn.O;
            }

            return symbol;
        }

        public enum eTurn
        {
            EMPTY,
            X,
            O
        }

        public int Row
        {
            get { return r_Row; }
        }

        public int Column
        {
            get { return r_Column; }
        }

        public eTurn Turn
        {
            get { return m_Turn; }
        }
    }
}
