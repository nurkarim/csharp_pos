using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.CrystalReport.Bank
{
    public partial class Bank : Form
    {
        public Bank()
        {
            InitializeComponent();
        }
        public string Type { get { return textBox1.Text; } set { textBox1.Text = value; } }
        public string dateA { get { return textBox2.Text; } set { textBox2.Text = value; } }
        public string dateB { get { return textBox3.Text; } set { textBox3.Text = value; } }
        private void Bank_Load(object sender, EventArgs e)
        {
            if(textBox1.Text=="week")
            {
                CrystalReport.Bank.bank_depposit obj = new bank_depposit();
                obj.SetParameterValue("date", textBox2.Text);
                obj.SetParameterValue("dateA", textBox3.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if(textBox1.Text=="month")
            {
                CrystalReport.Bank.month_bank_depposit obj = new month_bank_depposit();
                obj.SetParameterValue("date", textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "bank")
            {
                CrystalReport.Bank.acording_bank_depposit obj = new acording_bank_depposit();
                obj.SetParameterValue("id", textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "lweek")
            {
                CrystalReport.Bank.bank_loan obj = new bank_loan();
                obj.SetParameterValue("date", textBox2.Text);
                obj.SetParameterValue("dateA", textBox3.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "lmonth")
            {
                CrystalReport.Bank.month_bank_loan obj = new month_bank_loan();
                obj.SetParameterValue("date", textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "lbank")
            {
                CrystalReport.Bank.according_bank_loan obj = new according_bank_loan();
                obj.SetParameterValue("id", textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
        }
    }
}
