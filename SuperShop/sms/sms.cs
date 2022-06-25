using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net;
namespace SuperShop.sms
{
    public partial class sms : Form
    { 
        public sms()
        {
            InitializeComponent();
        }
       
        private void btnSend_Click(object sender, EventArgs e)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                try
                {
               
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void sms_Load(object sender, EventArgs e)
        {

            
        }
    }
}
