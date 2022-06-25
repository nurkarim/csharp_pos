using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.CrystalReport.employee
{
    public partial class viewReport : Form
    {
        public viewReport()
        {
            InitializeComponent();
        }

        public string type { get { return textBox1.Text; } set { textBox1.Text = value; } }
        public string date1 { get { return textBox2.Text; } set { textBox2.Text = value; } }
        public string date2 { get { return textBox3.Text; } set { textBox3.Text = value; } }

        private void viewReport_Load(object sender, EventArgs e)
        {
            if (textBox1.Text == "employee")
            {
                CrystalReport.employee.employee obj = new employee();
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "final")
            {
                CrystalReport.employee.employee_finalizs obj = new employee_finalizs();
                obj.SetParameterValue("date", textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "acc")
            {

                CrystalReport.employee.employee_acc obj = new employee_acc();
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "bonus")
            {
                CrystalReport.employee.employee_bonus_history obj = new employee_bonus_history();
                obj.SetParameterValue("date",textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "payHisatoy")
            {
                CrystalReport.employee.payment_his obj = new payment_his();
                obj.SetParameterValue("date",textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            
        }
    }
}
