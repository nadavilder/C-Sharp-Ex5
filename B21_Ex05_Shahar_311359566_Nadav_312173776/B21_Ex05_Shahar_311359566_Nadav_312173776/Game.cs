using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace B21_Ex05_Shahar_311359566_Nadav_312173776
{
    public class Game
    {
        private static readonly Player[] r_Players = new Player[2];
        private static Board m_Board;
        private static int m_BoardSize;
        private static int m_TurnNum;
        private static FormUI m_GameUI;
        private static FormSettings m_FormSettings;

        public static void CreatePlayers(string[] i_Names, bool i_Multiplayer)
        {
            if (i_Multiplayer)
            {
                r_Players[0] = new Player(i_Names[0], true);
                r_Players[1] = new Player(i_Names[1], true);
            }
            else
            {
                r_Players[0] = new Player(i_Names[0], true);
                r_Players[1] = new Player(i_Names[1], false);
            }
        }

        public static void CreateBoard(int i_Size)
        {
            m_Board = new Board(i_Size);
        }

        public static void InitializeGame()
        {
            m_FormSettings = new FormSettings();
            if (m_FormSettings.ShowDialog() == DialogResult.OK)
            {
                m_BoardSize = m_FormSettings.GameSize;
                NewGame();
            }
        }

        public static void NewGame()
        {
            m_TurnNum = 0;
            m_Board = new Board(m_BoardSize);
            if(m_GameUI != null)
            {
                m_GameUI.Close();
                m_GameUI.Dispose();
            }

            m_GameUI = new FormUI(m_FormSettings);
            m_GameUI.ShowDialog();
        }

        public static bool MakeMove(int i_Row, int i_Col)
        {
            Move newMove = new Move(i_Row, i_Col);
            bool valid = m_Board.UpdateBoard(newMove);
            return valid;
        }

        public static void NextTurn()
        {
            if (m_Board.CheckLose())
            {
                r_Players[(m_TurnNum + 1) % 2].PlayerPoints++;
                m_GameUI.EndGame("Lose");
            }
            else if (m_Board.CheckTie())
            {
                m_GameUI.EndGame("Tie");
            }
            else
            {
                m_TurnNum++;
                if (!r_Players[m_TurnNum % 2].IsHumanPlayer)
                {
                    //Check why name won't be bold
                    m_GameUI.NewTurn(false);
                    MakeAiMove();
                }
                else
                {
                    m_GameUI.NewTurn(true);
                }

            }
        }

        private static void MakeAiMove()
        {
            Move machineMove = m_Board.MakeMachineMove();
            m_GameUI.UpdateButton(machineMove.Row, machineMove.Column);
            NextTurn();
        }
       
        public static Player Player1
        {
            get { return r_Players[0]; }
        }

        public static Player Player2
        {
            get { return r_Players[1]; }
        }

        public static int TurnNum
        {
            get { return m_TurnNum; }
            set { m_TurnNum = value; }
        }
    }
}
