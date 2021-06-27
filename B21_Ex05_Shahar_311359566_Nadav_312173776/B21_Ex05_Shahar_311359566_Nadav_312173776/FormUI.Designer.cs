using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace B21_Ex05_Shahar_311359566_Nadav_312173776
{
    public partial class FormUI : Form
    {
        private void InitializeComponent()
        {
            this.Text = "TicTacToe";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Size = new Size((r_GameSize * 70) + 30, (r_GameSize * 70) + 80);
            createButtoms();
            createPlayersLabels();
            this.Controls.AddRange(m_controls);
        }

        private void createPlayersLabels()
        {
            m_Player1Label = new Label();
            m_Player1Label.Location = new Point((this.ClientSize.Width / 2) - 70, this.ClientSize.Height - 25);
            m_Player1Label.Text = $"{Game.Player1.PlayerName}: {Game.Player1.PlayerPoints}";
            m_Player1Label.AutoSize = true;
            m_Player2Label = new Label();
            m_Player2Label.Location = new Point((this.ClientSize.Width / 2) + 20, this.ClientSize.Height - 25);
            m_Player2Label.Text = $"{Game.Player2.PlayerName}: {Game.Player2.PlayerPoints}";
            m_Player2Label.AutoSize = true;
            this.Controls.Add(m_Player1Label);
            this.Controls.Add(m_Player2Label);
        }

        private void createButtoms()
        {
            for (int i = 0; i < r_ButtomsNumber; i++)
            {
                m_GameButtons[i] = new Button();
                m_GameButtons[i].Width = 60;
                m_GameButtons[i].Height = 60;
                m_GameButtons[i].Location = new Point(((i % r_GameSize) * 70) + 10, (i / r_GameSize * 70) + 10);
                m_GameButtons[i].Click += new EventHandler(m_button_Click);
                m_controls[i] = m_GameButtons[i];
            }
        }
    }
}