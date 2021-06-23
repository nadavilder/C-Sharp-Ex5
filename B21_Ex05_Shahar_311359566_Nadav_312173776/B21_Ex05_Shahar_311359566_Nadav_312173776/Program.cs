using System;
using System.Text;

namespace B21_Ex05_Shahar_311359566_Nadav_312173776
{
    public class Program
    {
        private static int m_BoardSize;
        private static Board m_Board;
        private static int m_TurnNum = 0;
        private static bool m_Multiplayer = false;

        public static void Main(string[] args)
        {
            Game.InitializeGame();



        }


        public static int TurnNum
        {
            get { return m_TurnNum; }

            set { m_TurnNum = value; }
        }        
    }
}