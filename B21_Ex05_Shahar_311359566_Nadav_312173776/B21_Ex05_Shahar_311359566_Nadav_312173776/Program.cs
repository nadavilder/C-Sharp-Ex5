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
            

            FormSettings fs = new FormSettings();
            fs.ShowDialog();
        }

        public static void InitializeGame()
        {
            bool playing = true;
            while (playing)
            {
                m_BoardSize = Game.GetBoardSizeFromPlayer();
                m_Board = new Board(m_BoardSize);
                m_TurnNum = 0;
                m_Multiplayer = Game.CheckIfMultiplayer();
                if (m_Multiplayer)
                {
                    playing = HumanPlayer.PlayMultiplayer(m_Board);
                }
                else
                {
                    playing = MachinePlayer.PlayVsMachine(m_Board);
                }
            }
        }

        public static int TurnNum
        {
            get { return m_TurnNum; }

            set { m_TurnNum = value; }
        }        
    }
}