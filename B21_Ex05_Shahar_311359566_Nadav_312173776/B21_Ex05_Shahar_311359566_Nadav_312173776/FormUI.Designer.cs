
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace B21_Ex05_Shahar_311359566_Nadav_312173776
{
    partial class FormUI:Form
    {
        private void InitializeComponent()
        {
            this.Text = "TicTacToe";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Size = new Size(r_GameSize * 70 + 30, r_GameSize * 70 + 80);
            createButtoms();
            createPlayersLabels();
            this.Controls.AddRange(m_controls);

        }

        private void createPlayersLabels()
        {
            m_Player1 = new Label();
            m_Player1.Location = new Point(((r_GameSize / 2)-1) * 70+10, r_GameSize * 70 );
           // m_Player2.Text = $"{Game.Player1.PlayerName}: {Game.Player1.PlayerPoints}";
            m_Player1.Text = "nadav: 0";
            m_Player1.AutoSize = true;
            //
            m_Player2 = new Label();
            m_Player2.Location = new Point((r_GameSize / 2) * 70+10, r_GameSize * 70 );
            //  m_Player2.Text = $"{Game.Player2.PlayerName}: {Game.Player1.PlayerPoints}";
            m_Player2.Text = "nadav: 0";
            m_Player2.AutoSize = true;
            this.Controls.Add(m_Player1);
            this.Controls.Add(m_Player2);

        }

        private void createButtoms()
        {
            for (int i = 0; i < r_ButtomsNumber; i++)
            {
                m_GameBoard[i] = new Button();
                m_GameBoard[i].Width = 60;
                m_GameBoard[i].Height = 60;
                m_GameBoard[i].Location = new Point((i % r_GameSize * 70) + 10, (i / r_GameSize * 70) + 10);
                m_GameBoard[i].Click += new EventHandler(m_button_Click);
                m_controls[i] = m_GameBoard[i];
            }
        }
    }
}