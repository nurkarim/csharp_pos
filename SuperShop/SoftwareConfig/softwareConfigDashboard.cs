using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.SoftwareConfig
{
    public partial class softwareConfigDashboard : Form
    {
        public softwareConfigDashboard()
        {
            InitializeComponent();
        }

        private void softwareConfigDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            var clossing = MessageBox.Show("Do You Really want To Close?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (clossing == DialogResult.Yes)
            {
                Application.Exit();
            }
            else 
            {
            
            }
        }

        private void companyRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register_company obj = new Register_company();
            obj.MdiParent = this;
            obj.Show();
        }

        private void serviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            service obj = new service();
            obj.MdiParent = this;
            obj.Show();
        }

        private void boothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoftwareConfig.Booth obj = new Booth();
            obj.MdiParent = this;
            obj.Show();
        }
    }
}
