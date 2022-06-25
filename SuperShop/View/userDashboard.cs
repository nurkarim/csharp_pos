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
    public partial class userDashboard : Form
    {
        public userDashboard()
        {
            InitializeComponent();
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
