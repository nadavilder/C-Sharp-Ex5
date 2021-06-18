using System;
using System.Collections.Generic;
using System.Text;

namespace B21_Ex05_Shahar_311359566_Nadav_312173776

{
    class Player
    {
        private string m_Name;
        private int m_Points;
        

        public Player(string i_Name)
        {
            m_Name = i_Name;
            m_Points = 0;
        }

        public int PlayerPoints
        {
            get { return m_Points; }

            set { m_Points = value; }
        }

        public string PlayerName
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

    }
}
