using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUtilits1
{
    public partial class MainForm : Form
    {
        int count = 0;
        Random rnd;

        public MainForm()
        {
            InitializeComponent();
            rnd = new Random();
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmAboutProgramm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This programm contains some small programms.", "About Programm");
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            count++;
            lblCount.Text = count.ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            count--;
            lblCount.Text = count.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            count = 0;
            lblCount.Text = count.ToString();
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            int number = rnd.Next(Convert.ToInt32(nudMin.Value), Convert.ToInt32(nudMax.Value) + 1);
            lblRandom.Text = number.ToString();
            if (cbRandom.Checked)
            {
                int i = 0;
                while (tbRandom.Text.IndexOf(number.ToString()) != -1)
                {
                    number = rnd.Next(Convert.ToInt32(nudMin.Value), Convert.ToInt32(nudMax.Value) + 1);
                   
                    i++;
                    if (i > Convert.ToInt32(nudMax.Value) + 1 - Convert.ToInt32(nudMin.Value)) break;

                }
                if(i <= Convert.ToInt32(nudMax.Value) + 1 - Convert.ToInt32(nudMin.Value))
                    tbRandom.AppendText(number + "\n ");
            }
            else
            {
                tbRandom.AppendText(number + "\n ");
            }
        }

        private void btnRandomClear_Click(object sender, EventArgs e)
        {
            lblRandom.Text = "0";
            tbRandom.Clear();
        }

        private void btnRandomCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbRandom.Text);
        }

        private void tsmInsertData_Click(object sender, EventArgs e)
        {
            rtbNotepad.AppendText(DateTime.Now.ToShortDateString());
        }

        private void tsmInsertTime_Click(object sender, EventArgs e)
        {
            rtbNotepad.AppendText(DateTime.Now.ToShortTimeString());
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            try
            {
                rtbNotepad.SaveFile("notepad.rtf");
            }
            catch
            {
                MessageBox.Show("Error for file saving!");
            }
        }

        private void tsmiLoad_Click(object sender, EventArgs e)
        {
            LoadNotepad();
        }

        void LoadNotepad()
        {
            try
            {
                rtbNotepad.LoadFile("notepad.rtf");
            }
            catch
            {
                MessageBox.Show("Error for file loading!");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadNotepad();
        }
    }
}
