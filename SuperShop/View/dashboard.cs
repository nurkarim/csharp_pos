using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.View
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            string date = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy H:m:s"));
            label1.Text = date.ToString();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}
