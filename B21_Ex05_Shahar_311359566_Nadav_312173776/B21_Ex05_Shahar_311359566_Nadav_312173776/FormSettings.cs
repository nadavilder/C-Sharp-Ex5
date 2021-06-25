using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace B21_Ex05_Shahar_311359566_Nadav_312173776
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
            string[] playerNames = { this.textBox1.Text, this.textBox2.Text };
            if (this.checkBox1.Checked)
            {
                Game.CreatePlayers(playerNames, true);
            }
            else
            {
                Game.CreatePlayers(playerNames, false);
            }

            Game.CreateBoard((int)this.numericUpDown1.Value);
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.textBox2.Text = "";
                this.textBox2.BackColor = System.Drawing.SystemColors.Window;
                this.textBox2.Enabled = true;
            }
            else
            {
                this.textBox2.Text = "[Computer]";
                this.textBox2.BackColor = System.Drawing.SystemColors.MenuBar;
                this.textBox2.Enabled = false;
            }
        }

        private void numericUpDown1_Changed(object sender, EventArgs e)
        {
            this.numericUpDown2.Value = this.numericUpDown1.Value;
        }

        private void numericUpDown2_Changed(object sender, EventArgs e)
        {
            this.numericUpDown1.Value = this.numericUpDown2.Value;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
        }
    }
}
