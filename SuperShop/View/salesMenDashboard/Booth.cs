using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.View.salesMenDashboard
{
    public partial class Booth : Form
    {
        public Booth()
        {
            InitializeComponent();
        }
       
        
       
        private void Booth_Load(object sender, EventArgs e)
        {
            
        }

          

        private void button1_Click(object sender, EventArgs e)
        {
          
            
            try
            {
                if (comboBox1.Text != "")
                {
                    
                  
                    if (comboBox1.Text != null)
                    {

                       

                    }
                   
                }
                else
                {

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Booth_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

  

        private void Booth_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
              
            }
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {

            }
            if (e.CloseReason == CloseReason.TaskManagerClosing)
            {

            }
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {

            }
        }
    }
}
