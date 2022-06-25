using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.View.report
{
    public partial class profitandloass : Form
    {
        public profitandloass()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                CrystalReport.profit_loss.Report obj = new CrystalReport.profit_loss.Report();
                obj.Type = "date";
                obj.dateA = dateTimePicker1.Text;
                obj.Show();
            }
            else if(radioButton2.Checked==true)
            {
                CrystalReport.profit_loss.Report obj = new CrystalReport.profit_loss.Report();
                obj.Type = "month";
                obj.dateA = dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length-8);
                obj.Show();
            }
        }
    }
}
