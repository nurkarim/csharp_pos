using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Management;
namespace SuperShop.View.salesMenDashboard
{
    public partial class slaesManDeashboard : Form
    {
    


        public slaesManDeashboard(string value,string value2)
        {
            InitializeComponent();
            
            txtId.Text = value.ToString();
            txtSoftwareType.Text = value2.ToString();
        }
       
        DB.config cn = new DB.config();
        MySqlConnection connect;
        Route.route _route = new Route.route();
     
      
        string boothName;
       
        public void con()
        {
            connect = cn.connection();
        if(connect.State==ConnectionState.Open)
        {
            connect.Close();

        }
        connect.Open();
        
        }

        
        public void selectCompany()
        {
            con();
            MySqlCommand cmd = new MySqlCommand("SELECT check_run_software.software_type,company_register.name,company_register.phone,company_register.logo FROM user INNER JOIN company_register ON user.companyId=company_register.id INNER JOIN check_run_software ON user.companyId=check_run_software.company_id where user.employee_id='" +txtId.Text + "'", connect);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                label2.Text = dr["name"].ToString();

                txtSoftwareType.Text = dr["software_type"].ToString();
            }
        }
      
        private void slaesManDeashboard_Load(object sender, EventArgs e)
        {

            booth();
            selectCompany();
            View.userDashboard obj = new userDashboard();
            obj.MdiParent = this;
            obj.Show();
        }
        public void booth()
        {

            try
            {

                label3.Text = hardware.GetProcessorId();
                con();
                MySqlCommand cmd = new MySqlCommand("SELECT * from booth_setup where pc_id='" + label3.Text + "'", connect);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    boothName = dr["booth_name"].ToString();
                    TopLevelControl.Text = txtSoftwareType.Text + "                Booth: " + boothName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
      
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.userDashboard obj = new userDashboard();
            obj.MdiParent = this;
            obj.Show();
        }

        private void saleToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (txtSoftwareType.Text == "Electronics")
            {
                View.Electronic.saleElectronic obj = new View.Electronic.saleElectronic();
                obj.Booth = boothName.ToString();
                obj.getUser = txtId.Text;
                obj.MdiParent = SuperShop.index.ActiveForm;
                obj.Show();

            }
            else if (txtSoftwareType.Text == "Garments")
            {
                View.ClothSHop.clothsalep obj = new View.ClothSHop.clothsalep();
                obj.MdiParent = SuperShop.index.ActiveForm;
                obj.Show();
            }
            else if (txtSoftwareType.Text == "inventory")
            {
                View.sale.Sale obj = new View.sale.Sale();
                obj.Booth = boothName.ToString();
                obj.getUser = txtId.Text;
                obj.MdiParent = SuperShop.index.ActiveForm;
                obj.Show();

            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            login.login obj = new login.login();
            obj.Show();
        }


  

    }
}
