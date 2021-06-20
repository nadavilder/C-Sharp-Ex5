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
        private Label m_Player1;
        private Label m_Player2;
        public static Button[] m_GameBoard;
        private Control[] m_controls;

        public FormUI(Form1 i_FormSettings)
        {
            r_GameSize = i_FormSettings.GameSize;
            r_ButtomsNumber = r_GameSize * r_GameSize;
            m_controls = new Control[r_ButtomsNumber + 2];
            m_GameBoard = new Button[r_ButtomsNumber];
            /*this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.StartPosition = FormStartPosition.CenterScreen;*/
            InitializeComponent();
        }

        private void m_button_Click(object sender, EventArgs e) {
        }



    }
}
