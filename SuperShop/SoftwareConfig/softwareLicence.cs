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
using Projectlib;
namespace SuperShop.SoftwareConfig
{
    public partial class softwareLicence : Form
    {
        public softwareLicence()
        {
            InitializeComponent();
        }
        MySqlConnection conDatabase;
        DB.config connect = new DB.config();
        Projectlib.Class1 cls = new Class1();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conDatabase = connect.connection();
                conDatabase.Open();
                //cls.LastId
                if (textBox1.Text == "01N8-20K0-18R7-72SW")
                {
                   
                    int n = -1;
                    String serial = "";

                    ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                    ManagementObjectCollection moc = mos.Get();

                    foreach (ManagementObject mo in moc)
                    {
                        serial = mo["SerialNumber"].ToString();
                        label1.Text = serial.ToString();
                    }
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conDatabase;
                    cmd.CommandText = "INSERT INTO  project_security (hwId) VALUES(@hwId)";
                    cmd.Parameters.AddWithValue("@hwId", label1.Text);
                    n = cmd.ExecuteNonQuery();
                    if (n > 0)
                    {
                        MessageBox.Show("Registration Form Successsfully");
                        View.login.login lg = new View.login.login();
                        lg.Show();

                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show(cls.LastId);
                    MessageBox.Show("Sorry Not Match");

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void softwareLicence_Load(object sender, EventArgs e)
        {

        }
    }
}
