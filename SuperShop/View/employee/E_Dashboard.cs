using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.View.employee
{
    public partial class E_Dashboard : Form
    {
        public E_Dashboard()
        {
            InitializeComponent();
        }
        Route.route _route = new Route.route();
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            _route.FromCheck();
          
            View.employee.addNewEmployee obj = new addNewEmployee();
            obj.MdiParent = index.ActiveForm;
            obj.Show();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
            _route.FromCheck();
            Payroll.From.employee_attendance  obj = new Payroll.From.employee_attendance();
            obj.MdiParent = index.ActiveForm;
            obj.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            _route.FromCheck();
            Payroll.From.finalizeSalery obj = new Payroll.From.finalizeSalery();
            obj.MdiParent = index.ActiveForm;
            obj.Show();
        }
    }
}
