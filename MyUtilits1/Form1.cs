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

        char[] spec_chars = new char[] { '%', '*', '(', ')', '!', '@', '#', '^', '$', '&', '~' };

        Dictionary<string, double> metrica;

        public MainForm()
        {
            InitializeComponent();
            rnd = new Random();
            metrica = new Dictionary<string, double>();
            metrica.Add("mm", 1);
            metrica.Add("cm", 10);
            metrica.Add("dm", 100);
            metrica.Add("m", 1000);
            metrica.Add("km", 1000000);
            metrica.Add("mile", 1609344);
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
            clbPassword.SetItemChecked(0, true);
        }

        private void btnCreatePassword_Click(object sender, EventArgs e)
        {
            if (clbPassword.CheckedItems.Count == 0) return;
            string password = "";
            for(int i = 0; i < nudPasswordLength.Value; i++)
            {
                int n = rnd.Next(0, clbPassword.CheckedItems.Count);
                string symbol = clbPassword.CheckedItems[n].ToString();
                switch (symbol)
                {
                    case "Figures":
                        {
                            password += rnd.Next(10);
                            break;
                        }
                    case "Small letters":
                        {
                            password += Convert.ToChar(rnd.Next(65, 88));
                            break;
                        }
                    case "Main letters":
                        {
                            password += Convert.ToChar(rnd.Next(97, 122));
                            break;
                        }
                    default:
                        {
                            password += spec_chars[rnd.Next(spec_chars.Length)];
                            break;
                        }
                }
                tbPassword.Text = password;
                Clipboard.SetText(password);
            }
        }

        

        private void btnConvert_Click(object sender, EventArgs e)
        {
            double inpMtr = metrica[cbInput.Text];
            double outMtr = metrica[cbOutput.Text];
            double number = Convert.ToDouble(tbInput.Text);
            tbOutput.Text = (number * inpMtr / outMtr).ToString();
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            string t = cbInput.Text;
            cbInput.Text = cbOutput.Text;
            cbOutput.Text = t;
        }

        private void cbMetrics_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbMetrics.Text)
            {
                case "length": 
                    {
                        metrica.Clear();
                        metrica.Add("mm", 1);
                        metrica.Add("cm", 10);
                        metrica.Add("dm", 100);
                        metrica.Add("m", 1000);
                        metrica.Add("km", 1000000);
                        metrica.Add("mile", 1609344);
                        
                        cbInput.Items.Clear();
                        cbInput.Items.Add("mm");
                        cbInput.Items.Add("cm");
                        cbInput.Items.Add("dm");
                        cbInput.Items.Add("m");
                        cbInput.Items.Add("km");
                        cbInput.Items.Add("mile");
                        
                        cbOutput.Items.Clear();
                        cbOutput.Items.Add("mm");
                        cbOutput.Items.Add("cm");
                        cbOutput.Items.Add("dm");
                        cbOutput.Items.Add("m");
                        cbOutput.Items.Add("km");
                        cbOutput.Items.Add("mile");

                        cbInput.Text = "mm";
                        cbOutput.Text = "mm";
                        break;
                    }
                case "weight":
                    {
                        metrica.Clear();
                        metrica.Add("g", 1);
                        metrica.Add("kg", 1000);
                        metrica.Add("t", 1000000);
                        metrica.Add("lb", 453.6);
                        metrica.Add("oz", 283);
                        
                        cbInput.Items.Clear();
                        cbInput.Items.Add("g");
                        cbInput.Items.Add("kg");
                        cbInput.Items.Add("t");
                        cbInput.Items.Add("lb");
                        cbInput.Items.Add("oz");

                        cbOutput.Items.Clear();
                        cbOutput.Items.Add("g");
                        cbOutput.Items.Add("kg");
                        cbOutput.Items.Add("t");
                        cbOutput.Items.Add("lb");
                        cbOutput.Items.Add("oz");
                        MessageBox.Show()
                        cbInput.Text = "g";
                        cbOutput.Text = "g";
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
