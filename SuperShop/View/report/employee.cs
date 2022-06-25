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
    public partial class employee : Form
    {
        public employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton6.Checked==true)
            {
                CrystalReport.employee.viewReport obj = new CrystalReport.employee.viewReport();
                obj.type = "employee";
                obj.Show();
            }
            else if (radioButton1.Checked==true)
            {

                CrystalReport.employee.viewReport obj = new CrystalReport.employee.viewReport();
                obj.type = "final";
                obj.date1 = dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length - 8);

                obj.Show();
            
            }

            else if (radioButton2.Checked == true)
            {

                CrystalReport.employee.viewReport obj = new CrystalReport.employee.viewReport();
                obj.type = "acc";
                obj.Show();

            }
            else if (radioButton7.Checked == true)
            {

                CrystalReport.employee.viewReport obj = new CrystalReport.employee.viewReport();
                obj.type = "bonus";
                obj.date1 = dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length - 8);
                obj.Show();

            }
            else if (radioButton3.Checked == true)
            {

                CrystalReport.employee.viewReport obj = new CrystalReport.employee.viewReport();
                obj.type = "payHisatoy";
                obj.date1 = dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length - 8);
                obj.Show();

            }
        }
    }
}
