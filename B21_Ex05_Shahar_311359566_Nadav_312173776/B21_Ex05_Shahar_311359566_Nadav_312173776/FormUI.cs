using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace B21_Ex05_Shahar_311359566_Nadav_312173776
{
    public partial class FormUI : Form
    {
        private int r_GameSize;
        private int r_ButtomsNumber;
        private Label m_Player1Label;
        private Label m_Player2Label;
        public static Button[] m_GameButtons;
        private Control[] m_controls;

        public FormUI(FormSettings i_FormSettings)
        {
            r_GameSize = i_FormSettings.GameSize;
            r_ButtomsNumber = r_GameSize * r_GameSize;
            m_controls = new Control[r_ButtomsNumber];
            m_GameButtons = new Button[r_ButtomsNumber];
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            NewTurn();
        }

        public void NewTurn()
        {
            if(Game.TurnNum%2 == 0)
            {
                m_Player1Label.Font = new Font(m_Player1Label.Font, FontStyle.Bold);
                m_Player2Label.Font = new Font(m_Player2Label.Font, FontStyle.Regular);
        }
            else
            {
                m_Player1Label.Font = new Font(m_Player2Label.Font, FontStyle.Regular);
                m_Player2Label.Font = new Font(m_Player2Label.Font, FontStyle.Bold);
            }
            //Buttons that were pressed should not be enabled
            foreach( Button button in m_GameButtons)
            {
                if(button.Text == "")
                {
                    button.Enabled = true;
                }
            }
        }

        public void EndGame(string i_Message)
        {
            this.Close();
            DialogResult result = MessageBox.Show(i_Message,"",  MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Game.NewGame();

            }

        }


        private void m_button_Click(object sender, EventArgs e) {
            Button buttonWasClicked = (Button)sender;
            int rowIndex = Array.IndexOf(m_GameButtons, buttonWasClicked)/ r_GameSize;
            int colIndex = Array.IndexOf(m_GameButtons, buttonWasClicked) % r_GameSize;
            if(Game.MakeMove(rowIndex, colIndex))
            {
                if(Game.TurnNum%2 == 0)
                {
                    buttonWasClicked.Text = "X";
                }
                else
                {
                    buttonWasClicked.Text = "O";
                }
                buttonWasClicked.Font = new Font(buttonWasClicked.Font, FontStyle.Bold);
                foreach (Button button in m_GameButtons)
                {
                    button.Enabled = false;
                }
                Game.NextTurn();
            }
        }

        public void UpdateButton(int i_Row, int i_Column)
        {
            int buttonIdx = i_Row * r_GameSize + i_Column;
            m_GameButtons[buttonIdx].Text = "O";
            m_GameButtons[buttonIdx].Font = new Font(m_GameButtons[buttonIdx].Font, FontStyle.Bold);
        }


    }
}
