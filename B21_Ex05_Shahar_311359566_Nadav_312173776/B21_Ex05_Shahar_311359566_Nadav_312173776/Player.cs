using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex05_Shahar_311359566_Nadav_312173776

{
    class Player
    {
        private readonly string r_Name;
        private int m_Points;
        private bool m_HumanPlayer;
        

        public Player(string i_Name, bool i_HumanPlayer)
        {
            r_Name = i_Name;
            m_Points = 0;
            m_HumanPlayer = i_HumanPlayer;

        }

        public int PlayerPoints
        {
            get { return m_Points; }

            set { m_Points = value; }
        }

        public string PlayerName
        {
            get { return r_Name; }
        }

        public bool IsHumanPlayer
        {
            get { return m_HumanPlayer; }
        }

    }
}
